using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Domain.Models;

public abstract class Terminal : BaseEntity
{
    public TerminalType Type { get; private set; }
    public string Title { get; set; }
}

public sealed class Pin : Terminal
{
    public PinRole Role { get; set; }
    public LogicGate LogicGate { get; set; }
    public int LogicGateId { get; set; }
}

public sealed class Port : Terminal
{
    public PortRole Role { get; set; }
    public SubCircuit SubCircuit { get; set; }
    public int SubCircuitId { get; set; }
}
