using SimulationEngine.Domain.Models;

namespace SimulationEngine.Cli.Simulation;

internal static class SubcircuitCloner
{
    public static Subcircuit Clone(Subcircuit template)
    {
        ArgumentNullException.ThrowIfNull(template);
        return CloneInternal(template).clone;
    }

    private static (Subcircuit clone, Dictionary<Terminal, Terminal> terminalMap) CloneInternal(Subcircuit template)
    {
        var clone = new Subcircuit { Title = template.Title };
        var terminalMap = new Dictionary<Terminal, Terminal>();

        foreach (var port in template.OrderedPorts)
        {
            var clonedPort = new Port(port) { Subcircuit = clone };
            clone.Ports.Add(clonedPort);
            terminalMap[port] = clonedPort;
        }

        foreach (var logicGate in template.LogicGates ?? [])
        {
            var clonedLogicGate = new LogicGate(logicGate) { Subcircuit = clone };
            foreach (var clonedPin in clonedLogicGate.Pins)
                clonedPin.LogicGate = clonedLogicGate;

            clone.LogicGates.Add(clonedLogicGate);

            foreach (var pin in logicGate.Pins)
            {
                var clonedPin = clonedLogicGate.Pins.Single(cloned => cloned.Role == pin.Role);
                terminalMap[pin] = clonedPin;
            }
        }

        foreach (var child in template.Subcircuits ?? [])
        {
            var (childClone, childMap) = CloneInternal(child);
            clone.Subcircuits.Add(childClone);

            foreach (var kvp in childMap)
                terminalMap[kvp.Key] = kvp.Value;
        }

        foreach (var wire in template.Wires ?? [])
        {
            var start = terminalMap[wire.StartTerminal];
            var end = terminalMap[wire.EndTerminal];

            clone.Wires.Add(new Wire
            {
                Subcircuit = clone,
                StartTerminal = start,
                EndTerminal = end
            });
        }

        return (clone, terminalMap);
    }
}
