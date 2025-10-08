using SimulationEngine.Application.Services.Database.SubCircuits;
using SimulationEngine.Application.Services.Export;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Settings.Enums;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows;

public class EmitFlow(IPrompter prompter, IRenderer renderer, IExportService service, ISubCircuitService subCircuitService)
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

    public async Task RunMenuAsync(SubCircuit subCircuit)
    {
        renderer.Clear();

        while (true)
        {
            var menuOption = await prompter.SelectEnumAsync<MenuOptions>("[bold]Select an emit option[/]");

            switch (menuOption)
            {
                case MenuOptions.EmitVerilog:
                    EmitVerilog(subCircuit);
                    break;

                case MenuOptions.EmitVerilogTestbnech:
                    EmitVerilogTestbench(subCircuit);
                    break;

                case MenuOptions.EmitVerilogTop:
                case MenuOptions.EmitVerilogTop7Seg:
                    EmitVerilogTop(subCircuit, menuOption == MenuOptions.EmitVerilogTop7Seg);
                    break;

                case MenuOptions.Emit7Seg:
                    EmitVerilog7SegmentDisplay();
                    break;

                case MenuOptions.EmitXdc:
                case MenuOptions.EmitXdc7Seg:
                    EmitXdc(subCircuit, menuOption == MenuOptions.EmitXdc7Seg);
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task EmitVerilog(int id, EmitKind emitKind)
    {
        var subCircuit = await subCircuitService.GetByIdAsync(id);
        if (subCircuit is null)
        {
            renderer.DrawError($"Subcircuit with id {id} was not found.");
            return;
        }

        EmitVerilog(subCircuit, emitKind);
    }

    public async Task EmitVerilog(string? title, EmitKind emitKind)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            renderer.DrawError($"Provide a title");
            return;
        }

        var subCircuit = await subCircuitService.GetByTitleAsync(title);
        if (subCircuit is null)
        {
            renderer.DrawError($"Subcircuit with title {title} was not found.");
            return;
        }

        EmitVerilog(subCircuit, emitKind);
    }

    private void EmitVerilog(SubCircuit subCircuit, EmitKind emitKind)
    {
        renderer.Clear();

        switch (emitKind)
        {
            case EmitKind.Verilog:
                EmitVerilog(subCircuit);
                break;

            case EmitKind.Testbench:
                EmitVerilogTestbench(subCircuit);
                break;

            case EmitKind.Top:
            case EmitKind.Top7Seg:
                EmitVerilogTop(subCircuit, emitKind == EmitKind.Top7Seg);
                break;

            case EmitKind.SevenSeg:
                EmitVerilog7SegmentDisplay();
                break;

            case EmitKind.Xdc:
            case EmitKind.Xdc7Seg:
                EmitXdc(subCircuit, emitKind == EmitKind.Xdc7Seg);
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

    private void EmitVerilog(SubCircuit subCircuit)
    {
        var verilog = service.EmitVerilog(subCircuit);
        renderer.Clear();
        renderer.Write(verilog);
        renderer.DrawLine(Environment.NewLine);
    }

    private void EmitVerilogTestbench(SubCircuit subCircuit)
    {
        var testString = DesignUtils.GetTestString(subCircuit.Title);
        if (string.IsNullOrWhiteSpace(testString))
        {
            renderer.DrawError($"No test string found for SubCircuit {subCircuit.Id}");
            return;
        }

        var testbench = service.EmitVerilogTestbench(subCircuit, testString);
        if (testbench == null)
        {
            renderer.DrawError($"Unable to get testbench for SubCircuit {subCircuit.Id}");
            return;
        }

        renderer.Clear();
        renderer.Write(testbench);
        renderer.DrawLine(Environment.NewLine);
    }

    private void EmitVerilogTop(SubCircuit subCircuit, bool include7SegmentDisplay)
    {
        renderer.Clear();

        try
        {
            var verilogTop = service.EmitVerilogTop(subCircuit, include7SegmentDisplay);
            renderer.Write(verilogTop);
            renderer.DrawLine(Environment.NewLine);
        }
        catch (InvalidOperationException ioe)
        {
            renderer.DrawError(ioe.Message);
        }
    }

    private void EmitXdc(SubCircuit subCircuit, bool include7SegmentDisplay)
    {
        renderer.Clear();

        try
        {
            var xdc = service.EmitXdc(subCircuit, include7SegmentDisplay);
            renderer.Write(xdc);
            renderer.DrawLine(Environment.NewLine);
        }
        catch (InvalidOperationException ioe)
        {
            renderer.DrawError(ioe.Message);
        }
    }
}