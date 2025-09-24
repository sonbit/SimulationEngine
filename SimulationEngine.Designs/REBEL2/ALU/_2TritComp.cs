using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class _2TritComp : SubCircuit
{
    public Port B1 => Inputs[0];
    public Port B0 => Inputs[1];
    public Port A1 => Inputs[2];
    public Port A0 => Inputs[3];
    public Port Q => Outputs[0];

    public _2TritComp()
    {
        this.AddInputs(nameof(B1), nameof(B0), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q));

        var H51 = this.AddLogicGate("H51");
        var ZZZH51000 = this.AddLogicGate("ZZZH51000");

        this.AddWires([
            (B1, H51.B),
            (A1, H51.A),

            (H51.Q, ZZZH51000.C),
            (B0, ZZZH51000.B),
            (A0, ZZZH51000.A),

            (ZZZH51000.Q, Q)
        ]);
    }

    public override string GetTestString() => """
        ---- 0
        ---0 +
        -0-0 0
        -+-0 -
        -+-+ 0
        -+0- +
        0-0- 0
        000- -
        0000 0
        000+ +
        0+0+ 0
        +-0+ -
        +-+- 0
        +-+0 +
        +0+0 0
        +++0 -
        ++++ 0
    """;
}