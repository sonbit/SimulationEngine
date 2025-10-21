using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Export;

public interface IExportService
{
    string EmitVerilog7SegmentDisplay();
    string EmitVerilog(Subcircuit subcircuit);
    string? EmitVerilogTestbench(Subcircuit subcircuit, string testString);
    string EmitVerilogTop(Subcircuit subcircuit, bool include7SegmentDisplay);
    string EmitXdc(Subcircuit subcircuit, bool include7SegmentDisplay);
    string ExportVerilog(Subcircuit subcircuit, string? testString, bool zip = false, string outputPath = "");
    string ExportVerilogWithTopAndXdc(Subcircuit subcircuit, string? testString, bool include7SegmentDisplay = false, bool zip = false, string outputPath = "");
}