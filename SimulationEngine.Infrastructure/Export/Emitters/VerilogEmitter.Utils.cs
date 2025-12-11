using SimulationEngine.Domain.Hashers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public sealed partial class VerilogEmitter
{
    private void ClearState()
    {
        BNetCounter = 0;
        TNetCounter = 0;

        Builder.Clear();
        ModuleIndexCounter.Clear();
        NetDeclarations.Clear();
        TerminalNetMap.Clear();
    }

    private void CreateBody(string moduleName, StringBuilder body, List<string> connections)
    {
        body.AppendLine($"\t{moduleName} {moduleName}_{GetNextIndex(moduleName)} (");
        body.AppendLine($"\t\t{string.Join($",\n\t\t", connections)}");
        body.AppendLine("\t);");
        body.AppendLine();
    }

    private void CreateConnection(List<Wire> wires, Terminal endTerminal, string moduleName, List<string> connections)
    {
        var name = $"{endTerminal.Title}";

        var wire = wires.FirstOrDefault(wire => wire.EndTerminal == endTerminal) ??
            throw new NullReferenceException($"Terminal '{name}' of '{moduleName}' is not driven by any wire.");

        var startTerminal = wire.StartTerminal;

        var net = startTerminal is Port port && port.IsInput() 
            ? port.Title 
            : GetOrCreateTerminalNet(startTerminal);

        if (startTerminal.IsBinary() && !endTerminal.IsBinary())
            net = $"{{{net},!{net}}}";
        else if (!startTerminal.IsBinary() && endTerminal.IsBinary())
            net = $"{net}[1]";

        connections.Add($".{name}({net})");
    }

    private string CreateNet(bool isBinary)
    {
        var name = isBinary ? $"bnet_{BNetCounter++}" : $"tnet_{TNetCounter++}";
        NetDeclarations.Add($"wire {VerilogUtils.GetWidth(isBinary)}{name};");
        return name;
    }

    private static IEnumerable<Subcircuit> EnumerateUniqueSubcircuits(Subcircuit root)
    {
        var seen = new HashSet<string>(StringComparer.Ordinal);
        var subcircuitStack = new Stack<Subcircuit>();
        subcircuitStack.Push(root);

        while (subcircuitStack.Count > 0)
        {
            var subcircuit = subcircuitStack.Pop();
            if (!seen.Add(SubcircuitHasher.Compute(subcircuit, [])))
                continue;

            yield return subcircuit;

            var subcircuits = subcircuit.Subcircuits;
            for (int i = subcircuits.Count - 1; i >= 0; i--)
                subcircuitStack.Push(subcircuits[i]);
        }
    }

    private int GetNextIndex(string moduleName)
    {
        if (!ModuleIndexCounter.TryGetValue(moduleName, out var index))
            index = 0;
        ModuleIndexCounter[moduleName] = index + 1;
        return index;
    }

    private string GetOrCreateTerminalNet(Terminal terminal)
    {
        if (TerminalNetMap.TryGetValue(terminal, out var net))
            return net;

        var newNet = CreateNet(terminal.IsBinary());
        TerminalNetMap[terminal] = newNet;
        return newNet;
    }
}