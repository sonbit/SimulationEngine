using SimulationEngine.Application.Services.Export;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows;

public class ExportFlow(IPrompter prompter, IRenderer renderer, IExportService service)
{
    private enum MenuOptions
    {
        [Description("Write single Verilog file")] VerilogSingleFile,
        [Description("Export all Verilog files in a zip file")] VerilogAllFiles,
        [Description("Export all Verilog files for Basys3 in a zip file")] VerilogAllFilesForBasys3,
        Back
    }

    public async Task RunMenuAsync(SubCircuit subCircuit)
    {
        renderer.Clear();

        while (true)
        {
            switch (await prompter.SelectEnumAsync<MenuOptions>("[bold]Select an export option[/]"))
            {
                case MenuOptions.VerilogSingleFile:
                    ExportVerilogSingleFileAsync(subCircuit);
                    break;

                case MenuOptions.VerilogAllFiles:
                    
                    break;

                case MenuOptions.VerilogAllFilesForBasys3:
                    
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    private void ExportVerilogSingleFileAsync(SubCircuit subCircuit)
    {
        renderer.Clear();
        renderer.Write(service.ExportSingleVerilogFileAsText(subCircuit));
    }
}