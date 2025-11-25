using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Control;

public class AluControlFlow : Subcircuit
{
    public Port Op1 => Inputs[0];
    public Port Op0 => Inputs[1];
    public Port Rd21 => Inputs[2];
    public Port Rd20 => Inputs[3];

    public Port Func2 => Outputs[0];
    public Port Func1 => Outputs[1];
    public Port Func0 => Outputs[2];

    public AluControlFlow()
    {
        this.AddInputs(
            nameof(Op1),
            nameof(Op0),
            nameof(Rd21),
            nameof(Rd20));

        this.AddOutputs(
            nameof(Func2),
            nameof(Func1),
            nameof(Func0));

        var h14 = this.AddLogicGate("H14");
        var xxx = this.AddLogicGate("XXX");
        var _060 = this.AddLogicGate("060");
        var _2 = this.AddLogicGate("2");
        var h = this.AddLogicGate("H");
        var v = this.AddLogicGate("V");
        var d = this.AddLogicGate("D");
        var dar = this.AddLogicGate("DAR");
        var dae = this.AddLogicGate("DAE");

        var _3MUX1_0 = this.AddSubcircuit(new _3MUX1());
        var _3MUX1_1 = this.AddSubcircuit(new _3MUX1());

        this.AddWires([
            (Op1, h14.B),
            (Op0, h14.A),

            (Op1, dar.B),
            (Op0, dar.A),

            (Op1, xxx.B),
            (Op0, xxx.A),

            (Op1, dae.B),
            (Op0, dae.A),

            (Rd21, _060.B),
            (Rd20, _060.A),

            (Rd20, _2.A),
            (Rd21, v.A),
            (Rd20, d.A),
            (_060.Q, h.A),

            (dar.Q, _3MUX1_0.Sel),
            (_060.Q, _3MUX1_0.C),
            (xxx.Q, _3MUX1_0.B),
            (_2.Q, _3MUX1_0.A),

            (dae.Q, _3MUX1_1.Sel),
            (h.Q, _3MUX1_1.C),
            (d.Q, _3MUX1_1.B),
            (v.Q, _3MUX1_1.A),

            (h14.Q, Func2),
            (_3MUX1_0.Q, Func1),
            (_3MUX1_1.Q, Func0)
        ]);
    }

    public override string GetTestString() => """
        ---- 00+
        0--- 0+0
        +--- --0
        -0-- 000
        00-- -+-
        +0-- -+0
        -+-- +00
        0+-- ++0
        ++-- 0+0
        --0- 00+
        0-0- 0+0
        +-0- --0
        -00- 000
        000- -++
        +00- -+0
        -+0- +00
        0+0- ++0
        ++0- 0+0
        --+- 00+
        0-+- 0+0
        +-+- --0
        -0+- 000
        00+- -++
        +0+- -+0
        -++- +00
        0++- ++0
        +++- 0+0
        ---0 00+
        0--0 0+0
        +--0 --0
        -0-0 000
        00-0 ---
        +0-0 -+0
        -+-0 +00
        0+-0 ++0
        ++-0 0+0
        --00 000
        0-00 0+0
        +-00 -+0
        -000 000
        0000 --+
        +000 -+0
        -+00 +00
        0+00 0+0
        ++00 00+
        --+0 0+0
        0-+0 --0
        +-+0 000
        -0+0 --+
        00+0 -+0
        +0+0 +00
        -++0 ++0
        0++0 0+0
        +++0 00+
        ---+ 0+0
        0--+ --0
        +--+ 000
        -0-+ ---
        00-+ 0+0
        +0-+ 0+0
        -+-+ 0+0
        0+-+ 0+0
        ++-+ 0+0
        --0+ 0+0
        0-0+ 0+0
        +-0+ 0+0
        -00+ 0+0
        000+ --0
        +00+ -+0
        -+0+ +00
        0+0+ ++0
        ++0+ 0+0
        --++ 00+
        0-++ 0+0
        +-++ --0
        -0++ 000
        00++ --+
        +0++ -+0
        -+++ +00
        0+++ ++0
        ++++ 0+0
    """;
}