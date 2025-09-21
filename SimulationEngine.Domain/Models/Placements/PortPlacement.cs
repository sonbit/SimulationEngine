namespace SimulationEngine.Domain.Models.Placements;

public class PortPlacement : Terminal
{
    public bool IsInput { get; set; }
    public int IndexWithinChild { get; set; }
    public int SubCircuitPlacementId { get; set; }
    public SubCircuitPlacement SubCircuitPlacement { get; set; }
}