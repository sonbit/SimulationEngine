using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Latches;

public class _2Latch2 : SubCircuit
{
    public Port Clk => Inputs[0];
    public Port A1 => Inputs[1];
    public Port A0 => Inputs[2];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public _2Latch2()
    {
        this.AddBinaryInput(nameof(Clk));
        this.AddInputs(nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var btl0 = this.AddSubCircuit(new BTLatch());
        var btl1 = this.AddSubCircuit(new BTLatch());

        this.AddWires([
            (Clk, btl0.Clk),
            (A1, btl0.Din),

            (Clk, btl1.Clk),
            (A0, btl1.Din),

            (btl0.Dout, Q1),
            (btl1.Dout, Q0)
        ]);
    }

    public override string GetTests() => """
        0-- --
        1-- --
        0-0 --
        1-0 -0
        0-- -0
        1-+ -+
        0-- -+
        10- 0-
        0-- 0-
        100 00
        0-- 00
        10+ 0+
        0-- 0+
        1+- +-
        0-- +-
        1+0 +0
        0-- +0
        1++ ++
        0-- ++
        1-- --
        0-- --
    """;
}