using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Compilers.Models;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Placements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public partial class SubCircuitRepository
{
    private async Task<SubCircuit> BuildInstanceFromTemplateAsync(SubCircuit template, List<SubCircuitPlacement> subCircuitPlacements)
    {
        var parentSubCircuitClone = CloneShallow(template, out var portMapByRef, out var pinMapByRef);

        var parentPortIds = template.Ports.Select(port => port.Id).ToHashSet();
        var parentLogicGateIds = template.LogicGates.Select(logicGate => logicGate.Id).ToHashSet();

        var topPortMapById = portMapByRef.ToDictionary(kv => kv.Key.Id, kv => kv.Value);
        var topPinMapById = pinMapByRef.ToDictionary(kv => kv.Key.Id, kv => kv.Value);

        var childSubCircuitClonesByOrdinal = new Dictionary<int, (SubCircuit childSubCircuit, List<Port> inputs, List<Port> outputs)>();
        foreach (var subCircuitPlacement in subCircuitPlacements.OrderBy(subCircuitPlacement => subCircuitPlacement.Ordinal))
        {
            var (childTemplate, childSubCircuitPlacements) = await GetSubCircuitWithChildren(subCircuitPlacement.ChildSubCircuitId);
            var childSubCircuitClone = await BuildInstanceFromTemplateAsync(childTemplate, childSubCircuitPlacements);
            childSubCircuitClonesByOrdinal[subCircuitPlacement.Ordinal] = (childSubCircuitClone, childSubCircuitClone.Inputs, childSubCircuitClone.Outputs);
        }
        parentSubCircuitClone.SubCircuits = [.. childSubCircuitClonesByOrdinal.OrderBy(kv => kv.Key).Select(kv => kv.Value.childSubCircuit)];

        var portPlacementIndex = subCircuitPlacements
            .SelectMany(subCircuitPlacement => subCircuitPlacement.PortPlacements
                .Select(portPlacement => new { portPlacement.Id, subCircuitPlacement.Ordinal, portPlacement.IsInput, portPlacement.IndexWithinChild }))
            .ToDictionary(x => x.Id, x => (x.Ordinal, x.IsInput, x.IndexWithinChild));

        Port MapPortPlacement(PortPlacement portPlacement)
        {
            var (ordinal, isInput, index) = portPlacementIndex[portPlacement.Id];
            var (_, inputs, outputs) = childSubCircuitClonesByOrdinal[ordinal];
            return isInput ? inputs[index] : outputs[index];
        }

        var childPortIdToClone = new Dictionary<int, Port>();
        foreach (var subCircuitPlacement in subCircuitPlacements)
        {
            var childTemplate = subCircuitPlacement.ChildSubCircuit;
            if (childTemplate is null) 
                continue;

            var childInputsByOrdinal = childTemplate.Inputs.OrderBy(port => port.Ordinal).ToList();
            var childOutputsByOrdinal = childTemplate.Outputs.OrderBy(port => port.Ordinal).ToList();

            foreach (var portPlacement in subCircuitPlacement.PortPlacements)
            {
                var (childSubCircuit, inputs, outputs) = childSubCircuitClonesByOrdinal[subCircuitPlacement.Ordinal];

                var templateChildPort = portPlacement.IsInput
                    ? childInputsByOrdinal[portPlacement.IndexWithinChild]
                    : childOutputsByOrdinal[portPlacement.IndexWithinChild];

                var clonedChildPort = portPlacement.IsInput
                    ? inputs[portPlacement.IndexWithinChild]
                    : outputs[portPlacement.IndexWithinChild];

                childPortIdToClone[templateChildPort.Id] = clonedChildPort;
            }
        }

        Terminal Translate(Terminal terminal) => terminal switch
        {
            Port port when parentPortIds.Contains(port.Id) => topPortMapById[port.Id],
            Pin pin when parentLogicGateIds.Contains(pin.LogicGateId) => topPinMapById[pin.Id],
            PortPlacement portPlacement => MapPortPlacement(portPlacement),
            Port childPort when childPortIdToClone.TryGetValue(childPort.Id, out var mappedChildPort) => mappedChildPort,
            _ => throw new InvalidOperationException($"Failed to translate terminal {terminal.Title}"),
        };

        var newWires = new List<Wire>(template.Wires.Count);
        foreach (var wire in template.Wires)
        {
            newWires.Add(new Wire
            {
                SubCircuit = parentSubCircuitClone,
                StartTerminal = Translate(wire.StartTerminal),
                EndTerminal = Translate(wire.EndTerminal)
            });
        }
        parentSubCircuitClone.Wires = newWires;

        return parentSubCircuitClone;
    }

    private static SubCircuit CloneShallow(SubCircuit subCircuit, out Dictionary<Port, Port> portMap, out Dictionary<Pin, Pin> pinMap)
    {
        var parentSubCircuit = new SubCircuit
        {
            Title = subCircuit.Title,
            Ports = [],
            LogicGates = [],
            Wires = [],
            SubCircuits = []
        };

        var clonedPorts = subCircuit.OrderedPorts.Select(port => new Port(port)).ToList();
        foreach (var clonedPort in clonedPorts)
            clonedPort.SubCircuit = parentSubCircuit;
        parentSubCircuit.Ports = clonedPorts;

        var clonedLogicGates = subCircuit.LogicGates.Select(logicGate => new LogicGate(logicGate)).ToList();
        foreach (var clonedLogicGate in clonedLogicGates)
        {
            foreach (var clonedPin in clonedLogicGate.Pins)
                clonedPin.LogicGate = clonedLogicGate;
        }
        parentSubCircuit.LogicGates = clonedLogicGates;

        portMap = subCircuit.OrderedPorts
            .Zip(parentSubCircuit.OrderedPorts)
            .ToDictionary(zipped => zipped.First, zipped => zipped.Second);

        var logicGateMap = subCircuit.LogicGates
            .Zip(parentSubCircuit.LogicGates)
            .ToDictionary(zipped => zipped.First, zipped => zipped.Second);

        pinMap = subCircuit.LogicGates
            .SelectMany(logicGate => logicGate.Pins)
            .ToDictionary(
                pin => pin,
                pin => logicGateMap[pin.LogicGate].Pins.Single(innerPin => innerPin.Role == pin.Role)
            );

        return parentSubCircuit;
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
            .Include(subCircuitPlacement => subCircuitPlacement.ChildSubCircuit)
                .ThenInclude(childSubCircuit => childSubCircuit.LogicGates)
                    .ThenInclude(logicGate => logicGate.Pins)
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
                dbContext.PortPlacements.Add(new PortPlacement { SubCircuitPlacement = subCircuitPlacement, IsInput = true, IndexWithinChild = i, Title = childSubCircuit.Inputs[i].Title });

            for (int i = 0; i < childSubCircuit.Outputs.Count; i++)
                dbContext.PortPlacements.Add(new PortPlacement { SubCircuitPlacement = subCircuitPlacement, IsInput = false, IndexWithinChild = i, Title = childSubCircuit.Outputs[i].Title });

            await dbContext.SaveChangesAsync();

            subCircuitPlacements.Add(subCircuitPlacement);
        }

        var portPlacementIndex = subCircuitPlacements
            .SelectMany(subCircuitPlacement => subCircuitPlacement.PortPlacements
                .Select(portPlacement => (subCircuitPlacement.Ordinal, portPlacement.IsInput, portPlacement.IndexWithinChild, portPlacement)))
            .ToDictionary(tuple => (tuple.Ordinal, tuple.IsInput, tuple.IndexWithinChild), tuple => tuple.portPlacement);

        PortPlacement ResolvePortPlacement(PortPlacement portPlacement) =>
            portPlacementIndex[(portPlacement.SubCircuitPlacement.Ordinal, portPlacement.IsInput, portPlacement.IndexWithinChild)];

        Terminal MapTerminal(Terminal terminal) => terminal switch
        {
            Port port => portMap[port],
            Pin pin => logicGateMap[placed.SubCircuit.LogicGates
                .Single(logicGate => logicGate.Pins.Contains(pin))].Pins
                .Single(innerPin => innerPin.Role == pin.Role),
            PortPlacement portPlacement => ResolvePortPlacement(portPlacement),
            _ => throw new InvalidOperationException()
        };

        foreach (var wire in placed.SubCircuit.Wires)
        {
            var start = MapTerminal(wire.StartTerminal);
            var end = MapTerminal(wire.EndTerminal);

            dbContext.Wires.Add(new Wire
            {
                SubCircuit = newSubCircuit,
                StartTerminal = start,
                EndTerminal = end
            });
        }

        await dbContext.SaveChangesAsync();
        return newSubCircuit;
    }
}