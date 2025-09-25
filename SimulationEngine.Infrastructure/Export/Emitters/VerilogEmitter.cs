using SimulationEngine.Application.Export;
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Domain.Models.Placements;
using SimulationEngine.Infrastructure.Export.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulationEngine.Infrastructure.Exporters.Verilog;

public sealed partial class VerilogEmitter(ExportOptions options) : IVerilogEmitter
{
    public string EmitSubCircuit(SubCircuit subCircuit)
    {
        var sb = new StringBuilder(64 * 1024);
        var visitedGates = new HashSet<string>(StringComparer.Ordinal);
        var visitedCircuits = new HashSet<string>(StringComparer.Ordinal);

        foreach (var circuit in EnumerateAllSubCircuits(subCircuit))
            EmitSubCircuitModuleOnce(circuit, sb, visitedCircuits);

        foreach (var logicGate in EnumerateAllLogicGates(subCircuit))
            EmitLogicGateModuleOnce(logicGate, sb, visitedGates);

        EmitSubCircuitModuleOnce(subCircuit, sb, visitedCircuits);

        return sb.ToString().Trim();
    }

    private string EmitLogicGateModule(LogicGate logicGate)
    {
        var inputPins = logicGate.Pins
            .Where(p => p.Role != PinRole.Q)
            .OrderByDescending(p => p.Role)
            .Select(p => p.Role)
            .ToList();

        var def = logicGate.TruthTable?.Definition ?? [];
        int arity = def.Length switch
        {
            3 => 1,
            9 => 2,
            27 => 3,
            81 => 4,
            _ => throw new InvalidOperationException($"Unsupported TT length: {def.Length}")
        };

        var mod = LogicGateModuleName(logicGate);
        var ins = new List<string>();
        var portsSb = new StringBuilder();
        var body = new StringBuilder();

        foreach (var role in inputPins)
            ins.Add(logicGate.IsBinary() ? $"input wire {role}" : $"input wire[1:0] {role}");

        var outDecl = logicGate.IsBinary() ? "output wire Q" : "output wire[1:0] Q";

        portsSb.AppendLine($"module {mod} (");
        for (int i = 0; i < ins.Count; i++)
            portsSb.AppendLine($"\t{ins[i]},");
        portsSb.AppendLine($"\t{outDecl}");
        portsSb.AppendLine(");");

        var clauses = new List<string>(def.Length);
        int idx = 0;

        var pinOrder = inputPins;
        if (pinOrder.Count > 1)
        {
            pinOrder.RemoveRange(inputPins.Count - 2, 2);
            pinOrder.AddRange([PinRole.A, PinRole.B]);
        }

        void Recurse(int depth, byte[] assign)
        {
            if (depth == arity)
            {
                var q = def[idx++];

                var conds = new List<string>();
                for (int d = 0; d < arity; d++)
                {
                    var r = pinOrder[d];
                    var v = assign[d];
                    conds.Add($"({r} == {RadixConverter.Convert(logicGate, v)})");
                }
                clauses.Add($"{string.Join(" && ", conds)}{(arity > 1 ? ")" : "")} ? {RadixConverter.Convert(logicGate, q)} :");

                return;
            }

            for (byte v = 0; v < 3; v++)
            {
                assign[depth] = v;
                Recurse(depth + 1, assign);
            }
        }

        Recurse(0, new byte[arity]);

        body.AppendLine($"\tassign Q = ");
        foreach (var clause in clauses)
            body.AppendLine($"\t\t{(arity > 1 ? "(" : "")}{clause}");
        body.AppendLine($"\t\t{(logicGate.IsBinary() ? "1'b0" : "2'b01")};");

        body.AppendLine("endmodule");

        return portsSb.ToString() + body.ToString();
    }

    private string EmitSubCircuitModule(SubCircuit subCircuit)
    {
        var mod = CircuitModuleName(subCircuit);
        var sb = new StringBuilder();

        sb.AppendLine($"module {mod} (");

        for (int i = 0; i < subCircuit.Inputs.Count; i++)
        {
            var port = subCircuit.Inputs[i];
            var decl = port.IsBinary() ? $"input {San(port.Title)}" : $"input [1:0] {San(port.Title)}";
            sb.AppendLine($"\t{decl},");
        }

        for (int i = 0; i < subCircuit.Outputs.Count; i++)
        {
            var port = subCircuit.Outputs[i];
            var decl = port.IsBinary() ? $"output {San(port.Title)}" : $"output [1:0] {San(port.Title)}";
            sb.AppendLine(i == subCircuit.Outputs.Count - 1 ? $"\t{decl}" : $"\t{decl},");
        }

        sb.AppendLine(");");

        int tnet = 0, bnet = 0;
        var netOf = new Dictionary<Terminal, string>();

        string NewNet(bool binary) => binary ? $"bnet_{bnet++}" : $"tnet_{tnet++}";

        for (var index = 0; index < subCircuit.LogicGates.Count; index++)
        {
            var logicGate = subCircuit.LogicGates[index];
            var instName = San($"{options.LogicGatesPrefix}{logicGate.TruthTable.HeptaIndex}_{index}");
            var modName = LogicGateModuleName(logicGate);

            var conns = new List<string>();
            foreach (var role in new[] { PinRole.D, PinRole.C, PinRole.A, PinRole.B })
            {
                var pin = logicGate.Pins.FirstOrDefault(p => p.Role == role);
                if (pin is null) continue;

                var incoming = subCircuit.Wires.FirstOrDefault(w => w.EndTerminal == pin);
                if (incoming == null)
                {
                    var tied = logicGate.IsBinary() ? "1'b0" : "2'b01";
                    conns.Add($".{role}({tied})");
                }
                else
                {
                    var src = incoming.StartTerminal;
                    var expr = TerminalExpr(src, ref netOf, NewNet);
                    conns.Add($".{role}({expr})");
                }
            }

            var qPin = logicGate.Pins.FirstOrDefault(p => p.Role == PinRole.Q);
            var qNet = NewNet(logicGate.IsBinary());
            netOf[qPin] = qNet;
            conns.Add($".Q({qNet})");

            sb.AppendLine($"\t{modName} {instName} (");
            sb.AppendLine($"\t\t{string.Join($",\n\t\t", conns)}");
            sb.AppendLine($"\t);");
            sb.AppendLine();
        }

        for (int index = 0; index < subCircuit.SubCircuits.Count; index++)
        {
            var child = subCircuit.SubCircuits[index];
            var childMod = CircuitModuleName(child);
            var instName = San($"{childMod}_{index}");

            var childConns = new List<string>();

            foreach (var port in child.Inputs)
            {
                var w = subCircuit.Wires.FirstOrDefault(wr => wr.EndTerminal == port);
                var expr = w != null ? TerminalExpr(w.StartTerminal, ref netOf, NewNet) : (port.IsBinary() ? "1'b0" : "2'b01");
                childConns.Add($".{San(port.Title)}({expr})");
            }

            foreach (var port in child.Outputs)
            {
                var net = NewNet(port.IsBinary());
                netOf[port] = net;
                childConns.Add($".{San(port.Title)}({net})");
            }

            sb.AppendLine($"\t{childMod} {instName} (");
            sb.AppendLine($"\t\t{string.Join($",\n\t\t", childConns)}");
            sb.AppendLine($"\t);");
            sb.AppendLine();
        }

        foreach (var pout in subCircuit.Outputs)
        {
            var w = subCircuit.Wires.FirstOrDefault(wr => wr.EndTerminal == pout);
            if (w == null)
            {
                sb.AppendLine($"\t  assign {San(pout.Title)} = {(pout.IsBinary() ? "1'b0" : "2'b01")};");
                continue;
            }
            var expr = TerminalExpr(w.StartTerminal, ref netOf, NewNet);
            sb.AppendLine($"\tassign {San(pout.Title)} = {expr};");
        }

        sb.AppendLine("endmodule");
        return sb.ToString();

        string TerminalExpr(Terminal terminal, ref Dictionary<Terminal, string> map, Func<bool, string> newNet)
        {
            if (map.TryGetValue(terminal, out var existing)) return existing;

            switch (terminal)
            {
                case Port port:
                    return San(port.Title);

                case Pin pin:
                    //if (map.TryGetValue(pin, out var qn)) 
                    //    return qn;
                    //var qb = pin.IsBinary ? "1'b0" : "2'b01";
                    //var qnet = newNet(pin.IsBinary);
                    //map[pin] = qnet;
                    //sb.AppendLine($"{indent}// WARN: Unmapped gate pin; tying: {qnet} = {qb}");
                    //sb.AppendLine($"{indent}assign {qnet} = {qb};");
                    //return qnet;

                case PortPlacement portPlacement:
                    var tnet = newNet(false);
                    sb.AppendLine($"\t// WARN: PlacementPort leaked; tying: {tnet} = 2'b01");
                    sb.AppendLine($"\tassign {tnet} = 2'b01;");
                    return tnet;

                default:
                    var nn = newNet(false);
                    sb.AppendLine($"\t// WARN: Unknown terminal; tying {nn} = 2'b01");
                    sb.AppendLine($"\tassign {nn} = 2'b01;");
                    return nn;
            }
        }
    }
}
