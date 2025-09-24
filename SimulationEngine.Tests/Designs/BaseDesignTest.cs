using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using System.Diagnostics;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs;

public abstract class BaseDesignTest(ITestOutputHelper testOutputHelper)
{
    protected void TestSimulatation(SubCircuit subCircuit, bool skipEvaluation = false)
    {
        var simulationSession = SimulationSession.Build(subCircuit);

        var testString = subCircuit.GetTestString();

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
                Assert.True(skipEvaluation || equal, TestStringConverter.GetEvaluationString(lineNumber, inputs, expectedOutputs, outputs, equal));

                if (skipEvaluation && !equal)
                    allEqual = false;
            }

            if (skipEvaluation)
                testOutputHelper.WriteLine(TestStringConverter.GetEvaluationString(lineNumber, inputs, expectedOutputs, outputs, allEqual));

            lineNumber++;
        }

        stopWatch.Stop();
        testOutputHelper.WriteLine($"Elapsed time: {stopWatch.Elapsed}");
    }
}