using SimulationEngine.Cli.Flows.Database;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database;

public sealed class DatabaseRecreateCommand(DatabaseFlow flow) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await flow.DatabaseRecreateAsync();
        return 0;
    }
}