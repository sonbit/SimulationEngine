using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Flows.Shared;
using SimulationEngine.Cli.Handlers.InputOutput;
using SimulationEngine.Cli.Handlers.Renderer;
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
        [Description("Simulate file")] SimulateFile,
        [Description("Simulate file (Normalized)")] SimulateFileNormalized,
        Back
    }

    public async Task RunMenuAsync()
    {
        while (true)
        {
            SubCircuit? subCircuit = null;

            switch (await inputOutput.SelectEnumAsync<MenuOptions>("[bold]Simulation - Pick a subcircuit[/]"))
            {
                case MenuOptions.FindById:
                    var id = await inputOutput.AskIdAsync("Enter subcircuit id:");
                    subCircuit = await service.GetAsync(id);
                    break;

                case MenuOptions.SelectFromList:
                    subCircuit = inputOutput.SelectOrBack("Select subcircuit", 
                        await service.GetAllAsync(), subCircuit => $"{subCircuit.Title} [grey]({subCircuit.Id})[/]")!;
                    break;

                case MenuOptions.Back:
                    return;
            }

            if (subCircuit is null)
                continue;

            renderer.Clear();

            while (true)
            {
                renderer.NameValueTable(
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

                var normalize = false;
                FileInfo? fileInfo = null;

                switch (await inputOutput.SelectEnumAsync<SimulationOptions>($"[bold]Simulation: {subCircuit.Title} ({subCircuit.Id})[/]"))
                {
                    case SimulationOptions.Simulate:
                        break;

                    case SimulationOptions.SimulateNormalized:
                        normalize = true;
                        break;

                    case SimulationOptions.SimulateFile:
                        fileInfo = await inputOutput.PickFileAsync("Pick a test file", Environment.CurrentDirectory, "*.txt");
                        break;

                    case SimulationOptions.SimulateFileNormalized:
                        normalize = true;
                        fileInfo = await inputOutput.PickFileAsync("Pick a test file", Environment.CurrentDirectory, "*.txt");
                        break;

                    case SimulationOptions.Back:
                        return;
                }

                await SimulationEntry.SimulateAsync(subCircuit, renderer, fileInfo, normalize);
            }
        }
    }
}