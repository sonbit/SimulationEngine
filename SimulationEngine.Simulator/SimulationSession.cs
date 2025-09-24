using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Metadata.Enums;
using SimulationEngine.Simulator.Comparers;
using SimulationEngine.Simulator.Finders;
using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator;

public partial class SimulationSession
{
    public readonly SubCircuit SubCircuit;
    private readonly DeltaKernel _deltaKernel = new();
    private readonly List<IProcess> _processes = [];
    private readonly Dictionary<Terminal, Net> _netOfTerminals = new(ReferenceEqualityComparer<Terminal>.Instance);

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

        simSession._deltaKernel.Prime(simSession._processes);
        return simSession;
    }

    public void SetInput(Port port, byte value) => _deltaKernel.Set(_netOfTerminals[port], value);

    public void SetInputs(byte[] values)
    {
        if (values.Length != SubCircuit.Inputs.Count)
            throw new ArgumentException($"Input length mismatch: expected {SubCircuit.Inputs.Count}, got {values.Length}.");

        for (int i = 0; i < values.Length; i++)
            SetInput(SubCircuit.Inputs[i], values[i]);
    }

    public void SetInputsWithRadix(string values)
    {
        if (values.Length != SubCircuit.Inputs.Count)
            throw new ArgumentException($"Input length mismatch: expected {SubCircuit.Inputs.Count}, got {values.Length}.");

        var byteArray = new byte[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            var port = SubCircuit.Inputs[i];
            byteArray[i] = port.PortMetadata.Radix switch
            {
                Radix.Binary or Radix.BinarySigned => values[i] switch
                {
                    '1' => 2,
                    '0' => 0,
                    _ => throw new InvalidOperationException($"Invalid binary value '{values[i]}' for port {port.Name}."),
                },
                Radix.TernaryBalanced => values[i] switch
                {
                    '+' => 2,
                    '0' => 1,
                    '-' => 0,
                    _ => throw new InvalidOperationException($"Invalid balanced ternary value '{values[i]}' for port {port.Name}."),
                },
                Radix.TernaryUnbalanced => values[i] switch
                {
                    '2' => 2,
                    '1' => 1,
                    '0' => 0,
                    _ => throw new InvalidOperationException($"Invalid unbalanced ternary value '{values[i]}' for port {port.Name}."),
                },
                _ => throw new InvalidOperationException($"Unsupported radix {port.PortMetadata.Radix} for port {port.Name}."),
            };
        }

        SetInputs(byteArray);
    }

    public byte GetOutput(Port port) => _netOfTerminals[port].CurrentValue;

    public byte[] GetOutputs() => [.. SubCircuit.Outputs.Select(GetOutput)];

    public string GetOutputsWithRadix()
    {
        var chars = new char[SubCircuit.Outputs.Count];

        for (int i = 0; i < SubCircuit.Outputs.Count; i++)
        {
            var port = SubCircuit.Outputs[i];
            var value = GetOutput(port);

            chars[i] = port.PortMetadata.Radix switch
            {
                Radix.Binary or Radix.BinarySigned => value switch
                {
                    2 => '1',
                    1 => '0',
                    0 => '0',
                    _ => throw new InvalidOperationException($"Invalid binary value '{value}' for port {port.Name}."),
                },
                Radix.TernaryBalanced => value switch
                {
                    2 => '+',
                    1 => '0',
                    0 => '-',
                    _ => throw new InvalidOperationException($"Invalid balanced ternary value '{value}' for port {port.Name}."),
                },
                Radix.TernaryUnbalanced => value switch
                {
                    2 => '2',
                    1 => '1',
                    0 => '0',
                    _ => throw new InvalidOperationException($"Invalid unbalanced ternary value '{value}' for port {port.Name}."),
                },
                _ => throw new InvalidOperationException($"Unsupported radix {port.PortMetadata.Radix} for port {port.Name}."),
            };
        }

        return new string(chars);
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
                if (logicGate.A != null) yield return logicGate.A;
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

    private static void UnionAllWiresRecursive(SubCircuit subCircuit, UnionFinder<Terminal> unionFind)
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
        var unionFind = new UnionFinder<Terminal>(ReferenceEqualityComparer<Terminal>.Instance);

        foreach (var terminal in EnumerateAllTerminalsRecursive(subCircuit)) 
            unionFind.Add(terminal);

        UnionAllWiresRecursive(subCircuit, unionFind);

        var rootTerminalToNet = new Dictionary<Terminal, Net>(ReferenceEqualityComparer<Terminal>.Instance);

        foreach (var terminal in EnumerateAllTerminalsRecursive(subCircuit))
        {
            var rootTerminal = unionFind.Find(terminal);
            if (!rootTerminalToNet.TryGetValue(rootTerminal, out var net))
            {
                net = new Net($"net({rootTerminal.Title})");
                rootTerminalToNet[rootTerminal] = net;
            }
            map[terminal] = net;
        }

        return [.. rootTerminalToNet.Values];
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

            var index = 0;
            foreach (var child in subCircuit.SubCircuits!)
                BuildProcesses(child, netOf, processes, $"{path}#{index++}/{child.Title}");
        }
    }
}