using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Core.Interfaces;
using SimulationEngine.Simulator.Core.Model;
using SimulationEngine.Simulator.Processes;
using SimulationEngine.Simulator.Utils;

namespace SimulationEngine.Simulator.Core.Engine;

public partial class SimulationSession
{
    public readonly SubCircuit SubCircuit;
    private readonly DeltaKernel _deltaKernel = new();
    private readonly List<IProcess> _processes = [];
    private readonly Dictionary<Terminal, Net> _netOfTerminals = new(ReferenceEqualityComparer<Terminal>.Instance);

    private readonly Dictionary<string, Port> _inputByTitle = new(StringComparer.Ordinal);
    private readonly Dictionary<string, Port> _outputByTitle = new(StringComparer.Ordinal);

    public bool Trace 
    { 
        get => _deltaKernel.Trace; 
        set => _deltaKernel.Trace = value; 
    }

    private SimulationSession(SubCircuit subCircuit) => SubCircuit = subCircuit;

    public static SimulationSession Build(SubCircuit subCircuit, bool trace = false)
    {
        var simSession = new SimulationSession(subCircuit) { Trace = trace };

        BuildNets(subCircuit, simSession._netOfTerminals);
        BuildProcesses(subCircuit, simSession._netOfTerminals, simSession._processes, path: subCircuit.Title);

        if (trace)
            ReportNetIssues(simSession._netOfTerminals.Values);

        foreach (var port in subCircuit.Inputs ?? Enumerable.Empty<Port>())
            simSession._inputByTitle[port.Title] = port;

        foreach (var port in subCircuit.Outputs ?? Enumerable.Empty<Port>())
            simSession._outputByTitle[port.Title] = port;

        simSession._deltaKernel.Prime(simSession._processes);
        return simSession;
    }

    public void SetInputs(byte[] values)
    {
        for (int i = 0; i < values.Length; i++)
            SetInput(SubCircuit.Ports[i].Title, values[i]);
    }

    public void SetInput(string title, byte value)
    {
        if (!_inputByTitle.TryGetValue(title, out var p))
            throw new KeyNotFoundException($"Input '{title}' not found. Known: {string.Join(", ", _inputByTitle.Keys)}");

        _deltaKernel.Set(_netOfTerminals[p], value);
    }

    public byte[] GetOutputs() => [.. SubCircuit.Outputs.Select(p => GetOutput(p.Title))];


    public byte GetOutput(string title)
    {
        if (!_outputByTitle.TryGetValue(title, out var p))
            throw new KeyNotFoundException($"Output '{title}' not found. Known: {string.Join(", ", _outputByTitle.Keys)}");

        return _netOfTerminals[p].Current;
    }

    private static void ReportNetIssues(IEnumerable<Net> nets)
    {
        foreach (var net in nets)
        {
            if (net.Driver == null)
                Console.WriteLine($"[diag] Net {net.Name} has NO drivers.");
        }
    }

    private static IEnumerable<Terminal> EnumerateAllTerminalsRecursive(SubCircuit subCircuit)
    {
        if (subCircuit.Ports != null)
        {
            foreach (var port in subCircuit.Ports) 
                yield return port;
        }
        
        if (subCircuit.LogicGates != null)
        {
            foreach (var logicGate in subCircuit.LogicGates)
            {
                if (logicGate.Pins != null) yield return logicGate.A;
                if (logicGate.B != null) yield return logicGate.B;
                if (logicGate.C != null) yield return logicGate.C;
                if (logicGate.D != null) yield return logicGate.D;
                if (logicGate.Q != null) yield return logicGate.Q;
            }
        }

        if (subCircuit.SubCircuits != null)
        {
            foreach (var child in subCircuit.SubCircuits)
            {
                foreach (var terminal in EnumerateAllTerminalsRecursive(child))
                    yield return terminal;
            }
        }
    }

    private static void UnionAllWiresRecursive(SubCircuit subCircuit, UnionFind<Terminal> unionFind)
    {
        foreach (var wire in subCircuit.Wires ?? Enumerable.Empty<Wire>())
        {
            unionFind.Add(wire.StartTerminal);
            unionFind.Add(wire.EndTerminal);
            unionFind.Union(wire.StartTerminal, wire.EndTerminal);
        }

        if (subCircuit.SubCircuits == null)
            return;

        foreach (var child in subCircuit.SubCircuits)
            UnionAllWiresRecursive(child, unionFind);
    }

    private static List<Net> BuildNets(SubCircuit subCircuit, Dictionary<Terminal, Net> map)
    {
        var unionFind = new UnionFind<Terminal>(ReferenceEqualityComparer<Terminal>.Instance);

        foreach (var terminal in EnumerateAllTerminalsRecursive(subCircuit)) 
            unionFind.Add(terminal);

        UnionAllWiresRecursive(subCircuit, unionFind);

        var rootToNet = new Dictionary<Terminal, Net>(ReferenceEqualityComparer<Terminal>.Instance);

        foreach (var terminal in EnumerateAllTerminalsRecursive(subCircuit))
        {
            var root = unionFind.Find(terminal);
            if (!rootToNet.TryGetValue(root, out var net))
            {
                net = new Net($"net({root.Title})");
                rootToNet[root] = net;
            }
            map[terminal] = net;
        }

        return [.. rootToNet.Values];
    }

    private static void BuildProcesses(SubCircuit subCircuit, Dictionary<Terminal, Net> netOf, List<IProcess> processes, string path)
    {
        var driverCount = new Dictionary<Net, int>();

        foreach (var logicGate in subCircuit.LogicGates ?? Enumerable.Empty<LogicGate>())
        {
            if (logicGate.TruthTable?.Definition == null)
                throw new InvalidOperationException($"Gate missing TruthTable.Definition in {path}.");

            var a = logicGate.A != null ? netOf[logicGate.A] : null;
            var b = logicGate.B != null ? netOf[logicGate.B] : null;
            var c = logicGate.C != null ? netOf[logicGate.C] : null;
            var d = logicGate.D != null ? netOf[logicGate.D] : null;

            if (logicGate.Q == null) 
                throw new InvalidOperationException($"Gate in {path} has null PortQ.");

            var q = netOf[logicGate.Q];

            driverCount.TryGetValue(q, out var count);
            driverCount[q] = count + 1;
            if (driverCount[q] > 1)
                throw new InvalidOperationException(
                    $"Multiple drivers detected on {path}:{q.Name}.");

            processes.Add(
                new TruthTableProcess(
                    $"{path}/gate[{logicGate.TruthTable.HeptaIndex ?? logicGate.TruthTable.Definition.Length.ToString()}]", 
                    a, b, c, d, q, logicGate.TruthTable.Definition));
        }

        if (subCircuit.SubCircuits != null)
        {
            var duplicatedSubCircuits = subCircuit.SubCircuits?
                .GroupBy(x => x, ReferenceEqualityComparer<SubCircuit>.Instance)
                .Where(g => g.Count() > 1);

            if (duplicatedSubCircuits != null)
            {
                foreach (var dup in duplicatedSubCircuits)
                    throw new InvalidOperationException(
                        $"SubCircuit '{path}/{subCircuit.Title}' reuses the same child instance '{dup.Key.Title}'. " +
                        "Instantiate distinct copies for each use.");
            }

            int index = 0;
            foreach (var child in subCircuit.SubCircuits!)
                BuildProcesses(child, netOf, processes, $"{path}#{index++}/{child.Title}");
        }
    }
}