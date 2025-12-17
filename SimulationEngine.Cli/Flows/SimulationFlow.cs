using SimulationEngine.Application.Services.Database.Subcircuits;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Simulation;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows;

public sealed partial class SimulationFlow(IPrompter prompter, IRenderer renderer, ISubcircuitService service)
{
    private enum MenuOptions
    {
        [Description("Select Subcircuit from list")] SelectFromList,
        [Description("Find Subcircuit by id")] FindById,
        [Description("Find Subcircuit by title (First match)")] FindByTitle,
        Back
    }

    private enum SimulationOptions
    {
        Simulate,
        [Description("Simulate (Normalized)")] SimulateNormalized,
        [Description("Simulate file")] SimulateFile,
        [Description("Simulate file (Normalized)")] SimulateFileNormalized,
        [Description("Simulate test")] SimulateTest,
        [Description("Duplicate and open menu")] DuplicateAndSimulate,
        [Description("Benchmark test (select iterations)")] BenchmarkTest,
        [Description("Benchmark file (select iterations)")] BenchmarkFile,
        [Description("Benchmark file (Normalized, select iterations)")] BenchmarkFileNormalized,
        Back
    }

    public async Task RunMenuAsync()
    {
        while (true)
        {
            Subcircuit? subcircuit = null;

            switch (await prompter.SelectEnumAsync<MenuOptions>("[bold]Pick a Subcircuit to simulate[/]"))
            {
                case MenuOptions.SelectFromList:
                    subcircuit = await PromptSelectSubcircuitAsync();
                    break;

                case MenuOptions.FindById:
                    subcircuit = await PromptFindSubcircuitByIdAsync();
                    break;

                case MenuOptions.FindByTitle:
                    subcircuit = await PromptFindSubcircuitByTitleAsync();
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }

            if (subcircuit == null)
                continue;

            await RunSimulationMenuAsync(subcircuit);
        }
    }

    public async Task RunSimulationMenuAsync(Subcircuit subcircuit)
    {
        renderer.Clear();

        while (true)
        {
            var (Inputs, Outputs, LogicGates, Wires, Subcircuits) = GetRecursiveCounts(subcircuit);

            renderer.DrawTableWithNameValuePairs(
            [
                (nameof(Subcircuit.Id), subcircuit.Id),
                (nameof(Subcircuit.Title), subcircuit.Title),
                (nameof(Subcircuit.Hash), subcircuit.Hash),
                (nameof(Subcircuit.Inputs), Inputs),
                (nameof(Subcircuit.LogicGates), LogicGates),
                (nameof(Subcircuit.Outputs), Outputs),
                (nameof(Subcircuit.Subcircuits), Subcircuits),
                (nameof(Subcircuit.Wires), Wires)
            ]);

            var simulationOption = await prompter.SelectEnumAsync<SimulationOptions>($"[bold]{subcircuit.Title} ({subcircuit.Id})[/]");

            switch (simulationOption)
            {
                case SimulationOptions.Simulate:
                case SimulationOptions.SimulateNormalized:
                    renderer.Clear();
                    await SimulationRepl.SimulateReplAsync(subcircuit, renderer, simulationOption == SimulationOptions.SimulateNormalized);
                    break;

                case SimulationOptions.DuplicateAndSimulate:
                    {
                        var copies = await prompter.AskPositiveIntAsync("Number of copies:");
                        var duplicated = SubcircuitDuplicator.Create(subcircuit, copies);
                        await RunSimulationMenuAsync(duplicated);
                        break;
                    }

                case SimulationOptions.SimulateFile:
                case SimulationOptions.SimulateFileNormalized:
                    await SimulationFile.SimulateFileAsync(subcircuit, prompter, renderer, simulationOption == SimulationOptions.SimulateFileNormalized);
                    break;

                case SimulationOptions.SimulateTest:
                    SimulationTest.Simulate(subcircuit, renderer);
                    break;

                case SimulationOptions.BenchmarkTest:
                    {
                        var iterations = await prompter.AskPositiveIntAsync("Iterations for benchmark:");
                        SimulationTest.Benchmark(subcircuit, renderer, iterations);
                        break;
                    }

                case SimulationOptions.BenchmarkFile:
                case SimulationOptions.BenchmarkFileNormalized:
                    {
                        var iterations = await prompter.AskPositiveIntAsync("Iterations for benchmark:");
                        await SimulationFile.SimulateFileAsync(
                            subcircuit,
                            prompter,
                            renderer,
                            simulationOption == SimulationOptions.BenchmarkFileNormalized,
                            benchmark: true,
                            iterations: iterations);
                        break;
                    }

                case SimulationOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    private async Task<Subcircuit?> PromptFindSubcircuitByIdAsync()
    {
        var id = await prompter.AskIdAsync("Enter Subcircuit id:");
        var subcircuit = await service.GetByIdAsync(id);

        if (subcircuit is null)
            renderer.DrawError($"Subcircuit with id {id} was not found");

        return subcircuit;
    }

    private async Task<Subcircuit?> PromptFindSubcircuitByTitleAsync()
    {
        var title = await prompter.AskAsync("Enter Subcircuit title:");
        var subcircuit = await service.GetByTitleAsync(title);

        if (subcircuit is null)
            renderer.DrawError($"Subcircuit with title {title} was not found");

        return subcircuit;
    }

    private async Task<Subcircuit?> PromptSelectSubcircuitAsync()
    {
        var selectedSubcircuit = await prompter.SelectOrBackAsync(
            "Select Subcircuit",
            await service.GetAllAsync(),
            subcircuit => $"{subcircuit.Title} [grey]({subcircuit.Id})[/]",
            "No Subcircuits found")!;

        if (selectedSubcircuit is null)
            return null;

        return await service.GetByIdAsync(selectedSubcircuit!.Id);
    }

    private static (int Inputs, int Outputs, int LogicGates, int Wires, int Subcircuits) GetRecursiveCounts(Subcircuit subcircuit)
    {
        var inputs = subcircuit.Inputs?.Count ?? 0;
        var outputs = subcircuit.Outputs?.Count ?? 0;
        var gates = subcircuit.LogicGates?.Count ?? 0;
        var wires = subcircuit.Wires?.Count ?? 0;
        var children = subcircuit.Subcircuits?.Count ?? 0;

        foreach (var child in subcircuit.Subcircuits ?? [])
        {
            var (Inputs, Outputs, LogicGates, Wires, Subcircuits) = GetRecursiveCounts(child);
            inputs += Inputs;
            outputs += Outputs;
            gates += LogicGates;
            wires += Wires;
            children += Subcircuits;
        }

        return (inputs, outputs, gates, wires, children);
    }
}
