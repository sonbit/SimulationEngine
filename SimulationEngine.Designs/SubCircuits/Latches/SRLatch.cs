using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Latches;

public class SRLatch : Subcircuit
{
    public Port Reset => Inputs[0];
    public Port Set => Inputs[1];
    public Port Q => Outputs[0];
    public Port NotQ => Outputs[1];

    public SRLatch()
    {
        this.AddBinaryInputs(nameof(Reset), nameof(Set));
        this.AddBinaryOutputs(nameof(Q), nameof(NotQ));

        var nor_0 = this.AddLogicGate("002");
        var nor_1 = this.AddLogicGate("002");

        this.AddWires([
            (Reset, nor_0.B),
            (Set, nor_1.A),

            (nor_0.Q, nor_1.B),
            (nor_1.Q, nor_0.A),

            (nor_0.Q, Q),
            (nor_1.Q, NotQ)
        ]);
    }

    public override string GetTestString() => """
        00 01
        01 10
        10 01
        00 01
        01 10
        00 10
        01 10
        00 10
        10 01
        00 01
        11 00
        00 10
        11 00
        00 10
        10 01
        00 01
    """;
}