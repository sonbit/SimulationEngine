using SimulationEngine.Cli.Flows.Database;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.Subcircuits;

public sealed class SubcircuitsListCommand(SubcircuitsFlow flow) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await flow.SubcircuitsListAsync();
        return 0;
    }
}