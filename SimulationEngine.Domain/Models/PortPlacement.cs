namespace SimulationEngine.Domain.Models;

public sealed class PortPlacement : Terminal
{
    public bool IsInput { get; set; }
    public int IndexWithinChild { get; set; }
    public int SubCircuitPlacementId { get; set; }
    public SubCircuitPlacement SubCircuitPlacement { get; set; }
}