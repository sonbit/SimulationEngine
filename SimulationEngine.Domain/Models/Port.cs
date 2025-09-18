using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Domain.Models;

public class Port : Terminal
{
    public PortRole Role { get; set; }
    public SubCircuit SubCircuit { get; set; }
    public int SubCircuitId { get; set; }
}