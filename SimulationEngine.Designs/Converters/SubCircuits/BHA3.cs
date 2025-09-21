using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Converters.SubCircuits;

public class BHA3 : SubCircuit
{
    public Port D => Inputs[0];
    public Port C => Inputs[1];
    public Port B => Inputs[2];
    public Port A => Inputs[3];
    public Port Q3 => Outputs[0];
    public Port Q2 => Outputs[1];
    public Port Q1 => Outputs[2];
    public Port Q0 => Outputs[3];

    public BHA3()
    {
        this.AddBinaryInputs(nameof(D), nameof(C), nameof(B), nameof(A));
        this.AddBinaryOutputs(nameof(Q3), nameof(Q2), nameof(Q1), nameof(Q0));

        var bha0 = this.AddSubCircuit(new BHA());
        var bha1 = this.AddSubCircuit(new BHA());
        var bha2 = this.AddSubCircuit(new BHA());

        this.AddWires([
            (D, bha0.B),
            (A, bha0.A),

            (B, bha1.B),
            (bha0.Q1, bha1.A),

            (C, bha2.B),
            (bha1.Q1, bha2.A),

            (bha2.Q1, Q3),
            (bha2.Q0, Q2),
            (bha1.Q0, Q1),
            (bha0.Q0, Q0)
        ]);
    }
}