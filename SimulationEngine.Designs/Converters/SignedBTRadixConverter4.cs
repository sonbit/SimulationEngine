using SimulationEngine.Designs.Converters.SubCircuits;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Converters;

public class SignedBTRadixConverter4 : SubCircuit
{
    public Port Sign => Inputs[0];
    public Port A2 => Inputs[1];
    public Port A1 => Inputs[2];
    public Port A0 => Inputs[3];
    public Port Q3 => Outputs[0];
    public Port Q2 => Outputs[1];
    public Port Q1 => Outputs[2];
    public Port Q0 => Outputs[3];

    public SignedBTRadixConverter4()
    {
        this.AddBinaryInputs(nameof(Sign), nameof(A2), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q3), nameof(Q2), nameof(Q1), nameof(Q0));

        var xor3 = this.AddSubCircuit(new XOR3());
        var bha3 = this.AddSubCircuit(new BHA3());
        var unsignedBT_RadixConverter4 = this.AddSubCircuit(new UnsignedBT_RadixConverter4());
        var conditionalSTI4 = this.AddSubCircuit(new ConditionalSTI4());

        this.AddWires([
            (Sign, xor3.Sign),
            (A2, xor3.A2),
            (A1, xor3.A1),
            (A0, xor3.A0),

            (Sign, bha3.D),
            (xor3.Q2, bha3.C),
            (xor3.Q1, bha3.B),
            (xor3.Q0, bha3.A),

            (bha3.Q3, unsignedBT_RadixConverter4.B3),
            (bha3.Q2, unsignedBT_RadixConverter4.B2),
            (bha3.Q1, unsignedBT_RadixConverter4.B1),
            (bha3.Q0, unsignedBT_RadixConverter4.B0),

            (Sign, conditionalSTI4.Sign),
            (unsignedBT_RadixConverter4.Q3, conditionalSTI4.A3),
            (unsignedBT_RadixConverter4.Q2, conditionalSTI4.A2),
            (unsignedBT_RadixConverter4.Q1, conditionalSTI4.A1),
            (unsignedBT_RadixConverter4.Q0, conditionalSTI4.A0),

            (conditionalSTI4.Q3, Q3),
            (conditionalSTI4.Q2, Q2),
            (conditionalSTI4.Q1, Q1),
            (conditionalSTI4.Q0, Q0)
        ]);
    }
}