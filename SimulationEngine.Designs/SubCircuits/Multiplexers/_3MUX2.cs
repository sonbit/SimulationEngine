using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class _3MUX2 : SubCircuit
{
    public Port Sel => Inputs[0];
    public Port C1 => Inputs[1];
    public Port C0 => Inputs[2];
    public Port B1 => Inputs[3];
    public Port B0 => Inputs[4];
    public Port A1 => Inputs[5];
    public Port A0 => Inputs[6];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public _3MUX2()
    {
        this.AddInputs(nameof(Sel), nameof(C1), nameof(C0), nameof(B1), nameof(B0), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var _3MUX1_0 = this.AddSubCircuit(new _3MUX1());
        var _3MUX1_1 = this.AddSubCircuit(new _3MUX1());

        this.AddWires([
            (Sel, _3MUX1_0.Sel),
            (C1, _3MUX1_0.C),
            (B1, _3MUX1_0.B),
            (A1, _3MUX1_0.A),

            (Sel, _3MUX1_1.Sel),
            (C0, _3MUX1_1.C),
            (B0, _3MUX1_1.B),
            (A0, _3MUX1_1.A),

            (_3MUX1_0.Q, Q1),
            (_3MUX1_1.Q, Q0)
        ]);
    }

    public override string GetTestString() => """
        ------- --
        ------0 -0
        ------+ -+
        -----0- 0-
        -----00 00
        -----0+ 0+
        -----+- +-
        -----+0 +0
        -----++ ++
        0------ --
        0---0-- -0
        0---+-- -+
        0--0--- 0-
        0--00-- 00
        0--0+-- 0+
        0--+--- +-
        0--+0-- +0
        0--++-- ++
        +------ --
        +-0---- -0
        +-+---- -+
        +0----- 0-
        +00---- 00
        +0+---- 0+
        ++----- +-
        ++0---- +0
        +++---- ++
        -++---- --
        ------- --
    """;
}