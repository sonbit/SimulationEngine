using System;
using System.Collections.Generic;

namespace SimulationEngine.Domain.Compilers.Models;

public record SubcircuitClosure
{
    public SubcircuitPlaced Placed { get; init; }
    public Dictionary<string, SubcircuitPlaced> PlacedByHash { get; init; } = new(StringComparer.Ordinal);
}