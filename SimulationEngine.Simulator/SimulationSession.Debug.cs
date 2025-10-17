using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator;

public partial class SimulationSession
{
    public void PrintSimulationSetup()
    {
        var nets = _netOfTerminals.Values.Distinct().ToList();

        Console.WriteLine($"[elab] inputs:      {SubCircuit.Inputs.Count}");
        Console.WriteLine($"[elab] outputs:     {SubCircuit.Outputs.Count}");
        Console.WriteLine($"[elab] logic gates: {_processes.Count}");
        Console.WriteLine($"[elab] nets:        {nets.Count}");

        var nonTopNets = GetNonTopNets();
        var noDriverNets = nonTopNets.Where(net => net.DriverCount == 0).ToList();
        var noFanoutNets = nonTopNets.Where(net => net.Fanout.Count == 0).ToList();

        Console.WriteLine($"[elab] nets NO driver: {noDriverNets.Count}");
        Console.WriteLine($"[elab] nets NO fanouts : {noFanoutNets.Count}");

        foreach (var net in noDriverNets)
            Show(net, _netOfTerminals, "no-driver");

        foreach (var net in noFanoutNets)
            Show(net, _netOfTerminals, "no-fanout");
    }

    private static void Show(Net net, Dictionary<Terminal, Net> portNetMap, string tag)
    {
        var ports = portNetMap.Where(kv => kv.Value == net).Select(kv => kv.Key);
        var portTitles = ports.Select(port => port.Title);

        Console.WriteLine($"  [{tag}] {net.Name} members=({string.Join(", ", portTitles)})");
    }

    public void PrintOutputDetails()
    {
        foreach (var output in SubCircuit.Outputs)
            PrintOutputDetails(output);
    }

    public void PrintOutputDetails(Port port)
    {
        var net = _netOfTerminals[port];

        Console.WriteLine($"[explain] {port.Title}: {net}");

        if (net.Driver is null)
        {
            Console.WriteLine("\tNo driver registered.");
            return;
        }

        Console.WriteLine($"\tDriver: {net.Driver.Name}");

        if (net.Driver is LogicGateProcess logicGateProcess)
        {
            Console.WriteLine($"[diag] {port.Title}: driven by {logicGateProcess.Name}");

            var a = logicGateProcess._a?.CurrentValue ?? 0;
            var b = logicGateProcess._b?.CurrentValue ?? 0;
            var c = logicGateProcess._c?.CurrentValue ?? 0;
            var d = logicGateProcess._d?.CurrentValue ?? 0;

            Console.WriteLine($"\t\tinputs: A={a} B={b} C={c} D={d}");
        }

        Console.WriteLine($"\tLastWriter: {net.LastDriver?.Name ?? "stimulus"}");
    }

    private void ReportNetIssues()
    {
        foreach (var net in GetNonTopNets())
        {
            if (net.Driver == null)
                Console.WriteLine($"[diag] Net {net.Name} has NO drivers.");
            if (net.Fanout == null)
                Console.WriteLine($"[diag] Net {net.Name} has NO fanouts.");
        }
    }

    private List<Net> GetNonTopNets()
    {
        var topPorts = SubCircuit.Inputs.Concat(SubCircuit.Outputs).ToHashSet();

        return [.. _netOfTerminals
            .Where(kv => !topPorts.Contains(kv.Key))
            .Select(kv => kv.Value)
            .Distinct()];
    }
}