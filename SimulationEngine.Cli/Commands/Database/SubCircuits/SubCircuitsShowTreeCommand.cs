using SimulationEngine.Cli.Flows.Database;
using SimulationEngine.Cli.Handlers.InputOutput;
using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Cli.Settings;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuits;

public sealed class SubCircuitsShowTreeCommand(SubCircuitFlow flow, IInputOutput inputOutput, IRenderer renderer) : AsyncCommand<FindSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, FindSettings settings)
    {
        var id = settings.Id;
        id ??= settings.Interactive ? await inputOutput.AskIdAsync("Enter an id") : 0;

        if (id == null || id == 0)
        {
            renderer.DrawError("Missing --id (or use --interactive).");
            return -1;
        }

        await flow.SubCircuitBuildTreeAsync(id ?? 0);
        return 0;
    }
}