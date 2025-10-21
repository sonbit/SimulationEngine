using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator;

internal sealed partial class DeltaKernel
{
    private const byte DefaultValue = 0;
    private const int LoopDeltaLimit = 4;

    private readonly Queue<HashSet<Net>> _recentDeltaChanges = new();
    private HashSet<Net> _allNets = [];

    public void Prime(IEnumerable<IProcess> processes, HashSet<Net> allNets)
    {
        _allNets = allNets;

        foreach (var process in processes)
            ScheduleDelta(process);

        IterateInitialProcesses();
    }

    private void IterateInitialProcesses()
    {
        int iterations = 0;

        while (true)
        {
            while (_deltaQueue.Count > 0)
                DequeueAndEvaluate();

            bool anyDirtyNets = false;
            var thisDeltaChanged = new List<Net>();

            foreach (var dirtyNet in _dirtyNets.ToArray())
            {
                if (dirtyNet.CommitAndWake(this))
                {
                    anyDirtyNets = true;
                    thisDeltaChanged.Add(dirtyNet);
                }
                _dirtyNets.Remove(dirtyNet);
            }

            if (thisDeltaChanged.Count > 0)
            {
                _recentDeltaChanges.Enqueue([.. thisDeltaChanged]);
                while (_recentDeltaChanges.Count > LoopDeltaLimit)
                    _recentDeltaChanges.Dequeue();
            }

            if (!anyDirtyNets)
                break;

            if (++iterations <= MaxDelta)
                continue;

            if (TryResolveLoop())
            {
                iterations = 0;
                _recentDeltaChanges.Clear();
                continue;
            }

            throw new InvalidOperationException("Init did not converge and no loop could be resolved");
        }
    }

    private bool TryResolveLoop()
    {
        var oscillators = new HashSet<Net>();
        foreach (var recentDeltaChange in _recentDeltaChanges)
            oscillators.UnionWith(recentDeltaChange);

        if (oscillators.Count == 0 || oscillators.Count > LoopDeltaLimit)
            return false;

        var stableNet = new HashSet<Net>(_allNets);
        foreach (var recentDeltaChangeNets in _recentDeltaChanges)
            stableNet.ExceptWith(recentDeltaChangeNets);
        foreach (var dirtyNet in _dirtyNets)
            stableNet.Remove(dirtyNet);

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
        oscillator.NextValue = DefaultValue;
        oscillator.CurrentValue = DefaultValue;

        foreach (var process in oscillator.Fanout)
            ScheduleDelta(process);

        if (Trace)
            Console.WriteLine($" tie-break: forced {oscillator.Name} := {DefaultValue}");

        return true;
    }
}