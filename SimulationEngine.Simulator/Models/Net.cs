namespace SimulationEngine.Simulator.Models;

internal sealed class Net(string name)
{
    public string Name { get; } = name;
    public byte CurrentValue { get; set; }
    public byte NextValue { get; set; }
    public bool Dirty { get; private set; }

    public IProcess? Driver { get; private set; }
    public int DriverCount { get; private set; }
    public IProcess? LastDriver { get; private set; }

    public List<IProcess> Fanout { get; private set; } = [];

    public void RegisterDriver(IProcess process)
    {
        DriverCount++;
        Driver ??= process;
    }

    public void Propose(byte value, DeltaKernel deltaKernel, IProcess? process = null)
    {
        if (Dirty && NextValue == value) 
            return;

        NextValue = value;
        Dirty = true;
        LastDriver = process;

        deltaKernel.MarkNetDirty(this);
    }

    internal bool CommitAndWake(DeltaKernel deltaKernel)
    {
        if (!Dirty) 
            return false;
        Dirty = false;

        if (CurrentValue == NextValue) 
            return false;
        CurrentValue = NextValue;

        if (deltaKernel.Trace) 
            Console.WriteLine($"  commit {Name} := {CurrentValue} (by {LastDriver?.Name ?? "stimulus"})");

        foreach (var process in Fanout) 
            deltaKernel.ScheduleDelta(process);

        return true;
    }
}