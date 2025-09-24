using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.IO;
using SimulationEngine.Cli.UI;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Database;

public sealed class SubCircuitsFlow(IPrompter prompter, IRenderer renderer, ISubCircuitService service, SubCircuitFlow subCircuitFlow)
{
    private enum MenuOptions
    {
        [Description("List all")] ListAll,
        [Description("Select from list")] SelectFromList,
        [Description("Find by id")] FindById,
        [Description("Populate database with existing subcircuits")] Populate,
        Back
    }

    public async Task RunMenuAsync()
    {
        while (true)
        {
            switch (await prompter.SelectEnumAsync<MenuOptions>("[bold]SubCircuits[/]"))
            {
                case MenuOptions.ListAll:
                    await SubCircuitsListAsync(); 
                    break;

                case MenuOptions.SelectFromList:
                    await SubCircuitsSelectAsync(); 
                    break;

                case MenuOptions.FindById:
                    await SubCircuitsFindAsync(); 
                    break;

                case MenuOptions.Populate:
                    await SubCircuitsPopulateAsync();
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task SubCircuitsFindAsync(int id = 0)
    {
        if (id == 0)
        {
            id = await prompter.AskIdAsync("Enter an id");

            if (id == 0)
            {
                renderer.DrawError("Invalid id");
                return;
            }
        }

        var subCircuit = await service.GetAsync(id);
        if (subCircuit is null)
        {
            renderer.DrawError($"SubCircuit with id {id} was not found");
            return;
        }

        await subCircuitFlow.RunMenuAsync(subCircuit, id);
    }

    public async Task SubCircuitsListAsync()
    {
        var subCircuits = await service.GetAllAsync();

        if (subCircuits.Count == 0)
        {
            renderer.DrawWarning("No subcircuits found");
            return;
        }

        renderer.DrawTableFromPropertiesWithColumnNames(subCircuits.Select(subCircuit => new
        {
            subCircuit.Id,
            subCircuit.Title,
            Inputs = subCircuit.Inputs.Count,
            LogicGates = subCircuit.LogicGates.Count,
            Outputs = subCircuit.Outputs.Count,
            SubCircuits = subCircuit.SubCircuits.Count,
            Wires = subCircuit.Wires.Count
        }), 
        true,
        [
            nameof(SubCircuit.Id),
            nameof(SubCircuit.Title),
            nameof(SubCircuit.Inputs),
            nameof(SubCircuit.LogicGates),
            nameof(SubCircuit.Outputs),
            nameof(SubCircuit.SubCircuits),
            nameof(SubCircuit.Wires)
        ]);
    }

    public async Task SubCircuitsPopulateAsync() =>
        await service.Populate();

    private async Task SubCircuitsSelectAsync()
    {
        var subCircuits = await service.GetAllAsync();

        if (subCircuits.Count == 0)
        {
            renderer.DrawWarning("No subcircuits found");
            return;
        }

        renderer.Clear();

        var selectedSubCircuit = await prompter.SelectOrBackAsync(
            "Select a subcircuit",
            subCircuits,
            subCircuit => $"{subCircuit.Title} [grey]({subCircuit.Id})[/]");

        if (selectedSubCircuit?.Id is null)
            return;

        var subCircuit = await service.GetAsync(selectedSubCircuit.Id);
        if (subCircuit is null)
        {
            renderer.DrawError($"SubCircuit with id {selectedSubCircuit.Id} was not found");
            return;
        }

        renderer.Clear();

        await subCircuitFlow.RunMenuAsync(subCircuit, selectedSubCircuit.Id);
    }
}