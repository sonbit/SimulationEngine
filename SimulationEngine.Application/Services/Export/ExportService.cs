using SimulationEngine.Application.Builders;
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Application.Export.Emitters.Models;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Export;

public class ExportService(IVerilogEmitter emitter, IVerilogTestbenchEmitter tbEmitter, IBasys3Emitter basys3Emitter) : IExportService
{
    public string EmitVerilog7SegmentDisplay() =>
        basys3Emitter.Emit7SegmentDisplayModule().Content;

    public string EmitVerilog(Subcircuit subcircuit) => 
        emitter.EmitSubcircuit(subcircuit).GetAllModules();

    public string? EmitVerilogTestbench(Subcircuit subcircuit, string testString) =>
        EmitVerilogTestbenchWithTests(subcircuit, testString)?.Content;

    public string EmitVerilogTop(Subcircuit subcircuit, bool include7SegmentDisplay) =>
        basys3Emitter.EmitTopModule(subcircuit, include7SegmentDisplay).Content;

    public string EmitXdc(Subcircuit subcircuit, bool include7SegmentDisplay) =>
        basys3Emitter.EmitXdc(subcircuit, include7SegmentDisplay);

    public string ExportVerilog(Subcircuit subcircuit, string? testString, bool zip = false, string outputPath = "")
    {
        var builder = CreteaBuilderAddVerilog(subcircuit, testString);
        return Write(builder, subcircuit.Title, outputPath, zip);
    }

    public string ExportVerilogWithTopAndXdc(Subcircuit subcircuit, string? testString, bool include7SegmentDisplay = false, bool zip = false, string outputPath = "")
    {
        var builder = CreteaBuilderAddVerilog(subcircuit, testString);

        if (include7SegmentDisplay && basys3Emitter.Emit7SegmentDisplayModule() is VerilogModule displayModule)
            builder.AddFile($"{displayModule.Name}.v", displayModule.Content);

        var topModule = basys3Emitter.EmitTopModule(subcircuit, include7SegmentDisplay);
        builder.AddFile($"{topModule.Name}.v", topModule.Content);

        var xdc = basys3Emitter.EmitXdc(subcircuit, include7SegmentDisplay);
        builder.AddFile($"{builder.TopModuleName}.xdc", xdc);

        return Write(builder, subcircuit.Title, outputPath, zip);
    }

    private ExportBuilder CreteaBuilderAddVerilog(Subcircuit subcircuit, string? testString)
    {
        var verilog = emitter.EmitSubcircuit(subcircuit);

        var builder = ExportBuilder.Create().AddVerilogFiles(verilog);

        if (EmitVerilogTestbenchWithTests(subcircuit, testString) is VerilogModule module)
            builder.AddFile($"{module.Name}.v", module.Content);

        return builder;
    }

    private VerilogModule? EmitVerilogTestbenchWithTests(Subcircuit subcircuit, string? testString)
    {
        if (string.IsNullOrWhiteSpace(testString))
            return null;

        return tbEmitter.EmitTestbench(subcircuit, testString);
    }

    private static string Write(ExportBuilder builder, string title, string outputPath = "", bool zip = false)
    {
        if (string.IsNullOrEmpty(outputPath))
            outputPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{nameof(SimulationEngine)}";

        var path = zip
            ? builder.WriteZip(outputPath, title)
            : builder.WriteFolder(outputPath, title);

        return path;
    }
}