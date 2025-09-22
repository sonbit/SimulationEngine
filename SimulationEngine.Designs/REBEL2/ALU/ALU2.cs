using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class ALU2 : SubCircuit
{
    public Port Func2 => Inputs[0];
    public Port Func1 => Inputs[1];
    public Port Func0 => Inputs[2];
    public Port B1 => Inputs[3];
    public Port B0 => Inputs[4];
    public Port A1 => Inputs[5];
    public Port A0 => Inputs[6];
    public Port Cout => Outputs[0];
    public Port Q1 => Outputs[1];
    public Port Q0 => Outputs[2];

    public ALU2()
    {
        this.AddInputs(nameof(Func2), nameof(Func1), nameof(Func0), nameof(B1), nameof(B0), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Cout), nameof(Q1), nameof(Q0));

        var DGDDDDDAD = this.AddLogicGate("DGDDDDDAD");

        var shift2 = this.AddSubCircuit(new Shift2());
        var _2TritMul = this.AddSubCircuit(new _2TritMul());
        var addSub2 = this.AddSubCircuit(new AddSub2());
        var cmp2 = this.AddSubCircuit(new CMP2());
        var cmp2Tritwise = this.AddSubCircuit(new CMP2Tritwise());
        var _2MUX2_0 = this.AddSubCircuit(new _2MUX2());
        var _2MUX2_1 = this.AddSubCircuit(new _2MUX2());
        var _2MUX2_2 = this.AddSubCircuit(new _2MUX2());
        var _3MUX2_0 = this.AddSubCircuit(new _3MUX2());
        var _3MUX2_1 = this.AddSubCircuit(new _3MUX2());

        this.AddWires([
            (A1, shift2.A1),
            (A0, shift2.A0),
            (B1, shift2.Imm1),
            (B0, shift2.Imm0),
            (Func1, shift2.Dir),
            (Func0, shift2.Ins),

            (B1, _2TritMul.B1),
            (B0, _2TritMul.B0),
            (A1, _2TritMul.A1),
            (A0, _2TritMul.A0),

            (Func0, addSub2.Sel),
            (B1, addSub2.B1),
            (B0, addSub2.B0),
            (A1, addSub2.A1),
            (A0, addSub2.A0),

            (B1, cmp2.B1),
            (B0, cmp2.B0),
            (A1, cmp2.A1),
            (A0, cmp2.A0),

            (Func0, cmp2Tritwise.Mode),
            (B1, cmp2Tritwise.B1),
            (B0, cmp2Tritwise.B0),
            (A1, cmp2Tritwise.A1),
            (A0, cmp2Tritwise.A0),

            (Func0, _2MUX2_0.Sel),
            (_2TritMul.Q3, _2MUX2_0.B1),
            (_2TritMul.Q2, _2MUX2_0.B0),
            (_2TritMul.Q1, _2MUX2_0.A1),
            (_2TritMul.Q0, _2MUX2_0.A0),

            (Func0, _3MUX2_0.Sel),
            (cmp2.Max1, _3MUX2_0.C1),
            (cmp2.Max0, _3MUX2_0.C0),
            (cmp2.Cmp, _3MUX2_0.B1),
            (cmp2.Cmp, _3MUX2_0.B0),
            (cmp2.Min1, _3MUX2_0.A1),
            (cmp2.Min0, _3MUX2_0.A0),

            (addSub2.Q2, DGDDDDDAD.C),
            (Func2, DGDDDDDAD.B),
            (Func1, DGDDDDDAD.A),

            (Func1, _2MUX2_1.Sel),
            (_2MUX2_0.Q1, _2MUX2_1.B1),
            (_2MUX2_0.Q0, _2MUX2_1.B0),
            (addSub2.Q1, _2MUX2_1.A1),
            (addSub2.Q0, _2MUX2_1.A0),

            (Func1, _2MUX2_2.Sel),
            (_3MUX2_0.Q1, _2MUX2_2.B1),
            (_3MUX2_0.Q0, _2MUX2_2.B0),
            (cmp2Tritwise.Q1, _2MUX2_2.A1),
            (cmp2Tritwise.Q0, _2MUX2_2.A0),

            (Func2, _3MUX2_1.Sel),
            (shift2.Q1, _3MUX2_1.C1),
            (shift2.Q0, _3MUX2_1.C0),
            (_2MUX2_1.Q1, _3MUX2_1.B1),
            (_2MUX2_1.Q0, _3MUX2_1.B0),
            (_2MUX2_2.Q1, _3MUX2_1.A1),
            (_2MUX2_2.Q0, _3MUX2_1.A0),

            (DGDDDDDAD.Q, Cout),
            (_3MUX2_1.Q1, Q1),
            (_3MUX2_1.Q0, Q0)
        ]);
    }

    public override string GetTests() => """
        ------- 0--
        000---- -0+
        000---0 -+-
        000---+ -+0
        000--0- -++
        000--00 0--
        000--0+ 0-0
        000--+- 0-+
        000--+0 00-
        000--++ 000
        000-0-- -+-
        00+-+-0 00-
        00+-+-+ 000
        00+-+0- 00+
        00+-+00 0+-
        00+-+0+ 0+0
        00+-++- 0++
        00+-++0 +--
        00+-+++ +-0
        00+0--- 0-0
        00+0--0 0-+
        0+000-+ 000
        0+0000- 000
        0+00000 000
        0+0000+ 000
        0+000+- 000
        0+000+0 000
        0+000++ 000
        0+00+-- 0--
        0+00+-0 0-0
        0+00+-+ 0-+
        0+++-0- 000
        0+++-00 000
        0+++-0+ 000
        0+++-+- 000
        0+++-+0 00+
        0+++-++ 00+
        0+++0-- 00-
        0+++0-0 00-
        0+++0-+ 00-
        0+++00- 000
        --+++00 0++
        --+++0+ 0++
        --++++- 0++
        --++++0 0++
        --+++++ 0++
        --0---- 000
        --0---0 00+
        --0---+ 00+
        --0--0- 0+0
        --0--00 0++
        ----00+ 0-0
        ----0+- 0--
        ----0+0 0-0
        ----0++ 0-0
        ----+-- 0--
        ----+-0 0-0
        ----+-+ 0-+
        ----+0- 0--
        ----+00 0-0
        ----+0+ 0-+
        -++0-+- 0+-
        -++0-+0 0+0
        -++0-++ 0++
        -++00-- 000
        -++00-0 000
        -++00-+ 000
        -++000- 000
        -++0000 000
        -++000+ 00+
        -++00+- 0+-
        -+00++0 0++
        -+00+++ 0++
        -+0+--- 0--
        -+0+--0 0--
        -+0+--+ 0--
        -+0+-0- 0--
        -+0+-00 0--
        -+0+-0+ 0--
        -+0+-+- 000
        -+0+-+0 0++
        -+-+0++ 0+0
        -+-++-- 0--
        -+-++-0 0-0
        -+-++-+ 0-+
        -+-++0- 00-
        -+-++00 000
        -+-++0+ 00+
        -+-+++- 0+-
        -+-+++0 0+0
        -+-++++ 0++
        ++0-0-- 000
        ++0-0-0 000
        ++0-0-+ 000
        ++0-00- 000
        ++0-000 000
        ++0-00+ 000
        ++0-0+- 000
        ++0-0+0 000
        ++0-0++ 000
    """;
}