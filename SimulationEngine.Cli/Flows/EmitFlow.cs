using SimulationEngine.Application.Services.Database.Subcircuits;
using SimulationEngine.Application.Services.Export;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Settings.Enums;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows;

public class EmitFlow(IPrompter prompter, IRenderer renderer, IExportService service, ISubcircuitService subcircuitService)
{
    private enum MenuOptions
    {
        [Description("Emit Verilog")] EmitVerilog,
        [Description("Emit Verilog testbench")] EmitVerilogTestbnech,
        [Description("Emit Verilog top")] EmitVerilogTop,
        [Description("Emit Verilog top with 7 segment display")] EmitVerilogTop7Seg,
        [Description("Emit Verilog 7 segment display")] Emit7Seg,
        [Description("Emit XDC")] EmitXdc,
        [Description("Emit XDC with 7 segment display")] EmitXdc7Seg,
        Back
    }

    public async Task RunMenuAsync(Subcircuit subcircuit)
    {
        renderer.Clear();

        while (true)
        {
            var menuOption = await prompter.SelectEnumAsync<MenuOptions>("[bold]Select an emit option[/]");

            switch (menuOption)
            {
                case MenuOptions.EmitVerilog:
                    EmitVerilog(subcircuit);
                    break;

                case MenuOptions.EmitVerilogTestbnech:
                    EmitVerilogTestbench(subcircuit);
                    break;

                case MenuOptions.EmitVerilogTop:
                case MenuOptions.EmitVerilogTop7Seg:
                    EmitVerilogTop(subcircuit, menuOption == MenuOptions.EmitVerilogTop7Seg);
                    break;

                case MenuOptions.Emit7Seg:
                    EmitVerilog7SegmentDisplay();
                    break;

                case MenuOptions.EmitXdc:
                case MenuOptions.EmitXdc7Seg:
                    EmitXdc(subcircuit, menuOption == MenuOptions.EmitXdc7Seg);
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task EmitVerilog(int id, EmitKind emitKind)
    {
        var subcircuit = await subcircuitService.GetByIdAsync(id);
        if (subcircuit is null)
        {
            renderer.DrawError($"Subcircuit with id {id} was not found.");
            return;
        }

        EmitVerilog(subcircuit, emitKind);
    }

    public async Task EmitVerilog(string? title, EmitKind emitKind)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            renderer.DrawError($"Provide a title");
            return;
        }

        var subcircuit = await subcircuitService.GetByTitleAsync(title);
        if (subcircuit is null)
        {
            renderer.DrawError($"Subcircuit with title {title} was not found.");
            return;
        }

        EmitVerilog(subcircuit, emitKind);
    }

    private void EmitVerilog(Subcircuit subcircuit, EmitKind emitKind)
    {
        renderer.Clear();

        switch (emitKind)
        {
            case EmitKind.Verilog:
                EmitVerilog(subcircuit);
                break;

            case EmitKind.Testbench:
                EmitVerilogTestbench(subcircuit);
                break;

            case EmitKind.Top:
            case EmitKind.Top7Seg:
                EmitVerilogTop(subcircuit, emitKind == EmitKind.Top7Seg);
                break;

            case EmitKind.SevenSeg:
                EmitVerilog7SegmentDisplay();
                break;

            case EmitKind.Xdc:
            case EmitKind.Xdc7Seg:
                EmitXdc(subcircuit, emitKind == EmitKind.Xdc7Seg);
                break;
        }
    }

    private void EmitVerilog7SegmentDisplay()
    {
        var verilog7SegmentDisplay = service.EmitVerilog7SegmentDisplay();
        renderer.Clear();
        renderer.Write(verilog7SegmentDisplay);
        renderer.DrawLine(Environment.NewLine);
    }

    private void EmitVerilog(Subcircuit subcircuit)
    {
        var verilog = service.EmitVerilog(subcircuit);
        renderer.Clear();
        renderer.Write(verilog);
        renderer.DrawLine(Environment.NewLine);
    }

    private void EmitVerilogTestbench(Subcircuit subcircuit)
    {
        var testString = DesignUtils.GetTestString(subcircuit.Title);
        if (string.IsNullOrWhiteSpace(testString))
        {
            renderer.DrawError($"No test string found for Subcircuit {subcircuit.Id}");
            return;
        }

        var testbench = service.EmitVerilogTestbench(subcircuit, testString);
        if (testbench == null)
        {
            renderer.DrawError($"Unable to get testbench for Subcircuit {subcircuit.Id}");
            return;
        }

        renderer.Clear();
        renderer.Write(testbench);
        renderer.DrawLine(Environment.NewLine);
    }

    private void EmitVerilogTop(Subcircuit subcircuit, bool include7SegmentDisplay)
    {
        renderer.Clear();

        try
        {
            var verilogTop = service.EmitVerilogTop(subcircuit, include7SegmentDisplay);
            renderer.Write(verilogTop);
            renderer.DrawLine(Environment.NewLine);
        }
        catch (InvalidOperationException ioe)
        {
            renderer.DrawError(ioe.Message);
        }
    }

    private void EmitXdc(Subcircuit subcircuit, bool include7SegmentDisplay)
    {
        renderer.Clear();

        try
        {
            var xdc = service.EmitXdc(subcircuit, include7SegmentDisplay);
            renderer.Write(xdc);
            renderer.DrawLine(Environment.NewLine);
        }
        catch (InvalidOperationException ioe)
        {
            renderer.DrawError(ioe.Message);
        }
    }
}