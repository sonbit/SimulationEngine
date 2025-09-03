using SimulationEngine.Simulator.Core.Engine;
using SimulationEngine.Simulator.Core.Interfaces;

namespace SimulationEngine.Simulator.Core.Model;

internal sealed class Net(string name)
{
    public string Name { get; } = name;
    public byte Current { get; private set; }
    public byte Next { get; private set; }
    public bool Dirty { get; private set; }

    public IProcess? Driver { get; private set; }
    public int DriverCount { get; private set; }
    public IProcess? LastWriter { get; private set; }

    public List<IProcess> Fanout { get; private set; } = [];

    public void RegisterDriver(IProcess process)
    {
        DriverCount++;
        Driver ??= process;
    }

    public void Propose(byte value, DeltaKernel simKernel, IProcess? process = null)
    {
        if (Dirty && Next == value) 
            return;

        Next = value;
        Dirty = true;
        LastWriter = process;

        simKernel.MarkNetDirty(this);
    }

    internal bool CommitAndWake(DeltaKernel simKernel)
    {
        if (!Dirty) 
            return false;
        Dirty = false;

        if (Current == Next) 
            return false;
        Current = Next;

        if (simKernel.Trace) 
            Console.WriteLine($"  commit {Name} := {Current} (by {LastWriter?.Name ?? "stimulus"})");

        foreach (var process in Fanout) 
            simKernel.ScheduleDelta(process);

        return true;
    }
}