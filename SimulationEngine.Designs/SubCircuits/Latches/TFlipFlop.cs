using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Latches;

public class TFlipFlop : Subcircuit
{
    public Port Clk => Inputs[0];
    public Port A => Inputs[1];
    public Port Q => Outputs[0];

    public TFlipFlop()
    {
        this.AddBinaryInput(nameof(Clk));
        this.AddInput(nameof(A));
        this.AddOutputs(nameof(Q));

        var _2 = this.AddBinaryLogicGate("2");

        var btl0 = this.AddSubcircuit(new BTLatch());
        var btl1 = this.AddSubcircuit(new BTLatch());

        this.AddWires([
            (Clk, _2.A),

            (_2.Q, btl0.Clk),
            (A, btl0.Din),

            (Clk, btl1.Clk),
            (btl0.Dout, btl1.Din),

            (btl1.Dout, Q)
        ]);
    }

    public override string GetTestString() => """
        0- -
        1- -
        00 -
        10 0
        0+ 0
        1+ +
        0- +
        1- -
        00 -
        10 0
        0+ 0
        1+ +
        0- +
        1- -
        00 -
        10 0
        0+ 0
        1+ +
        0- +
        1- -
        0- -
    """;
}