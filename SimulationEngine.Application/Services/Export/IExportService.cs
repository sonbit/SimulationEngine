using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Export;

public interface IExportService
{
    string EmitVerilog7SegmentDisplay();
    string EmitVerilog(SubCircuit subCircuit);
    string? EmitVerilogTestbench(SubCircuit subCircuit, string testString);
    string EmitVerilogTop(SubCircuit subCircuit, bool include7SegmentDisplay);
    string EmitXdc(SubCircuit subCircuit, bool include7SegmentDisplay);
    string ExportVerilog(SubCircuit subCircuit, string? testString, bool zip = false, string outputPath = "");
    string ExportVerilogWithTopAndXdc(SubCircuit subCircuit, string? testString, bool include7SegmentDisplay = false, bool zip = false, string outputPath = "");
}