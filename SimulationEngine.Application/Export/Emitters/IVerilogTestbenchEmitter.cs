using SimulationEngine.Application.Export.Emitters.Models;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Export.Emitters;

public interface IVerilogTestbenchEmitter
{
    VerilogModule EmitTestbench(Subcircuit subcircuit, string testString);
}