using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class CMP2 : SubCircuit
{
    public Port B1 => Inputs[0];
    public Port B0 => Inputs[1];
    public Port A1 => Inputs[2];
    public Port A0 => Inputs[3];
    public Port Min1 => Outputs[0];
    public Port Min0 => Outputs[1];
    public Port Max1 => Outputs[2];
    public Port Max0 => Outputs[3];
    public Port Cmp => Outputs[4];

    public CMP2()
    {
        this.AddInputs(nameof(B1), nameof(B0), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Min1), nameof(Min0), nameof(Max1), nameof(Max0), nameof(Cmp));

        var _2TritComp = this.AddSubCircuit(new _2TritComp());
        var _2MUX2_0 = this.AddSubCircuit(new _2MUX2());
        var _2MUX2_1 = this.AddSubCircuit(new _2MUX2());

        this.AddWires([
            (B1, _2TritComp.B1),
            (B0, _2TritComp.B0),
            (A1, _2TritComp.A1),
            (A0, _2TritComp.A0),

            (_2TritComp.Q, _2MUX2_0.Sel),
            (B1, _2MUX2_0.B1),
            (B0, _2MUX2_0.B0),
            (A1, _2MUX2_0.A1),
            (A0, _2MUX2_0.A0),

            (_2TritComp.Q, _2MUX2_1.Sel),
            (A1, _2MUX2_1.B1),
            (A0, _2MUX2_1.B0),
            (B1, _2MUX2_1.A1),
            (B0, _2MUX2_1.A0),

            (_2MUX2_0.Q1, Min1),
            (_2MUX2_0.Q0, Min0),
            (_2MUX2_1.Q1, Max1),
            (_2MUX2_1.Q0, Max0),
            (_2TritComp.Q, Cmp)
        ]);
    }

    public override string GetTests() => """
        ---- ----0
        ---0 ---0+
        -0-- ---0-
        --+- --+-+
        +--- --+--
        +--0 -0+--
        -0-0 -0-00
        -0-+ -0-++
        -+-0 -0-+-
        -+-+ -+-+0
        -+0- -+0-+
        0-0- 0-0-0
        000- 0-00-
        0000 00000
        000+ 000++
        0+0+ 0+0+0
        +-0+ 0++--
        +-+- +-+-0
        +-+0 +-+0+
        +0+0 +0+00
        +++0 +0++-
        ++++ ++++0
    """;
}