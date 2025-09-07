using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Cli.IOHandlers;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuit;

public sealed class SubCircuitListCommand(ISubCircuitService svc, IInteraction interaction) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var all = await svc.GetAllAsync();

        var table = new Table().RoundedBorder().Expand().Title("SubCircuits");
        table.AddColumn("Id"); table.AddColumn("Title");
        foreach (var s in all)
            table.AddRow($"{s.Id}", Markup.Escape(s.Title));
        AnsiConsole.Write(table);

        // Optional: allow quick select to view a single item
        var pick = interaction.SelectOrBack("Select to view or Back", all, s => $"{s.Title} ({s.Id})");
        if (pick is not null)
            AnsiConsole.Panel($"[bold]{Markup.Escape(pick.Title)}[/]\n[grey]{pick.Id}[/]", "SubCircuit");

        return 0;
    }
}
