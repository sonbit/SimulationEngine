using System;
using System.Collections.Generic;

namespace SimulationEngine.Domain.Converters;

public static class TestStringConverter
{
    public static string GetEvaluationString(int lineNumber, string inputs, string expectedOutputs, string outputs, bool equal) =>
        $"{lineNumber}: {inputs} -> {expectedOutputs} {(equal ? "==" : "!=")} {outputs}";

    public static List<(string inputs, string expectedOutputs)> GetInputOutputPairs(string testString)
    {
        var tests = new List<(string inputs, string expectedOutputs)>();
        var rows = testString.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

        foreach (var row in rows)
        {
            var parts = row.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);

            tests.Add((parts[0], parts[1]));
        }

        return tests;
    }
}