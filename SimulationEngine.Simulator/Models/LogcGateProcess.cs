namespace SimulationEngine.Simulator.Models;

internal sealed class LogicGateProcess : IProcess
{
    public readonly Net? _a;
    public readonly Net? _b;
    public readonly Net? _c;
    public readonly Net? _d;

    private readonly Net _q;
    private readonly byte[] _truthTable;
    private readonly byte _arity;

    public LogicGateProcess(string name, Net? a, Net? b, Net? c, Net? d, Net q, byte[] truthTable)
    {
        Name = name;
        _a = a; 
        _b = b;
        _c = c; 
        _d = d;
        _q = q;

        _truthTable = truthTable ?? throw new ArgumentNullException(nameof(truthTable));
        _arity = _truthTable.Length switch 
        { 
            3 => 1, 
            9 => 2, 
            27 => 3, 
            81 => 4, 
            _ => throw new ArgumentException("TruthTable length must be 3, 9, 27, or 81 (Arity 1 to 4)") 
        };

        _a?.Fanout.Add(this);
        _b?.Fanout.Add(this);
        _c?.Fanout.Add(this);
        _d?.Fanout.Add(this);
        _q.RegisterDriver(this);
    }

    public string Name { get; }

    public void Evaluate(DeltaKernel deltaKernel)
    {
        var tri = GetOutput();
        _q.Propose(tri, deltaKernel, this);
    }

    public List<Net> GetInputs()
    {
        var inputs = new List<Net>();
        if (_a is not null) inputs.Add(_a);
        if (_b is not null) inputs.Add(_b);
        if (_c is not null) inputs.Add(_c);
        if (_d is not null) inputs.Add(_d);
        return inputs;
    }

    private byte GetOutput()
    {
        var index = ComputeIndex(
            _a?.CurrentValue ?? 0, 
            _b?.CurrentValue ?? 0, 
            _c?.CurrentValue ?? 0, 
            _d?.CurrentValue ?? 0, 
            _arity);

        return _truthTable[index];
    }

    private static int ComputeIndex(byte a, byte b, byte c, byte d, byte arity)
    {
        return arity switch
        {
            1 => a,
            2 => b + 3 * a,
            3 => b + 3 * a + 9 * c,
            4 => b + 3 * a + 9 * c + 27 * d,
            _ => throw new InvalidOperationException("Arity needs to be between 1 and 4")
        };
    }
}
