using SimulationEngine.Application.Export.Emitters.Models;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Export.Emitters;

public interface IVerilogEmitter
{
    Verilog EmitSubcircuit(Subcircuit topSubcircuit);
}