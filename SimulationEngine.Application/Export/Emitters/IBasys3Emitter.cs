using SimulationEngine.Application.Export.Emitters.Models;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Export.Emitters;

public interface IBasys3Emitter
{
    VerilogModule Emit7SegmentDisplayModule();
    VerilogModule EmitTopModule(Subcircuit subcircuit, bool include7SegmentDisplay = false);
    string EmitXdc(Subcircuit subcircuit, bool include7SegmentDisplay = false);
}