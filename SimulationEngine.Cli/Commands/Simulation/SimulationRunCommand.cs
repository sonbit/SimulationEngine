using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Interactive;
using SimulationEngine.Cli.IO;
using SimulationEngine.Cli.Settings;
using SimulationEngine.Cli.UI;
using SimulationEngine.Cli.Validators;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Simulation;

public sealed class SimulationRunCommand(ISubCircuitService service, IRenderer renderer) : AsyncCommand<SimulationRunSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, SimulationRunSettings settings)
    {
        if (settings.Id == null || settings.Id == 0)
        {
            renderer.DrawError($"Missing or invalid id");
            return 1;
        }

        var subCircuit = await service.GetAsync(settings.Id ?? 0);
        if (subCircuit is null) 
        { 
            renderer.DrawError($"Subcircuit with id {settings.Id} was not found."); 
            return 1; 
        }

        if (settings.File is not null)
            return SimulationFile.Simulate(subCircuit, settings.File, renderer, settings.Normalize);

        if (settings.InputStrings is not null)
            return SimulateInputStrings(subCircuit, settings.InputStrings, settings.Normalize);

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
        {
            var validationErrorMessage = InputValidator.Validate(subCircuit, inputs, normalize, allowedValuesPerInput);
            if (validationErrorMessage is not null)
            {
                renderer.DrawError(validationErrorMessage);
                return -1;
            }

            AnsiConsole.WriteLine(simulationSession.Simulate(inputs, normalize));
        }

        return 0;
    }

    private async Task<int> SimulateStreamAsync(SubCircuit subCircuit, bool normalize)
    {
        var allowedValuesPerInput = InputValidator.GetAllowedValuesPerInput(subCircuit);

        var simulationSession = SimulationSession.Build(subCircuit);

        string? inputs;
        while ((inputs = await Console.In.ReadLineAsync()) is not null)
        {
            if (string.Equals(inputs, "q", StringComparison.OrdinalIgnoreCase) || string.Equals(inputs, "quit", StringComparison.OrdinalIgnoreCase))
                break;

            var validationErrorMessage = InputValidator.Validate(subCircuit, inputs, normalize, allowedValuesPerInput);
            if (validationErrorMessage is not null)
            {
                renderer.DrawError(validationErrorMessage);
                continue;
            } 

            simulationSession.Simulate(inputs, normalize);
        }

        return 0;
    }
}