using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Domain.Models;

public class Pin : Terminal
{
    public Pin() => Title ??= Role.ToString();

    public PinRole Role { get; set; }
    public LogicGate LogicGate { get; set; }
    public int LogicGateId { get; set; }
}