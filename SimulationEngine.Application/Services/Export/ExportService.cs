using SimulationEngine.Application.Builders;
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Application.Export.Emitters.Models;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Export;

public class ExportService(IVerilogEmitter emitter, IVerilogTestbenchEmitter tbEmitter, IBasys3Emitter basys3Emitter) : IExportService
{
    public string EmitVerilog7SegmentDisplay() =>
        basys3Emitter.Emit7SegmentDisplayModule().Content;

    public string EmitVerilog(SubCircuit subCircuit) => 
        emitter.EmitSubCircuit(subCircuit).GetAllModules();

    public string? EmitVerilogTestbench(SubCircuit subCircuit) =>
        EmitVerilogTestbenchWithPredefinedTests(subCircuit)?.Content;

    public string EmitVerilogTop(SubCircuit subCircuit, bool include7SegmentDisplay) =>
        basys3Emitter.EmitTopModule(subCircuit, include7SegmentDisplay).Content;

    public string EmitXdc(SubCircuit subCircuit, bool include7SegmentDisplay) =>
        basys3Emitter.EmitXdc(subCircuit, include7SegmentDisplay);

    public string ExportVerilog(SubCircuit subCircuit, bool zip = false, string outputPath = "")
    {
        var builder = CreteaBuilderAddVerilog(subCircuit);
        return Write(builder, subCircuit.Title, outputPath, zip);
    }

    public string ExportVerilogWithTopAndXdc(SubCircuit subCircuit, bool include7SegmentDisplay = false, bool zip = false, string outputPath = "")
    {
        var builder = CreteaBuilderAddVerilog(subCircuit);

        if (include7SegmentDisplay && basys3Emitter.Emit7SegmentDisplayModule() is VerilogModule displayModule)
            builder.AddFile($"{displayModule.Name}.v", displayModule.Content);

        var topModule = basys3Emitter.EmitTopModule(subCircuit, include7SegmentDisplay);
        builder.AddFile($"{topModule.Name}.v", topModule.Content);

        var xdc = basys3Emitter.EmitXdc(subCircuit, include7SegmentDisplay);
        builder.AddFile($"{builder.TopModuleName}.xdc", xdc);

        return Write(builder, subCircuit.Title, outputPath, zip);
    }

    private ExportBuilder CreteaBuilderAddVerilog(SubCircuit subCircuit)
    {
        var verilog = emitter.EmitSubCircuit(subCircuit);

        var builder = ExportBuilder.Create().AddVerilogFiles(verilog);

        if (EmitVerilogTestbenchWithPredefinedTests(subCircuit) is VerilogModule module)
            builder.AddFile($"{module.Name}.v", module.Content);

        return builder;
    }

    private VerilogModule? EmitVerilogTestbenchWithPredefinedTests(SubCircuit subCircuit)
    {
        var testString = DesignUtils.GetTestString(subCircuit.Title);
        if (testString == null)
            return null;

        return tbEmitter.EmitTestbench(subCircuit, testString);
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