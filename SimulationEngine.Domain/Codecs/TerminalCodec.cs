using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine.Domain.Codecs;

public static class TerminalCodec
{
    private const string ChildPort = $"Child{nameof(Port)}";
    private const string LogicGatePin = $"{nameof(LogicGate)}{nameof(Port)}";
    private const string Separator = "|";
    private const string TopPort = $"Top{nameof(Port)}";

    public static Terminal Decode(string code, List<Port> ports, List<LogicGate> logicGates, List<SubCircuit> subCircuits)
    {
        var parts = code.Split(Separator);
        switch (parts[0])
        {
            case TopPort:
                var topPortRole = Enum.Parse<PortRole>(parts[1]);
                return ports.Single(port => port.Role == topPortRole);
            case ChildPort:
                var subCircuitIndex = int.Parse(parts[1]);
                var childPortRole = Enum.Parse<PortRole>(parts[2]);
                return subCircuits[subCircuitIndex].Ports.Single(port => port.Role == childPortRole);
            case LogicGatePin:
                var logicGateIndex = int.Parse(parts[1]);
                var pinRole = Enum.Parse<PinRole>(parts[2]);
                return logicGates[logicGateIndex].Pins.Single(pin => pin.Role == pinRole);
            default:
                throw new InvalidOperationException($"Bad endpoint code: {code}");
        }
    }

    public static string Encode(Terminal terminal, SubCircuit subCircuit, List<LogicGate> logicGates, List<SubCircuit> subCircuits)
    {
        if (terminal is Port port)
        {
            if (ReferenceEquals(port.SubCircuit, subCircuit))
                return $"{TopPort}{Separator}{port.Role}";
            else
                return $"{ChildPort}{Separator}{subCircuits.IndexOf(port.SubCircuit)}{Separator}{port.Role}";
        }

        if (terminal is Pin pin)
            return $"{LogicGatePin}{Separator}{logicGates.IndexOf(pin.LogicGate)}{Separator}{pin.Role}";

        throw new NotSupportedException("Unknown terminal type.");
    }
}