using SimulationEngine.Domain.Models;

namespace SimulationEngine.Domain.Compilers.Models;

public record SubCircuitPlacementInfo
{
    public SubCircuitPlacement SubCircuitPlacement { get; init; } = default!;
    public SubCircuit ChildSubCircuit { get; init; } = default!;
    public string ChildSubCircuitHash { get; init; } = "";
}