using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Application.Export.Emitters.Models;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public partial class Basys3Emitter : IBasys3Emitter
{
    private readonly StringBuilder Builder = new(64 * 1024);

    public VerilogModule EmitTopModule(SubCircuit subCircuit, bool include7SegmentDisplay = false)
    {
        (var inputBits, var outputBits) = ValidateAndReturnBits(subCircuit);

        var topModuleName = $"{VerilogUtils.GetSubCircuitModuleName(subCircuit)}_top";

        Builder.Clear();

        Builder.AppendLine("`timescale 1ns/1ps");
        Builder.AppendLine();

        Builder.AppendLine($"module {topModuleName} (");
        if (include7SegmentDisplay)
            Builder.AppendLine("\tinput clk,");
        Builder.AppendLine($"\tinput [{inputBits - 1}:0] sw,");
        Builder.AppendLine($"\toutput [{outputBits - 1}:0] led,");

        if (include7SegmentDisplay)
        {
            Builder.AppendLine("\toutput [6:0] seg,");
            Builder.AppendLine("\toutput dp,");
            Builder.AppendLine("\toutput [3:0] an,");
        }

        Builder.Remove(Builder.Length - 3, 1);
        Builder.AppendLine(");");

        foreach (var output in subCircuit.Outputs)
            Builder.AppendLine($"\twire {VerilogUtils.GetPortWidthAndTitle(output)};");
        Builder.AppendLine();

        var moduleName = VerilogUtils.GetSubCircuitModuleName(subCircuit);
        Builder.AppendLine($"\t{moduleName} {moduleName} (");

        var connections = new List<string>();
        var switchIndex = 0;

        foreach (var inputPort in subCircuit.Inputs)
        {
            connections.Add($"\t\t.{inputPort.Title}(sw[{(inputPort.IsBinary() ? "" : $"{switchIndex + 1}:")}{switchIndex}])");
            switchIndex += inputPort.IsBinary() ? 1 : 2;
        }

        foreach (var outputPort in subCircuit.Outputs)
            connections.Add($"\t\t.{outputPort.Title}({outputPort.Title})");

        Builder.AppendLine(string.Join(",\n", connections));
        Builder.AppendLine("\t);");
        Builder.AppendLine();

        if (include7SegmentDisplay)
            Add7SegmentDisplayModule(subCircuit.Outputs);

        var ledIndex = 0;
        foreach (var output in subCircuit.Outputs)
        {
            Builder.AppendLine($"\tassign led[{(output.IsBinary() ? "" : $"{ledIndex + 1}:")}{ledIndex}] = {output.Title};");
            ledIndex += output.IsBinary() ? 1 : 2;
        }

        Builder.Append("endmodule");

        return new VerilogModule
        {
            Name = topModuleName,
            Content = Builder.ToString()
        };
    }

    private static (int inputBits, int outputBits) ValidateAndReturnBits(SubCircuit subCircuit)
    {
        var inputBits = subCircuit.Inputs.Sum(port => port.IsBinary() ? 1 : 2);
        var outputBits = subCircuit.Outputs.Sum(port => port.IsBinary() ? 1 : 2);

        var errors = new List<string>();

        if (inputBits > 16)
            errors.Add($"{inputBits} switch pins for its inputs");
        if (outputBits > 16)
            errors.Add($"{outputBits} LED pins for its outputs");

        if (errors.Count > 0)
            throw new InvalidOperationException($"{subCircuit.Title} requires {string.Join(" and ", errors)} (Basys 3 has 16{(errors.Count == 2 ? " of each" : "")})");

        return (inputBits, outputBits);
    }
}