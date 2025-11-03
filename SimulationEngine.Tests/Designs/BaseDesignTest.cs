using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using System.Diagnostics;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs;

public abstract class BaseDesignTest(ITestOutputHelper testOutputHelper)
{
    protected void TestSimulatation(Subcircuit subcircuit, bool skipEvaluation = false)
    {
        var simulationSession = SimulationSession.Build(subcircuit);

        var testString = subcircuit.GetTestString();

        var tests = TestStringConverter.GetInputOutputPairs(testString);

        var lineNumber = 1;
        var stopWatch = Stopwatch.StartNew();

        foreach (var (inputs, expectedOutputs) in tests)
        {
            var allEqual = true;
            var outputs = simulationSession.Simulate(inputs);

            Assert.True(skipEvaluation || outputs.Length == expectedOutputs.Length);

            for (var i = 0; i < outputs.Length; i++)
            {
                var equal = outputs[i] == expectedOutputs[i];
                Assert.True(skipEvaluation || equal, GetEvaluationString(lineNumber, inputs, expectedOutputs, outputs, equal));

                if (skipEvaluation && !equal)
                    allEqual = false;
            }

            if (skipEvaluation)
                testOutputHelper.WriteLine(GetEvaluationString(lineNumber, inputs, expectedOutputs, outputs, allEqual));

            lineNumber++;
        }

        stopWatch.Stop();
        testOutputHelper.WriteLine($"Elapsed time: {stopWatch.Elapsed}");
    }

    protected void TestSimulatation(Subcircuit subcircuit, List<Subcircuit> subcircuits, string testString, bool skipEvaluation = false)
    {
        var simulationSession = SimulationSession.Build(subcircuit);

        var tests = TestStringConverter.GetInputOutputPairs(testString);

        var lineNumber = 1;
        var stopWatch = Stopwatch.StartNew();
        var outputString = string.Empty;
        foreach (var (inputs, expectedOutputs) in tests)
        {
            var allEqual = true;

            simulationSession.SetInputs(inputs);
            var outputs = string.Join(" ", subcircuits.Select(simulationSession.GetOutputs));
            outputString += outputs + Environment.NewLine;
            continue;
            Assert.True(skipEvaluation || outputs.Length == expectedOutputs.Length);

            for (var i = 0; i < outputs.Length; i++)
            {
                var equal = outputs[i] == expectedOutputs[i];
                Assert.True(skipEvaluation || equal, GetEvaluationString(lineNumber, inputs, expectedOutputs, outputs, equal));

                if (skipEvaluation && !equal)
                    allEqual = false;
            }

            if (skipEvaluation)
                testOutputHelper.WriteLine(GetEvaluationString(lineNumber, inputs, expectedOutputs, outputs, allEqual));

            lineNumber++;
        }

        stopWatch.Stop();
        testOutputHelper.WriteLine($"Elapsed time: {stopWatch.Elapsed}");
    }

    private static string GetEvaluationString(int lineNumber, string inputs, string expectedOutputs, string outputs, bool equal) =>
        $"{lineNumber}: {inputs} -> {expectedOutputs} {(equal ? "==" : "!=")} {outputs}";
}