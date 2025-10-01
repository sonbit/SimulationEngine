using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Application.Export.Emitters.Models;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.Export.Converters;
using System.Text;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public class VerilogTestbenchEmitter : IVerilogTestbenchEmitter
{
    private readonly StringBuilder Builder = new(64 * 1024);

    public VerilogModule EmitTestbench(SubCircuit subCircuit, string testString)
    {
        var moduleName = $"tb_{VerilogUtils.GetSubCircuitModuleName(subCircuit)}";

        Builder.Clear();

        Builder.AppendLine($"module {moduleName};");
        foreach (var input in subCircuit.Inputs)
            Builder.AppendLine($"\treg {VerilogUtils.GetPortWidthAndTitle(input)};");

        foreach (var output in subCircuit.Outputs)
            Builder.AppendLine($"\twire {VerilogUtils.GetPortWidthAndTitle(output)};");
        Builder.AppendLine();

        AddDut(subCircuit);
        AddTests(subCircuit, testString);

        Builder.Append("endmodule");

        return new VerilogModule
        {
            Name = moduleName,
            Content = Builder.ToString()
        };
    }

    private void AddDut(SubCircuit subCircuit)
    {
        Builder.AppendLine($"\t{VerilogUtils.GetSubCircuitModuleName(subCircuit)} dut (");

        foreach (var port in subCircuit.OrderedPorts)
            Builder.AppendLine($"\t\t.{port.Title}({port.Title}),");
        Builder.Remove(Builder.Length - 3, 1);

        Builder.AppendLine("\t);");
        Builder.AppendLine();
    }

    private void AddTests(SubCircuit subCircuit, string testString)
    {
        var testVectors = TestStringConverter.GetInputOutputPairs(testString);

        Builder.AppendLine("integer i;");
        Builder.AppendLine("\tinitial begin");
        Builder.AppendLine($"\t\t$display(\"Running {testVectors.Count} vectors...\");");

        for (int i = 0; i < testVectors.Count; i++)
        {
            Builder.AppendLine();

            var (inputs, expectedOutputs) = testVectors[i];

            for (int k = 0; k < subCircuit.Inputs.Count; k++)
            {
                var port = subCircuit.Inputs[k];
                Builder.AppendLine($"\t\t{port.Title} = {RadixConverter.Convert(port, inputs[k])};");
            }

            Builder.AppendLine("\t\t#1;");

            for (int k = 0; k < subCircuit.Outputs.Count; k++)
            {
                var port = subCircuit.Outputs[k];
                var title = port.Title;
                var expectedString = RadixConverter.Convert(port, expectedOutputs[k]);
                Builder.AppendLine($"\t\tif ({title} !== {expectedString}) begin $display(\"FAIL vec {i}: {title} (got %b at %0d)\", {title}, $time); $stop; end");
            }
        }

        Builder.AppendLine();
        Builder.AppendLine("\t\t$display(\"PASS\");");
        Builder.AppendLine("\t\t$finish;");
        Builder.AppendLine("\tend");
    }
}
