using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Interactive;
using SimulationEngine.Cli.IO;
using SimulationEngine.Cli.UI;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Simulation;

public sealed partial class SimulationFlow(IInputOutput inputOutput, IRenderer renderer, ISubCircuitService service)
{
    private enum MenuOptions
    {
        [Description("Find subcircuit by id")] FindById,
        [Description("Select subcircuit from list")] SelectFromList,
        Back
    }

    private enum SimulationOptions
    {
        Simulate,
        [Description("Simulate (Normalized)")] SimulateNormalized,
        [Description("Simulate from file")] SimulateFile,
        [Description("Simulate from file (Normalized)")] SimulateFileNormalized,
        Back
    }

    public async Task RunMenuAsync()
    {
        while (true)
        {
            renderer.Clear();

            SubCircuit? subCircuit = null;
            var id = 0;

            switch (await inputOutput.SelectEnumAsync<MenuOptions>("[bold]Simulation: Pick a subcircuit[/]"))
            {
                case MenuOptions.FindById:
                    id = await inputOutput.AskIdAsync("Enter subcircuit id:");
                    subCircuit = await service.GetAsync(id);
                    if (subCircuit is null)
                        renderer.DrawError($"SubCircuit with id {id} was not found");
                    break;

                case MenuOptions.SelectFromList:
                    subCircuit = await inputOutput.SelectOrBackAsync(
                        "Select subcircuit", 
                        await service.GetAllAsync(), 
                        subCircuit => $"{subCircuit.Title} [grey]({subCircuit.Id})[/]", 
                        "No subcircuits found")!;
                    id = subCircuit?.Id ?? 0;
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }

            if (subCircuit == null)
                continue;

            renderer.Clear();

            var goBack = false;

            while (true)
            {
                renderer.DrawTableWithNameValuePairs(
                [
                    (nameof(SubCircuit.Id), id),
                    (nameof(SubCircuit.Title), subCircuit.Title),
                    (nameof(SubCircuit.Hash), subCircuit.Hash),
                    (nameof(SubCircuit.Inputs), subCircuit.Inputs.Count),
                    (nameof(SubCircuit.LogicGates), subCircuit.LogicGates.Count),
                    (nameof(SubCircuit.Outputs), subCircuit.Outputs.Count),
                    (nameof(SubCircuit.SubCircuits), subCircuit.SubCircuits.Count),
                    (nameof(SubCircuit.Wires), subCircuit.Wires.Count)
                ]);

                var simulationOption = await inputOutput.SelectEnumAsync<SimulationOptions>($"[bold]{subCircuit.Title} ({id})[/]");

                switch (simulationOption)
                {
                    case SimulationOptions.Simulate:
                    case SimulationOptions.SimulateNormalized:
                        renderer.Clear();
                        await SimulationRepl.SimulateReplAsync(subCircuit, renderer, simulationOption == SimulationOptions.SimulateNormalized);
                        break;

                    case SimulationOptions.SimulateFile:
                    case SimulationOptions.SimulateFileNormalized:
                        renderer.Clear();
                        var file = await inputOutput.PickFileAsync("Pick a test file", Environment.CurrentDirectory, "*.txt");
                        SimulationFile.Simulate(subCircuit, file, renderer, simulationOption == SimulationOptions.SimulateFileNormalized);
                        break;

                    case SimulationOptions.Back:
                        goBack = true;
                        break;
                }

                if (goBack)
                    break;
            }
        }
    }
}