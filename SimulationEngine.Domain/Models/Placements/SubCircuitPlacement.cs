using System.Collections.Generic;

namespace SimulationEngine.Domain.Models.Placements;

public sealed class SubcircuitPlacement : BaseTitleEntity
{
    public int Ordinal { get; init; }

    public int ParentTemplateId { get; init; }
    public required Subcircuit ParentTemplate { get; init; }

    public int ChildTemplateId { get; init; }
    public required Subcircuit ChildTemplate { get; init; }

    public ICollection<PortPlacement> PortPlacements { get; init; } = [];
}