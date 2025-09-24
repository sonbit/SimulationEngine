using SimulationEngine.Cli.Flows;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Simulation;

public sealed class SimulationMenuCommand(SimulationFlow simulationFlow) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await simulationFlow.RunMenuAsync();
        return 0;
    }
}