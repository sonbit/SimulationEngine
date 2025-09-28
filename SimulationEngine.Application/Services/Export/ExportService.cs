
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Export;

public class ExportService(IVerilogEmitter emitter, IVerilogTestbenchEmitter tbEmitter, IBasys3Emitter xdcEmitter) : IExportService
{
    public FileInfo ExportAllVerilog(SubCircuit subCircuit, bool includeTestbench = false)
    {
        throw new NotImplementedException();
    }

    public FileInfo ExportAllVerilogForBasys3(SubCircuit subCircuit, bool includeTestbench = false)
    {
        throw new NotImplementedException();
    }

    public FileInfo ExportSingleVerilogFile(SubCircuit subCircuit, bool includeTestbench = false)
    {
        throw new NotImplementedException();
    }

    public string ExportSingleVerilogFileAsText(SubCircuit subCircuit)
    {
        return emitter.EmitSubCircuit(subCircuit);
    }

    public string? ExportSingleVerilogTestbenchFileAsText(SubCircuit subCircuit)
    {
        var testString = DesignUtils.GetTestString(subCircuit.Title);
        if (testString == null)
            return null;

        return tbEmitter.EmitTestbench(subCircuit, testString);
    }
}