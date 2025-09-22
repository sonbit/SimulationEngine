using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class CMP2Tritwise : SubCircuit
{
    public Port Mode => Inputs[0];
    public Port B1 => Inputs[1];
    public Port B0 => Inputs[2];
    public Port A1 => Inputs[3];
    public Port A0 => Inputs[4];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public CMP2Tritwise()
    {
        this.AddInputs(nameof(Mode), nameof(B1), nameof(B0), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var ZRPH51PC0_0 = this.AddLogicGate("ZRPH51PC0");
        var ZRPH51PC0_1 = this.AddLogicGate("ZRPH51PC0");

        this.AddWires([
            (Mode, ZRPH51PC0_0.C),
            (B1, ZRPH51PC0_0.B),
            (A1, ZRPH51PC0_0.A),

            (Mode, ZRPH51PC0_1.C),
            (B0, ZRPH51PC0_1.B),
            (A0, ZRPH51PC0_1.A),

            (ZRPH51PC0_0.Q, Q1),
            (ZRPH51PC0_1.Q, Q0)
        ]);
    }

    public override string GetTests() => """
        ----- --
        -++++ ++
        -+0++ +0
        -+0+0 +0
        -+0+- +-
        -+-+- +-
        -0++- 0-
        -0+0+ 0+
        -0+00 00
        -0000 00
        -0-00 0-
        -0-0- 0-
        -0--+ --
        --+-+ -+
        --0-+ -0
        --0-0 -0
        --0-- --
        ----- --
        0---- 00
        0---0 0+
        0-0-0 00
        0-+-0 0-
        0-+-+ 00
        0-+0- +-
        00-0- 00
        0000- 0-
        00000 00
        0000+ 0+
        00+0+ 00
        0+-0+ -+
        0+-+- 00
        0+-+0 0+
        0+0+0 00
        0+++0 0-
        0++++ 00
        +++++ ++
        ++0++ ++
        ++0+0 +0
        ++0+- +0
        ++-+- +-
        +0++- ++
        +0+0+ 0+
        +0+00 0+
        +0000 00
        +0-00 00
        +0-0- 0-
        +0--+ 0+
        +-+-+ -+
        +-0-+ -+
        +-0-0 -0
        +-0-- -0
        +---- --
        ----- --
    """;
}