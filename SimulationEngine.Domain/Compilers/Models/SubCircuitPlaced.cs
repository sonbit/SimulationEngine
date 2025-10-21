using SimulationEngine.Domain.Models;
using System.Collections.Generic;

namespace SimulationEngine.Domain.Compilers.Models;

public record SubcircuitPlaced
{
    public Subcircuit Template { get; init; }
    public List<SubcircuitPlacementInfo> PlacementInfos { get; init; } = [];
}