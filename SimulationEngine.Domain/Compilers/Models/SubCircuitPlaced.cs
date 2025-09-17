using SimulationEngine.Domain.Models;
using System.Collections.Generic;

namespace SimulationEngine.Domain.Compilers.Models;

public record SubCircuitPlaced
{
    public SubCircuit SubCircuit { get; init; } = default!;
    public List<SubCircuitPlacementInfo> SubCircuitPlacementInfos { get; init; } = [];
}