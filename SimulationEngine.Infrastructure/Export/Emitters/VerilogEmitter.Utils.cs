using SimulationEngine.Domain.Hashers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Domain.Models.Placements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulationEngine.Infrastructure.Exporters.Verilog;

public sealed partial class VerilogEmitter
{
    private static string BitToTrit(string bit) => $"{{{bit},!{bit}}}";

    private void ClearState()
    {
        BNetCounter = 0;
        TNetCounter = 0;

        Builder.Clear();
        ModuleIndexCounter.Clear();
        Nets.Clear();
        TerminalNetMap.Clear();
    }

    private void CreateConnection(List<Wire> wires, Terminal endTerminal, string moduleName, List<string> connections)
    {
        var name = $"{endTerminal.Title}";

        var wire = wires.FirstOrDefault(wire => wire.EndTerminal == endTerminal) ??
            throw new NullReferenceException($"Terminal '{name}' of '{moduleName}' is not driven by any wire.");

        var startTerminal = wire.StartTerminal;
        var value = GetValue(startTerminal);

        if (startTerminal.IsBinary() && !endTerminal.IsBinary())
            value = BitToTrit(value);

        connections.Add($".{name}({value})");
    }

    private void CreateBody(string moduleName, StringBuilder body, List<string> connections)
    {
        body.AppendLine($"\t{moduleName} {moduleName}_{GetNextIndex(moduleName)} (");
        body.AppendLine($"\t\t{string.Join($",\n\t\t", connections)}");
        body.AppendLine("\t);");
        body.AppendLine();
    }

    private string CreateNet(bool isBinary)
    {
        var name = isBinary ? $"bnet_{BNetCounter++}" : $"tnet_{TNetCounter++}";
        Nets.Add(isBinary ? $"wire {name};" : $"wire [1:0] {name};");
        return name;
    }

    private static IEnumerable<SubCircuit> EnumerateUniqueSubCircuits(SubCircuit rootSubCircuit)
    {
        var seen = new HashSet<string>(StringComparer.Ordinal);
        var subCircuitStack = new Stack<SubCircuit>();
        subCircuitStack.Push(rootSubCircuit);

        while (subCircuitStack.Count > 0)
        {
            var subCircuit = subCircuitStack.Pop();
            if (!seen.Add(SubCircuitHasher.Compute(subCircuit, [])))
                continue;

            yield return subCircuit;

            var subCircuits = subCircuit.SubCircuits;
            for (int i = subCircuits.Count - 1; i >= 0; i--)
                subCircuitStack.Push(subCircuits[i]);
        }
    }

    private string GetLogicGateModuleName(LogicGate logicGate)
        => $"{options.LogicGatesPrefix}{logicGate.TruthTable.HeptaIndex}";

    private int GetNextIndex(string moduleName)
    {
        if (!ModuleIndexCounter.TryGetValue(moduleName, out var index))
            index = 0;
        ModuleIndexCounter[moduleName] = index + 1;
        return index;
    }

    private string GetSubCircuitModuleName(SubCircuit subCircuit)
        => $"{options.SubCircuitPrefix}{subCircuit.Title}";

    private string GetValue(Terminal terminal)
    {
        if (TerminalNetMap.TryGetValue(terminal, out var terminalValue))
            return terminalValue;

        switch (terminal)
        {
            case Port port:
                return port.Title;

            case Pin pin:
                if (TerminalNetMap.TryGetValue(pin, out var pinValue))
                    return pinValue;
                break;
            case PortPlacement:
            default:
                break;
        }

        throw new NullReferenceException($"Unable to resolve terminal '{terminal.Title}' (ID: {terminal.Id}).");
    }
}