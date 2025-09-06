namespace SimulationEngine.Domain.Models;

public class Wire : BaseEntity
{
    public Terminal StartTerminal { get; set; }
    public int StartTerminalId { get; set; }
    public Terminal EndTerminal { get; set; }
    public int EndTerminalId { get; set; }
    public SubCircuit SubCircuit { get; set; }
    public int SubCircuitId { get; set; }
}