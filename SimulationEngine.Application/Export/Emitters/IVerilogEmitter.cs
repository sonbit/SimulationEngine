using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Export.Emitters;

public interface IVerilogEmitter
{
    string EmitSubCircuit(SubCircuit subCircuit);
}