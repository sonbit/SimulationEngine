using SimulationEngine.Simulator.Core.Engine;
using SimulationEngine.Simulator.Core.Interfaces;
using SimulationEngine.Simulator.Core.Model;

namespace SimulationEngine.Simulator.Processes;

internal sealed class TruthTableProcess : IProcess
{
    public readonly Net? _a;
    public readonly Net? _b;
    public readonly Net? _c;
    public readonly Net? _d;

    private readonly Net _q;
    private readonly byte[] _truthTable;
    private readonly byte _arity;

    public TruthTableProcess(string name, Net? a, Net? b, Net? c, Net? d, Net q, byte[] truthTable)
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

    private byte GetOutput()
    {
        var a = _a?.Current;
        var b = _b?.Current;
        var c = _c?.Current;
        var d = _d?.Current;

        if ((_arity < 1 || a.HasValue) && (_arity < 2 || b.HasValue) && (_arity < 3 || c.HasValue) && (_arity < 4 || d.HasValue))
        {
            var index = ComputeIndex(a ?? 0, b ?? 0, c ?? 0, d ?? 0, _arity);
            return _truthTable[index];
        }

        static IEnumerable<byte> Domain(byte? value) => value.HasValue ? new[] { value.Value } : [0, 1, 2];

        byte? resolved = null;

        foreach (var ai in _arity >= 1 ? Domain(a) : [0])
        {
            foreach (var bi in _arity >= 2 ? Domain(b) : [0])
            {
                foreach (var ci in _arity >= 3 ? Domain(c) : [0])
                {
                    foreach (var di in _arity >= 4 ? Domain(d) : [0])
                    {
                        var index = ComputeIndex(ai, bi, ci, di, _arity);
                        var value = _truthTable[index];

                        if (resolved is null)
                            resolved = value;
                        else if (resolved.Value != value)
                            return 0;
                    }
                }
            }
        }

        return resolved is null ? (byte)0 : resolved.Value;
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
