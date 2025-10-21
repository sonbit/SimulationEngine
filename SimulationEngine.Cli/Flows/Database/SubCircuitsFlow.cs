using SimulationEngine.Application.Services.Database.Subcircuits;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Database;

public sealed class SubcircuitsFlow(IPrompter prompter, IRenderer renderer, ISubcircuitService service, SubcircuitFlow subcircuitFlow)
{
    private enum MenuOptions
    {
        [Description("List all")] ListAll,
        [Description("Select from list")] SelectFromList,
        [Description("Find by id")] FindById,
        [Description("Find by title (First match)")] FindByTitle,
        [Description("Populate database with existing subcircuits")] Populate,
        Back
    }

    public async Task RunMenuAsync()
    {
        while (true)
        {
            switch (await prompter.SelectEnumAsync<MenuOptions>("[bold]Subcircuits[/]"))
            {
                case MenuOptions.ListAll:
                    await SubcircuitsListAsync(); 
                    break;

                case MenuOptions.SelectFromList:
                    await SubcircuitsSelectAsync(); 
                    break;

                case MenuOptions.FindById:
                    await SubcircuitsFindAsync(); 
                    break;

                case MenuOptions.FindByTitle:
                    await SubcircuitsFindByTitleAsync();
                    break;

                case MenuOptions.Populate:
                    await SubcircuitsPopulateAsync();
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task SubcircuitsFindAsync(int? id = null)
    {
        id ??= await prompter.AskIdAsync("Enter Subcircuit id:");
        if (id.HasValue && id.Value == 0)
        {
            renderer.DrawError("Invalid id");
            return;
        }

        var subcircuit = await service.GetByIdAsync(id.Value);
        if (subcircuit is null)
        {
            renderer.DrawError($"Subcircuit with id {id} was not found");
            return;
        }

        await subcircuitFlow.RunMenuAsync(subcircuit);
    }

    public async Task SubcircuitsFindByTitleAsync(string? title = null)
    {
        title ??= await prompter.AskAsync("Enter Subcircuit title (Full or partial, finds first match):");
        if (string.IsNullOrWhiteSpace(title))
        {
            renderer.DrawError("Invalid title");
            return;
        }

        var subcircuit = await service.GetByTitleAsync(title);
        if (subcircuit is null)
        {
            renderer.DrawError($"Subcircuit with title {title} was not found");
            return;
        }

        await subcircuitFlow.RunMenuAsync(subcircuit);
    }

    public async Task SubcircuitsListAsync()
    {
        var subcircuits = await service.GetAllAsync();
        if (subcircuits.Count == 0)
        {
            renderer.DrawWarning("No Subcircuits found");
            return;
        }

        renderer.DrawTableFromPropertiesWithColumnNames(subcircuits.Select(subcircuit => new
        {
            subcircuit.Id,
            subcircuit.Title,
            Inputs = subcircuit.Inputs.Count,
            LogicGates = subcircuit.LogicGates.Count,
            Outputs = subcircuit.Outputs.Count,
            Subcircuits = subcircuit.Subcircuits.Count,
            Wires = subcircuit.Wires.Count
        }), 
        true,
        [
            nameof(Subcircuit.Id),
            nameof(Subcircuit.Title),
            nameof(Subcircuit.Inputs),
            nameof(Subcircuit.LogicGates),
            nameof(Subcircuit.Outputs),
            nameof(Subcircuit.Subcircuits),
            nameof(Subcircuit.Wires)
        ]);
    }

    public async Task SubcircuitsPopulateAsync()
    {
        var designsAssembly = typeof(StandardCellLibrary).Assembly;

        var designs = designsAssembly
            .GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && typeof(Subcircuit).IsAssignableFrom(type))
            .ToList();

        foreach (var design in designs)
        {
            var subcircuit = (Subcircuit?)Activator.CreateInstance(design, nonPublic: true);
            if (subcircuit == null)
                continue;
            await service.CreateOrGetAsync(subcircuit);
        }
    }

    private async Task SubcircuitsSelectAsync()
    {
        var subcircuits = await service.GetAllAsync();
        if (subcircuits.Count == 0)
        {
            renderer.DrawWarning("No Subcircuits found");
            return;
        }

        renderer.Clear();

        var selectedSubcircuit = await prompter.SelectOrBackAsync(
            "Select a Subcircuit",
            subcircuits,
            subcircuit => $"{subcircuit.Title} [grey]({subcircuit.Id})[/]");

        if (selectedSubcircuit?.Id is null)
            return;

        var subcircuit = await service.GetByIdAsync(selectedSubcircuit.Id);
        if (subcircuit is null)
        {
            renderer.DrawError($"Subcircuit with id {selectedSubcircuit.Id} was not found");
            return;
        }

        renderer.Clear();

        await subcircuitFlow.RunMenuAsync(subcircuit);
    }
}