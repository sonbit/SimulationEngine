using SimulationEngine.Application.Services.Analysis;
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
    ISubcircuitAnalysisService analysisService,
    SimulationFlow simulationFlow, 
    EmitFlow emitFlow,
    ExportFlow exportFlow)
{
    private enum MenuOptions
    {
        Simulate,
        [Description("Draw tree")] ShowTree,
        [Description("Count gates")] CountGates,
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

                case MenuOptions.CountGates:
                    await ShowGateSummaryAsync(subcircuit.Id);
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

    public async Task ShowGateSummaryAsync(int id)
    {
        var subcircuit = await service.GetByIdAsync(id);
        if (subcircuit is null)
        {
            renderer.DrawError($"Subcircuit with id {id} was not found");
            return;
        }

        var summary = analysisService.SummarizeGates(subcircuit);

        renderer.Clear();
        renderer.DrawHeader($"{subcircuit.Title} ({subcircuit.Id}) gate summary");

        var arityTable = new Table().RoundedBorder().BorderColor(Color.Grey).Title("By Arity");
        arityTable.AddColumn("Arity");
        arityTable.AddColumn("Count");

        foreach (var kvp in summary.ByArity.OrderBy(pair => pair.Key))
            arityTable.AddRow(kvp.Key.ToString(), kvp.Value.ToString());

        var heptaTable = new Table().RoundedBorder().BorderColor(Color.Grey).Title("By HeptaIndex");
        heptaTable.AddColumn("HeptaIndex");
        heptaTable.AddColumn("Count");

        foreach (var kvp in summary.ByHeptaIndex.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key, StringComparer.Ordinal))
            heptaTable.AddRow(Markup.Escape(kvp.Key), kvp.Value.ToString());

        renderer.Write(new Rows(arityTable, new Markup(string.Empty), heptaTable));
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
