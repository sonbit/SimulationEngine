
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Export;

public class ExportService(IVerilogEmitter emitter, IVerilogTestbenchEmitter tbEmitter, IXdcEmitter xdcEmitter) : IExportService
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
}