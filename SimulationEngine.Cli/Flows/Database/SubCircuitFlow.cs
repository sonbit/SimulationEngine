using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.IO;
using SimulationEngine.Cli.Simulation;
using SimulationEngine.Cli.UI;
using SimulationEngine.Domain.Models;
using Spectre.Console;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Database;

public sealed class SubCircuitFlow(IPrompter prompter, IRenderer renderer, ISubCircuitService service)
{
    private enum MenuOptions
    {
        Simulate,
        [Description("Simulate (Normalized)")] SimulateNormalized,
        [Description("Simulate file")] SimulateFile,
        [Description("Simulate file (Normalized)")] SimulateFileNormalized,
        [Description("Simulate test")] SimulateTest,
        [Description("Show as tree")] ShowTree,
        Back
    }

    public async Task RunMenuAsync(SubCircuit subCircuit, int id)
    {
        renderer.Clear();

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

            var menuOption = await prompter.SelectEnumAsync<MenuOptions>($"[bold]{subCircuit.Title} ({id})[/]");

            switch (menuOption)
            {
                case MenuOptions.Simulate:
                case MenuOptions.SimulateNormalized:
                    await SimulationRepl.SimulateReplAsync(subCircuit, renderer, menuOption == MenuOptions.SimulateNormalized);
                    break;

                case MenuOptions.SimulateFile:
                case MenuOptions.SimulateFileNormalized:
                    await SimulationFile.SimulateFileAsync(subCircuit, prompter, renderer, menuOption == MenuOptions.SimulateFileNormalized);
                    break;

                case MenuOptions.SimulateTest:
                    SimulationTest.Simulate(subCircuit, renderer);
                    break;

                case MenuOptions.ShowTree:
                    await SubCircuitBuildTreeAsync(subCircuit: subCircuit);
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task SubCircuitBuildTreeAsync(int id = 0, SubCircuit? subCircuit = null)
    {
        if (id == 0 && subCircuit == null)
        {
            id = await prompter.AskIdAsync("Enter an id");

            if (id == 0)
            {
                renderer.DrawError("Invalid id");
                return;
            }

            subCircuit = await service.GetAsync(id);
            if (subCircuit is null)
            {
                renderer.DrawError($"SubCircuit with id {id} was not found");
                return;
            }
        }

        if (subCircuit is null)
            return;

        renderer.Clear();
        BuildTree(subCircuit);
    }

    private void BuildTree(SubCircuit parentSubCircuit, int maxDepth = 32)
    {
        var tree = new Tree(GetSubCircuitLabel(parentSubCircuit));
        int depth = 0;

        Build(parentSubCircuit, text => tree.AddNode(text), depth);

        renderer.Write(tree);

        void Build(SubCircuit subCircuit, Func<string, TreeNode> addChild, int depth)
        {
            if (depth >= maxDepth)
            {
                addChild($"[grey] Max depth of {maxDepth} reached[/]");
                return;
            }

            foreach (var logicGate in subCircuit.LogicGates)
                addChild(GetLogicGateLabel(logicGate));

            foreach (var childSubCircuit in subCircuit.SubCircuits)
            {
                var childNode = addChild(GetSubCircuitLabel(childSubCircuit));
                Build(childSubCircuit, label => childNode.AddNode(label), depth + 1);
            }
        }
    }

    private static string GetLogicGateLabel(LogicGate logicGate) =>
        $"[blue]{Markup.Escape(logicGate.TruthTable.HeptaIndex)}[/]";

    private static string GetSubCircuitLabel(SubCircuit subCircuit) =>
        $"[yellow]{Markup.Escape(subCircuit.Title)}[/] [grey](Inputs: {subCircuit.Inputs.Count}, Outputs: {subCircuit.Outputs.Count}, Wires: {subCircuit.Wires.Count})[/]";
}