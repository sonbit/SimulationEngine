using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Commands.Settings;
using SimulationEngine.Cli.Handlers.InputOutput;
using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Models;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuits;

public sealed class SubCircuitsShowTreeCommand(ISubCircuitService service, IInputOutput inputOutput, IRenderer renderer) : AsyncCommand<FindByIdSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, FindByIdSettings settings)
    {
        var id = settings.Id;

        if (id == 0 && int.TryParse(await inputOutput.PromptValidateAsync("Id"), out var promptId))
            id = promptId;

        if (id == 0)
        {
            renderer.DrawError("Invalid id");
            return 1;
        }

        var subCircuit = await service.GetAsync(id);
        if (subCircuit is null)
        {
            renderer.DrawError("Not found");
            return 1;
        }

        renderer.Clear();

        BuildTree(subCircuit);

        return 0;
    }

    public static void BuildTree(SubCircuit parentSubCircuit, int maxDepth = 32)
    {
        var tree = new Tree(GetSubCircuitLabel(parentSubCircuit));
        int depth = 0;

        Build(parentSubCircuit, text => tree.AddNode(text), depth);

        AnsiConsole.Write(tree);

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