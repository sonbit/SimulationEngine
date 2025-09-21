using SimulationEngine.Designs.SubCircuits.Adders;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class _2TritMul : SubCircuit
{
    public Port B1 => Inputs[0];
    public Port B0 => Inputs[1];
    public Port A1 => Inputs[2];
    public Port A0 => Inputs[3];
    public Port Q3 => Outputs[0];
    public Port Q2 => Outputs[1];
    public Port Q1 => Outputs[2];
    public Port Q0 => Outputs[3];

    public _2TritMul()
    {
        this.AddInputs(nameof(B1), nameof(B0), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q3), nameof(Q2), nameof(Q1), nameof(Q0));

        var PD5_0 = this.AddLogicGate("PD5");
        var PD5_1 = this.AddLogicGate("PD5");
        var PD5_2 = this.AddLogicGate("PD5");
        var PD5_3 = this.AddLogicGate("PD5");

        var triHalfAdder_0 = this.AddSubCircuit(new TriHalfAdder());
        var triHalfAdder_1 = this.AddSubCircuit(new TriHalfAdder());

        this.AddWires([
            (B1, PD5_0.B),
            (A1, PD5_0.A),

            (B0, PD5_1.B),
            (A1, PD5_1.A),

            (B1, PD5_2.B),
            (A0, PD5_2.A),

            (B0, PD5_3.B),
            (A0, PD5_3.A),
            
            (PD5_1.Q, triHalfAdder_0.B),
            (PD5_2.Q, triHalfAdder_0.A),

            (PD5_0.Q, triHalfAdder_1.B),
            (triHalfAdder_0.Cout, triHalfAdder_1.A),

            (triHalfAdder_1.Cout, Q3),
            (triHalfAdder_1.Q, Q2),
            (triHalfAdder_0.Q, Q1),
            (PD5_3.Q, Q0)
        ]);
    }
}