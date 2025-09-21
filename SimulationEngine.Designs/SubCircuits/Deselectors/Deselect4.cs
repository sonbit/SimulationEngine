using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Designs.SubCircuits.Deselectors;

public class Deselect4 : SubCircuit
{
    public Port Sel => Inputs[0];
    public Port A3 => Inputs[1];
    public Port A2 => Inputs[2];
    public Port A1 => Inputs[3];
    public Port A0 => Inputs[4];
    public Port B3 => Inputs[5];
    public Port B2 => Inputs[6];
    public Port B1 => Inputs[7];
    public Port B0 => Inputs[8];
    public Port S3 => Outputs[0];
    public Port S2 => Outputs[1];
    public Port S1 => Outputs[2];
    public Port S0 => Outputs[3];

    public Deselect4()
    {
        this.AddBinaryInput(nameof(Sel));
        this.AddInputs(nameof(A3), nameof(A2), nameof(A1), nameof(A0), nameof(B3), nameof(B2), nameof(B1), nameof(B0));
        this.AddOutputs(nameof(S3), nameof(S2), nameof(S1), nameof(S0));

        var inv = this.AddLogicGate("2");

        var rd4_0 = this.AddLogicGate("RD4");
        var rd4_1 = this.AddLogicGate("RD4");
        var rd4_2 = this.AddLogicGate("RD4");
        var rd4_3 = this.AddLogicGate("RD4");
        var rd4_4 = this.AddLogicGate("RD4");
        var rd4_5 = this.AddLogicGate("RD4");
        var rd4_6 = this.AddLogicGate("RD4");
        var rd4_7 = this.AddLogicGate("RD4");

        var vp0_0 = this.AddLogicGate("VP0");
        var vp0_1 = this.AddLogicGate("VP0");
        var vp0_2 = this.AddLogicGate("VP0");
        var vp0_3 = this.AddLogicGate("VP0");

        this.AddWires([
            (Sel, inv.A),

            (inv.Q, rd4_0.B),
            (A3, rd4_0.A),

            (inv.Q, rd4_1.B),
            (A2, rd4_1.A),

            (inv.Q, rd4_2.B),
            (A1, rd4_2.A),

            (inv.Q, rd4_3.B),
            (A0, rd4_3.A),

            (Sel, rd4_4.B),
            (B3, rd4_4.A),

            (Sel, rd4_5.B),
            (B2, rd4_5.A),

            (Sel, rd4_6.B),
            (B1, rd4_6.A),

            (Sel, rd4_7.B),
            (B0, rd4_7.A),

            (rd4_0.Q, vp0_0.B),
            (rd4_4.Q, vp0_0.A),

            (rd4_1.Q, vp0_1.B),
            (rd4_5.Q, vp0_1.A),

            (rd4_2.Q, vp0_2.B),
            (rd4_6.Q, vp0_2.A),

            (rd4_3.Q, vp0_3.B),
            (rd4_7.Q, vp0_3.A),

            (vp0_0.Q, S3),
            (vp0_1.Q, S2),
            (vp0_2.Q, S1),
            (vp0_3.Q, S0)
        ]);
    }
}