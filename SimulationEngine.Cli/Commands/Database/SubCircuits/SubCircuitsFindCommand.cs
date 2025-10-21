using SimulationEngine.Cli.Flows.Database;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Settings;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.Subcircuits;

public sealed class SubcircuitsFindCommand(SubcircuitsFlow flow, IPrompter prompter, IRenderer renderer) : AsyncCommand<FindSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, FindSettings settings)
    {
        if (settings.Id is not null)
        {
            await flow.SubcircuitsFindAsync(settings.Id);
            return 0;
        }
        else if (!string.IsNullOrWhiteSpace(settings.Title))
        {
            await flow.SubcircuitsFindByTitleAsync(settings.Title);
            return 0;
        }
        else if (settings.Interactive)
        {
            var id = await prompter.AskIdAsync("Enter an id:");
            await flow.SubcircuitsFindAsync(id);
            return 0;
        }

        renderer.DrawError("Provide --id or --title (or use --interactive)");
        return 1;
    }
}