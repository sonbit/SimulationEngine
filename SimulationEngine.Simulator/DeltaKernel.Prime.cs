using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator;

internal sealed partial class DeltaKernel
{
    private const byte DefaultValue = 0;
    private const int LoopDeltaLimit = 4;

    private readonly Queue<HashSet<Net>> _recentNetWrites = new();
    private HashSet<Net> _allNets = [];

    public void Prime(IEnumerable<IProcess> processes, HashSet<Net> allNets)
    {
        _allNets = allNets;

        foreach (var process in processes)
            ScheduleProcess(process);

        InitialRunDeltaToQuiescence();
    }

    private bool InitialCommitPendingNetUpdates()
    {
        if (_pendingNetWrites.Count == 0)
            return false;

        var netWrites = new List<Net>();

        foreach (var net in _pendingNetWrites.ToArray())
        {
            if (net.CommitAndScheduleFanout(this))
                netWrites.Add(net);
            _pendingNetWrites.Remove(net);
        }

        if (netWrites.Count > 0)
        {
            _recentNetWrites.Enqueue([.. netWrites]);
            while (_recentNetWrites.Count > LoopDeltaLimit)
                _recentNetWrites.Dequeue();
        }

        return netWrites.Count > 0;
    }

    private void InitialRunDeltaToQuiescence()
    {
        int delta = 0;

        while (true)
        {
            while (_readyQueue.Count > 0)
                EvaluateNextReadyProcess();

            if (!InitialCommitPendingNetUpdates())
                break;

            if (++delta <= MaxDelta)
                continue;

            if (TryResolveLoop())
            {
                delta = 0;
                _recentNetWrites.Clear();
                continue;
            }

            throw new InvalidOperationException("Delta-cycle failed to resolve loop convergence");
        }
    }

    private bool TryResolveLoop()
    {
        var oscillators = new HashSet<Net>();
        foreach (var recentNetWrite in _recentNetWrites)
            oscillators.UnionWith(recentNetWrite);

        if (oscillators.Count == 0 || oscillators.Count > LoopDeltaLimit)
            return false;

        var stableNet = new HashSet<Net>(_allNets);
        foreach (var recentNetWrite in _recentNetWrites)
            stableNet.ExceptWith(recentNetWrite);
        foreach (var pendingNetWrite in _pendingNetWrites)
            stableNet.Remove(pendingNetWrite);

        foreach (var net in oscillators)
        {
            var process = net.Driver;
            if (process == null)
                return false;

            foreach (var input in process.GetInputs())
            {
                if (!(oscillators.Contains(input) || stableNet.Contains(input)))
                    return false;
            }
        }

        var oscillator = oscillators.OrderBy(net => net.Name, StringComparer.Ordinal).First();
        oscillator.PendingValue = DefaultValue;
        oscillator.Value = DefaultValue;

        foreach (var process in oscillator.Fanout)
            ScheduleProcess(process);

        if (Trace)
            Console.WriteLine($"\ttie-break: forced {oscillator.Name} := {DefaultValue}");

        return true;
    }
}