using SimulationEngine.Application.Export;
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Infrastructure.Export.Converters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public class VerilogTestbenchEmitter(ExportOptions options) : IVerilogTestbenchEmitter
{
    public string EmitTestbench(SubCircuit subCircuit, IReadOnlyList<(byte[] Inputs, byte[] ExpectedOutputs)> testVectors)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"module tb_{subCircuit.GetType().Name};");

        foreach (var port in subCircuit.Inputs)
            sb.AppendLine(port.IsBinary() ? $"\treg {San(port.Title)};" : $"\treg [1:0] {San(port.Title)};");

        foreach (var port in subCircuit.Outputs)
            sb.AppendLine(port.IsBinary() ? $"\twire {San(port.Title)};" : $"\twire [1:0] {San(port.Title)};");

        sb.AppendLine();

        sb.AppendLine($"\t{options.SubCircuitPrefix}{subCircuit.GetType().Name} dut (");

        foreach (var port in subCircuit.OrderedPorts)
        {
            sb.Append($"\t\t.{San(port.Title)}({San(port.Title)})");
            if (port != subCircuit.OrderedPorts.Last())
                sb.AppendLine(",");
        }

        sb.AppendLine();
        sb.AppendLine("\t);");
        sb.AppendLine();

        sb.AppendLine("integer i;");
        sb.AppendLine("\tinitial begin");
        sb.AppendLine($"\t\t$display(\"Running {testVectors.Count} vectors...\");");

        for (int i = 0; i < testVectors.Count; i++)
        {
            sb.AppendLine();

            var (testInputs, testExpectedOutputs) = testVectors[i];

            for (int k = 0; k < subCircuit.Inputs.Count; k++)
            {
                var port = subCircuit.Inputs[k];
                var v = testInputs[k];

                if (port.IsBinary())
                    sb.AppendLine($"\t\t{San(port.Title)} = 1'b{(v == 0 ? 0 : 1)};");
                else
                    sb.AppendLine($"\t\t{San(port.Title)} = {TritBitConverter.ConvertTritToBits(v)};");
            }

            sb.AppendLine("\t\t#1;");

            for (int k = 0; k < subCircuit.Outputs.Count; k++)
            {
                var port = subCircuit.Outputs[k];
                var output = testExpectedOutputs[k];

                var title = $"{San(port.Title)}";
                var expectedString = port.IsBinary() ? $"1'b{(output == 0 ? "0" : "1")}" : TritBitConverter.ConvertTritToBits(output);
                sb.AppendLine($"\t\tif ({title} !== {expectedString}) begin $display(\"FAIL vec {i}: {title} (got %b at %0d)\", {title}, $time); $stop; end");
            }
        }

        sb.AppendLine();
        sb.AppendLine("\t\t$display(\"PASS\");");
        sb.AppendLine("\t\t$finish;");
        sb.AppendLine("\tend");
        sb.AppendLine("endmodule");
        return sb.ToString();

        static string San(string s) => Regex.Replace(s ?? "p", @"[^A-Za-z0-9_]", "_");
    }
}
