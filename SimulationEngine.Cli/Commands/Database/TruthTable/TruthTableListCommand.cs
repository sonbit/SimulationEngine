using SimulationEngine.Application.Services.TruthTables;
using SimulationEngine.Cli.Handlers.Renderer;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTable;

public sealed class TruthTableListCommand(ITruthTableService service, IRenderer renderer) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var truthTables = await service.GetAllAsync();

        renderer.PropertyTable(truthTables.Select(truthTable => new
        {
            truthTable.Id,
            truthTable.Title,
            truthTable.HeptaIndex,
            truthTable.Metadata.Radix,
            LogicGates = truthTable.LogicGates.Count
        }), [
            nameof(Domain.Models.TruthTable.Id),
            nameof(Domain.Models.TruthTable.Title),
            nameof(Domain.Models.TruthTable.HeptaIndex),
            nameof(Domain.Models.Metadata.TruthTableMetadata.Radix),
            nameof(Domain.Models.TruthTable.LogicGates)
        ]);

        return 0;
    }
}