using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Comparers;
using SimulationEngine.Simulator.Finders;
using SimulationEngine.Simulator.Models;
using System.Collections.Frozen;

namespace SimulationEngine.Simulator;

public partial class SimulationSession
{
    public readonly Subcircuit Subcircuit;
    private readonly DeltaKernel _deltaKernel = new();
    private readonly List<IProcess> _processes = [];
    private FrozenDictionary<Terminal, Net> _netOfTerminals = FrozenDictionary<Terminal, Net>.Empty;
    private readonly Dictionary<Subcircuit, SubcircuitPortProbe> _probeBySubcircuit =
        new(ReferenceEqualityComparer<Subcircuit>.Instance);
    private SubcircuitPortProbe _rootProbe = null!;

    public bool Trace 
    { 
        get => _deltaKernel.Trace; 
        set => _deltaKernel.Trace = value; 
    }

    private SimulationSession(Subcircuit subcircuit) => Subcircuit = subcircuit;

    public static SimulationSession Build(Subcircuit subcircuit, bool trace = false)
    {
        return Build(subcircuit, new SimulationSessionBuildOptions { Trace = trace });
    }

    public static SimulationSession Build(Subcircuit subcircuit, SimulationSessionBuildOptions options)
    {
        var simSession = new SimulationSession(subcircuit) { Trace = options.Trace };

        var netOf = new Dictionary<Terminal, Net>(ReferenceEqualityComparer<Terminal>.Instance);
        var allNets = BuildNets(subcircuit, netOf);
        BuildProcesses(subcircuit, netOf, simSession._processes, subcircuit.Title);
        simSession._netOfTerminals = netOf.ToFrozenDictionary(ReferenceEqualityComparer<Terminal>.Instance);
        simSession.InitializePortProbes(options);

        if (options.Trace)
            simSession.ReportNetIssues();

        simSession._deltaKernel.Prime(simSession._processes, allNets);
        return simSession;
    }

    private static HashSet<Net> BuildNets(Subcircuit subcircuit, Dictionary<Terminal, Net> map)
    {
        var unionFinder = new UnionFinder<Terminal>(ReferenceEqualityComparer<Terminal>.Instance);
        var terminals = EnumerateAllTerminalsRecursive(subcircuit).ToArray();

        foreach (var terminal in terminals)
            unionFinder.Add(terminal);

        UnionAllWiresRecursive(subcircuit, unionFinder);

        var netByRootTerminal = new Dictionary<Terminal, Net>(ReferenceEqualityComparer<Terminal>.Instance);
        foreach (var terminal in terminals)
        {
            var parentTerminal = unionFinder.Find(terminal);
            if (!netByRootTerminal.TryGetValue(parentTerminal, out var net))
            {
                net = new Net($"net({parentTerminal.Title})");
                netByRootTerminal[parentTerminal] = net;
            }
            map[terminal] = net;
        }

        return [.. netByRootTerminal.Values];
    }

    private static void BuildProcesses(Subcircuit subcircuit, Dictionary<Terminal, Net> netOf, List<IProcess> processes, string path)
    {
        var driverCount = new Dictionary<Net, int>();

        foreach (var logicGate in subcircuit.LogicGates ?? [])
        {
            if (logicGate.TruthTable?.Definition == null)
                throw new InvalidOperationException($"Gate missing TruthTable.Definition in {path}.");

            var a = netOf[logicGate.A];
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
                new LogicGateProcess(
                    $"{path}/gate[{logicGate.TruthTable.HeptaIndex ?? logicGate.TruthTable.Definition.Length.ToString()}]",
                    a, b, c, d, q, logicGate.TruthTable.Definition));
        }

        if (subcircuit.Subcircuits == null)
            return;

        var duplicatedSubcircuits = subcircuit.Subcircuits
            .GroupBy(x => x, ReferenceEqualityComparer<Subcircuit>.Instance)
            .Where(g => g.Count() > 1);

        foreach (var duplicatedSubcircuit in duplicatedSubcircuits ?? [])
            throw new InvalidOperationException(
                $"Subcircuit '{path}/{subcircuit.Title}' reuses the same child instance '{duplicatedSubcircuit.Key.Title}'. " +
                "Instantiate distinct copies for each use.");

        var index = 0;
        foreach (var child in subcircuit.Subcircuits)
            BuildProcesses(child, netOf, processes, $"{path}#{index++}/{child.Title}");
    }

    private static IEnumerable<Terminal> EnumerateAllTerminalsRecursive(Subcircuit subcircuit)
    {
        if (subcircuit.Ports != null)
        {
            foreach (var port in subcircuit.Ports)
                yield return port;
        }

        if (subcircuit.LogicGates != null)
        {
            foreach (var logicGate in subcircuit.LogicGates)
            {
                if (logicGate.A != null) yield return logicGate.A;
                if (logicGate.B != null) yield return logicGate.B;
                if (logicGate.C != null) yield return logicGate.C;
                if (logicGate.D != null) yield return logicGate.D;
                if (logicGate.Q != null) yield return logicGate.Q;
            }
        }

        if (subcircuit.Subcircuits != null)
        {
            foreach (var child in subcircuit.Subcircuits)
            {
                foreach (var terminal in EnumerateAllTerminalsRecursive(child))
                    yield return terminal;
            }
        }
    }

    private static void UnionAllWiresRecursive(Subcircuit subcircuit, UnionFinder<Terminal> unionFinder)
    {
        foreach (var wire in subcircuit.Wires ?? [])
            unionFinder.Union(wire.StartTerminal, wire.EndTerminal);

        if (subcircuit.Subcircuits == null)
            return;

        foreach (var child in subcircuit.Subcircuits)
            UnionAllWiresRecursive(child, unionFinder);
    }
}
