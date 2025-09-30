using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Infrastructure.Export.Converters;
using SimulationEngine.Infrastructure.Export.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulationEngine.Infrastructure.Exporters.Verilog;

public sealed partial class VerilogEmitter : IVerilogEmitter
{
    private const int Capacity = 64 * 1024;
    private int BNetCounter;
    private int TNetCounter;

    private readonly StringBuilder Builder = new(Capacity);
    private readonly Dictionary<string, int> ModuleIndexCounter = new(StringComparer.Ordinal);
    private readonly HashSet<string> NetDeclarations = [];
    private readonly Dictionary<Terminal, string> TerminalNetMap = [];

    public string EmitSubCircuit(SubCircuit topSubCircuit)
    {
        ClearState();

        var builder = new StringBuilder(Capacity);

        var subCircuits = EnumerateUniqueSubCircuits(topSubCircuit);

        var emittedSubCircuitModules = new HashSet<string>(StringComparer.Ordinal);
        foreach (var subCircuit in subCircuits)
        {
            if (emittedSubCircuitModules.Add(VerilogUtils.GetSubCircuitModuleName(subCircuit)))
                builder.AppendLine(EmitSubCircuitModule(subCircuit));
        }

        var emittedLogicGateModules = new HashSet<string>(StringComparer.Ordinal);
        var uniqueLogicGates = subCircuits
            .SelectMany(subCircuit => subCircuit.LogicGates)
            .DistinctBy(logicGate => logicGate.TruthTable.HeptaIndex);

        foreach (var logicGate in uniqueLogicGates)
        {
            if (emittedLogicGateModules.Add(VerilogUtils.GetLogicGateModuleName(logicGate)))
                builder.AppendLine(EmitLogicGateModule(logicGate));
        }

        return builder.ToString().TrimEnd();
    }

    private string EmitLogicGateModule(LogicGate logicGate)
    {
        ClearState();

        var inputRoles = logicGate.InputPinsDescending.Select(pin => pin.Role).ToList();
        var isBinary = logicGate.IsBinary();

        var inputs = new List<string>();
        foreach (var role in inputRoles)
            inputs.Add($"input wire {VerilogUtils.GetWidth(isBinary)}{role}");

        Builder.AppendLine($"module {VerilogUtils.GetLogicGateModuleName(logicGate)} (");
        for (int i = 0; i < inputs.Count; i++)
            Builder.AppendLine($"\t{inputs[i]},");
        Builder.AppendLine($"\toutput wire {VerilogUtils.GetWidth(isBinary)}{PinRole.Q}");
        Builder.AppendLine(");");

        var arity = HeptaIndexConverter.GetArity(logicGate.TruthTable.HeptaIndex);
        int[] pinOrder = arity > 1
            ? [.. Enumerable.Range(0, Math.Max(0, arity - 2)), ..new[] { arity - 1, arity - 2 }] 
            : [0];

        int index = 0;
        var outputConditions = new List<string>(logicGate.TruthTable.Definition.Length);

        void AddOutputConditions(int depth, byte[] definition)
        {
            if (depth == arity)
            {
                var outputValue = logicGate.TruthTable.Definition[index++];
                if (isBinary)
                    outputValue = (byte)(outputValue == 2 ? 1 : 0);

                if (isBinary && outputValue == 0 || !isBinary && outputValue == 1)
                    return;

                var conditions = new List<string>(arity);
                for (var i = 0; i < arity; i++)
                    conditions.Add($"({inputRoles[i]} == {RadixConverter.Convert(logicGate, definition[i])})");

                outputConditions.Add($"{string.Join(" & ", conditions)} ? {RadixConverter.Convert(logicGate, outputValue)} :");
                return;
            }

            for (byte value = 0; value < (isBinary ? 2 : 3); value++)
            {
                definition[pinOrder[depth]] = value;
                AddOutputConditions(depth + 1, definition);
            }
        }

        AddOutputConditions(0, new byte[arity]);

        Builder.AppendLine($"\tassign Q = ");
        foreach (var outputCondition in outputConditions)
            Builder.AppendLine($"\t\t{outputCondition}");
        Builder.AppendLine($"\t\t{(isBinary ? "1'b0" : "2'b11")};");

        Builder.AppendLine("endmodule");
        return Builder.ToString();
    }

    private string EmitSubCircuitModule(SubCircuit subCircuit)
    {
        ClearState();

        Builder.AppendLine($"module {VerilogUtils.GetSubCircuitModuleName(subCircuit)} (");

        for (int i = 0; i < subCircuit.Inputs.Count; i++)
            Builder.AppendLine($"\tinput {VerilogUtils.GetPortWidthAndTitle(subCircuit.Inputs[i])},");

        for (int i = 0; i < subCircuit.Outputs.Count; i++)
            Builder.AppendLine($"\toutput {VerilogUtils.GetPortWidthAndTitle(subCircuit.Outputs[i])},");

        Builder.Remove(Builder.Length - 3, 1);
        Builder.AppendLine(");");

        var moduleBodyBuilder = new StringBuilder();

        for (var index = 0; index < subCircuit.LogicGates.Count; index++)
        {
            var logicGate = subCircuit.LogicGates[index];
            var moduleName = VerilogUtils.GetLogicGateModuleName(logicGate);
            var connections = new List<string>();

            var pinQ = logicGate.Pins.FirstOrDefault(p => p.Role == PinRole.Q);
            var net = GetOrCreateTerminalNet(pinQ);

            foreach (var pin in logicGate.InputPinsDescending)
                CreateConnection(subCircuit.Wires, pin, moduleName, connections);

            connections.Add($".Q({net})");

            CreateBody(moduleName, moduleBodyBuilder, connections);
        }

        for (int i = 0; i < subCircuit.SubCircuits.Count; i++)
        {
            var childSubCircuit = subCircuit.SubCircuits[i];
            var moduleName = VerilogUtils.GetSubCircuitModuleName(childSubCircuit);
            var connections = new List<string>();

            foreach (var input in childSubCircuit.Inputs)
                CreateConnection(subCircuit.Wires, input, moduleName, connections);

            foreach (var output in childSubCircuit.Outputs)
            {
                var net = GetOrCreateTerminalNet(output);
                connections.Add($".{output.Title}({net})");
            }

            CreateBody(moduleName, moduleBodyBuilder, connections);
        }

        foreach (var net in NetDeclarations)
            Builder.AppendLine($"\t{net}");

        if (NetDeclarations.Count > 0)
            Builder.AppendLine();

        Builder.Append(moduleBodyBuilder);

        foreach (var output in subCircuit.Outputs)
        {
            var wire = subCircuit.Wires.FirstOrDefault(wire => wire.EndTerminal == output) ?? 
                throw new NullReferenceException($"Output port '{output.Title}' is not driven by any wire.");

            Builder.AppendLine($"\tassign {output.Title} = {GetOrCreateTerminalNet(wire.StartTerminal)};");
        }

        Builder.AppendLine("endmodule");
        return Builder.ToString();
    }
}