using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Validators;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using System.Diagnostics;

namespace SimulationEngine.Cli.Simulation;

public static class SimulationBenchmark
{
    public const int BenchmarkRowLimit = 100;

    public record BenchmarkIteration(int Iteration, int Rows, TimeSpan Elapsed)
    {
        public double Frequency => Elapsed.TotalSeconds <= 0 ? 0 : Math.Round(Rows / Elapsed.TotalSeconds, 2);
    }

    public record BenchmarkResult(
        IReadOnlyList<TestResult> TestResults,
        IReadOnlyList<BenchmarkIteration> Iterations,
        TimeSpan Average,
        int RowsUsed,
        int TotalRows,
        bool HasMinimumRows);

    public static BenchmarkResult? Run(
        Subcircuit subcircuit,
        IReadOnlyList<string> inputs,
        bool normalize,
        int iterations,
        IRenderer renderer,
        HashSet<char>[]? allowedValuesPerInput = null,
        bool captureOutputs = true)
    {
        if (iterations < 1)
            throw new ArgumentOutOfRangeException(nameof(iterations), "Iterations must be at least 1.");

        renderer.Clear();
        allowedValuesPerInput ??= InputValidator.GetAllowedValuesPerInput(subcircuit);

        var totalRows = inputs.Count;
        var limitedInputs = inputs.Take(BenchmarkRowLimit).ToList();
        var rowsUsed = limitedInputs.Count;

        if (rowsUsed == 0)
        {
            renderer.DrawWarning("No inputs available for benchmarking.");
            return null;
        }

        renderer.DrawLine($"[grey]Benchmarking {rowsUsed} row(s) across {iterations} iteration(s)...[/]");

        var testResults = captureOutputs ? new List<TestResult>(rowsUsed) : new List<TestResult>();
        var iterationResults = new List<BenchmarkIteration>(iterations);

        for (var iteration = 0; iteration < iterations; iteration++)
        {
            var simulationSession = SimulationSession.Build(subcircuit);
            var stopwatch = Stopwatch.StartNew();

            for (var index = 0; index < rowsUsed; index++)
            {
                var currentInput = limitedInputs[index];
                if (InputValidator.Validate(subcircuit, currentInput, normalize, allowedValuesPerInput) is string message)
                {
                    renderer.DrawError(message);
                    return null;
                }

                var outputs = simulationSession.Simulate(currentInput, normalize);

                if (captureOutputs && iteration == 0)
                    testResults.Add(TestStringConverter.GetResult(index + 1, currentInput, outputs));
            }

            stopwatch.Stop();
            iterationResults.Add(new BenchmarkIteration(iteration + 1, rowsUsed, stopwatch.Elapsed));

            var iterationFrequency = stopwatch.Elapsed.TotalSeconds <= 0
                ? 0
                : Math.Round(rowsUsed / stopwatch.Elapsed.TotalSeconds, 2);
            renderer.DrawLine($"[grey]Iteration {iteration + 1}/{iterations}: {stopwatch.Elapsed} ({iterationFrequency} rows/s)[/]");
        }

        var average = iterationResults.Count == 0
            ? TimeSpan.Zero
            : TimeSpan.FromTicks((long)iterationResults.Average(result => result.Elapsed.Ticks));

        return new BenchmarkResult(
            testResults,
            iterationResults,
            average,
            rowsUsed,
            totalRows,
            totalRows >= BenchmarkRowLimit);
    }

    public static void RenderSummary(IRenderer renderer, BenchmarkResult result)
    {
        renderer.DrawTableFromPropertiesWithColumnNames(
            result.Iterations.Select(iteration => new
            {
                iteration.Iteration,
                iteration.Rows,
                iteration.Elapsed,
                iteration.Frequency
            }),
            true,
            "Iteration",
            "Rows",
            "Elapsed",
            "Frequency");

        var averageFrequency = result.Average.TotalSeconds <= 0
            ? 0
            : Math.Round(result.RowsUsed / result.Average.TotalSeconds, 2);

        renderer.DrawTableFromPropertiesWithColumnNames(
            [
                new
                {
                    Label = "Average",
                    Iterations = result.Iterations.Count,
                    Elapsed = result.Average,
                    Frequency = averageFrequency
                }
            ],
            true,
            "Label",
            "Iterations",
            "Elapsed",
            "Frequency");

        if (!result.HasMinimumRows)
            renderer.DrawWarning($"Test string has only {result.TotalRows} row(s); benchmark uses available rows.");
        else if (result.TotalRows > result.RowsUsed)
            renderer.DrawWarning($"Benchmark limited to the first {result.RowsUsed} row(s) of {result.TotalRows}.");
    }
}
