using SimulationEngine.Application.Services.TruthTables;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTables;

public sealed class TruthTablesPopulateCommand(ITruthTableService service) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        await service.Populate();
        return 0;
    }
}