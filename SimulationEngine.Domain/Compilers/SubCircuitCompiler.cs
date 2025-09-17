using SimulationEngine.Domain.Codecs;
using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Compilers.Models;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Hashers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine.Domain.Compilers;

public static class SubCircuitCompiler
{
    public static SubCircuitClosure Compile(SubCircuit subCircuit)
    {
        var byAuthor = new Dictionary<SubCircuit, SubCircuitPlaced>(ReferenceEqualityComparer.Instance);
        var byHash = new Dictionary<string, SubCircuitPlaced>(StringComparer.Ordinal);

        return new SubCircuitClosure 
        { 
            SubCircuitPlaced = CompileRecursive(byAuthor, subCircuit, byHash), 
            MapByHash = byHash 
        };
    }

    public static (SubCircuit subCircuit, List<SubCircuitPlacement> subCircuitPlacements) BuildPlaced(SubCircuit authorSubCircuit)
    {
        var subCircuit = new SubCircuit
        {
            Title = authorSubCircuit.Title,
            Ports = [.. authorSubCircuit.Ports.Select(port => new Port { Title = port.Title, Role = port.Role })],
            LogicGates = [.. authorSubCircuit.LogicGates.Select(logicGate => new LogicGate
            {
                TruthTable = logicGate.TruthTable,
                Pins = [.. logicGate.Pins.Select(pin => new Pin { Role = pin.Role })]
            })],
            Wires = []
        };

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

            var orderedPorts = childSubCircuit.Ports.OrderBy(port => port, PortOrderComparer.Instance).ToList();
            var inputCount = orderedPorts.Count(port => port.Role.IsInput());
            var outputCount = orderedPorts.Count - inputCount;

            for (int i = 0; i < inputCount; i++) 
                subCircuitPlacement.PortPlacements.Add(new PortPlacement { SubCircuitPlacement = subCircuitPlacement, IsInput = true, IndexWithinChild = i, Title = $"{nameof(PortRole.In0)[..2]}{i}" });

            for (int i = 0; i < outputCount; i++)
                subCircuitPlacement.PortPlacements.Add(new PortPlacement { SubCircuitPlacement = subCircuitPlacement, IsInput = false, IndexWithinChild = i, Title = $"{nameof(PortRole.Out0)[..3]}{i}" });

            subCircuitPlacements.Add(subCircuitPlacement);
        }

        PortPlacement MapChildPort(SubCircuit childSubCircuit, Port childPort)
        {
            int childSubCircuitIndex = authorSubCircuit.SubCircuits.IndexOf(childSubCircuit);
            var subCircuitPlacement = subCircuitPlacements[childSubCircuitIndex];

            var ordered = childSubCircuit.Ports.OrderBy(po => po, PortOrderComparer.Instance).ToList();
            var isInput = childPort.Role.IsInput();
            var list = isInput 
                ? ordered.Where(po => po.Role.IsInput()).ToList() 
                : [.. ordered.Where(po => !po.Role.IsInput())];

            int childPortIndex = list.IndexOf(childPort);
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

            if (string.CompareOrdinal(TerminalCodec.Encode(startTerminal), TerminalCodec.Encode(endTerminal)) > 0) 
                (startTerminal, endTerminal) = (endTerminal, startTerminal);

            subCircuit.Wires.Add(new Wire { SubCircuit = subCircuit, StartTerminal = startTerminal, EndTerminal = endTerminal });
        }

        return (subCircuit, subCircuitPlacements);
    }

    private static SubCircuitPlaced CompileRecursive(
        Dictionary<SubCircuit, SubCircuitPlaced> byAuthor,
        SubCircuit author,
        Dictionary<string, SubCircuitPlaced> byHash)
    {
        if (byAuthor.TryGetValue(author, out var cached)) return cached;

        var (def, placements) = BuildPlaced(author);

        var infos = new List<SubCircuitPlacementInfo>(placements.Count);
        for (int i = 0; i < placements.Count; i++)
        {
            var childAuthor = author.SubCircuits[i];
            var childPlaced = CompileRecursive(byAuthor, childAuthor, byHash);
            var childHash = SubCircuitHasher.Compute(childPlaced.SubCircuit, [.. childPlaced.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);
            childPlaced.SubCircuit.Hash = childHash;

            var pi = placements[i];
            infos.Add(new SubCircuitPlacementInfo
            {
                SubCircuitPlacement = pi,
                ChildSubCircuit = childAuthor,
                ChildSubCircuitHash = childHash
            });
        }

        var myHash = SubCircuitHasher.Compute(def, [.. infos.Select(p => p.SubCircuitPlacement)]);
        def.Hash = myHash;

        var placed = new SubCircuitPlaced { SubCircuit = def, SubCircuitPlacementInfos = infos };
        byAuthor[author] = placed;
        byHash[myHash] = placed;
        return placed;
    }
}