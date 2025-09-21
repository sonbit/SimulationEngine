using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.Export.Converters;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimulationEngine.Infrastructure.Exporters.Verilog;

public sealed partial class VerilogEmitter
{
    private static IEnumerable<LogicGate> EnumerateAllLogicGates(SubCircuit rootSubCircuit)
    {
        var subCircuitStack = new Stack<SubCircuit>();
        var handledSubCircuits = new HashSet<int>();
        subCircuitStack.Push(rootSubCircuit);

        while (subCircuitStack.Count > 0)
        {
            var subCircuit = subCircuitStack.Pop();

            if (!handledSubCircuits.Add(subCircuit.GetHashCode())) 
                continue;

            foreach (var logicGate in subCircuit.LogicGates)
                yield return logicGate;

            foreach (var childSubCircuit in subCircuit.SubCircuits) 
                subCircuitStack.Push(childSubCircuit);
        }
    }

    private static IEnumerable<SubCircuit> EnumerateAllSubCircuits(SubCircuit rootSubCircuit)
    {
        var subCircuitStack = new Stack<SubCircuit>();
        var handledSubCircuits = new HashSet<int>();
        subCircuitStack.Push(rootSubCircuit);

        while (subCircuitStack.Count > 0)
        {
            var subCircuit = subCircuitStack.Pop();

            if (!handledSubCircuits.Add(subCircuit.GetHashCode()))
                continue;

            foreach (var childSubCircuit in subCircuit.SubCircuits) 
                subCircuitStack.Push(childSubCircuit);

            yield return subCircuit;
        }
    }

    private void EmitLogicGateModuleOnce(LogicGate logicGate, StringBuilder sb, HashSet<string> visited)
    {
        var modName = LogicGateModuleName(logicGate);

        if (!visited.Add(modName)) 
            return;

        sb.AppendLine(EmitLogicGateModule(logicGate));
    }

    private void EmitSubCircuitModuleOnce(SubCircuit subCircuit, StringBuilder sb, HashSet<string> visited)
    {
        var modName = CircuitModuleName(subCircuit);

        if (!visited.Add(modName)) 
            return;

        sb.AppendLine(EmitSubCircuitModule(subCircuit));
    }

    private string LogicGateModuleName(LogicGate logicGate)
        => San($"{options.LogicGatesPrefix}{logicGate.TruthTable?.HeptaIndex ?? "UNK"}");

    private string CircuitModuleName(SubCircuit subCircuit)
        => San($"{options.SubCircuitPrefix}{(string.IsNullOrWhiteSpace(subCircuit.Title) ? "SubCircuit" : subCircuit.Title)}");

    private static string San(string s)
        => Regex.Replace(s, @"[^A-Za-z0-9_]", "_");

    private static string TritEq(string net, byte trit) => 
        $"{net} == {TritBitConverter.ConvertTritToBits(trit)}";

    private static string BoolEq(string net, int bit) => 
        bit == 0 ? $"{net} == 1'b0" : $"{net} == 1'b1";
}