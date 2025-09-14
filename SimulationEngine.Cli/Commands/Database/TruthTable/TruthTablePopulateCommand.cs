using SimulationEngine.Application.Services.TruthTables;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTable;

public sealed class TruthTablePopulateCommand(ITruthTableService service) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        await service.Populate();
        return 0;
    }
}