using SimulationEngine.Cli.Flows.Database;
using SimulationEngine.Cli.IO;
using SimulationEngine.Cli.Settings;
using SimulationEngine.Cli.UI;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTables;

public sealed class TruthTablesFindCommand(TruthTablesFlow flow, IInputOutput inputOutput, IRenderer renderer) : AsyncCommand<FindSettings>
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

        await flow.TruthTablesFindAsync(id ?? 0);
        return 0;
    }
}