using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine.Domain.Converters;

public record TestResult(
    int LineNumber,
    string Inputs,
    string ExpectedOutputs,
    string Outputs,
    bool IsEqual
);

public static class TestStringConverter
{
    private static readonly char[] ColumnSeparators = [' ', ','];
    private static readonly char[] RowSeparators = ['\r', '\n'];

    public static TestResult GetResult(int lineNumber, string inputs, string outputs) =>
        new(lineNumber, inputs, null, outputs, false);

    public static TestResult GetResult(int lineNumber, string inputs, string expectedOutputs, string outputs, bool isEqual) =>
        new(lineNumber, inputs, expectedOutputs, outputs, isEqual);

    public static List<(string inputs, string expectedOutputs)> GetInputOutputPairs(string testString)
    {
        var tests = new List<(string inputs, string expectedOutputs)>();
        var rows = testString.Split(RowSeparators, StringSplitOptions.RemoveEmptyEntries);

        foreach (var row in rows)
        {
            var parts = row.Split(ColumnSeparators, StringSplitOptions.RemoveEmptyEntries);
            tests.Add((parts[0], parts[1]));
        }

        return tests;
    }

    public static List<string> GetInputs(string testString)
    {
        return [.. testString
            .Split(RowSeparators, StringSplitOptions.RemoveEmptyEntries)
            .Select(row => row.Split(ColumnSeparators, StringSplitOptions.RemoveEmptyEntries)[0])];
    }
}