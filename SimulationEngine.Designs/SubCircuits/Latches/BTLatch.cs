using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Latches;

public class BTLatch : SubCircuit
{
    public Port Clk => Inputs[0];
    public Port Din => Inputs[1];
    public Port Dout => Outputs[0];

    public BTLatch()
    {
        this.AddBinaryInput(nameof(Clk));
        this.AddInput(nameof(Din));
        this.AddOutputs(nameof(Dout));

        var ZD0PPPPPP = this.AddLogicGate("ZD0PPPPPP");

        this.AddWires([
            (Clk, ZD0PPPPPP.C),
            (Din, ZD0PPPPPP.A),

            (ZD0PPPPPP.Q, ZD0PPPPPP.B),
            (ZD0PPPPPP.Q, Dout)
        ]);
    }

    public override string GetTests() => """
        0- -
        00 -
        10 0
        0+ 0
        1+ +
        00 +
        10 0
        0- 0
        1- -
        0+ -
        10 0
        0+ 0
        1+ +
        0- +
        1- -
        0- -
    """;
}