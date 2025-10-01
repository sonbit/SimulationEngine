using SimulationEngine.Application.Services.Database.SubCircuits;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Domain.Models;
using Spectre.Console;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Database;

public sealed class SubCircuitFlow(
    IPrompter prompter, 
    IRenderer renderer, 
    ISubCircuitService service,
    SimulationFlow simulationFlow, 
    EmitFlow emitFlow,
    ExportFlow exportFlow)
{
    private enum MenuOptions
    {
        Simulate,
        [Description("Draw tree")] ShowTree,
        Emit,
        Export,
        Back
    }

    public async Task RunMenuAsync(SubCircuit subCircuit)
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

            var menuOption = await prompter.SelectEnumAsync<MenuOptions>($"[bold]{subCircuit.Title} ({subCircuit.Id})[/]");

            switch (menuOption)
            {
                case MenuOptions.Simulate:
                    await simulationFlow.RunSimulationMenuAsync(subCircuit);
                    break;

                case MenuOptions.ShowTree:
                    renderer.Clear();
                    BuildTree(subCircuit);
                    break;

                case MenuOptions.Emit:
                    await emitFlow.RunMenuAsync(subCircuit);
                    break;

                case MenuOptions.Export:
                    await exportFlow.RunMenuAsync(subCircuit);
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task SubCircuitBuildTreeAsync(int id)
    {
        var subCircuit = await service.GetByIdAsync(id);
        if (subCircuit is null)
        {
            renderer.DrawError($"SubCircuit with id {id} was not found");
            return;
        }

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
        $"[yellow]{Markup.Escape(subCircuit.Title)}[/]";
}