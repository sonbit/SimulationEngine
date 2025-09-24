using SimulationEngine.Application.Services.TruthTables;
using SimulationEngine.Cli.IO;
using SimulationEngine.Cli.UI;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Metadata;
using Spectre.Console;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Database;

public sealed class TruthTablesFlow(IInputOutput inputOutput, IRenderer renderer, ITruthTableService service)
{
    private enum MenuOptions
    {
        [Description("List all")] ListAll,
        [Description("Select from list")] SelectFromList,
        [Description("Find by id")] FindById,
        [Description("Populate database with standard cell library")] Populate,
        Back
    }

    public async Task RunMenuAsync()
    {
        while (true)
        {
            switch (await inputOutput.SelectEnumAsync<MenuOptions>("[bold]TruthTables[/]"))
            {
                case MenuOptions.ListAll:
                    await TruthTablesListAsync(); 
                    break;

                case MenuOptions.SelectFromList:
                    await TruthTablesSelectAsync(); 
                    break;

                case MenuOptions.FindById:
                    await TruthTablesFindAsync();
                    break;

                case MenuOptions.Populate:
                    await TruthTablesPopulateAsync();
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task TruthTablesFindAsync(int id = 0)
    {
        if (id == 0) 
        {
            id = await inputOutput.AskIdAsync("Enter an id");

            if (id == 0)
            {
                renderer.DrawError("Invalid id");
                return;
            }
        }

        await DrawTruthTable(id);
    }

    public async Task TruthTablesListAsync()
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
    }

    public async Task TruthTablesPopulateAsync() => 
        await service.Populate();

    private async Task DrawTruthTable(int id)
    {
        var truthTable = await service.GetAsync(id);
        if (truthTable is null)
        {
            renderer.DrawError($"TruthTable with id {id} was not found");
            return;
        }

        renderer.Clear();

        renderer.NameValueTable(
        [
            (nameof(TruthTable.Id), truthTable.Id),
            (nameof(TruthTable.Title), truthTable.Title),
            (nameof(TruthTable.HeptaIndex), truthTable.HeptaIndex),
            (nameof(TruthTable.Definition), truthTable.Definition),
            (nameof(TruthTableMetadata.Radix), truthTable.Metadata.Radix),
            (nameof(TruthTable.LogicGates), truthTable.LogicGates.Count),
        ]);
    }

    private async Task TruthTablesSelectAsync()
    {
        var truthTables = await service.GetAllAsync();

        if (truthTables.Count == 0)
        {
            renderer.DrawWarning("No truthtables found");
            return;
        }

        renderer.Clear();

        var selectedTruthTable = AnsiConsole.Prompt(
            new SelectionPrompt<TruthTable>()
                .Title("Select a truthTable")
                .UseConverter(truthTable => $"{truthTable.Title ?? truthTable.HeptaIndex} [grey]({truthTable.Id})[/]")
                .AddChoices(truthTables));

        await DrawTruthTable(selectedTruthTable.Id);
    }
}