using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator.Core.Engine;

public partial class SimulationSession
{
    public void PrintSimulationSetup()
    {
        var nets = _netOfTerminals.Values.Distinct().ToList();

        Console.WriteLine($"[elab] gates:   {_processes.Count}");
        Console.WriteLine($"[elab] nets:    {nets.Count}");
        Console.WriteLine($"[elab] inputs:  {_inputPortByRole.Count}, outputs: {_outputPortByRole.Count}");

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

        foreach (var net in noFanout.Take(5))
            Show(net, _netOfTerminals, "no-fanout");

        foreach (var net in noDriver.Where(n => !_inputPortByRole.Values.Any(p => _netOfTerminals[p] == n)).Take(5))
            Show(net, _netOfTerminals, "no-driver");
    }

    public void PrintOutputDetails(Port port)
    {
        var outputPort = _outputPortByRole[port.Role];
        var net = _netOfTerminals[outputPort];

        Console.WriteLine($"[explain] {port.Role}: {net}");

        if (net.Driver is null)
        {
            Console.WriteLine("  No driver registered.");
            return;
        }

        Console.WriteLine($"  Driver: {net.Driver.Name}");

        if (net.Driver is TruthTableProcess gateProcess)
        {
            Console.WriteLine($"[diag] {port.Role}: driven by {gateProcess.Name}");

            var a = gateProcess._a?.CurrentValue ?? 0;
            var b = gateProcess._b?.CurrentValue ?? 0;
            var c = gateProcess._c?.CurrentValue ?? 0;
            var d = gateProcess._d?.CurrentValue ?? 0;

            Console.WriteLine($"       inputs: A={a} B={b} C={c} D={d}");
        }

        Console.WriteLine($"  LastWriter: {net.LastDriver?.Name ?? "stimulus"}");
    }
}