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

public partial class SubcircuitRepository
{
    private async Task<Subcircuit> BuildInstanceAsync(Subcircuit template, List<SubcircuitPlacement> placements)
    {
        var templateClone = CloneShallow(template, out var portMapByRef, out var pinMapByRef);

        var templatePortIds = template.Ports.Select(port => port.Id).ToHashSet();
        var templateLogicGateIds = template.LogicGates.Select(logicGate => logicGate.Id).ToHashSet();

        var topPortMapById = portMapByRef.ToDictionary(kv => kv.Key.Id, kv => kv.Value);
        var topPinMapById = pinMapByRef.ToDictionary(kv => kv.Key.Id, kv => kv.Value);

        var childInstancesByOrdinal = new Dictionary<int, (Subcircuit childSubcircuit, List<Port> inputs, List<Port> outputs)>();
        foreach (var placement in placements.OrderBy(subcircuitPlacement => subcircuitPlacement.Ordinal))
        {
            var (childTemplate, childPlacements) = await GetTemplateWithPlacementsAsync(placement.ChildTemplateId);
            var childInstance = await BuildInstanceAsync(childTemplate, childPlacements);
            childInstancesByOrdinal[placement.Ordinal] = (childInstance, childInstance.Inputs, childInstance.Outputs);
        }
        templateClone.Subcircuits = [.. childInstancesByOrdinal.OrderBy(kv => kv.Key).Select(kv => kv.Value.childSubcircuit)];

        var portPlacementIndex = placements
            .SelectMany(placement => placement.PortPlacements
                .Select(pp => new { pp.Id, placement.Ordinal, pp.IsInput, pp.IndexWithinChild }))
            .ToDictionary(pp => pp.Id, pp => (pp.Ordinal, pp.IsInput, pp.IndexWithinChild));

        Port MapPortPlacement(PortPlacement portPlacement)
        {
            var (ordinal, isInput, index) = portPlacementIndex[portPlacement.Id];
            var (_, inputs, outputs) = childInstancesByOrdinal[ordinal];
            return isInput ? inputs[index] : outputs[index];
        }

        var childPortMapById = new Dictionary<int, Port>();
        foreach (var placement in placements)
        {
            var childTemplate = placement.ChildTemplate;
            if (childTemplate is null)
                continue;

            var childInputsByOrdinal = childTemplate.Inputs.OrderBy(port => port.Ordinal).ToList();
            var childOutputsByOrdinal = childTemplate.Outputs.OrderBy(port => port.Ordinal).ToList();

            foreach (var portPlacement in placement.PortPlacements)
            {
                var (childInstance, inputs, outputs) = childInstancesByOrdinal[placement.Ordinal];

                var templateChildPort = portPlacement.IsInput
                    ? childInputsByOrdinal[portPlacement.IndexWithinChild]
                    : childOutputsByOrdinal[portPlacement.IndexWithinChild];

                var instanceChildPort = portPlacement.IsInput
                    ? inputs[portPlacement.IndexWithinChild]
                    : outputs[portPlacement.IndexWithinChild];

                childPortMapById[templateChildPort.Id] = instanceChildPort;
            }
        }

        Terminal Translate(Terminal terminal) => terminal switch
        {
            Port port when templatePortIds.Contains(port.Id) => topPortMapById[port.Id],
            Pin pin when templateLogicGateIds.Contains(pin.LogicGateId) => topPinMapById[pin.Id],
            PortPlacement portPlacement => MapPortPlacement(portPlacement),
            Port childPort when childPortMapById.TryGetValue(childPort.Id, out var mappedChildPort) => mappedChildPort,
            _ => throw new InvalidOperationException($"Failed to translate terminal {terminal.Title}"),
        };

        var wires = new List<Wire>(template.Wires.Count);
        foreach (var wire in template.Wires)
        {
            wires.Add(new Wire
            {
                Subcircuit = templateClone,
                StartTerminal = Translate(wire.StartTerminal),
                EndTerminal = Translate(wire.EndTerminal)
            });
        }
        templateClone.Wires = wires;

        return templateClone;
    }

    private static Subcircuit CloneShallow(Subcircuit subcircuit, out Dictionary<Port, Port> portMap, out Dictionary<Pin, Pin> pinMap)
    {
        var parentSubcircuit = new Subcircuit
        {
            Title = subcircuit.Title,
            Ports = [],
            LogicGates = [],
            Wires = [],
            Subcircuits = []
        };

        var clonedPorts = subcircuit.OrderedPorts.Select(port => new Port(port)).ToList();
        foreach (var clonedPort in clonedPorts)
            clonedPort.Subcircuit = parentSubcircuit;
        parentSubcircuit.Ports = clonedPorts;

        var clonedLogicGates = subcircuit.LogicGates.Select(logicGate => new LogicGate(logicGate)).ToList();
        foreach (var clonedLogicGate in clonedLogicGates)
        {
            foreach (var clonedPin in clonedLogicGate.Pins)
                clonedPin.LogicGate = clonedLogicGate;
        }
        parentSubcircuit.LogicGates = clonedLogicGates;

        portMap = subcircuit.OrderedPorts
            .Zip(parentSubcircuit.OrderedPorts)
            .ToDictionary(zipped => zipped.First, zipped => zipped.Second);

        var logicGateMap = subcircuit.LogicGates
            .Zip(parentSubcircuit.LogicGates)
            .ToDictionary(zipped => zipped.First, zipped => zipped.Second);

        pinMap = subcircuit.LogicGates
            .SelectMany(logicGate => logicGate.Pins)
            .ToDictionary(
                pin => pin,
                pin => logicGateMap[pin.LogicGate].Pins.Single(innerPin => innerPin.Role == pin.Role)
            );

        return parentSubcircuit;
    }

    private async Task<(Subcircuit template, List<SubcircuitPlacement> placements)> GetTemplateWithPlacementsAsync(int id)
    {
        var template = await GetSubcircuitQuery().SingleOrDefaultAsync(subcircuit => subcircuit.Id == id);

        if (template == null)
            return (null, null);

        var logicGateById = template.LogicGates.ToDictionary(logicGate => logicGate.Id);
        foreach (var pin in template.LogicGates.SelectMany(logicGate => logicGate.Pins))
        {
            if (pin.LogicGate is null && logicGateById.TryGetValue(pin.LogicGateId, out var logicGate))
                pin.LogicGate = logicGate;
        }

        foreach (var wire in template.Wires)
        {
            if (wire.StartTerminal is Pin startTerminalPin && startTerminalPin.LogicGate is null && logicGateById.TryGetValue(startTerminalPin.LogicGateId, out var startTerminalLogicGate))
                startTerminalPin.LogicGate = startTerminalLogicGate;
            if (wire.EndTerminal is Pin endTerminalPin && endTerminalPin.LogicGate is null && logicGateById.TryGetValue(endTerminalPin.LogicGateId, out var endTerminalLogicGate))
                endTerminalPin.LogicGate = endTerminalLogicGate;
        }

        var placements = await dbContext.SubcircuitPlacements
            .AsNoTrackingWithIdentityResolution()
            .AsSplitQuery()
            .Where(subcircuitPlacement => subcircuitPlacement.ParentTemplateId == id)
            .Include(subcircuitPlacement => subcircuitPlacement.PortPlacements)
            .Include(subcircuitPlacement => subcircuitPlacement.ChildTemplate)
                .ThenInclude(subcircuit => subcircuit.Ports)
            .Include(subcircuitPlacement => subcircuitPlacement.ChildTemplate)
                .ThenInclude(childSubcircuit => childSubcircuit.LogicGates)
                    .ThenInclude(logicGate => logicGate.Pins)
            .ToListAsync();

        return (template, placements);
    }

    private async Task<Subcircuit> PersistTemplateAsync(SubcircuitPlaced root)
    {
        if (await dbContext.Subcircuits.AsNoTracking().FirstOrDefaultAsync(sc => sc.Hash == root.Template.Hash) is { } existing)
            return existing;

        var template = new Subcircuit
        {
            Title = root.Template.Title,
            Hash = root.Template.Hash,
            Ports = [.. root.Template.OrderedPorts.Select(port => new Port(port))],
            LogicGates = [],
            Wires = []
        };
        dbContext.Subcircuits.Add(template);
        await dbContext.SaveChangesAsync();

        var logicGateMap = new Dictionary<LogicGate, LogicGate>();
        foreach (var logicGate in root.Template.LogicGates.OrderBy(x => x, LogicGateOrderComparer.Instance))
        {
            var truthTable = await truthTableRepository.CreateOrGetAsync(logicGate.TruthTable);
            var newLogicGate = new LogicGate
            {
                Subcircuit = template,
                TruthTable = truthTable,
                Pins = [.. logicGate.Pins.Select(pin => new Pin(pin))]
            };
            dbContext.LogicGates.Add(newLogicGate);
            logicGateMap[logicGate] = newLogicGate;
        }
        await dbContext.SaveChangesAsync();

        var portMap = root.Template.OrderedPorts
            .Zip(template.OrderedPorts)
            .ToDictionary(portPair => portPair.First, portPair => portPair.Second);

        var placements = new List<SubcircuitPlacement>(root.PlacementInfos.Count);
        foreach (var placementInfo in root.PlacementInfos.OrderBy(pi => pi.Placement.Ordinal))
        {
            var child = await dbContext.Subcircuits
                .FirstAsync(subcircuit => subcircuit.Hash == placementInfo.ChildTemplateHash);

            var placement = new SubcircuitPlacement
            {
                ParentTemplate = template,
                ChildTemplate = child,
                Ordinal = placementInfo.Placement.Ordinal,
                Title = placementInfo.Placement.Title
            };
            dbContext.SubcircuitPlacements.Add(placement);
            await dbContext.SaveChangesAsync();

            for (int i = 0; i < child.Inputs.Count; i++)
                dbContext.PortPlacements.Add(new PortPlacement(true, i, child.Inputs[i].Title, placement));

            for (int i = 0; i < child.Outputs.Count; i++)
                dbContext.PortPlacements.Add(new PortPlacement(false, i, child.Outputs[i].Title, placement));

            await dbContext.SaveChangesAsync();

            placements.Add(placement);
        }

        var portPlacementIndex = placements
            .SelectMany(placement => placement.PortPlacements
                .Select(portPlacement => (placement.Ordinal, portPlacement.IsInput, portPlacement.IndexWithinChild, portPlacement)))
            .ToDictionary(tuple => (tuple.Ordinal, tuple.IsInput, tuple.IndexWithinChild), tuple => tuple.portPlacement);

        Terminal MapTerminal(Terminal terminal) => terminal switch
        {
            Port port => portMap[port],
            Pin pin => logicGateMap[root.Template.LogicGates
                .Single(logicGate => logicGate.Pins.Contains(pin))].Pins
                .Single(innerPin => innerPin.Role == pin.Role),
            PortPlacement pp => portPlacementIndex[(pp.SubcircuitPlacement.Ordinal, pp.IsInput, pp.IndexWithinChild)],
            _ => throw new InvalidOperationException()
        };

        foreach (var wire in root.Template.Wires)
        {
            var start = MapTerminal(wire.StartTerminal);
            var end = MapTerminal(wire.EndTerminal);

            dbContext.Wires.Add(new Wire
            {
                Subcircuit = template,
                StartTerminal = start,
                EndTerminal = end
            });
        }

        await dbContext.SaveChangesAsync();
        return template;
    }
}
