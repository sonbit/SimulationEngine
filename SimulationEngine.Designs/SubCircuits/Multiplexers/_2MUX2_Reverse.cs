using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class _2MUX2_Reverse : SubCircuit
{
    public Port Sel => Ports.Single(p => p.Role == PortRole.In0);
    public Port B1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public _2MUX2_Reverse()
    {
        this.AddPorts([
            (nameof(Sel), PortRole.In0),
            (nameof(B1), PortRole.In1),
            (nameof(B0), PortRole.In2),
            (nameof(A1), PortRole.In3),
            (nameof(A0), PortRole.In4),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var ZD0ZD0PPP_0 = this.AddLogicGate("ZD0ZD0PPP");
        var ZD0ZD0PPP_1 = this.AddLogicGate("ZD0ZD0PPP");

        this.AddWires([
            (Sel, ZD0ZD0PPP_0.C),
            (B1, ZD0ZD0PPP_0.B),
            (A1, ZD0ZD0PPP_0.A),

            (Sel, ZD0ZD0PPP_1.C),
            (B0, ZD0ZD0PPP_1.B),
            (A0, ZD0ZD0PPP_1.A),

            (ZD0ZD0PPP_0.Q, Q1),
            (ZD0ZD0PPP_1.Q, Q0)]);
    }
}
