using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using Spectre.Console;

namespace SimulationEngine.Cli.Flows.Shared;

public static class SimulationFile
{
    public static int ReadFile(SubCircuit subCircuit, FileInfo file, IRenderer renderer, bool normalize = false)
    {
        var simulationSession = SimulationSession.Build(subCircuit);

        var allowedValuesPerInput = SimulationUtils.GetAllowedValuesPerInput(subCircuit);

        foreach (var inputs in File.ReadLines(file.FullName))
        {
            if (inputs.Length != subCircuit.Inputs.Count)
            {
                renderer.DrawError($"Expected {subCircuit.Inputs.Count} inputs, got {inputs.Length}");
                return -1;
            }

            if (normalize)
            {
                foreach (var (ch, index) in inputs.Select((ch, index) => (ch, index)))
                {
                    if ("012".Contains(ch))
                        continue;

                    renderer.DrawError($"Invalid character '{ch}' for input {index + 1}");
                    return -1;
                }

                simulationSession.SetInputs(SimulationUtils.GetInputsAsByteArray(inputs));
                AnsiConsole.WriteLine(SimulationUtils.GetOutputsAsString(simulationSession.GetOutputs()));
            }
            else
            {
                foreach (var (ch, index) in inputs.Select((ch, index) => (ch, index)))
                {
                    if (allowedValuesPerInput[index].Contains(ch))
                        continue;

                    renderer.DrawError($"Invalid character '{ch}' for input {index + 1}");
                    return -1;
                }

                simulationSession.SetInputsWithRadix(inputs);
                AnsiConsole.WriteLine(simulationSession.GetOutputsWithRadix());
            }
        }

        return 0;
    }
}