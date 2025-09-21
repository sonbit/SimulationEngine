using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Converters.SubCircuits;

public class XOR3 : SubCircuit
{
    public Port Sign => Inputs[0];
    public Port A2 => Inputs[1];
    public Port A1 => Inputs[2];
    public Port A0 => Inputs[3];
    public Port Q2 => Outputs[0];
    public Port Q1 => Outputs[1];
    public Port Q0 => Outputs[2];

    public XOR3()
    {
        this.AddBinaryInputs(nameof(Sign), nameof(A2), nameof(A1), nameof(A0));
        this.AddBinaryOutputs(nameof(Q2), nameof(Q1), nameof(Q0));

        var xor0 = this.AddLogicGate("20K");
        var xor1 = this.AddLogicGate("20K");
        var xor2 = this.AddLogicGate("20K");

        this.AddWires([
            (Sign, xor0.B),
            (A2, xor0.A),

            (Sign, xor1.B),
            (A1, xor1.A),

            (Sign, xor2.B),
            (A0, xor2.A),

            (xor0.Q, Q2),
            (xor1.Q, Q1),
            (xor2.Q, Q0)
        ]);
    }
}