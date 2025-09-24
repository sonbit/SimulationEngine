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

        var testString = subCircuit.GetTests();
        var testRows = testString.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries).ToList();

        var lineNumber = 1;
        var stopWatch = Stopwatch.StartNew();

        foreach (var test in testRows)
        {
            var testParts = test.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var inputTest = testParts[0];
            simulationSession.SetInputsWithRadix(inputTest);

            var outputs = simulationSession.GetOutputsWithRadix();
            var outputTest = testParts[1];

            Assert.True(skipEvaluation || outputs.Length == outputTest.Length);

            var allEqual = true;

            for (var i = 0; i < outputs.Length; i++)
            {
                var equal = outputs[i] == outputTest[i];
                Assert.True(skipEvaluation || equal, GetEvaluationString2(lineNumber, inputTest, outputTest, outputs, equal));

                if (skipEvaluation && !equal)
                    allEqual = false;
            }

            if (skipEvaluation)
                testOutputHelper.WriteLine(GetEvaluationString2(lineNumber, inputTest, outputTest, outputs, allEqual));

            lineNumber++;
        }

        stopWatch.Stop();
        testOutputHelper.WriteLine($"Elapsed time: {stopWatch.Elapsed}");
    }

    private static string GetEvaluationString2(int lineNumber, string testInputString, string testOutputString, string outputString, bool equal) => 
        $"{lineNumber}: {testInputString} -> {testOutputString} {(equal ? "==" : "!=")} {outputString}";
}