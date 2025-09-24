using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Settings;
using SimulationEngine.Cli.Simulation;
using SimulationEngine.Cli.Validators;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Simulation;

public sealed class SimulationRunCommand(ISubCircuitService service, IRenderer renderer) : AsyncCommand<SimulationRunSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, SimulationRunSettings settings)
    {
        if (settings?.Id > 0)
        {
            var subCircuit = await service.GetByIdAsync(settings.Id ?? 0);
            return await SimulateAsync(subCircuit, settings);
        }
        else if (!string.IsNullOrWhiteSpace(settings?.Title))
        {
            var subCircuit = await service.GetByTitleAsync(settings.Title);
            return await SimulateAsync(subCircuit, settings);
        }

        renderer.DrawError("Provide --id or --title");
        return 1;
    }

    private void Simulate(SubCircuit subCircuit, SimulationSession simulationSession, string inputs, bool normalize, HashSet<char>[] allowedValuesPerInput)
    {
        if (InputValidator.Validate(subCircuit, inputs, normalize, allowedValuesPerInput) is string message)
        {
            renderer.DrawError(message);
            return;
        }

        renderer.DrawLine(simulationSession.Simulate(inputs, normalize));
    }

    private async Task<int> SimulateAsync(SubCircuit subCircuit, SimulationRunSettings settings)
    {
        if (subCircuit is null)
        {
            renderer.DrawError($"Subcircuit{(settings.Id > 0 ? $" with id {settings.Id} " : "")}was not found.");
            return 1;
        }

        if (settings.File is not null)
            return await SimulationFile.SimulateFileAsync(subCircuit, settings.File, renderer, settings.Normalize);

        if (settings.Inputs.Length >0 && string.Join(' ',  settings.Inputs) is string inputs)
            return SimulateInputStrings(subCircuit, inputs, settings.Normalize);

        if (settings.Stream || Console.IsInputRedirected)
            return await SimulateStreamAsync(subCircuit, settings.Normalize);

        return await SimulationRepl.SimulateReplAsync(subCircuit, renderer, settings.Normalize);
    }

    private int SimulateInputStrings(SubCircuit subCircuit, string inputStrings, bool normalize)
    {
        var allowedValuesPerInput = InputValidator.GetAllowedValuesPerInput(subCircuit);
        var inputStringsArray = inputStrings.Split([',', ' ']);

        var simulationSession = SimulationSession.Build(subCircuit);

        foreach (var inputs in inputStringsArray)
            Simulate(subCircuit, simulationSession, inputs, normalize, allowedValuesPerInput);

        return 0;
    }

    private async Task<int> SimulateStreamAsync(SubCircuit subCircuit, bool normalize)
    {
        var allowedValuesPerInput = InputValidator.GetAllowedValuesPerInput(subCircuit);

        var simulationSession = SimulationSession.Build(subCircuit);

        string? inputs;
        while ((inputs = await Console.In.ReadLineAsync()) is not null)
        {
            if (string.Equals(inputs, "q", StringComparison.OrdinalIgnoreCase) || 
                string.Equals(inputs, "quit", StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrWhiteSpace(inputs))
                break;

            Simulate(subCircuit, simulationSession, inputs, normalize, allowedValuesPerInput);
        }

        return 0;
    }
}