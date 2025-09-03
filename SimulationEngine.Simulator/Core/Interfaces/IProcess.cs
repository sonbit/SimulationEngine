using SimulationEngine.Simulator.Core.Engine;

namespace SimulationEngine.Simulator.Core.Interfaces;

internal interface IProcess
{
    string Name { get; }
    void Evaluate(DeltaKernel deltaKernel);
}
