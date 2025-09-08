using Microsoft.VisualBasic;
using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Application.Utils;
using SimulationEngine.Cli.IOHandlers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Core.Engine;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Text;

namespace SimulationEngine.Cli.Commands.Simulation;

public sealed class SimListCommand(ISubCircuitService service, IInteraction interaction) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var path = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Simulation").AddChoices("Pick from list", "Enter id", "Back"));

        SubCircuit? subCircuit = path switch
        {
            "Pick from list" => interaction.SelectOrBack("Select subcircuit", await service.GetAllAsync(), s => $"{s.Title} [grey]({s.Id})[/]"),
            "Enter id" => await service.GetByIdAsync(interaction.AskId("Enter id:")),
            _ => null
        };

        if (subCircuit is null) 
            return 0;

        var simulationSession = SimulationSession.Build(subCircuit);

        await SimulatorReplAsync(simulationSession);
        return 0;
    }

    public static async Task SimulatorReplAsync(SimulationSession simulationSession)
    {
        AnsiConsole.MarkupLine($"[bold green]Simulator[/] — {Markup.Escape(simulationSession.SubCircuit.Title)} [grey]({simulationSession.SubCircuit.Id})[/]");

        AnsiConsole.MarkupLine("[grey]Type input lines. Press [bold]Esc[/] to go back.[/]");
        Console.TreatControlCAsInput = true;

        var buffer = new StringBuilder();
        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape) 
                    break;

                if (key.Key == ConsoleKey.Enter)
                {
                    var line = buffer.ToString();
                    buffer.Clear();

                    if (line.Length != simulationSession.SubCircuit.Inputs.Count)
                    {
                        AnsiConsole.MarkupLine($"[red]Input length must be {simulationSession.SubCircuit.Inputs.Count}[/]");
                        continue;
                    }

                    simulationSession.SetInputs(TestStringConverter.Convert(line)[0].Inputs);
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
            await Task.Delay(10);
        }
    }
}
