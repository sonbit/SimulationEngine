namespace SimulationEngine.Domain.Models.Extensions;

public static class TerminalExtensions
{
    public static bool IsBinary(this Terminal terminal)
        => terminal is Pin pin && pin.LogicGate.IsBinary() || terminal is Port port && port.IsBinary();
}