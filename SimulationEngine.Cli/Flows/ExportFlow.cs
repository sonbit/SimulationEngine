using SimulationEngine.Application.Services.Database.Subcircuits;
using SimulationEngine.Application.Services.Export;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows;

public class ExportFlow(IPrompter prompter, IRenderer renderer, IExportService service, ISubcircuitService subcircuitService)
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

    public async Task RunMenuAsync(Subcircuit subcircuit)
    {
        renderer.Clear();

        while (true)
        {
            var menuOption = await prompter.SelectEnumAsync<MenuOptions>("[bold]Select an export option[/]");

            switch (menuOption)
            {
                case MenuOptions.ExportVerilogFiles:
                case MenuOptions.ExportVerilogFilesZipped:
                    ExportVerilog(subcircuit, menuOption == MenuOptions.ExportVerilogFilesZipped);
                    break;

                case MenuOptions.ExportVerilogFilesWithTopXdc:
                case MenuOptions.ExportVerilogFilesWithTopXdc7Seg:
                    ExportVerilogWithTopAndXdc(subcircuit, menuOption == MenuOptions.ExportVerilogFilesWithTopXdc7Seg);
                    break;

                case MenuOptions.ExportVerilogFilesWithTopXdcZipped:
                case MenuOptions.ExportVerilogFilesWithTopXdc7SegZipped:
                    ExportVerilogWithTopAndXdc(subcircuit, menuOption == MenuOptions.ExportVerilogFilesWithTopXdc7SegZipped, true);
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task ExportVerilog(int id, bool includeTop, bool zip, string outputPath = "")
    {
        var subcircuit = await subcircuitService.GetByIdAsync(id);
        if (subcircuit is null)
        {
            renderer.DrawError($"Subcircuit with id {id} was not found.");
            return;
        }

        ExportVerilog(subcircuit, includeTop, zip, outputPath);
    }

    public async Task ExportVerilog(string? title, bool includeTop, bool zip, string outputPath = "")
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

        ExportVerilog(subcircuit, includeTop, zip, outputPath);
    }

    private void ExportVerilog(Subcircuit subcircuit, bool includeTop, bool zip, string outputPath = "")
    {
        if (includeTop)
            ExportVerilogWithTopAndXdc(subcircuit, true, zip, outputPath);
        else
            ExportVerilog(subcircuit, zip, outputPath);
    }

    private void ExportVerilog(Subcircuit subcircuit, bool zip = false, string outputPath = "")
    {
        var testString = DesignUtils.GetTestString(subcircuit.Title);
        var path = service.ExportVerilog(subcircuit, testString, zip, outputPath);
        renderer.Clear();
        renderer.Write(path);
        renderer.DrawLine(Environment.NewLine);
    }

    private void ExportVerilogWithTopAndXdc(Subcircuit subcircuit, bool include7SegmentDisplay = false, bool zip = false, string outputPath = "")
    {
        renderer.Clear();

        try
        {
            var testString = DesignUtils.GetTestString(subcircuit.Title);
            var path = service.ExportVerilogWithTopAndXdc(subcircuit, testString, include7SegmentDisplay, zip, outputPath);
            renderer.Write(path);
            renderer.DrawLine(Environment.NewLine);
        }
        catch (InvalidOperationException ioe)
        {
            renderer.DrawError(ioe.Message);
        }
    }
}