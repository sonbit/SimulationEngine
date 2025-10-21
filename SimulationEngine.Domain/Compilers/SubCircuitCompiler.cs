using SimulationEngine.Domain.Compilers.Models;
using SimulationEngine.Domain.Hashers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Domain.Models.Placements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine.Domain.Compilers;

public static class SubcircuitCompiler
{
    public static SubcircuitClosure Compile(Subcircuit author)
    {
        var placedByAuthor = new Dictionary<Subcircuit, SubcircuitPlaced>(ReferenceEqualityComparer.Instance);
        var placedByHash = new Dictionary<string, SubcircuitPlaced>(StringComparer.Ordinal);

        return new SubcircuitClosure 
        { 
            Placed = CompileRecursive(placedByAuthor, author, placedByHash), 
            PlacedByHash = placedByHash 
        };
    }

    private static (Subcircuit subcircuit, List<SubcircuitPlacement> placements) BuildPlaced(Subcircuit author)
    {
        var parent = new Subcircuit
        {
            Title = author.Title,
            Ports = [.. author.Ports.Select(port => new Port(port))],
            LogicGates = [.. author.LogicGates.Select(logicGate => new LogicGate(logicGate))],
            Wires = []
        };

        foreach (var port in parent.Ports)
            port.Subcircuit = parent;

        foreach (var logicGate in parent.LogicGates)
        {
            foreach (var pin in logicGate.Pins)
                pin.LogicGate = logicGate;
        }

        var topPortMap = author.Ports
            .Zip(parent.Ports)
            .ToDictionary(portPair => portPair.First, portPair => portPair.Second);

        var logicGateMap = author.LogicGates
            .Zip(parent.LogicGates)
            .ToDictionary(portPair => portPair.First, portPair => portPair.Second);

        Pin MapPin(Pin old) => 
            logicGateMap[old.LogicGate].Pins.Single(p => p.Role == old.Role);

        var placements = new List<SubcircuitPlacement>(author.Subcircuits.Count);
        for (int index = 0; index < author.Subcircuits.Count; index++)
        {
            var child = author.Subcircuits[index];
            var parentPlacement = new SubcircuitPlacement
            {
                ParentTemplate = parent,
                ChildTemplate = child,
                Ordinal = index,
                Title = child.Title,
                PortPlacements = []
            };

            for (int i = 0; i < child.Inputs.Count; i++)
                parentPlacement.PortPlacements.Add(new PortPlacement(true, i, child.Inputs[i].Title, parentPlacement));

            for (int i = 0; i < child.Outputs.Count; i++)
                parentPlacement.PortPlacements.Add(new PortPlacement(false, i, child.Outputs[i].Title, parentPlacement));

            placements.Add(parentPlacement);
        }

        PortPlacement MapChildPort(Subcircuit child, Port port)
        {
            int childIndex = author.Subcircuits.IndexOf(child);
            var placement = placements[childIndex];

            var isInput = port.IsInput();
            var ports = isInput ? child.Inputs : child.Outputs;
            int childPortIndex = ports.IndexOf(port);

            return placement.PortPlacements.Single(portPlacement => 
                portPlacement.IsInput == isInput && 
                portPlacement.IndexWithinChild == childPortIndex);
        }

        foreach (var wire in author.Wires)
        {
            Terminal startTerminal = wire.StartTerminal switch
            {
                Port port when author.Ports.Contains(port) => topPortMap[port],
                Pin pin when author.LogicGates.Contains(pin.LogicGate) => MapPin(pin),
                Port port when author.Subcircuits.Contains(port.Subcircuit) => MapChildPort(port.Subcircuit, port),
                _ => throw new InvalidOperationException("Unsupported wire start")
            };
            Terminal endTerminal = wire.EndTerminal switch
            {
                Port port when author.Ports.Contains(port) => topPortMap[port],
                Pin pin when author.LogicGates.Contains(pin.LogicGate) => MapPin(pin),
                Port port when author.Subcircuits.Contains(port.Subcircuit) => MapChildPort(port.Subcircuit, port),
                _ => throw new InvalidOperationException("Unsupported wire end")
            };

            parent.Wires.Add(new Wire { Subcircuit = parent, StartTerminal = startTerminal, EndTerminal = endTerminal });
        }

        return (parent, placements);
    }

    private static SubcircuitPlaced CompileRecursive(
        Dictionary<Subcircuit, SubcircuitPlaced> placedByAuthor,
        Subcircuit author,
        Dictionary<string, SubcircuitPlaced> placedByHash)
    {
        if (placedByAuthor.TryGetValue(author, out var cachedPlaced)) 
            return cachedPlaced;

        var (subcircuit, placements) = BuildPlaced(author);

        var placementInfos = new List<SubcircuitPlacementInfo>(placements.Count);
        for (int i = 0; i < placements.Count; i++)
        {
            var child = author.Subcircuits[i];
            var childPlaced = CompileRecursive(placedByAuthor, child, placedByHash);
            var childHash = SubcircuitHasher.Compute(childPlaced.Template, 
                [.. childPlaced.PlacementInfos.Select(placementInfo => placementInfo.Placement)]);
            childPlaced.Template.Hash = childHash;

            placementInfos.Add(new SubcircuitPlacementInfo
            {
                Placement = placements[i],
                ChildTemplate = child,
                ChildTemplateHash = childHash
            });
        }

        var hash = SubcircuitHasher.Compute(subcircuit, 
            [.. placementInfos.Select(placementInfo => placementInfo.Placement)]);
        subcircuit.Hash = hash;

        var placed = new SubcircuitPlaced { Template = subcircuit, PlacementInfos = placementInfos };
        placedByAuthor[author] = placed;
        placedByHash[hash] = placed;

        return placed;
    }
}