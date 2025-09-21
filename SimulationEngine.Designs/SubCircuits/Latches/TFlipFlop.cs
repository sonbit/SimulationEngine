using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Latches;

public class TFlipFlop : SubCircuit
{
    public Port Clk => Inputs[0];
    public Port A => Inputs[1];
    public Port Q => Outputs[0];

    public TFlipFlop()
    {
        this.AddBinaryInput(nameof(Clk));
        this.AddInput(nameof(A));
        this.AddOutputs(nameof(Q));

        var _2 = this.AddLogicGate("2");

        var btl0 = this.AddSubCircuit(new BTLatch());
        var btl1 = this.AddSubCircuit(new BTLatch());

        this.AddWires([
            (Clk, _2.A),

            (_2.Q, btl0.Clk),
            (A, btl0.Din),

            (Clk, btl1.Clk),
            (btl0.Dout, btl1.Din),

            (btl1.Dout, Q)
        ]);
    }
}