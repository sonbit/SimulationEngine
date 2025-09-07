using Microsoft.VisualBasic;
using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Cli.IOHandlers;
using SimulationEngine.Domain.Models;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Text;

namespace SimulationEngine.Cli.Commands.Simulation;

public sealed class SimListCommand(ISubCircuitService svc, IInteraction interaction) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var all = await svc.GetAllAsync();

        // Let user choose path
        var path = AnsiConsole.Prompt(
            new SelectionPrompt<string>().Title("Simulation")
                .AddChoices("Pick from list", "Enter id", "Back"));

        SubCircuit? subCircuit = path switch
        {
            "Pick from list" => interaction.SelectOrBack("Select subcircuit", all, s => $"{s.Title} [grey]({s.Id})[/]"),
            "Enter id" => await svc.GetByIdAsync(interaction.AskId("Enter id:")),
            _ => null
        };

        if (subCircuit is null) return 0;

        await SimulatorReplAsync(subCircuit, _sim);
        return 0;
    }

    public static async Task SimulatorReplAsync(SubCircuitDto sub, ISimulator sim, CancellationToken ct)
    {
        AnsiConsole.MarkupLine($"[bold green]Simulator[/] — {Markup.Escape(sub.Title)} [grey]({sub.Id})[/]");
        using var session = await sim.StartAsync(sub, ct);

        AnsiConsole.MarkupLine("[grey]Type input lines. Press [bold]Esc[/] to go back.[/]");
        Console.TreatControlCAsInput = true;

        var buffer = new StringBuilder();
        while (!ct.IsCancellationRequested)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape) break;
                if (key.Key == ConsoleKey.Enter)
                {
                    var line = buffer.ToString();
                    buffer.Clear();
                    await session.FeedAsync(line, ct);
                    AnsiConsole.MarkupLine($"[blue]›[/] {Markup.Escape(line)}");
                }
                else if (key.Key == ConsoleKey.Backspace && buffer.Length > 0)
                {
                    buffer.Remove(buffer.Length - 1, 1);
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    buffer.Append(key.KeyChar);
                }
            }
            await Task.Delay(10, ct);
        }
    }
}
