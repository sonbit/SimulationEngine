using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Domain.Extensions;

public static class SubCircuitExtensions
{
    public static LogicGate AddLogicGate(this SubCircuit subCircuit, string heptaIndex)
    {
        var logicGate = new LogicGate(heptaIndex) { SubCircuit = subCircuit };
        subCircuit.LogicGates.Add(logicGate);
        return logicGate;
    }

    public static void AddPort(this SubCircuit subCircuit, string title, PortRole role) =>
        subCircuit.Ports.Add(new Port { Title = title, Role = role, SubCircuit = subCircuit });

    public static void AddPorts(this SubCircuit subCircuit, params (string title, PortRole role)[] ports)
    {
        foreach (var (title, role) in ports)
            subCircuit.AddPort(title, role);
    }

    public static void AddWire(this SubCircuit subCircuit, Terminal startTerminal, Terminal endTerminal) =>
        subCircuit.Wires.Add(new Wire { StartTerminal = startTerminal, EndTerminal = endTerminal, SubCircuit = subCircuit });

    public static void AddWires(this SubCircuit subCircuit, params (Terminal startTerminal, Terminal endTerminal)[] wires)
    {
        foreach (var (startTerminal, endTerminal) in wires)
         
            subCircuit.AddWire(startTerminal, endTerminal);
    }
}