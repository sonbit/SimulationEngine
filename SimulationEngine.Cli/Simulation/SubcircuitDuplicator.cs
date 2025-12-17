using SimulationEngine.Designs;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Extensions;
using System.Text;

namespace SimulationEngine.Cli.Simulation;

internal static class SubcircuitDuplicator
{
    public static Subcircuit Create(Subcircuit template, int copies, string? titleOverride = null)
    {
        ArgumentNullException.ThrowIfNull(template);
        if (copies < 1)
            throw new ArgumentOutOfRangeException(nameof(copies), "Copies must be at least 1.");

        var duplicatedTitle = titleOverride ?? $"{copies}x {template.Title}";
        var testString = TryBuildTestString(template, copies);
        var parent = new RuntimeSubcircuit(duplicatedTitle, testString);

        foreach (var input in template.Inputs)
            parent.AddPort(input.Title, PortDirection.Input, input.Metadata.Radix);

        for (var copyIndex = 0; copyIndex < copies; copyIndex++)
        {
            foreach (var output in template.Outputs)
                parent.AddPort($"{output.Title}_{copyIndex}", PortDirection.Output, output.Metadata.Radix);
        }

        var outputsPerChild = template.Outputs.Count;

        for (var copyIndex = 0; copyIndex < copies; copyIndex++)
        {
            var child = SubcircuitCloner.Clone(template);
            child.Title = $"{template.Title}_{copyIndex}";
            parent.Subcircuits.Add(child);

            for (var inputIndex = 0; inputIndex < template.Inputs.Count; inputIndex++)
                parent.AddWire(parent.Inputs[inputIndex], child.Inputs[inputIndex]);

            for (var outputIndex = 0; outputIndex < outputsPerChild; outputIndex++)
            {
                var parentOutput = parent.Outputs[copyIndex * outputsPerChild + outputIndex];
                parent.AddWire(child.Outputs[outputIndex], parentOutput);
            }
        }

        if (!string.IsNullOrWhiteSpace(testString))
            DesignUtils.RegisterTestString(parent.Title, testString);

        return parent;
    }

    private static string? TryBuildTestString(Subcircuit template, int copies)
    {
        var baseTestString = template.GetTestString();
        if (string.IsNullOrWhiteSpace(baseTestString))
            baseTestString = DesignUtils.GetTestString(template.Title);

        if (string.IsNullOrWhiteSpace(baseTestString))
            return null;

        var builder = new StringBuilder();
        foreach (var (inputs, expectedOutputs) in TestStringConverter.GetInputOutputPairs(baseTestString))
        {
            builder.Append(inputs);

            if (!string.IsNullOrWhiteSpace(expectedOutputs))
                builder.Append(' ').Append(string.Concat(Enumerable.Repeat(expectedOutputs, copies)));

            builder.AppendLine();
        }

        return builder.ToString();
    }

    private sealed class RuntimeSubcircuit : Subcircuit
    {
        private readonly string? _testString;

        public RuntimeSubcircuit(string title, string? testString)
        {
            Title = title;
            _testString = testString;
        }

        public override string GetTestString() => _testString ?? base.GetTestString();
    }
}
