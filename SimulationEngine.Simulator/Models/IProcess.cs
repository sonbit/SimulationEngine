namespace SimulationEngine.Simulator.Models;

internal interface IProcess
{
    string Name { get; }
    void Evaluate(DeltaKernel deltaKernel);
}
