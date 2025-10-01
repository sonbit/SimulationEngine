using SimulationEngine.Domain.Compilers.Models;
using SimulationEngine.Domain.Hashers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Domain.Models.Placements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine.Domain.Compilers;

public static class SubCircuitCompiler
{
    public static SubCircuitClosure Compile(SubCircuit subCircuit)
    {
        var subCircuitPlacedBySubCircuit = new Dictionary<SubCircuit, SubCircuitPlaced>(ReferenceEqualityComparer.Instance);
        var subCircuitPlacedByHash = new Dictionary<string, SubCircuitPlaced>(StringComparer.Ordinal);

        return new SubCircuitClosure 
        { 
            SubCircuitPlaced = CompileRecursive(subCircuitPlacedBySubCircuit, subCircuit, subCircuitPlacedByHash), 
            MapByHash = subCircuitPlacedByHash 
        };
    }

    public static (SubCircuit subCircuit, List<SubCircuitPlacement> subCircuitPlacements) BuildPlaced(SubCircuit authorSubCircuit)
    {
        var subCircuit = new SubCircuit
        {
            Title = authorSubCircuit.Title,
            Ports = [.. authorSubCircuit.Ports.Select(port => new Port(port))],
            LogicGates = [.. authorSubCircuit.LogicGates.Select(logicGate => new LogicGate(logicGate))],
            Wires = []
        };

        foreach (var port in subCircuit.Ports)
            port.SubCircuit = subCircuit;

        foreach (var logicGate in subCircuit.LogicGates)
        {
            foreach (var pin in logicGate.Pins)
                pin.LogicGate = logicGate;
        }

        var topPortMap = authorSubCircuit.Ports
            .Zip(subCircuit.Ports)
            .ToDictionary(portPair => portPair.First, portPair => portPair.Second);

        var logicGateMap = authorSubCircuit.LogicGates
            .Zip(subCircuit.LogicGates)
            .ToDictionary(portPair => portPair.First, portPair => portPair.Second);

        Pin MapPin(Pin old) => 
            logicGateMap[old.LogicGate].Pins.Single(p => p.Role == old.Role);

        var subCircuitPlacements = new List<SubCircuitPlacement>(authorSubCircuit.SubCircuits.Count);
        for (int index = 0; index < authorSubCircuit.SubCircuits.Count; index++)
        {
            var childSubCircuit = authorSubCircuit.SubCircuits[index];
            var subCircuitPlacement = new SubCircuitPlacement
            {
                ParentSubCircuit = subCircuit,
                ChildSubCircuit = childSubCircuit,
                Ordinal = index,
                Title = childSubCircuit.Title,
                PortPlacements = []
            };

            for (int i = 0; i < childSubCircuit.Inputs.Count; i++) 
                subCircuitPlacement.PortPlacements.Add(new PortPlacement { SubCircuitPlacement = subCircuitPlacement, IsInput = true, IndexWithinChild = i, Title = childSubCircuit.Inputs[i].Title });

            for (int i = 0; i < childSubCircuit.Outputs.Count; i++)
                subCircuitPlacement.PortPlacements.Add(new PortPlacement { SubCircuitPlacement = subCircuitPlacement, IsInput = false, IndexWithinChild = i, Title = childSubCircuit.Outputs[i].Title });

            subCircuitPlacements.Add(subCircuitPlacement);
        }

        PortPlacement MapChildPort(SubCircuit childSubCircuit, Port childPort)
        {
            int childSubCircuitIndex = authorSubCircuit.SubCircuits.IndexOf(childSubCircuit);
            var subCircuitPlacement = subCircuitPlacements[childSubCircuitIndex];

            var isInput = childPort.IsInput();
            var ports = isInput ? childSubCircuit.Inputs : childSubCircuit.Outputs;

            int childPortIndex = ports.IndexOf(childPort);
                return subCircuitPlacement.PortPlacements.Single(pp => pp.IsInput == isInput && pp.IndexWithinChild == childPortIndex);
            }

        foreach (var wire in authorSubCircuit.Wires)
        {
            Terminal startTerminal = wire.StartTerminal switch
            {
                Port port when authorSubCircuit.Ports.Contains(port) => topPortMap[port],
                Pin pin when authorSubCircuit.LogicGates.Contains(pin.LogicGate) => MapPin(pin),
                Port port when authorSubCircuit.SubCircuits.Contains(port.SubCircuit) => MapChildPort(port.SubCircuit, port),
                _ => throw new InvalidOperationException("Unsupported wire start")
            };
            Terminal endTerminal = wire.EndTerminal switch
            {
                Port port when authorSubCircuit.Ports.Contains(port) => topPortMap[port],
                Pin pin when authorSubCircuit.LogicGates.Contains(pin.LogicGate) => MapPin(pin),
                Port port when authorSubCircuit.SubCircuits.Contains(port.SubCircuit) => MapChildPort(port.SubCircuit, port),
                _ => throw new InvalidOperationException("Unsupported wire end")
            };

            subCircuit.Wires.Add(new Wire { SubCircuit = subCircuit, StartTerminal = startTerminal, EndTerminal = endTerminal });
        }

        return (subCircuit, subCircuitPlacements);
    }

    private static SubCircuitPlaced CompileRecursive(
        Dictionary<SubCircuit, SubCircuitPlaced> subCircuitPlacedBySubCircuit,
        SubCircuit authorSubCircuit,
        Dictionary<string, SubCircuitPlaced> subCircuitPlacedByHash)
    {
        if (subCircuitPlacedBySubCircuit.TryGetValue(authorSubCircuit, out var cachedSubCircuitPlaced)) 
            return cachedSubCircuitPlaced;

        var (subCircuit, subCircuitPlacements) = BuildPlaced(authorSubCircuit);

        var subCircuitPlacementInfos = new List<SubCircuitPlacementInfo>(subCircuitPlacements.Count);
        for (int i = 0; i < subCircuitPlacements.Count; i++)
        {
            var childAuthorSubCircuit = authorSubCircuit.SubCircuits[i];
            var childSubCircuitPlaced = CompileRecursive(subCircuitPlacedBySubCircuit, childAuthorSubCircuit, subCircuitPlacedByHash);
            var childSubCircuitHash = SubCircuitHasher.Compute(childSubCircuitPlaced.SubCircuit, 
                [.. childSubCircuitPlaced.SubCircuitPlacementInfos.Select(subCircuitPlacementInfo => subCircuitPlacementInfo.SubCircuitPlacement)]);
            childSubCircuitPlaced.SubCircuit.Hash = childSubCircuitHash;

            subCircuitPlacementInfos.Add(new SubCircuitPlacementInfo
            {
                SubCircuitPlacement = subCircuitPlacements[i],
                ChildSubCircuit = childAuthorSubCircuit,
                ChildSubCircuitHash = childSubCircuitHash
            });
        }

        var hash = SubCircuitHasher.Compute(subCircuit, 
            [.. subCircuitPlacementInfos.Select(subCircuitPlacementInfo => subCircuitPlacementInfo.SubCircuitPlacement)]);
        subCircuit.Hash = hash;

        var subCircuitPlaced = new SubCircuitPlaced { SubCircuit = subCircuit, SubCircuitPlacementInfos = subCircuitPlacementInfos };
        subCircuitPlacedBySubCircuit[authorSubCircuit] = subCircuitPlaced;
        subCircuitPlacedByHash[hash] = subCircuitPlaced;

        return subCircuitPlaced;
    }
}