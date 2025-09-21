using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Export.Emitters;

public interface IVerilogTestbenchEmitter
{
    string EmitTestbench(SubCircuit subCircuit, IReadOnlyList<(byte[] Inputs, byte[] ExpectedOutputs)> testVectors);
}