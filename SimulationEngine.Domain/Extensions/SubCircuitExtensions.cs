using SimulationEngine.Domain.Codecs;
using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using System;
using System.Linq;

namespace SimulationEngine.Domain.Extensions;

public static class SubCircuitExtensions
{
    public static LogicGate AddLogicGate(this SubCircuit subCircuit, string heptaIndex)
    {
        var logicGate = new LogicGate(heptaIndex) { SubCircuit = subCircuit };
        subCircuit.LogicGates.Add(logicGate);
        return logicGate;
    }

    public static void AddPort(this SubCircuit subCircuit, string title, PortRole role) =>
        subCircuit.Ports.Add(new Port { Title = title, Role = role, SubCircuit = subCircuit });

    public static void AddPorts(this SubCircuit subCircuit, params (string title, PortRole role)[] ports)
    {
        foreach (var (title, role) in ports)
            subCircuit.AddPort(title, role);
    }

    public static void AddWire(this SubCircuit subCircuit, Terminal startTerminal, Terminal endTerminal) =>
        subCircuit.Wires.Add(new Wire { StartTerminal = startTerminal, EndTerminal = endTerminal, SubCircuit = subCircuit });

    public static void AddWires(this SubCircuit subCircuit, params (Terminal startTerminal, Terminal endTerminal)[] wires)
    {
        foreach (var (startTerminal, endTerminal) in wires)
         
            subCircuit.AddWire(startTerminal, endTerminal);
    }

    public static void ReconnectWiresFromSource(this SubCircuit subCircuit, SubCircuit source)
    {
        ArgumentNullException.ThrowIfNull(source);

        var sourceLogicGates = (source.LogicGates ?? [])
            .OrderBy(logicGate => logicGate, LogicGateOrderComparer.Instance)
            .ToList();

        var sourceSubCircuits = (source.SubCircuits ?? [])
            .OrderBy(subCircuit => subCircuit.Hash, StringComparer.Ordinal)
            .ThenBy(subCircuit => subCircuit.Title, StringComparer.Ordinal)
            .ToList();

        var ports = (subCircuit.Ports ?? [])
            .OrderBy(port => port, PortOrderComparer.Instance)
            .ToList();

        var logicGates = (subCircuit.LogicGates ?? [])
            .OrderBy(logicGate => logicGate, LogicGateOrderComparer.Instance)
            .ToList();

        var subCircuits = (subCircuit.SubCircuits ?? [])
            .OrderBy(subCircuit => subCircuit.Hash, StringComparer.Ordinal)
            .ThenBy(subCircuit => subCircuit.Title, StringComparer.Ordinal)
            .ToList();

        subCircuit.Wires ??= [];
        subCircuit.Wires.Clear();

        foreach (var sourceWire in source.Wires ?? Enumerable.Empty<Wire>())
        {
            var encodedWireX = TerminalCodec.Encode(sourceWire.StartTerminal, source, sourceLogicGates, sourceSubCircuits);
            var encodedWireY = TerminalCodec.Encode(sourceWire.EndTerminal, source, sourceLogicGates, sourceSubCircuits);

            if (string.CompareOrdinal(encodedWireX, encodedWireY) > 0)
                (encodedWireX, encodedWireY) = (encodedWireY, encodedWireX);

            var decodedWireX = TerminalCodec.Decode(encodedWireX, ports, logicGates, subCircuits);
            var decodedWireY = TerminalCodec.Decode(encodedWireY, ports, logicGates, subCircuits);

            subCircuit.Wires.Add(new Wire
            {
                StartTerminal = decodedWireX,
                EndTerminal = decodedWireY,
                SubCircuit = subCircuit
            });
        }
    }
}
