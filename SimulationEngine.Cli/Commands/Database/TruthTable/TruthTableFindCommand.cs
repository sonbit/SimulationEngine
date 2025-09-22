using SimulationEngine.Application.Services.TruthTables;
using SimulationEngine.Cli.Commands.Settings;
using SimulationEngine.Cli.Handlers.InputOutput;
using SimulationEngine.Cli.Handlers.Renderer;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTable;

public sealed class TruthTableFindCommand(ITruthTableService service, IRenderer renderer, IInputOutput inputOutput) : AsyncCommand<FindByIdSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, FindByIdSettings s)
    {
        var id = s.Id;

        if (id == 0 && int.TryParse(await inputOutput.PromptValidateAsync("Id"), out var promptId))
            id = promptId;

        if (id == 0)
        {
            renderer.DrawError("Invalid id");
            return 1;
        }

        var truthTable = await service.GetByIdAsync(id);
        if (truthTable is null) 
        {
            renderer.DrawError($"TruthTable with id {id} was not found");
            return 1; 
        }

        renderer.Clear();

        renderer.NameValueTable(
        [
            (nameof(Domain.Models.TruthTable.Id), truthTable.Id),
            (nameof(Domain.Models.TruthTable.Title), truthTable.Title),
            (nameof(Domain.Models.TruthTable.HeptaIndex), truthTable.HeptaIndex),
            (nameof(Domain.Models.TruthTable.Definition), truthTable.Definition),
            (nameof(Domain.Models.Metadata.TruthTableMetadata.Radix), truthTable.Metadata.Radix),
            (nameof(Domain.Models.TruthTable.LogicGates), truthTable.LogicGates.Count),
        ]);

        return 2;
    }
}