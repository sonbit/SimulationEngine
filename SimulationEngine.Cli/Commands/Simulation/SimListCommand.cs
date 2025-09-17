using SimulationEngine.Application.Converters;
using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Handlers.InputOutput;
using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Core.Engine;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Rendering;
using System.Text;

namespace SimulationEngine.Cli.Commands.Simulation;

public sealed class SimListCommand(ISubCircuitService service, IInputOutput inputOutput, IRenderer renderer) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var path = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Simulation").AddChoices("Pick from list", "Enter id", "Back"));

        SubCircuit? subCircuit = path switch
        {
            "Pick from list" => inputOutput.SelectOrBack("Select subcircuit", await service.GetAllAsync(), s => $"{s.Title} [grey]({s.Id})[/]"),
            "Enter id" => await service.GetByIdAsync(inputOutput.AskId("Enter id:")),
            _ => null
        };

        if (subCircuit is null) 
            return 0;

        subCircuit = await service.GetAsync(subCircuit.Id);

        var simulationSession = SimulationSession.Build(subCircuit);

        await SimulatorReplAsync(simulationSession, inputOutput, renderer);
        return 0;
    }

    public static async Task SimulatorReplAsync(SimulationSession session, IInputOutput intputOutput, IRenderer renderer)
    {
        var sub = session.SubCircuit;
        var inputCount = sub.Inputs.Count;
        var inputNames = string.Join(", ", sub.Inputs.Select(p => p.Title));

        renderer.DrawHeader($"Simulator — {sub.Title} ({sub.Id})");
        AnsiConsole.MarkupLine($"[grey]Type {inputCount} inputs ({Markup.Escape(inputNames)}). Press [bold]Esc[/] to go back.[/]");

        var stringBuilder = new StringBuilder();
        var history = new List<(string In, string Out)>();
        string? statusText = null;
        var isError = false;
        var done = false;

        IRenderable Screen() => renderer.Stack(
            history.Count > 0 ? renderer.HistoryPanel(history) : Text.Empty,
            renderer.InputPanel(stringBuilder, inputCount, statusText, isError)
        );

        await AnsiConsole.Live(Screen()).AutoClear(false).StartAsync(async ctx =>
        {
            ctx.UpdateTarget(Screen());
            ctx.Refresh();

            while (!done)
            {
                if (!Console.KeyAvailable) 
                { 
                    await Task.Delay(16); 
                    continue; 
                }

                var key = Console.ReadKey(intercept: true);
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        done = true;
                        break;

                    case ConsoleKey.Backspace:
                        if (stringBuilder.Length <= 0)
                            break;
                      
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        statusText = null;
                        break;

                    case ConsoleKey.Enter:
                        var inputString = stringBuilder.ToString();
                        if (inputString.Length != inputCount)
                        {
                            statusText = $"Input length must be {inputCount}";
                            isError = true;
                            break;
                        }

                        session.SetInputs(TestStringConverter.Convert(inputString)[0].Inputs);

                        var outputs = session.GetOutputs();
                        var outputString = TestStringConverter.Convert(outputs);

                        history.Add((inputString, outputString));
                        if (history.Count > 200) 
                            history.RemoveAt(0);

                        statusText = $"{inputString} {outputString}";
                        isError = false;
                        stringBuilder.Clear();
                        break;
      
                    default:
                        if (char.IsControl(key.KeyChar) || !char.IsDigit(key.KeyChar))
                            break;

                        if (!"012".Contains(key.KeyChar))
                        {
                            statusText = "Only ternary input (0, 1, 2) is accepted";
                            isError = true;
                        }
                        else if (stringBuilder.Length >= inputCount)
                        {
                            statusText = $"Max {inputCount} digits";
                            isError = true;
                        }
                        else
                        {
                            stringBuilder.Append(key.KeyChar);
                            statusText = null;
                        }
                        break;
                }

                ctx.UpdateTarget(Screen());
                ctx.Refresh();
            }
        });
    }
}