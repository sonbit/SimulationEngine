using SimulationEngine.Application.Services.Database.Subcircuits;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Settings;
using SimulationEngine.Cli.Simulation;
using SimulationEngine.Cli.Validators;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Simulation;

public sealed class SimulationRunCommand(IPrompter prompter, IRenderer renderer, ISubcircuitService service) : AsyncCommand<SimulationRunSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, SimulationRunSettings settings)
    {
        Subcircuit? subcircuit = null;

        if (settings.Id > 0)
            subcircuit = await service.GetByIdAsync(settings.Id ?? 0);
        else if (!string.IsNullOrWhiteSpace(settings.Title))
            subcircuit = await service.GetByTitleAsync(settings.Title);
        else if (settings.Interactive == true && await prompter.AskIdAsync("Enter Subcircuit id:") is int id)
            subcircuit = await service.GetByIdAsync(id);

        return await SimulateAsync(subcircuit, settings);
    }

    private void Simulate(Subcircuit subcircuit, SimulationSession simulationSession, string inputs, bool normalize, HashSet<char>[] allowedValuesPerInput)
    {
        if (InputValidator.Validate(subcircuit, inputs, normalize, allowedValuesPerInput) is string message)
        {
            renderer.DrawError(message);
            return;
        }

        renderer.DrawLine(simulationSession.Simulate(inputs, normalize));
    }

    private async Task<int> SimulateAsync(Subcircuit? subcircuit, SimulationRunSettings settings)
    {
        if (subcircuit is null)
        {
            renderer.DrawError($"Subcircuit{(settings.Id > 0 ? $" with id {settings.Id} " : "")}was not found.");
            return 1;
        }

        var iterationsAreApplicable = settings.Benchmark && (settings.File is not null || settings.UseTests);
        var iterationsToUse = iterationsAreApplicable ? settings.Iterations : 1;

        if (!iterationsAreApplicable && settings.Iterations > 1)
            renderer.DrawWarning("Iterations are only used when benchmarking files or predefined tests. Using a single run.");

        if (settings.UseTests)
        {
            return settings.Benchmark
                ? SimulationTest.Benchmark(subcircuit, renderer, iterationsToUse)
                : SimulationTest.Simulate(subcircuit, renderer);
        }

        if (settings.File is not null)
            return await SimulationFile.SimulateFileAsync(subcircuit, settings.File, renderer, settings.Normalize, settings.Benchmark, iterationsToUse);

        if (settings.InputString is not null)
        {
            if (settings.Benchmark)
                renderer.DrawWarning("Benchmark mode is intended for predefined tests or files. Running inputs without benchmarking.");

            return SimulateInputStrings(subcircuit, settings.InputString, settings.Normalize);
        }

        if (settings.InputVectors.Length > 0 && string.Join(' ',  settings.InputVectors) is string inputs)
        {
            if (settings.Benchmark)
                renderer.DrawWarning("Benchmark mode is intended for predefined tests or files. Running inputs without benchmarking.");

            return SimulateInputStrings(subcircuit, inputs, settings.Normalize);
        }

        if (settings.Stream || Console.IsInputRedirected)
            return await SimulateStreamAsync(subcircuit, settings.Normalize);

        return await SimulationRepl.SimulateReplAsync(subcircuit, renderer, settings.Normalize);
    }

    private int SimulateInputStrings(Subcircuit subcircuit, string inputStrings, bool normalize)
    {
        var allowedValuesPerInput = InputValidator.GetAllowedValuesPerInput(subcircuit);
        var inputStringsArray = inputStrings.Split([',', ' '], StringSplitOptions.RemoveEmptyEntries);

        if (inputStringsArray.Length == 0)
        {
            renderer.DrawWarning("No inputs provided to simulate.");
            return 1;
        }

        var simulationSession = SimulationSession.Build(subcircuit);

        foreach (var inputs in inputStringsArray)
            Simulate(subcircuit, simulationSession, inputs, normalize, allowedValuesPerInput);
        return 0;
    }

    private async Task<int> SimulateStreamAsync(Subcircuit subcircuit, bool normalize)
    {
        var allowedValuesPerInput = InputValidator.GetAllowedValuesPerInput(subcircuit);

        var simulationSession = SimulationSession.Build(subcircuit);

        string? inputs;
        while ((inputs = await Console.In.ReadLineAsync()) is not null)
        {
            if (string.Equals(inputs, "q", StringComparison.OrdinalIgnoreCase) || 
                string.Equals(inputs, "quit", StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrWhiteSpace(inputs))
                break;

            Simulate(subcircuit, simulationSession, inputs, normalize, allowedValuesPerInput);
        }

        return 0;
    }
}
