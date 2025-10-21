using SimulationEngine.Application.Services.Database.Subcircuits;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Domain.Models;
using Spectre.Console;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Database;

public sealed class SubcircuitFlow(
    IPrompter prompter, 
    IRenderer renderer, 
    ISubcircuitService service,
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

    public async Task RunMenuAsync(Subcircuit subcircuit)
    {
        renderer.Clear();

        while (true)
        {
            renderer.DrawTableWithNameValuePairs(
            [
                (nameof(Subcircuit.Id), subcircuit.Id),
                (nameof(Subcircuit.Title), subcircuit.Title),
                (nameof(Subcircuit.Hash), subcircuit.Hash),
                (nameof(Subcircuit.Inputs), subcircuit.Inputs.Count),
                (nameof(Subcircuit.LogicGates), subcircuit.LogicGates.Count),
                (nameof(Subcircuit.Outputs), subcircuit.Outputs.Count),
                (nameof(Subcircuit.Subcircuits), subcircuit.Subcircuits.Count),
                (nameof(Subcircuit.Wires), subcircuit.Wires.Count)
            ]);

            var menuOption = await prompter.SelectEnumAsync<MenuOptions>($"[bold]{subcircuit.Title} ({subcircuit.Id})[/]");

            switch (menuOption)
            {
                case MenuOptions.Simulate:
                    await simulationFlow.RunSimulationMenuAsync(subcircuit);
                    break;

                case MenuOptions.ShowTree:
                    renderer.Clear();
                    BuildTree(subcircuit);
                    break;

                case MenuOptions.Emit:
                    await emitFlow.RunMenuAsync(subcircuit);
                    break;

                case MenuOptions.Export:
                    await exportFlow.RunMenuAsync(subcircuit);
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task SubcircuitBuildTreeAsync(int id)
    {
        var subcircuit = await service.GetByIdAsync(id);
        if (subcircuit is null)
        {
            renderer.DrawError($"Subcircuit with id {id} was not found");
            return;
        }

        renderer.Clear();
        BuildTree(subcircuit);
    }

    private void BuildTree(Subcircuit parentSubcircuit, int maxDepth = 32)
    {
        var tree = new Tree(GetSubcircuitLabel(parentSubcircuit));
        int depth = 0;

        Build(parentSubcircuit, text => tree.AddNode(text), depth);

        renderer.Write(tree);

        void Build(Subcircuit subcircuit, Func<string, TreeNode> addChild, int depth)
        {
            if (depth >= maxDepth)
            {
                addChild($"[grey] Max depth of {maxDepth} reached[/]");
                return;
            }

            foreach (var logicGate in subcircuit.LogicGates)
                addChild(GetLogicGateLabel(logicGate));

            foreach (var childSubcircuit in subcircuit.Subcircuits)
            {
                var childNode = addChild(GetSubcircuitLabel(childSubcircuit));
                Build(childSubcircuit, label => childNode.AddNode(label), depth + 1);
            }
        }
    }

    private static string GetLogicGateLabel(LogicGate logicGate) =>
        $"[blue]{Markup.Escape(logicGate.TruthTable.HeptaIndex)}[/]";

    private static string GetSubcircuitLabel(Subcircuit subcircuit) =>
        $"[yellow]{Markup.Escape(subcircuit.Title)}[/]";
}