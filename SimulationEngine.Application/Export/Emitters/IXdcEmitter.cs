using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Export.Emitters;

public interface IXdcEmitter
{
    string EmitSubCircuit(SubCircuit subCircuit);
}