using SimulationEngine.Cli.Flows.Database;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTables;

public sealed class TruthTablesListCommand(TruthTablesFlow flow) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await flow.TruthTablesListAsync();
        return 0;
    }
}