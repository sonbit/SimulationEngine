using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Deselectors;

public class Deselect4 : SubCircuit
{
    public Port Sel => Ports.Single(p => p.Role == PortRole.In0);
    public Port A3 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A2 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port B3 => Ports.Single(p => p.Role == PortRole.In5);
    public Port B2 => Ports.Single(p => p.Role == PortRole.In6);
    public Port B1 => Ports.Single(p => p.Role == PortRole.In7);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In8);
    public Port S3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port S2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port S1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port S0 => Ports.Single(p => p.Role == PortRole.Out3);

    public Deselect4()
    {
        this.AddPorts([
            (nameof(Sel), PortRole.In0),
            (nameof(A3), PortRole.In1),
            (nameof(A2), PortRole.In2),
            (nameof(A1), PortRole.In3),
            (nameof(A0), PortRole.In4),
            (nameof(B3), PortRole.In5),
            (nameof(B2), PortRole.In6),
            (nameof(B1), PortRole.In7),
            (nameof(B0), PortRole.In8),
            (nameof(S3), PortRole.Out0),
            (nameof(S2), PortRole.Out1),
            (nameof(S1), PortRole.Out2),
            (nameof(S0), PortRole.Out3)]);

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
            (vp0_3.Q, S0)]);
    }
}
