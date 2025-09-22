using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Decode;

public class ALUCtrl2 : SubCircuit
{
    public Port Op1 => Inputs[0];
    public Port Op0 => Inputs[1];
    public Port Rd1 => Inputs[2];
    public Port Rd0 => Inputs[3];
    public Port AluCtrl2 => Outputs[0];
    public Port AluCtrl1 => Outputs[1];
    public Port AluCtrl0 => Outputs[2];

    public ALUCtrl2()
    {
        this.AddInputs(nameof(Op1), nameof(Op0), nameof(Rd1), nameof(Rd0));
        this.AddOutputs(nameof(AluCtrl2), nameof(AluCtrl1), nameof(AluCtrl0));

        var GDD = this.AddLogicGate("GDD");
        var D17 = this.AddLogicGate("D17");
        var ZTZ = this.AddLogicGate("ZTZ");
        var D48G74DDD = this.AddLogicGate("D48G74DDD");
        var PPPZD0ZD0_0 = this.AddLogicGate("PPPZD0ZD0");
        var PPPZD0ZD0_1 = this.AddLogicGate("PPPZD0ZD0");

        this.AddWires([
            (Op1, GDD.B),
            (Op0, GDD.A),

            (Op1, D17.B),
            (Op0, D17.A),

            (Rd1, ZTZ.B),
            (Rd0, ZTZ.A),

            (ZTZ.Q, D48G74DDD.C),
            (Op1, D48G74DDD.B),
            (Op0, D48G74DDD.A),
            
            (GDD.Q, PPPZD0ZD0_0.C),
            (Rd1, PPPZD0ZD0_0.B),
            (D17.Q, PPPZD0ZD0_0.A),

            (GDD.Q, PPPZD0ZD0_1.C),
            (Rd0, PPPZD0ZD0_1.B),
            (D48G74DDD.Q, PPPZD0ZD0_1.A),

            (GDD.Q, AluCtrl2),
            (PPPZD0ZD0_0.Q, AluCtrl1),
            (PPPZD0ZD0_1.Q, AluCtrl0)
        ]);
    }

    public override string GetTests() => """
        ---- 00+
        ---0 00+
        ---+ 00+
        --0- 00+
        --00 000
        --0+ 00+
        --+- 00+
        --+0 00+
        --++ 00+
        -0-- 000
        -0-0 000
        -0-+ 000
        -00- 000
        -000 000
        -00+ 000
        -0+- 000
        -0+0 000
        -0++ 000
        -+-- 000
        -+-0 000
        -+-+ 000
        -+0- 000
        -+00 000
        -+0+ 000
        -++- 000
        -++0 000
        -+++ 000
        0--- 0++
        0--0 0++
        0--+ 0++
        0-0- 0++
        0-00 0+0
        0-0+ 0++
        0-+- 0++
        0-+0 0++
        0-++ 0++
        00-- 0-0
        00-0 0-0
        00-+ 0-0
        000- 0-0
        0000 0-+
        000+ 0-0
        00+- 0-0
        00+0 0-0
        00++ 0-0
        0+-- +--
        0+-0 +-0
        0+-+ +-+
        0+0- +0-
        0+00 +00
        0+0+ +0+
        0++- ++-
        0++0 ++0
        0+++ +++
        +--- 0--
        +--0 0--
        +--+ 0--
        +-0- 0--
        +-00 0--
        +-0+ 0--
        +-+- 0--
        +-+0 0--
        +-++ 0--
        +0-- 0--
        +0-0 0--
        +0-+ 0--
        +00- 0--
        +000 0--
        +00+ 0--
        +0+- 0--
        +0+0 0--
        +0++ 0--
        ++-- 000
        ++-0 000
        ++-+ 000
        ++0- 000
        ++00 000
        ++0+ 000
        +++- 000
        +++0 000
        ++++ 000
    """;
}