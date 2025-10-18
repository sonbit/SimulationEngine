using SimulationEngine.Application.Services.Database.SubCircuits;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Simulation;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows;

public sealed partial class SimulationFlow(IPrompter prompter, IRenderer renderer, ISubCircuitService service)
{
    private enum MenuOptions
    {
        [Description("Select SubCircuit from list")] SelectFromList,
        [Description("Find SubCircuit by id")] FindById,
        [Description("Find SubCircuit by title (First match)")] FindByTitle,
        Back
    }

    private enum SimulationOptions
    {
        Simulate,
        [Description("Simulate (Normalized)")] SimulateNormalized,
        [Description("Simulate file")] SimulateFile,
        [Description("Simulate file (Normalized)")] SimulateFileNormalized,
        [Description("Simulate test")] SimulateTest,
        Back
    }

    public async Task RunMenuAsync()
    {
        while (true)
        {
            SubCircuit? subCircuit = null;

            switch (await prompter.SelectEnumAsync<MenuOptions>("[bold]Pick a SubCircuit to simulate[/]"))
            {
                case MenuOptions.SelectFromList:
                    subCircuit = await PromptSelectSubCircuitAsync();
                    break;

                case MenuOptions.FindById:
                    subCircuit = await PromptFindSubCircuitByIdAsync();
                    break;

                case MenuOptions.FindByTitle:
                    subCircuit = await PromptFindSubCircuitByTitleAsync();
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }

            if (subCircuit == null)
                continue;

            await RunSimulationMenuAsync(subCircuit);
        }
    }

    public async Task RunSimulationMenuAsync(SubCircuit subCircuit)
    {
        renderer.Clear();

        while (true)
        {
            renderer.DrawTableWithNameValuePairs(
            [
                (nameof(SubCircuit.Id), subCircuit.Id),
                    (nameof(SubCircuit.Title), subCircuit.Title),
                    (nameof(SubCircuit.Hash), subCircuit.Hash),
                    (nameof(SubCircuit.Inputs), subCircuit.Inputs.Count),
                    (nameof(SubCircuit.LogicGates), subCircuit.LogicGates.Count),
                    (nameof(SubCircuit.Outputs), subCircuit.Outputs.Count),
                    (nameof(SubCircuit.SubCircuits), subCircuit.SubCircuits.Count),
                    (nameof(SubCircuit.Wires), subCircuit.Wires.Count)
            ]);

            var simulationOption = await prompter.SelectEnumAsync<SimulationOptions>($"[bold]{subCircuit.Title} ({subCircuit.Id})[/]");

            switch (simulationOption)
            {
                case SimulationOptions.Simulate:
                case SimulationOptions.SimulateNormalized:
                    renderer.Clear();
                    await SimulationRepl.SimulateReplAsync(subCircuit, renderer, simulationOption == SimulationOptions.SimulateNormalized);
                    break;

                case SimulationOptions.SimulateFile:
                case SimulationOptions.SimulateFileNormalized:
                    await SimulationFile.SimulateFileAsync(subCircuit, prompter, renderer, simulationOption == SimulationOptions.SimulateFileNormalized);
                    break;

                case SimulationOptions.SimulateTest:
                    SimulationTest.Simulate(subCircuit, renderer);
                    break;

                case SimulationOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    private async Task<SubCircuit?> PromptFindSubCircuitByIdAsync()
    {
        var id = await prompter.AskIdAsync("Enter SubCircuit id:");
        var subCircuit = await service.GetByIdAsync(id);

        if (subCircuit is null)
            renderer.DrawError($"SubCircuit with id {id} was not found");

        return subCircuit;
    }

    private async Task<SubCircuit?> PromptFindSubCircuitByTitleAsync()
    {
        var title = await prompter.AskAsync("Enter SubCircuit title:");
        var subCircuit = await service.GetByTitleAsync(title);

        if (subCircuit is null)
            renderer.DrawError($"SubCircuit with title {title} was not found");

        return subCircuit;
    }

    private async Task<SubCircuit?> PromptSelectSubCircuitAsync()
    {
        var selectedSubCircuit = await prompter.SelectOrBackAsync(
            "Select SubCircuit",
            await service.GetAllAsync(),
            subCircuit => $"{subCircuit.Title} [grey]({subCircuit.Id})[/]",
            "No SubCircuits found")!;

        if (selectedSubCircuit is null)
            return null;

        return await service.GetByIdAsync(selectedSubCircuit!.Id);
    }
}