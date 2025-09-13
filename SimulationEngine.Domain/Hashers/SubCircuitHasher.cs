using SimulationEngine.Domain.Codecs;
using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Hashers.Utils;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine.Domain.Hashers;

public static class SubCircuitHasher
{
    public static string ComputeAndAssignHash(SubCircuit subCircuit)
    {
        foreach (var subCircuitChild in subCircuit.SubCircuits ?? Enumerable.Empty<SubCircuit>())
            subCircuitChild.Hash = ComputeAndAssignHash(subCircuitChild);

        var logicGates = (subCircuit.LogicGates ?? [])
            .OrderBy(logicGate => logicGate, LogicGateOrderComparer.Instance)
            .ToList();

        var subCircuits = (subCircuit.SubCircuits ?? [])
            .OrderBy(subCircuit => subCircuit.Hash, StringComparer.Ordinal)
            .ThenBy(subCircuit => subCircuit.Title, StringComparer.Ordinal)
            .ToList();

        var wireEncodings = new List<(string From, string To)>();
        foreach (var wire in subCircuit.Wires ?? Enumerable.Empty<Wire>())
        {
            var encodingX = TerminalCodec.Encode(wire.StartTerminal, subCircuit, logicGates, subCircuits);
            var encodingY = TerminalCodec.Encode(wire.EndTerminal, subCircuit, logicGates, subCircuits);

            if (string.CompareOrdinal(encodingX, encodingY) <= 0) 
                wireEncodings.Add((encodingX, encodingY));
            else 
                wireEncodings.Add((encodingY, encodingX));
        }

        wireEncodings.Sort((wireX, wireY) =>
        {
            int cmp = string.CompareOrdinal(wireX.From, wireY.From);
            if (cmp != 0) 
                return cmp;
            return string.CompareOrdinal(wireX.To, wireY.To);
        });

        var portsOrdered = (subCircuit.Ports ?? [])
            .OrderBy(port => port, PortOrderComparer.Instance)
            .ToList();

        var inputs = portsOrdered
            .Where(port => port.Role.ToString().StartsWith(nameof(PortRole.In0)[..2]))
            .ToList();

        var outputs = portsOrdered
            .Where(port => port.Role.ToString().StartsWith(nameof(PortRole.Out0)[..3]))
            .ToList();

        var bytes = WriteAndGetBytes(inputs, outputs, subCircuits, logicGates, wireEncodings);
        return Sha256Hasher.Hash(bytes);
    }

    private static byte[] WriteAndGetBytes(List<Port> inputs, List<Port> outputs, List<SubCircuit> subCircuits, List<LogicGate> logicGates, List<(string From, string To)> wireEncodings)
    {
        return JsonWriter.Write(jsonWriter =>
        {
            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName(nameof(SubCircuit));

            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName(nameof(PortRole.In0)[..2]);
            jsonWriter.WriteStartArray();

            foreach (var port in inputs) 
                jsonWriter.WriteStringValue(port.Title ?? port.Role.ToString());

            jsonWriter.WriteEndArray();

            jsonWriter.WritePropertyName(nameof(PortRole.Out0)[..3]);
            jsonWriter.WriteStartArray();

            foreach (var port in outputs) 
                jsonWriter.WriteStringValue(port.Title ?? port.Role.ToString());

            jsonWriter.WriteEndArray();
            jsonWriter.WriteEndObject();

            jsonWriter.WritePropertyName($"{nameof(LogicGate)}s");
            jsonWriter.WriteStartArray();

            foreach (var logicGate in logicGates)
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteString(nameof(TruthTable), logicGate.TruthTable?.HeptaIndex ?? string.Empty);

                jsonWriter.WriteNumber("mask", logicGate.GetPinMask());

                jsonWriter.WriteEndObject();
            }
            jsonWriter.WriteEndArray();

            jsonWriter.WritePropertyName($"{nameof(SubCircuit)}s");
            jsonWriter.WriteStartArray();

            foreach (var subCircuit in subCircuits)
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteString(nameof(SubCircuit.Hash), subCircuit.Hash ?? string.Empty);
                jsonWriter.WriteEndObject();
            }
            jsonWriter.WriteEndArray();

            jsonWriter.WritePropertyName($"{nameof(Wire)}s");
            jsonWriter.WriteStartArray();

            foreach (var (from, to) in wireEncodings)
            {
                jsonWriter.WriteStartArray();
                jsonWriter.WriteStringValue(from);
                jsonWriter.WriteStringValue(to);
                jsonWriter.WriteEndArray();
            }

            jsonWriter.WriteEndArray();
            jsonWriter.WriteEndObject();
        });
    }
}