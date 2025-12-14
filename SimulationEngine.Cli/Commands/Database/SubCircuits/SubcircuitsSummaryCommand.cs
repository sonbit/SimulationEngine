using SimulationEngine.Cli.Flows.Database;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Settings;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.Subcircuits;

public sealed class SubcircuitsSummaryCommand(SubcircuitFlow flow, IPrompter prompter, IRenderer renderer) : AsyncCommand<FindSettings>
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

        await flow.ShowGateSummaryAsync(id.Value);
        return 0;
    }
}
