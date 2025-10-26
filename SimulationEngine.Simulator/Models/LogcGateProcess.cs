namespace SimulationEngine.Simulator.Models;

internal sealed class LogicGateProcess : IProcess
{
    private readonly Net _q;
    private readonly byte[] _truthTable;
    private readonly byte _arity;

    public LogicGateProcess(string name, Net a, Net? b, Net? c, Net? d, Net q, byte[] truthTable)
    {
        Name = name;
        A = a; 
        B = b;
        C = c; 
        D = d;
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

        A.Fanout.Add(this);
        B?.Fanout.Add(this);
        C?.Fanout.Add(this);
        D?.Fanout.Add(this);
        _q.Driver = this;
    }

    public Net A { get; private set; }
    public Net? B { get; private set; }
    public Net? C { get; private set; }
    public Net? D { get; private set; }
    public string Name { get; }

    public void Evaluate(DeltaKernel deltaKernel)
    {
        var trit = _truthTable[ComputeIndex()];
        _q.StageWrite(trit, deltaKernel, this);
    }

    public List<Net> GetInputs()
    {
        var inputs = new List<Net>();
        if (A is not null) inputs.Add(A);
        if (B is not null) inputs.Add(B);
        if (C is not null) inputs.Add(C);
        if (D is not null) inputs.Add(D);
        return inputs;
    }

    private int ComputeIndex()
    {
        var a = A.Value;
        var b = B?.Value ?? 0;
        var c = C?.Value ?? 0;
        var d = D?.Value ?? 0;

        return _arity switch
        {
            1 => a,
            2 => b + 3 * a,
            3 => b + 3 * a + 9 * c,
            4 => b + 3 * a + 9 * c + 27 * d,
            _ => throw new InvalidOperationException("Arity needs to be between 1 and 4")
        };
    }
}
