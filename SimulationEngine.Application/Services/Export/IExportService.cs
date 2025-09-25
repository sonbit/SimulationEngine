using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Export;

public interface IExportService
{
    FileInfo ExportAllVerilogForBasys3(SubCircuit subCircuit, bool includeTestbench = false);
    FileInfo ExportAllVerilog(SubCircuit subCircuit, bool includeTestbench = false);
    FileInfo ExportSingleVerilogFile(SubCircuit subCircuit, bool includeTestbench = false);
    string ExportSingleVerilogFileAsText(SubCircuit subCircuit);
    string? ExportSingleVerilogTestbenchFileAsText(SubCircuit subCircuit);
}