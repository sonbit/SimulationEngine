using SimulationEngine.Application.Services.SubCircuits;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuit;

public sealed class SubCircuitTreeSettings : CommandSettings
{
    [CommandOption("--id <ID>")] public int Id { get; set; }
}

public sealed class SubCircuitShowTreeCommand(ISubCircuitService svc) : AsyncCommand<SubCircuitTreeSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, SubCircuitTreeSettings s)
    {
        var root = await svc.GetByIdAsync(s.Id);
        if (root is null) { AnsiConsole.MarkupLine("[red]Not found[/]"); return 1; }

        var tree = new Tree($"[yellow]{Markup.Escape(root.Title)}[/] [grey]({root.Id})[/]");

        //async Task AddSub(TreeNode node, Guid id, int depth)
        //{
        //    // children subcircuits
        //    var children = await svc.GetChildrenAsync(id);
        //    foreach (var c in children)
        //    {
        //        var n = node.AddNode($"[blue]{Markup.Escape(c.Title)}[/] [grey]({c.Id})[/]");
        //        await AddSub(n, c.Id, depth + 1);
        //    }

        //    // truth tables on this node
        //    var tts = await svc.GetTruthTablesAsync(id);
        //    if (tts.Count > 0)
        //    {
        //        var ttNode = node.AddNode("[purple]TruthTables[/]");
        //        foreach (var tt in tts)
        //            ttNode.AddNode($"{Markup.Escape(tt.HeptaIndex)} [grey]({tt.Id})[/]");
        //    }
        //}

        //await AddSub(tree.AddNode($"[green]{Markup.Escape(root.Title)}[/]"), root.Id, 0);
        AnsiConsole.Write(tree);
        return 0;
    }
}
