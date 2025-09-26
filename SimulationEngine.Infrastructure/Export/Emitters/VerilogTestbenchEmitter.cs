using SimulationEngine.Application.Export;
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Infrastructure.Export.Converters;
using System.Text;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public class VerilogTestbenchEmitter(ExportOptions options) : IVerilogTestbenchEmitter
{
    public string EmitTestbench(SubCircuit subCircuit, string testString)
    {
        var testVectors = TestStringConverter.GetInputOutputPairs(testString);

        var builder = new StringBuilder();
        builder.AppendLine($"module tb_{subCircuit.Title};");

        foreach (var inputPort in subCircuit.Inputs)
            builder.AppendLine($"\treg {(inputPort.IsBinary() ? "" : "[1:0] ")}{inputPort.Title};");

        foreach (var outputPort in subCircuit.Outputs)
            builder.AppendLine($"\twire {(outputPort.IsBinary() ? "" : "[1:0] ")}{outputPort.Title};");

        builder.AppendLine();

        builder.AppendLine($"\t{options.SubCircuitPrefix}{subCircuit.Title} dut (");

        foreach (var port in subCircuit.OrderedPorts)
            builder.AppendLine($"\t\t.{port.Title}({port.Title}),");
        builder.Remove(builder.Length - 3, 1);

        builder.AppendLine("\t);");
        builder.AppendLine();

        builder.AppendLine("integer i;");
        builder.AppendLine("\tinitial begin");
        builder.AppendLine($"\t\t$display(\"Running {testVectors.Count} vectors...\");");

        for (int i = 0; i < testVectors.Count; i++)
        {
            builder.AppendLine();

            var (inputs, expectedOutputs) = testVectors[i];

            for (int k = 0; k < subCircuit.Inputs.Count; k++)
            {
                var port = subCircuit.Inputs[k];
                builder.AppendLine($"\t\t{port.Title} = {RadixConverter.Convert(port, inputs[k])}");
            }

            builder.AppendLine("\t\t#1;");

            for (int k = 0; k < subCircuit.Outputs.Count; k++)
            {
                var port = subCircuit.Outputs[k];
                var title = port.Title;
                var expectedString = RadixConverter.Convert(port, expectedOutputs[k]);
                builder.AppendLine($"\t\tif ({title} !== {expectedString}) begin $display(\"FAIL vec {i}: {title} (got %b at %0d)\", {title}, $time); $stop; end");
            }
        }

        builder.AppendLine();
        builder.AppendLine("\t\t$display(\"PASS\");");
        builder.AppendLine("\t\t$finish;");
        builder.AppendLine("\tend");
        builder.AppendLine("endmodule");

        return builder.ToString();
    }
}
