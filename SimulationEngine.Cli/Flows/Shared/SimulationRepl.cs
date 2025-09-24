using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Simulator;
using Spectre.Console;
using Spectre.Console.Rendering;
using System.Text;

namespace SimulationEngine.Cli.Flows.Shared;

public static class SimulationRepl
{
    public static async Task ReplAsync(SubCircuit subCircuit, IRenderer renderer, bool normalize = false)
    {
        renderer.DrawHeader($"Simulator");

        var inputs = string.Join("\n", subCircuit.Inputs
            .Select(port => $"  {Markup.Escape(port.Title)}{(!normalize ? $" - {Markup.Escape(port.GetRadix().GetDescription())}" : "")}"));

        var outputs = string.Join("\n", subCircuit.Outputs
            .Select(port => $"  {Markup.Escape(port.Title)}{(!normalize ? $" - {Markup.Escape(port.GetRadix().GetDescription())}" : "")}"));

        renderer.DrawPanel(subCircuit.Title, $"Inputs \n{inputs}\n\nOutputs \n{outputs}");

        var inputCount = subCircuit.Inputs.Count;
        var outputCount = subCircuit.Outputs.Count;
        AnsiConsole.MarkupLine($"[grey]Type {inputCount} inputs to get {outputCount} outputs. \nPress [bold]Esc[/] to go back.[/]");

        var allowedValuesPerInput = SimulationUtils.GetAllowedValuesPerInput(subCircuit);
        var simulationSession = SimulationSession.Build(subCircuit);

        var buf = new StringBuilder();
        var history = new List<(string In, string Out)>();
        string? status = null;
        bool isError = false;
        bool done = false;

        IRenderable Screen()
        {
            var historyRenderable = history.Count > 0
                ? renderer.HistoryPanel(
                    history,
                    panelHeader: "Simulation History",
                    leftHeader: "Inputs",
                    rightHeader: "Outputs")
                : Text.Empty;

            return renderer.Stack(
                historyRenderable,
                renderer.InputPanel(buf, inputCount, status, isError)
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
                        var inputText = buf.ToString();
                        if (inputText.Length != inputCount)
                        {
                            status = $"Input length must be {inputCount}";
                            isError = true;
                            break;
                        }

                        string outputText;
                        if (normalize)
                        {
                            simulationSession.SetInputs(SimulationUtils.GetInputsAsByteArray(inputs));
                            outputText = SimulationUtils.GetOutputsAsString(simulationSession.GetOutputs());
                        }
                        else
                        {
                            simulationSession.SetInputsWithRadix(inputText);
                            outputText = simulationSession.GetOutputsWithRadix();
                        }

                        history.Add((inputText, outputText));
                        if (history.Count > 200)
                            history.RemoveAt(0);

                        status = $"{inputText} {outputText}";
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

                        if (normalize)
                        {
                            if (ch is '0' or '1' or '2')
                            {
                                buf.Append(ch);
                                status = null;
                                isError = false;
                            }
                            else
                            {
                                status = "Only unbalanced ternary (0,1,2) is accepted";
                                isError = true;
                            }
                        }
                        else
                        {
                            var position = buf.Length;
                            var allowedValues = allowedValuesPerInput[position];

                            if (allowedValues.Contains(ch))
                            {
                                buf.Append(ch);
                                status = null;
                                isError = false;
                            }
                            else
                            {
                                var input = subCircuit.Inputs[position];
                                status =
                                    $"Input {position + 1} expects {input.GetRadix().GetDescription()} " +
                                    $"values ({string.Join(", ", allowedValues.OrderBy(c => c).Select(c => c.ToString()))})";
                                isError = true;
                            }
                        }
                        break;
                }

                ctx.UpdateTarget(Screen());
                ctx.Refresh();
            }
        });

        renderer.Clear();
    }
}