using SimulationEngine.Cli.UI;
using SimulationEngine.Cli.Validators;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using Spectre.Console;

namespace SimulationEngine.Cli.IO;

public static class FileSimulation
{
    public static int Simulate(SubCircuit subCircuit, FileInfo? file, IRenderer renderer, bool normalize = false)
    {
        if (file is null)
            return 0;

        var allowedValuesPerInput = InputValidator.GetAllowedValuesPerInput(subCircuit);

        var simulationSession = SimulationSession.Build(subCircuit);

        foreach (var inputs in File.ReadLines(file.FullName))
        {
            if (inputs.Length != subCircuit.Inputs.Count)
            {
                renderer.DrawError($"Expected {subCircuit.Inputs.Count} inputs, got {inputs.Length}");
                return -1;
            }

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
}