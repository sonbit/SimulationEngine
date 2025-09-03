using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Core.Model;
using SimulationEngine.Simulator.Processes;

namespace SimulationEngine.Simulator.Core.Engine;

public partial class SimulationSession
{
    public void PrintSimulationSetup()
    {
        var nets = _netOfTerminals.Values.Distinct().ToList();

        Console.WriteLine($"[elab] gates:   {_processes.Count}");
        Console.WriteLine($"[elab] nets:    {nets.Count}");
        Console.WriteLine($"[elab] inputs:  {_inputByTitle.Count}, outputs: {_outputByTitle.Count}");

        var noDriver = nets.Where(n => n.DriverCount == 0).ToList();
        var noFanout = nets.Where(n => n.Fanout.Count == 0).ToList();

        Console.WriteLine($"[elab] nets NO driver: {noDriver.Count}");
        Console.WriteLine($"[elab] nets NO fanouts : {noFanout.Count}");

        static void Show(Net net, Dictionary<Terminal, Net> portNetMap, string tag)
        {
            var ports = portNetMap.Where(kv => kv.Value == net).Select(kv => kv.Key);
            var portTitles = ports.Select(port => port.Title);

            Console.WriteLine($"  [{tag}] {net.Name} members=({string.Join(", ", portTitles)})");
        }

        foreach (var n in noFanout.Take(5))
            Show(n, _netOfTerminals, "no-fanout");

        foreach (var n in noDriver.Where(n => !_inputByTitle.Values.Any(p => _netOfTerminals[p] == n)).Take(5))
            Show(n, _netOfTerminals, "no-driver");
    }

    public void PrintOutputDetails(Port port) => PrintOutputDetails(port.Title);

    public void PrintOutputDetails(string portTitle)
    {
        var outputPort = _outputByTitle[portTitle];
        var net = _netOfTerminals[outputPort];

        Console.WriteLine($"[explain] {portTitle}: {net}");

        if (net.Driver is null)
        {
            Console.WriteLine("  No driver registered.");
            return;
        }

        Console.WriteLine($"  Driver: {net.Driver.Name}");

        if (net.Driver is TruthTableProcess gateProcess)
        {
            Console.WriteLine($"[diag] {portTitle}: driven by {gateProcess.Name}");

            var a = gateProcess._a?.Current ?? 0;
            var b = gateProcess._b?.Current ?? 0;
            var c = gateProcess._c?.Current ?? 0;
            var d = gateProcess._d?.Current ?? 0;

            Console.WriteLine($"       inputs: A={a} B={b} C={c} D={d}");
        }

        Console.WriteLine($"  LastWriter: {net.LastWriter?.Name ?? "stimulus"}");
    }
}
