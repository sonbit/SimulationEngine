using SimulationEngine.Application.Services.TruthTables;
using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Metadata;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTables;

public sealed class TruthTablesListCommand(ITruthTableService service, IRenderer renderer) : AsyncCommand
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
            nameof(TruthTable.Id),
            nameof(TruthTable.Title),
            nameof(TruthTable.HeptaIndex),
            nameof(TruthTableMetadata.Radix),
            nameof(TruthTable.LogicGates)
        ]);

        return 0;
    }
}