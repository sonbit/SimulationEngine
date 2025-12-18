using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator;

public partial class SimulationSession
{
    public void PrintSimulationSetup()
    {
        var nets = _netOfTerminals.Values.Distinct().ToList();
        Console.WriteLine($"[elab] inputs:      {Subcircuit.Inputs.Count}");
        Console.WriteLine($"[elab] outputs:     {Subcircuit.Outputs.Count}");
        Console.WriteLine($"[elab] logic gates: {_processes.Count}");
        Console.WriteLine($"[elab] nets:        {nets.Count}");

        var internalNets = InternalNets().ToList();
        var noDriver = internalNets.Where(n => n.Driver != null).ToList();
        var noFanout = internalNets.Where(n => n.Fanout.Count == 0).ToList();

        Console.WriteLine($"[elab] nets NO driver: {noDriver.Count}");
        Console.WriteLine($"[elab] nets NO fanouts: {noFanout.Count}");

        foreach (var net in noDriver) 
            Show(net, _netOfTerminals, "no-driver");

        foreach (var net in noFanout) 
            Show(net, _netOfTerminals, "no-fanout");
    }

    public void PrintOutputDetails()
    {
        foreach (var output in Subcircuit.Outputs)
            PrintOutputDetails(output);
    }

    public void PrintOutputDetails(Port port)
    {
        var net = _netOfTerminals[port];

        Console.WriteLine($"[explain] {port.Title}: {net}");

        switch (net.Driver)
        {
            case null:
                Console.WriteLine("\tNo driver registered.");
                break;
            case LogicGateProcess logicGateProcess:
                var a = logicGateProcess.A?.Value ?? 0;
                var b = logicGateProcess.B?.Value ?? 0;
                var c = logicGateProcess.C?.Value ?? 0;
                var d = logicGateProcess.D?.Value ?? 0;

                Console.WriteLine($"[diag] {port.Title}: driven by {logicGateProcess.Name}");
                Console.WriteLine($"\t\tinputs: A={a} B={b} C={c} D={d}");
                break;
            default:
                Console.WriteLine($"\tDriven by: {net.Driver.Name}");
                break;
        }

        Console.WriteLine($"\tLastWriter: {net.LastWriter?.Name ?? "stimulus"}");
    }

    private IEnumerable<Net> InternalNets()
    {
        var tops = Subcircuit.Inputs.Concat(Subcircuit.Outputs).ToHashSet();

        return _netOfTerminals
            .Where(kv => !tops.Contains(kv.Key))
            .Select(kv => kv.Value)
            .Distinct();
    }

    private void ReportNetIssues()
    {
        foreach (var net in InternalNets())
        {
            if (net.Driver == null)
                Console.WriteLine($"[diag] Net {net.Name} has NO drivers.");
            if (net.Fanout == null)
                Console.WriteLine($"[diag] Net {net.Name} has NO fanouts.");
        }
    }

    private static void Show(Net net, IReadOnlyDictionary<Terminal, Net> portNetMap, string tag)
    {
        var ports = portNetMap.Where(kv => kv.Value == net).Select(kv => kv.Key);
        var portTitles = ports.Select(port => port.Title);

        Console.WriteLine($"\t[{tag}] {net.Name} members=({string.Join(", ", portTitles)})");
    }
}
