using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Placements;

namespace SimulationEngine.Domain.Compilers.Models;

public record SubcircuitPlacementInfo
{
    public SubcircuitPlacement Placement { get; init; }
    public Subcircuit ChildTemplate { get; init; }
    public string ChildTemplateHash { get; init; }
}