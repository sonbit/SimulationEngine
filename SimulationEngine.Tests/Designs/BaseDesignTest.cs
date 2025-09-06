using SimulationEngine.Application.Utils;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Core.Engine;
using System.Diagnostics;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs;

public abstract class BaseDesignTest(ITestOutputHelper output)
{
    protected void RunTest(SubCircuit subCircuit, string testString, bool skipEvaluation = false)
    {
        var simulationSession = SimulationSession.Build(subCircuit);
        var testVectors = TestStringConverter.Convert(testString);
        var lineNumber = 1;
        var stopWatch = Stopwatch.StartNew();

        foreach (var testVector in testVectors)
        {
            simulationSession.SetInputs(testVector.Inputs);
            var outputs = simulationSession.GetOutputs();

            Assert.True(
                testVector.ExpectedOutputs.Length == outputs.Length, 
                $"{lineNumber}: {testVector.ExpectedOutputs.Length} != {outputs.Length}");

            var allEqual = true;

            for (var i = 0; i < outputs.Length; i++)
            {
                var equal = testVector.ExpectedOutputs[i] == outputs[i];

                if (!equal)
                    allEqual = false;

                if (!skipEvaluation)
                    Assert.True(equal, GetEvaluationString(lineNumber, testVector, outputs, equal));
            }

             if (skipEvaluation)
                output.WriteLine(GetEvaluationString(lineNumber, testVector, outputs, allEqual));

            lineNumber++;
        }

        stopWatch.Stop();
        output.WriteLine($"Elapsed time: {stopWatch.Elapsed}");
    }

    private static string GetEvaluationString(int lineNumber, TestVector testVector, byte[] outputs, bool equal)
    {
        return 
            $"{lineNumber}: {TestStringConverter.Convert(testVector.Inputs)} -> " +
            $"{TestStringConverter.Convert(testVector.ExpectedOutputs)} {(equal ? "==" : "!=")} {TestStringConverter.Convert(outputs)}";
    }
}
