using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Cli.Commands.Settings;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuit;

public sealed class SubCircuitFindCommand(ISubCircuitService svc) : AsyncCommand<FindByIdSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, FindByIdSettings s)
    {
        var item = await svc.GetByIdAsync(s.Id);
        if (item is null) { AnsiConsole.MarkupLine("[red]Not found[/]"); return 1; }
        AnsiConsole.Write(new Panel($"[bold]{Markup.Escape(item.Title)}[/]\n[grey]{item.Id}[/]").Header("SubCircuit").RoundedBorder());
        return 0;
    }
}
