using SimulationEngine.Application.Services.SubCircuits;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuit;

public sealed class SubCircuitPopulateCommand(ISubCircuitService service) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        await service.Populate();
        return 0;
    }
}