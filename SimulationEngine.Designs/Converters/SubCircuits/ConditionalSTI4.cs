using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Converters.SubCircuits;

public class ConditionalSTI4 : SubCircuit
{
    public Port Sign => Inputs[0];
    public Port A3 => Inputs[1];
    public Port A2 => Inputs[2];
    public Port A1 => Inputs[3];
    public Port A0 => Inputs[4];
    public Port Q3 => Outputs[0];
    public Port Q2 => Outputs[1];
    public Port Q1 => Outputs[2];
    public Port Q0 => Outputs[3];

    public ConditionalSTI4()
    {
        this.AddBinaryInput(nameof(Sign));
        this.AddInputs(nameof(A3), nameof(A2), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q3), nameof(Q2), nameof(Q1), nameof(Q0));

        var condSTI_0 = this.AddLogicGate("5DP");
        var condSTI_1 = this.AddLogicGate("5DP");
        var condSTI_2 = this.AddLogicGate("5DP");
        var condSTI_3 = this.AddLogicGate("5DP");

        this.AddWires([
            (Sign, condSTI_0.B),
            (A3, condSTI_0.A),

            (Sign, condSTI_1.B),
            (A2, condSTI_1.A),

            (Sign, condSTI_2.B),
            (A1, condSTI_2.A),

            (Sign, condSTI_3.B),
            (A0, condSTI_3.A),

            (condSTI_0.Q, Q3),
            (condSTI_1.Q, Q2),
            (condSTI_2.Q, Q1),
            (condSTI_3.Q, Q0)
        ]);
    }
}