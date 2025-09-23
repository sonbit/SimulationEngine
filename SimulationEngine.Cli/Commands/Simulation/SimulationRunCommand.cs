using SimulationEngine.Application.Converters;
using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Flows.Shared;
using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Cli.Settings;
using SimulationEngine.Simulator.Core.Engine;
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
            return await SimulationEntry.SimulateAsync(subCircuit, renderer, settings.File, settings.Normalize);

        if (settings.Inputs is not null)
        {
            // Split inputstring - Consider a general method to handle all cases (E.g. one in SimulationSession)
            var simulationSession = SimulationSession.Build(subCircuit);
            simulationSession.SetInputs(SimulationUtils.GetInputsAsByteArray(settings.Inputs));
            AnsiConsole.WriteLine(SimulationUtils.GetOutputsAsString(simulationSession.GetOutputs()));
            return 0;
        }

        //if (settings.Stream || Console.IsInputRedirected)
        //    return await RunStdInAsync();

        await SimulationRepl.ReplAsync(subCircuit, renderer, settings.Normalize);
        return 0;
    }

    //private static async Task<int> RunStdInAsync(SimulationSession session, bool normalize)
    //{
    //    string? input;
    //    while ((input = await Console.In.ReadLineAsync()) is not null)
    //    {
    //        if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
    //            break;

    //        if (string.IsNullOrWhiteSpace(input)) continue;

    //        var vectors = TestStringConverter.Convert(input);
    //        foreach (var v in vectors)
    //        {
    //            session.SetInputs(v.Inputs);
    //            Console.WriteLine(TestStringConverter.Convert(session.GetOutputs()));
    //        }
    //    }
    //    return 0;
    //}
}