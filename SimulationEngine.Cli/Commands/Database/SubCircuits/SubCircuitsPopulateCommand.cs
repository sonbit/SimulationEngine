using SimulationEngine.Cli.Flows.Database;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuits;

public sealed class SubCircuitsPopulateCommand(SubCircuitsFlow flow) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await flow.SubCircuitsPopulateAsync();
        return 0;
    }
}