using SimulationEngine.Application.Services.Database.SubCircuits;
using SimulationEngine.Application.Services.Export;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows;

public class ExportFlow(IPrompter prompter, IRenderer renderer, IExportService service, ISubCircuitService subCircuitService)
{
    private enum MenuOptions
    {
        [Description("Export Verilog files to desktop")] ExportVerilogFiles,
        [Description("Export Verilog files to desktop (zipped)")] ExportVerilogFilesZipped,
        [Description("Export Verilog files with top and xdc to desktop")] ExportVerilogFilesWithTopXdc,
        [Description("Export Verilog files with top and xdc to desktop (zipped)")] ExportVerilogFilesWithTopXdcZipped,
        [Description("Export Verilog files with top, xdc and 7 segment display to desktop")] ExportVerilogFilesWithTopXdc7Seg,
        [Description("Export Verilog files with top, xdc and 7 segment display desktop (zipped)")] ExportVerilogFilesWithTopXdc7SegZipped,
        Back
    }

    public async Task RunMenuAsync(SubCircuit subCircuit)
    {
        renderer.Clear();

        while (true)
        {
            var menuOption = await prompter.SelectEnumAsync<MenuOptions>("[bold]Select an export option[/]");

            switch (menuOption)
            {
                case MenuOptions.ExportVerilogFiles:
                case MenuOptions.ExportVerilogFilesZipped:
                    ExportVerilog(subCircuit, menuOption == MenuOptions.ExportVerilogFilesZipped);
                    break;

                case MenuOptions.ExportVerilogFilesWithTopXdc:
                case MenuOptions.ExportVerilogFilesWithTopXdc7Seg:
                    ExportVerilogWithTopAndXdc(subCircuit, menuOption == MenuOptions.ExportVerilogFilesWithTopXdc7Seg);
                    break;

                case MenuOptions.ExportVerilogFilesWithTopXdcZipped:
                case MenuOptions.ExportVerilogFilesWithTopXdc7SegZipped:
                    ExportVerilogWithTopAndXdc(subCircuit, menuOption == MenuOptions.ExportVerilogFilesWithTopXdc7SegZipped, true);
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task ExportVerilog(int id, bool includeTop, bool zip, string outputPath = "")
    {
        var subCircuit = await subCircuitService.GetByIdAsync(id);
        if (subCircuit is null)
        {
            renderer.DrawError($"Subcircuit with id {id} was not found.");
            return;
        }

        ExportVerilog(subCircuit, includeTop, zip, outputPath);
    }

    public async Task ExportVerilog(string? title, bool includeTop, bool zip, string outputPath = "")
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

        ExportVerilog(subCircuit, includeTop, zip, outputPath);
    }

    private void ExportVerilog(SubCircuit subCircuit, bool includeTop, bool zip, string outputPath = "")
    {
        if (includeTop)
            ExportVerilogWithTopAndXdc(subCircuit, true, zip, outputPath);
        else
            ExportVerilog(subCircuit, zip, outputPath);
    }

    private void ExportVerilog(SubCircuit subCircuit, bool zip = false, string outputPath = "")
    {
        var testString = DesignUtils.GetTestString(subCircuit.Title);
        var path = service.ExportVerilog(subCircuit, testString, zip, outputPath);
        renderer.Clear();
        renderer.Write(path);
        renderer.DrawLine(Environment.NewLine);
    }

    private void ExportVerilogWithTopAndXdc(SubCircuit subCircuit, bool include7SegmentDisplay = false, bool zip = false, string outputPath = "")
    {
        renderer.Clear();

        try
        {
            var testString = DesignUtils.GetTestString(subCircuit.Title);
            var path = service.ExportVerilogWithTopAndXdc(subCircuit, testString, include7SegmentDisplay, zip, outputPath);
            renderer.Write(path);
            renderer.DrawLine(Environment.NewLine);
        }
        catch (InvalidOperationException ioe)
        {
            renderer.DrawError(ioe.Message);
        }
    }
}