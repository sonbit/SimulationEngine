using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Adders;

public class _2TritAdder : SubCircuit
{
    public Port B1 => Inputs[0];
    public Port B0 => Inputs[1];
    public Port A1 => Inputs[2];
    public Port A0 => Inputs[3];
    public Port Cout => Outputs[0];
    public Port Q1 => Outputs[1];
    public Port Q0 => Outputs[2];

    public _2TritAdder()
    {
        this.AddInputs(nameof(B1), nameof(B0), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Cout), nameof(Q1), nameof(Q0));

        var triHalfAdder = this.AddSubCircuit(new TriHalfAdder());
        var triFullAdder = this.AddSubCircuit(new TriFullAdder());

        this.AddWires([
            (B1, triFullAdder.B),
            (B0, triHalfAdder.B),

            (A1, triFullAdder.A),
            (A0, triHalfAdder.A),

            (triHalfAdder.Cout, triFullAdder.C),
            (triHalfAdder.Q, Q0),

            (triFullAdder.Cout, Cout),
            (triFullAdder.Q, Q1)
        ]);
    }

    public override string GetTestString() => """
        ---- -0+
        -0-- -+-
        -+-- -+0
        0--- -++
        00-- 0--
        0+-- 0-0
        +--- 0-+
        +0-- 00-
        ++-- 000
        ++-0 00+
        ++-+ 0+-
        ++0- 0+0
        ++00 0++
        ++0+ +--
        +++- +-0
        +++0 +-+
        ++++ +0-
        +0++ +-+
        +-++ +-0
        0+++ +--
        00++ 0++
        0-++ 0+0
        -+++ 0+-
        -0++ 00+
        --++ 000
        --+0 00-
        --+- 0-+
        --0+ 0-0
        --00 0--
        --0- -++
        ---+ -+0
        ---0 -+-
        ---- -0+
    """;
}