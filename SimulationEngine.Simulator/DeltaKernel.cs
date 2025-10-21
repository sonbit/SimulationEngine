using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator;

internal sealed partial class DeltaKernel
{
    private const int MaxDelta = 100000;

    private readonly Queue<IProcess> _deltaQueue = new();
    private readonly HashSet<IProcess> _scheduled = [];
    private readonly HashSet<Net> _dirtyNets = [];

    public bool Trace { get; set; } = false;

    public void MarkNetDirty(Net net) => _dirtyNets.Add(net);

    public void ScheduleDelta(IProcess process)
    {
        if (_scheduled.Add(process))
            _deltaQueue.Enqueue(process);
    }

    public void Set(Net net, byte value)
    {
        if (Trace) 
            Console.WriteLine($"set {net.Name} -> {value}");

        net.Propose(value, this, null);
        IterateProcesses();
    }

    private void DequeueAndEvaluate()
    {
        var process = _deltaQueue.Dequeue();
        _scheduled.Remove(process);

        if (Trace)
            Console.WriteLine($" eval {process.Name}");

        process.Evaluate(this);
    }

    private void IterateProcesses()
    {
        int iterations = 0;

        while (true)
        {
            while (_deltaQueue.Count > 0)
                DequeueAndEvaluate();

            bool anyDirtyNets = false;
            foreach (var dirtyNet in _dirtyNets.ToArray())
            {
                if (dirtyNet.CommitAndWake(this))
                    anyDirtyNets = true;

                _dirtyNets.Remove(dirtyNet);
            }

            if (!anyDirtyNets) 
                break;

            if (++iterations <= MaxDelta)
                continue;

            throw new InvalidOperationException("Reached delta limit before converging");
        }
    }
}