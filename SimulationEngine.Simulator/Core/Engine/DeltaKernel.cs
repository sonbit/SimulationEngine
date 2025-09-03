using SimulationEngine.Simulator.Core.Interfaces;
using SimulationEngine.Simulator.Core.Model;

namespace SimulationEngine.Simulator.Core.Engine;

internal sealed class DeltaKernel
{
    private const int MaxDelta = 100000;

    private readonly Queue<IProcess> _deltaQueue = new();
    private readonly HashSet<IProcess> _scheduled = [];
    private readonly HashSet<Net> _dirtyNets = [];

    public bool Trace { get; set; } = false;

    public void ScheduleDelta(IProcess process)
    {
        if (_scheduled.Add(process)) 
            _deltaQueue.Enqueue(process);
    }

    public void MarkNetDirty(Net net) => _dirtyNets.Add(net);

    public void Prime(IEnumerable<IProcess> processes)
    {
        foreach (var process in processes) 
            ScheduleDelta(process);

        RunToQuiescence();
    }

    public void Set(Net net, byte value)
    {
        if (Trace) 
            Console.WriteLine($"set {net.Name} -> {value}");

        net.Propose(value, this, null);
        RunToQuiescence();
    }

    private void RunToQuiescence()
    {
        int iterations = 0;

        while (true)
        {
            while (_deltaQueue.Count > 0)
            {
                var process = _deltaQueue.Dequeue();
                _scheduled.Remove(process);

                if (Trace) 
                    Console.WriteLine($" eval {process.Name}");

                process.Evaluate(this);
            }

            bool anyDirtyNets = false;
            foreach (var dirtyNet in _dirtyNets.ToArray())
            {
                if (dirtyNet.CommitAndWake(this)) 
                    anyDirtyNets = true;

                _dirtyNets.Remove(dirtyNet);
            }

            if (!anyDirtyNets) 
                break;

            if (++iterations > MaxDelta)
                throw new InvalidOperationException("Reached delta limit after not converging");
        }
    }
}