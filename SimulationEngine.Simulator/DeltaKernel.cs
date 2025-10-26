using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator;

internal sealed partial class DeltaKernel
{
    private const int MaxDelta = 100000;

    private readonly Queue<IProcess> _readyQueue = new();
    private readonly HashSet<IProcess> _scheduled = [];
    private readonly HashSet<Net> _pendingNetWrites = [];

    public bool Trace { get; set; } = false;

    public void MarkPendingWrite(Net net) => _pendingNetWrites.Add(net);

    public void ScheduleProcess(IProcess process)
    {
        if (_scheduled.Add(process))
            _readyQueue.Enqueue(process);
    }

    public void Set(Net net, byte value)
    {
        if (Trace) 
            Console.WriteLine($"set {net.Name} -> {value}");

        net.StageWrite(value, this, null);
        RunDeltaToQuiescence();
    }

    private bool CommitPendingNetUpdates()
    {
        if (_pendingNetWrites.Count == 0)
            return false;

        var anyScheduled = false;

        foreach (var net in _pendingNetWrites.ToArray())
        {
            if (net.CommitAndScheduleFanout(this))
                anyScheduled = true; 
            _pendingNetWrites.Remove(net);
        }

        return anyScheduled;
    }

    private void EvaluateNextReadyProcess()
    {
        var process = _readyQueue.Dequeue();
        _scheduled.Remove(process);

        if (Trace)
            Console.WriteLine($"\teval {process.Name}");

        process.Evaluate(this);
    }

    private void RunDeltaToQuiescence()
    {
        var delta = 0;

        while (true)
        {
            while (_readyQueue.Count > 0)
                EvaluateNextReadyProcess();

            if (!CommitPendingNetUpdates()) 
                break;

            if (++delta > MaxDelta)
                throw new InvalidOperationException("Delta-cycle limit reached before convergence");
        }
    }
}