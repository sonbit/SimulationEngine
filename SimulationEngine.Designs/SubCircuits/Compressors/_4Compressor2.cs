using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Compressors;

public class _4Compressor2 : Subcircuit
{
    public Port D => Inputs[0];
    public Port C => Inputs[1];
    public Port B => Inputs[2];
    public Port A => Inputs[3];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public _4Compressor2()
    {
        this.AddInputs(nameof(D), nameof(C), nameof(B), nameof(A));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var carry = this.AddLogicGate("ZXRXRDRDCXRDRDCDC9RDCDC9C90");
        var sum = this.AddLogicGate("PB7B7P7PBB7P7PBPB77PBPB7B7P");

        this.AddWires([
            (D, carry.D),
            (C, carry.C),
            (B, carry.B),
            (A, carry.A),

            (D, sum.D),
            (C, sum.C),
            (B, sum.B),
            (A, sum.A),

            (carry.Q, Q1),
            (sum.Q, Q0)
        ]);
    }

    public override string GetTestString() => """
        ---- --
        ---0 -0
        ---+ -+
        --0- -0
        --00 -+
        --0+ 0-
        --+- -+
        --+0 0-
        --++ 00
        -0-- -0
        -0-0 -+
        -0-+ 0-
        -00- -+
        -000 0-
        -00+ 00
        -0+- 0-
        -0+0 00
        -0++ 0+
        -+-- -+
        -+-0 0-
        -+-+ 00
        -+0- 0-
        -+00 00
        -+0+ 0+
        -++- 00
        -++0 0+
        -+++ +-
        0--- -0
        0--0 -+
        0--+ 0-
        0-0- -+
        0-00 0-
        0-0+ 00
        0-+- 0-
        0-+0 00
        0-++ 0+
        00-- -+
        00-0 0-
        00-+ 00
        000- 0-
        0000 00
        000+ 0+
        00+- 00
        00+0 0+
        00++ +-
        0+-- 0-
        0+-0 00
        0+-+ 0+
        0+0- 00
        0+00 0+
        0+0+ +-
        0++- 0+
        0++0 +-
        0+++ +0
        +--- -+
        +--0 0-
        +--+ 00
        +-0- 0-
        +-00 00
        +-0+ 0+
        +-+- 00
        +-+0 0+
        +-++ +-
        +0-- 0-
        +0-0 00
        +0-+ 0+
        +00- 00
        +000 0+
        +00+ +-
        +0+- 0+
        +0+0 +-
        +0++ +0
        ++-- 00
        ++-0 0+
        ++-+ +-
        ++0- 0+
        ++00 +-
        ++0+ +0
        +++- +-
        +++0 +0
        ++++ ++
    """;
}