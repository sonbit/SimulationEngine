using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using System.Diagnostics;
using System.Linq;

namespace SimulationEngine.Cli.Simulation;

public static class SimulationTest
{
    public static int Simulate(Subcircuit subcircuit, IRenderer renderer)
    {
        var testString = ResolveTestString(subcircuit);
        if (string.IsNullOrWhiteSpace(testString))
        {
            renderer.DrawError($"No tests defined for subcircuit {subcircuit.Title}");
            return 1;
        }

        Simulate(subcircuit, testString, renderer);
        return 0;
    }

    private static void Simulate(Subcircuit subcircuit, string testString, IRenderer renderer)
    {
        renderer.Clear();

        var simulationSession = SimulationSession.Build(subcircuit);
        var allPassed = true;
        var lineNumber = 1;
        var evaluationStrings = new List<TestResult>();

        var stopWatch = Stopwatch.StartNew();

        foreach (var (inputs, expectedOutputs) in TestStringConverter.GetInputOutputPairs(testString))
        {
            var outputs = simulationSession.Simulate(inputs);
            if (outputs.CompareTo(expectedOutputs) != 0)
                allPassed = false;
            evaluationStrings.Add(TestStringConverter.GetResult(lineNumber, inputs, expectedOutputs, outputs, outputs.CompareTo(expectedOutputs) == 0));
            lineNumber++;
        }

        stopWatch.Stop();

        renderer.DrawTableFromPropertiesWithColumnNames(evaluationStrings
            .Select(evaluationString =>
            {
                return new
                {
                    No = evaluationString.LineNumber,
                    evaluationString.Inputs,
                    Expected = evaluationString.ExpectedOutputs,
                    evaluationString.Outputs,
                    Eq = evaluationString.IsEqual,
                };
            }),
            false,
            [
                "No",
                "Inputs",
                "Expected",
                "Outputs",
                "Eq"
            ]
        );

        if (allPassed)
            renderer.DrawLine($"[green]All tests passed for {subcircuit.Title}[/]");
        else
            renderer.DrawLine($"[red]Some tests failed for {subcircuit.Title}[/]");

        renderer.DrawLine($"Elapsed time: {stopWatch.Elapsed}");
    }

    public static int Benchmark(Subcircuit subcircuit, IRenderer renderer, int iterations)
    {
        var testString = ResolveTestString(subcircuit);
        if (string.IsNullOrWhiteSpace(testString))
        {
            renderer.DrawError($"No tests defined for subcircuit {subcircuit.Title}");
            return 1;
        }

        renderer.Clear();

        var inputPairs = TestStringConverter.GetInputOutputPairs(testString);
        var inputs = inputPairs.Select(pair => pair.inputs).ToList();

        var benchmarkResult = SimulationBenchmark.Run(subcircuit, inputs, normalize: false, iterations, renderer, captureOutputs: false);
        if (benchmarkResult is null)
            return 1;

        SimulationBenchmark.RenderSummary(renderer, benchmarkResult);
        return 0;
    }

    private static string? ResolveTestString(Subcircuit subcircuit)
    {
        var testString = subcircuit.GetTestString();
        if (!string.IsNullOrWhiteSpace(testString))
            return testString;

        return DesignUtils.GetTestString(subcircuit.Title);
    }
}
