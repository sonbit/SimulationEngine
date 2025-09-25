using SimulationEngine.Application.Services.Database.SubCircuits;
using SimulationEngine.Application.Services.Export;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Domain.Models;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows;

public class ExportFlow(IPrompter prompter, IRenderer renderer, IExportService service, ISubCircuitService subCircuitService)
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
                    ExportVerilogSingleFile(subCircuit);
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

    public async Task ExportVerilogSingleFileAsync(int id)
    {
        var subCircuit = await subCircuitService.GetByIdAsync(id);
        if (subCircuit is null)
        {
            renderer.DrawError($"Subcircuit with id {id} was not found.");
            return;
        }

        ExportVerilogSingleFile(subCircuit);
    }

    public async Task ExportVerilogSingleFileAsync(string title)
    {
        var subCircuit = await subCircuitService.GetByTitleAsync(title);
        if (subCircuit is null)
        {
            renderer.DrawError($"Subcircuit with title {title} was not found.");
            return;
        }

        ExportVerilogSingleFile(subCircuit);
    }

    public void ExportVerilogSingleFile(SubCircuit subCircuit)
    {
        var verilog = service.ExportSingleVerilogFileAsText(subCircuit);
        renderer.Clear();
        renderer.Write(verilog);
    }
}