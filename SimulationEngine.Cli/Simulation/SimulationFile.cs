using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Validators;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using System.Diagnostics;

namespace SimulationEngine.Cli.Simulation;

public static class SimulationFile
{
    public static async Task<int> SimulateFileAsync(Subcircuit subcircuit, IPrompter prompter, IRenderer renderer, bool normalize)
    {
        var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        var file = await prompter.PickFileAsync("Pick a txt file with rows of inputs", directoryPath, "*.txt");
        if (file is null)
        {
            renderer.DrawError("No file selected");
            return 1;
        }

        var (testResults, elapsed) = await SimulateFileAsync(subcircuit, file, renderer, normalize);
        if (testResults is null || elapsed is null)
            return 1;

        renderer.DrawTableFromPropertiesWithColumnNames(testResults
            .Select(evaluationString => new
            {
                No = evaluationString.LineNumber,
                evaluationString.Inputs,
                evaluationString.Outputs
            }),
            false,
            [
                "No",
                "Inputs",
                "Outputs"
            ]
        );

        renderer.DrawLine($"[green]Elapsed time: {elapsed}[/]");

        return 0;
    }

    public static async Task<int> SimulateFileAsync(Subcircuit subcircuit, FileInfo file, IRenderer renderer, bool normalize, bool benchmark)
    {
        var (testResults, elapsed) = await SimulateFileAsync(subcircuit, file, renderer, normalize);
        if (testResults is null || elapsed is null)
            return 1;

        foreach (var testResult in testResults)
            renderer.DrawLine(testResult.Outputs);

        if (benchmark)
            renderer.DrawLine($"[green]Elapsed time: {elapsed}[/]");

        return 0;
    }

    private async static Task<(List<TestResult>? testResults, TimeSpan? elapsed)> SimulateFileAsync(Subcircuit subcircuit, FileInfo file, IRenderer renderer, bool normalize)
    {
        renderer.Clear();

        var simulationSession = SimulationSession.Build(subcircuit);
        var allowedValuesPerInput = InputValidator.GetAllowedValuesPerInput(subcircuit);
        var testString = await File.ReadAllTextAsync(file.FullName);

        var lineNumber = 1;
        var testResults = new List<TestResult>();

        var stopWatch = Stopwatch.StartNew();

        foreach (var inputs in TestStringConverter.GetInputs(testString))
        {
            if (InputValidator.Validate(subcircuit, inputs, normalize, allowedValuesPerInput) is string message)
            {
                renderer.DrawError(message);
                return (null, null);
            }

            var outputs = simulationSession.Simulate(inputs);
            testResults.Add(TestStringConverter.GetResult(lineNumber, inputs, outputs));
            lineNumber++;
        }

        stopWatch.Stop();

        return (testResults, stopWatch.Elapsed);
    }
}