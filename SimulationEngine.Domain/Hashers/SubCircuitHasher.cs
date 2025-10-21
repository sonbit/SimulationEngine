using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Placements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SimulationEngine.Domain.Hashers;

public static class SubcircuitHasher
{
    private const string LogicGatePin = $"{nameof(LogicGate)}{nameof(Port)}";
    private const char Separator = '|';
    private const string TopPort = $"Top{nameof(Port)}";

    public static string Compute(Subcircuit subcircuit, IReadOnlyList<SubcircuitPlacement> subcircuitPlacements)
    {
        var sb = new StringBuilder();

        BuildString(sb, [nameof(Subcircuit.Title), subcircuit.Title], true);

        var ports = subcircuit.OrderedPorts;
        foreach (var port in ports)
            BuildString(sb, [nameof(Port), port.Title]);

        var logicGates = subcircuit.LogicGates.OrderBy(logicGate => logicGate, LogicGateOrderComparer.Instance).ToList();
        foreach (var logicGate in logicGates)
        {
            BuildString(sb, [nameof(LogicGate), logicGate.TruthTable.HeptaIndex]);

            var pins = logicGate.Pins.OrderBy(x => x.Role).ToList();
            foreach (var pin in pins)
                BuildString(sb, [$"{pin.Role}"], false, ',');

            sb.Append(Environment.NewLine);
        }

        var encodedWires = subcircuit.Wires
            .Select(wire => $"{Encode(wire.StartTerminal)}->{Encode(wire.EndTerminal)}")
            .OrderBy(encodedWire => encodedWire, StringComparer.Ordinal)
            .ToList();

        foreach (var wire in encodedWires)
            BuildString(sb, [nameof(Wire), wire], true);

        subcircuitPlacements = [.. subcircuitPlacements
            .OrderBy(x => x.ChildTemplate.Hash, StringComparer.Ordinal)
            .ThenBy(x => x.Ordinal)];

        foreach (var subcircuitPlacement in subcircuitPlacements)
            BuildString(sb, ["Placement", subcircuitPlacement.ChildTemplate.Hash, $"{subcircuitPlacement.Ordinal}"], true);

        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(sb.ToString()));
        return Convert.ToHexString(bytes);
    }

    private static void BuildString(StringBuilder sb, List<string> strings, bool newLineEnd = false, char separator = Separator)
    {
        for (var i = 0; i < strings.Count; i++)
            sb.Append(strings[i]).Append(newLineEnd && i == (strings.Count - 1) ? Environment.NewLine : separator);
    }

    private static string Encode(Terminal terminal) => terminal switch
    {
        Port port => $"{TopPort}{Separator}{port.Direction}{Separator}{port.Ordinal}",
        Pin pin => $"{LogicGatePin}{Separator}{pin.Role}",
        PortPlacement portPlacement => $"{nameof(PortPlacement)}{Separator}{portPlacement.IsInput}{Separator}{portPlacement.IndexWithinChild}",
        _ => throw new NotSupportedException("Unknwon terminal type")
    };
}