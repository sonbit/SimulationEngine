using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Utils;

namespace SimulationEngine.Simulator.Builders;

public static class SubCircuitBuilder
{
    private sealed class CloneContext
    {
        public readonly Dictionary<Terminal, Terminal> TerminalMap =
            new(ReferenceEqualityComparer<Terminal>.Instance);
    }

    public static SubCircuit Build(SubCircuit subCircuit)
    {
        ArgumentNullException.ThrowIfNull(subCircuit);
        return Clone(subCircuit, new CloneContext());
    }

    private static SubCircuit Clone(SubCircuit subCircuitSource, CloneContext cloneContext)
    {
        var subCircuit = new SubCircuit
        {
            Title = subCircuitSource.Title,
            Ports = [],
            LogicGates = [],
            SubCircuits = [],
            Wires = []
        };

        foreach (var portSource in subCircuitSource.Ports ?? Enumerable.Empty<Port>())
        {
            var port = new Port 
            { 
                Title = portSource.Title, 
                Role = portSource.Role, 
                SubCircuit = subCircuit 
            };

            cloneContext.TerminalMap[portSource] = port;
            subCircuit.Ports.Add(port);
        }

        foreach (var logicGateSource in subCircuitSource.LogicGates ?? Enumerable.Empty<LogicGate>())
        {
            var logicGate = new LogicGate
            {
                TruthTableId = logicGateSource.TruthTableId,
                Pins = []
            };

            foreach (var pinSource in logicGateSource.Pins ?? Enumerable.Empty<Pin>())
            {
                var pin = new Pin 
                { 
                    Title = pinSource.Title, 
                    Role = pinSource.Role, 
                    LogicGate = logicGate 
                };

                cloneContext.TerminalMap[pinSource] = pin;
                logicGate.Pins.Add(pin);
            }

            subCircuit.LogicGates.Add(logicGate);
        }

        foreach (var subCircuitChildSource in subCircuit.SubCircuits ?? Enumerable.Empty<SubCircuit>())
        {
            var subCircuitChild = Clone(subCircuitChildSource, cloneContext);
            subCircuitChild.Parent = subCircuit;
            subCircuit.SubCircuits?.Add(subCircuitChild);
        }

        foreach (var wireSource in subCircuitSource.Wires ?? Enumerable.Empty<Wire>())
        {
            if (!cloneContext.TerminalMap.TryGetValue(wireSource.StartTerminal, out var startTerminal) ||
                !cloneContext.TerminalMap.TryGetValue(wireSource.EndTerminal, out var endTerminal))
            {
                throw new InvalidOperationException(
                    $"Builder error: wire endpoint not cloned: {wireSource.StartTerminal?.Title} -> {wireSource.EndTerminal?.Title}");
            }

            subCircuit.Wires.Add(new Wire
            {
                StartTerminal = startTerminal,
                EndTerminal = endTerminal,
                SubCircuit = subCircuit
            });
        }

        return subCircuit;
    }
}