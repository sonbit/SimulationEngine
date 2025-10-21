using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Converters.Subcircuits;

public class BHA : Subcircuit
{
    public Port B => Inputs[0];
    public Port A => Inputs[1];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public BHA()
    {
        this.AddBinaryInputs(nameof(B), nameof(A));
        this.AddBinaryOutputs(nameof(Q1), nameof(Q0));

        var k00 = this.AddLogicGate("K00");
        var _20k = this.AddLogicGate("20K");

        this.AddWires([
            (B, k00.B),
            (A, k00.A),

            (B, _20k.B),
            (A, _20k.A),

            (k00.Q, Q1),
            (_20k.Q, Q0)
        ]);
    }
}