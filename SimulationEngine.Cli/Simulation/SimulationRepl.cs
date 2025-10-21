using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Validators;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Simulator;
using Spectre.Console;
using Spectre.Console.Rendering;
using System.Text;

namespace SimulationEngine.Cli.Simulation;

public static class SimulationRepl
{
    public static async Task<int> SimulateReplAsync(Subcircuit subcircuit, IRenderer renderer, bool normalize = false)
    {
        renderer.DrawHeader($"Simulator");

        var inputs = string.Join("\n", subcircuit.Inputs
            .Select(port => $"  {Markup.Escape(port.Title)}{(!normalize ? $" - {Markup.Escape(port.GetRadix().GetDescription())}" : "")}"));

        var outputs = string.Join("\n", subcircuit.Outputs
            .Select(port => $"  {Markup.Escape(port.Title)}{(!normalize ? $" - {Markup.Escape(port.GetRadix().GetDescription())}" : "")}"));

        renderer.DrawPanel(subcircuit.Title, $"Inputs \n{inputs}\n\nOutputs \n{outputs}");

        var inputCount = subcircuit.Inputs.Count;
        var outputCount = subcircuit.Outputs.Count;
        renderer.DrawLine($"[grey]Type or paste {inputCount} inputs to get {outputCount} outputs[/]");
        renderer.DrawLine("[grey]Press [bold]Esc[/] when done[/]");

        var allowedValuesPerInput = InputValidator.GetAllowedValuesPerInput(subcircuit);
        var simulationSession = SimulationSession.Build(subcircuit);

        var buf = new StringBuilder();
        var history = new List<(string In, string Out)>();
        string? status = null;
        bool isError = false;
        bool done = false;

        IRenderable Screen()
        {
            var historyRenderable = history.Count > 0
                ? renderer.DrawHistoryPanel(
                    history,
                    panelHeader: "Simulation history",
                    leftHeader: "Inputs",
                    rightHeader: "Outputs")
                : Text.Empty;

            return renderer.DrawStack(
                historyRenderable,
                renderer.DrawInputPanel(buf, inputCount, status, isError)
            );
        }

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
                        if (buf.Length > 0)
                        {
                            buf.Remove(buf.Length - 1, 1);
                            status = null;
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (buf.Length != inputCount)
                        {
                            status = $"Fill in remaining {inputCount - buf.Length}/{inputCount} inputs";
                            isError = true;
                            break;
                        }

                        var inputString = buf.ToString();
                        var outputs = simulationSession.Simulate(inputString, normalize);

                        history.Add((inputString, outputs));
                        if (history.Count > 200)
                            history.RemoveAt(0);

                        status = $"{inputString} {outputs}";
                        isError = false;
                        buf.Clear();
                        break;

                    default:
                        var ch = key.KeyChar;
                        if (char.IsControl(ch))
                            break;

                        if (buf.Length >= inputCount)
                        {
                            status = $"Max {inputCount} inputs";
                            isError = true;
                            break;
                        }

                        status = InputValidator.Validate(subcircuit, ch, buf.Length, normalize, allowedValuesPerInput);
                        isError = status is not null;

                        if (isError)
                            break;

                        buf.Append(ch);
                        break;
                }

                ctx.UpdateTarget(Screen());
                ctx.Refresh();
            }
        });

        renderer.Clear();

        return 0;
    }
}