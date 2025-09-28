using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Export.Emitters;

public interface IBasys3Emitter
{
    string Emit7SegmentDisplayModule();
    string EmitTopModule(SubCircuit subCircuit, bool include7SegmentDisplay = false);
    string EmitXdc(SubCircuit subCircuit, bool include7SegmentDisplay = false);
}