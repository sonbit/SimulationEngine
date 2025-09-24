using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Compilers.Models;
using SimulationEngine.Domain.Encoders;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Placements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public partial class SubCircuitRepository
{
    private async Task<SubCircuit> BuildInstanceFromTemplateAsync(SubCircuit template, List<SubCircuitPlacement> placements)
    {
        var subCircuit = CloneShallow(template, out var portMap, out var pinMap);

        var childSubCircuits = new List<SubCircuit>(placements.Count);
        var ordinalToChild = new Dictionary<int, (SubCircuit child, List<Port> ins, List<Port> outs)>();

        foreach (var subCircuitPlacement in placements.OrderBy(p => p.Ordinal))
        {
            var (childSubCircuitTemplate, childSubCircuitTemplatePlacements) = await GetSubCircuitWithChildren(subCircuitPlacement.ChildSubCircuitId);
            var childSubCircuit = await BuildInstanceFromTemplateAsync(childSubCircuitTemplate, childSubCircuitTemplatePlacements);
            childSubCircuits.Add(childSubCircuit);

            ordinalToChild[subCircuitPlacement.Ordinal] = (childSubCircuit, childSubCircuit.Inputs, childSubCircuit.Outputs);
        }

        subCircuit.SubCircuits = childSubCircuits;

        var ppIndex = placements
            .SelectMany(subCircuitPlacement => subCircuitPlacement.PortPlacements
                .Select(portPlacement => new { portPlacement.Id, subCircuitPlacement.Ordinal, portPlacement.IsInput, portPlacement.IndexWithinChild }))
            .ToDictionary(k => k.Id, k => (k.Ordinal, k.IsInput, k.IndexWithinChild));

        Port MapPlacementPort(PortPlacement pp)
        {
            var (ordinal, isInput, index) = ppIndex[pp.Id];
            var (child, inputs, outputs) = ordinalToChild[ordinal];
            return isInput ? inputs[index] : outputs[index];
        }

        Terminal Translate(Terminal t) => t switch
        {
            Port port => portMap[port],
            Pin pin => pinMap[pin],
            PortPlacement pp => MapPlacementPort(pp),
            _ => throw new InvalidOperationException()
        };

        var newWires = new List<Wire>(template.Wires.Count);
        foreach (var wire in template.Wires)
        {
            var startTerminal = Translate(wire.StartTerminal);
            var endTerminal = Translate(wire.EndTerminal);
            if (string.CompareOrdinal(TerminalEncoder.Encode(startTerminal), TerminalEncoder.Encode(endTerminal)) > 0) 
                (startTerminal, endTerminal) = (endTerminal, startTerminal);

            newWires.Add(new Wire { SubCircuit = subCircuit, StartTerminal = startTerminal, EndTerminal = endTerminal });
        }
        subCircuit.Wires = newWires;

        return subCircuit;
    }

    private static SubCircuit CloneShallow(SubCircuit subCircuit, out Dictionary<Port, Port> portMap, out Dictionary<Pin, Pin> pinMap)
    {
        var ports = subCircuit.OrderedPorts;

        var parent = new SubCircuit
        {
            Title = subCircuit.Title,
            Ports = [.. ports.Select(port => new Port(port))],
            LogicGates = [.. subCircuit.LogicGates.Select(logicGate => new LogicGate(logicGate))],
            Wires = [],
            SubCircuits = []
        };

        portMap = ports
            .Zip(parent.OrderedPorts)
            .ToDictionary(z => z.First, z => z.Second);

        var gateMap = subCircuit.LogicGates
            .Zip(parent.LogicGates)
            .ToDictionary(z => z.First, z => z.Second);

        pinMap = subCircuit.LogicGates
            .SelectMany(g => g.Pins)
            .ToDictionary(src => src, src => gateMap[src.LogicGate].Pins
            .Single(p => p.Role == src.Role));

        return parent;
    }

    private async Task<(SubCircuit subCircuit, List<SubCircuitPlacement> subCircuitPlacements)> GetSubCircuitWithChildren(int id)
    {
        var subCircuit = await GetSubCircuitQuery().SingleOrDefaultAsync(subCircuit => subCircuit.Id == id);

        if (subCircuit == null)
            return (null, null);

        var logicGateById = subCircuit.LogicGates.ToDictionary(logicGate => logicGate.Id);
        foreach (var pin in subCircuit.LogicGates.SelectMany(logicGate => logicGate.Pins))
        {
            if (pin.LogicGate is null && logicGateById.TryGetValue(pin.LogicGateId, out var logicGate))
                pin.LogicGate = logicGate;
        }

        foreach (var wire in subCircuit.Wires)
        {
            if (wire.StartTerminal is Pin startTerminalPin && startTerminalPin.LogicGate is null && logicGateById.TryGetValue(startTerminalPin.LogicGateId, out var startTerminalLogicGate))
                startTerminalPin.LogicGate = startTerminalLogicGate;
            if (wire.EndTerminal is Pin endTerminalPin && endTerminalPin.LogicGate is null && logicGateById.TryGetValue(endTerminalPin.LogicGateId, out var endTerminalLogicGate))
                endTerminalPin.LogicGate = endTerminalLogicGate;
        }

        var subCircuitPlacements = await dbContext.SubCircuitPlacements
            .AsNoTrackingWithIdentityResolution()
            .AsSplitQuery()
            .Where(subCircuitPlacement => subCircuitPlacement.ParentSubCircuitId == id)
            .Include(subCircuitPlacement => subCircuitPlacement.PortPlacements)
            .Include(subCircuitPlacement => subCircuitPlacement.ChildSubCircuit)
                .ThenInclude(subCircuit => subCircuit.Ports)
            .ToListAsync();

        return (subCircuit, subCircuitPlacements);
    }

    private async Task<SubCircuit> PersistPlacedAsync(SubCircuitPlaced placed)
    {
        if (await dbContext.SubCircuits.AsNoTracking().FirstOrDefaultAsync(s => s.Hash == placed.SubCircuit.Hash) is { } existing)
            return existing;

        var newSubCircuit = new SubCircuit
        {
            Title = placed.SubCircuit.Title,
            Hash = placed.SubCircuit.Hash,
            Ports = [.. placed.SubCircuit.OrderedPorts.Select(port => new Port(port))],
            LogicGates = [],
            Wires = []
        };
        dbContext.SubCircuits.Add(newSubCircuit);
        await dbContext.SaveChangesAsync();

        var logicGateMap = new Dictionary<LogicGate, LogicGate>();
        foreach (var logicGate in placed.SubCircuit.LogicGates.OrderBy(x => x, LogicGateOrderComparer.Instance))
        {
            var truthTable = await truthTableRepository.CreateOrGetAsync(logicGate.TruthTable);
            var newLogicGate = new LogicGate
            {
                SubCircuit = newSubCircuit,
                TruthTable = truthTable,
                Pins = [.. logicGate.Pins.Select(pin => new Pin { Role = pin.Role })]
            };
            dbContext.LogicGates.Add(newLogicGate);
            logicGateMap[logicGate] = newLogicGate;
        }
        await dbContext.SaveChangesAsync();

        var portMap = placed.SubCircuit.OrderedPorts
            .Zip(newSubCircuit.OrderedPorts)
            .ToDictionary(portPair => portPair.First, portPair => portPair.Second);

        var subCircuitPlacements = new List<SubCircuitPlacement>(placed.SubCircuitPlacementInfos.Count);
        foreach (var subCircuitPlacementInfo in placed.SubCircuitPlacementInfos.OrderBy(p => p.SubCircuitPlacement.Ordinal))
        {
            var childSubCircuit = await dbContext.SubCircuits
                .FirstAsync(subCircuit => subCircuit.Hash == subCircuitPlacementInfo.ChildSubCircuitHash);

            var subCircuitPlacement = new SubCircuitPlacement
            {
                ParentSubCircuit = newSubCircuit,
                ChildSubCircuit = childSubCircuit,
                Ordinal = subCircuitPlacementInfo.SubCircuitPlacement.Ordinal,
                Title = subCircuitPlacementInfo.SubCircuitPlacement.Title
            };
            dbContext.SubCircuitPlacements.Add(subCircuitPlacement);
            await dbContext.SaveChangesAsync();

            for (int i = 0; i < childSubCircuit.Inputs.Count; i++)
                dbContext.PortPlacements.Add(new PortPlacement { SubCircuitPlacement = subCircuitPlacement, IsInput = true, IndexWithinChild = i, Title = childSubCircuit.Inputs[i].Name });

            for (int i = 0; i < childSubCircuit.Outputs.Count; i++)
                dbContext.PortPlacements.Add(new PortPlacement { SubCircuitPlacement = subCircuitPlacement, IsInput = false, IndexWithinChild = i, Title = childSubCircuit.Outputs[i].Name });

            await dbContext.SaveChangesAsync();

            subCircuitPlacements.Add(subCircuitPlacement);
        }

        var ppIndex = subCircuitPlacements
            .SelectMany(subCircuitPlacement => subCircuitPlacement.PortPlacements
                .Select(portPlacement => (subCircuitPlacement.Ordinal, portPlacement.IsInput, portPlacement.IndexWithinChild, portPlacement)))
            .ToDictionary(k => (k.Ordinal, k.IsInput, k.IndexWithinChild));

        PortPlacement ResolvePlacementPort(PortPlacement src) =>
            ppIndex[(src.SubCircuitPlacement.Ordinal, src.IsInput, src.IndexWithinChild)].portPlacement;

        Terminal MapTerminal(Terminal terminal) => terminal switch
        {
            Port port => portMap[port],
            Pin pin => logicGateMap[placed.SubCircuit.LogicGates
                .Single(logicGate => logicGate.Pins.Contains(pin))].Pins
                .Single(mapPin => mapPin.Role == pin.Role),
            PortPlacement portPlacement => ResolvePlacementPort(portPlacement),
            _ => throw new InvalidOperationException()
        };

        foreach (var wire in placed.SubCircuit.Wires)
        {
            var startTerminal = MapTerminal(wire.StartTerminal);
            var endTerminal = MapTerminal(wire.EndTerminal);

            if (string.CompareOrdinal(TerminalEncoder.Encode(startTerminal), TerminalEncoder.Encode(endTerminal)) > 0) 
                (startTerminal, endTerminal) = (endTerminal, startTerminal);

            dbContext.Wires.Add(new Wire { SubCircuit = newSubCircuit, StartTerminal = startTerminal, EndTerminal = endTerminal });
        }
        await dbContext.SaveChangesAsync();

        return newSubCircuit;
    }
}