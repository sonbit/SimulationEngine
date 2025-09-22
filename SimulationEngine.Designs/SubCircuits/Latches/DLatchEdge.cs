using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Latches;

public class DLatchEdge : SubCircuit
{
    public Port Clk => Inputs[0];
    public Port Din => Inputs[1];
    public Port Dout => Outputs[0];

    public DLatchEdge()
    {
        this.AddBinaryInput(nameof(Clk));
        this.AddInput(nameof(Din));
        this.AddOutputs(nameof(Dout));

        var btl0 = this.AddSubCircuit(new BTLatch());
        var btl1 = this.AddSubCircuit(new BTLatch());

        var inv0 = this.AddLogicGate("5");
        var inv1 = this.AddLogicGate("5");

        this.AddWires([
            (Clk, inv0.A),
            (inv0.Q, inv1.A),

            (inv0.Q, btl0.Clk),
            (Din, btl0.Din),

            (inv1.Q, btl1.Clk),
            (btl0.Dout, btl1.Din),

            (btl1.Dout, Dout)
        ]);
    }

    public override string GetTests() => """
        0- -
        1- -
        00 -
        0+ -
        0- -
        00 -
        10 0
        0+ 0
        1+ +
        00 +
        10 0
        0- 0
        1- -
        0- -
    """;
}