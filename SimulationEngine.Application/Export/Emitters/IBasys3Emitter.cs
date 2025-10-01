using SimulationEngine.Application.Export.Emitters.Models;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Export.Emitters;

public interface IBasys3Emitter
{
    VerilogModule Emit7SegmentDisplayModule();
    VerilogModule EmitTopModule(SubCircuit subCircuit, bool include7SegmentDisplay = false);
    string EmitXdc(SubCircuit subCircuit, bool include7SegmentDisplay = false);
}