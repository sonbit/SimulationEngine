using System.Collections.Generic;

namespace SimulationEngine.Domain.Models;

public class SubCircuitPlacement : BaseEntity
{
    public int Ordinal { get; set; }
    public string Title { get; set; }
    public int ParentSubCircuitId { get; set; }
    public SubCircuit ParentSubCircuit { get; set; }
    public int ChildSubCircuitId { get; set; }
    public SubCircuit ChildSubCircuit { get; set; }
    public List<PortPlacement> PortPlacements { get; set; } = [];
}