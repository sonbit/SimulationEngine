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

    public VerilogModule EmitTestbench(Subcircuit subcircuit, string testString)
    {
        var moduleName = $"{VerilogUtils.GetSubcircuitModuleName(subcircuit)}_tb";

        Builder.Clear();

        Builder.AppendLine($"module {moduleName};");
        foreach (var input in subcircuit.Inputs)
            Builder.AppendLine($"\treg {VerilogUtils.GetPortWidthAndIdentifier(input)};");

        foreach (var output in subcircuit.Outputs)
            Builder.AppendLine($"\twire {VerilogUtils.GetPortWidthAndIdentifier(output)};");
        Builder.AppendLine();

        AddDut(subcircuit);
        AddTests(subcircuit, testString);

        Builder.Append("endmodule");

        return new VerilogModule
        {
            Name = moduleName,
            Content = Builder.ToString()
        };
    }

    private void AddDut(Subcircuit subcircuit)
    {
        Builder.AppendLine($"\t{VerilogUtils.GetSubcircuitModuleName(subcircuit)} dut (");

        foreach (var port in subcircuit.OrderedPorts)
            Builder.AppendLine($"\t\t.{VerilogUtils.GetPortIdentifier(port)}({VerilogUtils.GetPortIdentifier(port)}),");
        Builder.Remove(Builder.Length - 3, 1);

        Builder.AppendLine("\t);");
        Builder.AppendLine();
    }

    private void AddTests(Subcircuit subcircuit, string testString)
    {
        var testVectors = TestStringConverter.GetInputOutputPairs(testString);

        Builder.AppendLine("integer i;");
        Builder.AppendLine("\tinitial begin");
        Builder.AppendLine($"\t\t$display(\"Running {testVectors.Count} vectors...\");");

        for (int i = 0; i < testVectors.Count; i++)
        {
            Builder.AppendLine();

            var (inputs, expectedOutputs) = testVectors[i];

            for (int k = 0; k < subcircuit.Inputs.Count; k++)
            {
                var port = subcircuit.Inputs[k];
                var identifier = VerilogUtils.GetPortIdentifier(port);
                Builder.AppendLine($"\t\t{identifier} = {RadixConverter.Convert(port, inputs[k])};");
            }

            Builder.AppendLine("\t\t#1;");

            for (int k = 0; k < subcircuit.Outputs.Count; k++)
            {
                var port = subcircuit.Outputs[k];
                var title = VerilogUtils.GetPortIdentifier(port);
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
