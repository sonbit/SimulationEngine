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
    public static async Task<int> SimulateFileAsync(SubCircuit subCircuit, IPrompter prompter, IRenderer renderer, bool normalize)
    {
        var directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        var file = await prompter.PickFileAsync("Pick a txt file with rows of inputs", directoryPath, "*.txt");
        if (file is null)
        {
            renderer.DrawError("No file selected");
            return 1;
        }

        var testString = await File.ReadAllTextAsync(file.FullName);
        Simulate(subCircuit, testString, renderer, normalize);

        return 0;
    }

    public static async Task<int> SimulateFileAsync(SubCircuit subCircuit, FileInfo file, IRenderer renderer, bool normalize)
    {
        var testString = await File.ReadAllTextAsync(file.FullName);
        Simulate(subCircuit, testString, renderer, normalize);
        return 0;
    }

    private static void Simulate(SubCircuit subCircuit, string testString, IRenderer renderer, bool normalize = false)
    {
        renderer.Clear();

        var simulationSession = SimulationSession.Build(subCircuit);
        var allowedValuesPerInput = InputValidator.GetAllowedValuesPerInput(subCircuit);

        var lineNumber = 1;
        var evaluationStrings = new List<TestResult>();

        var stopWatch = Stopwatch.StartNew();

        foreach (var inputs in TestStringConverter.GetInputs(testString))
        {
            if (InputValidator.Validate(subCircuit, inputs, normalize, allowedValuesPerInput) is string message)
            {
                renderer.DrawError(message);
                return;
            }

            var outputs = simulationSession.Simulate(inputs);
            evaluationStrings.Add(TestStringConverter.GetResult(lineNumber, inputs, outputs));
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
                    evaluationString.Outputs
                };
            }),
            false,
            [
                "No",
                "Inputs",
                "Outputs"
            ]
        );

        renderer.DrawLine($"Elapsed time: {stopWatch.Elapsed}");
    }
}