using System;
using System.Collections.Generic;

namespace SimulationEngine.Domain.Compilers.Models;

public record SubCircuitClosure
{
    public SubCircuitPlaced SubCircuitPlaced { get; init; }
    public Dictionary<string, SubCircuitPlaced> MapByHash { get; init; } = new(StringComparer.Ordinal);
}