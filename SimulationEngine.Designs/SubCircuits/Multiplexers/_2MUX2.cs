using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class _2MUX2 : SubCircuit
{
    public Port Sel => Inputs[0];
    public Port B1 => Inputs[1];
    public Port B0 => Inputs[2];
    public Port A1 => Inputs[3];
    public Port A0 => Inputs[4];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public _2MUX2()
    {
        this.AddInputs(nameof(Sel), nameof(B1), nameof(B0), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var PPPZD0ZD0_0 = this.AddLogicGate("PPPZD0ZD0");
        var PPPZD0ZD0_1 = this.AddLogicGate("PPPZD0ZD0");

        this.AddWires([
            (Sel, PPPZD0ZD0_0.C),
            (B1, PPPZD0ZD0_0.B),
            (A1, PPPZD0ZD0_0.A),

            (Sel, PPPZD0ZD0_1.C),
            (B0, PPPZD0ZD0_1.B),
            (A0, PPPZD0ZD0_1.A),

            (PPPZD0ZD0_0.Q, Q1),
            (PPPZD0ZD0_1.Q, Q0)
        ]);
    }

    public override string GetTests() => """
        ----- --
        ----0 -0
        ----+ -+
        ---0- 0-
        ---+- +-
        ---00 00
        ---+0 +0
        ---++ ++
        --0-- --
        --+-- --
        -0--- --
        -+--- --
        -00-- --
        -+0-- --
        -++-- --
        -00++ ++
        -++00 00
        00--- --
        0+--- --
        000-- --
        0+0-- --
        0++-- --
        000++ ++
        0++00 00
        +0-+- 0-
        ++-0- +-
        +00++ 00
        ++00+ +0
        +++00 ++
        +00++ 00
        +++-- ++
        ----- --
    """;
}