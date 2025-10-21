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

        var nand_0 = this.AddLogicGate("002");
        var nand_1 = this.AddLogicGate("002");

        this.AddWires([
            (Reset, nand_0.B),
            (Set, nand_1.A),

            (nand_0.Q, nand_1.B),
            (nand_1.Q, nand_0.A),

            (nand_0.Q, Q),
            (nand_1.Q, NotQ)
        ]);
    }
}