using SimulationEngine.Application.Services.Database;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database;

public class DatabaseDeleteCommand(IDatabaseService service) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        await service.EnsureDatabaseDeletedAsync();
        return 0;
    }
}