using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Cli.Commands.Settings;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTable;

public sealed class TruthTableFindCommand(ITruthTableService svc) : AsyncCommand<FindByIdSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, FindByIdSettings s)
    {
        var x = await svc.GetByIdAsync(s.Id);
        if (x is null) { AnsiConsole.MarkupLine("[red]Not found[/]"); return 1; }
        AnsiConsole.Write(new Panel($"[bold]{Markup.Escape(x.HeptaIndex)}[/]\n[grey]{x.Id}[/]").Header("TruthTable"));
        return 0;
    }
}
