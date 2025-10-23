namespace SimulationEngine.Simulator.Models;

internal sealed class Net(string name)
{
    public string Name { get; } = name;
    public byte Value { get; set; }
    public byte PendingValue { get; set; }
    public bool HasPendingWrite { get; private set; }

    public IProcess? Driver { get; private set; }
    public int DriverCount { get; private set; }
    public IProcess? LastWriter { get; private set; }

    public List<IProcess> Fanout { get; private set; } = [];

    public void RegisterDriver(IProcess process)
    {
        DriverCount++;
        Driver ??= process;
    }

    public void StageWrite(byte value, DeltaKernel kernel, IProcess? process = null)
    {
        if (HasPendingWrite && PendingValue == value) 
            return;

        PendingValue = value;
        HasPendingWrite = true;
        LastWriter = process;

        kernel.MarkPendingWrite(this);
    }

    internal bool CommitAndScheduleFanout(DeltaKernel kernel)
    {
        if (!HasPendingWrite) 
            return false;
        HasPendingWrite = false;

        if (Value == PendingValue) 
            return false;
        Value = PendingValue;

        if (kernel.Trace) 
            Console.WriteLine($"  commit {Name} := {Value} (by {LastWriter?.Name ?? "stimulus"})");

        foreach (var process in Fanout) 
            kernel.ScheduleProcess(process);

        return true;
    }
}