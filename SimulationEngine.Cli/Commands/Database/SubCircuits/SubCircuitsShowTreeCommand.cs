using SimulationEngine.Cli.Flows.Database;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Settings;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.Subcircuits;

public sealed class SubcircuitsShowTreeCommand(SubcircuitFlow flow, IPrompter prompter, IRenderer renderer) : AsyncCommand<FindSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, FindSettings settings)
    {
        var id = settings.Id;
        id ??= settings.Interactive ? await prompter.AskIdAsync("Enter an id:") : 0;

        if (id == null || id == 0)
        {
            renderer.DrawError("Missing --id (or use --interactive).");
            return 1;
        }

        await flow.SubcircuitBuildTreeAsync(id ?? 0);
        return 0;
    }
}