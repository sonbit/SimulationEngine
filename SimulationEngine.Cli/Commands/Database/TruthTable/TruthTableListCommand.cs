using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Cli.Renderers;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTable;

public sealed class TruthTableListCommand(ITruthTableService service, IRenderer renderer) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var truthTables = await service.GetAllAsync();
        renderer.DrawTable(truthTables);
        return 0;
    }
}
