using SimulationEngine.Application.Services.SubCircuits;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuits;

public sealed class SubCircuitsPopulateCommand(ISubCircuitService service) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        await service.Populate();
        return 0;
    }
}