using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class _3MUX : SubCircuit
{
    public Port Sel => Ports.Single(p => p.Role == PortRole.In0);
    public Port C => Ports.Single(p => p.Role == PortRole.In1);
    public Port B => Ports.Single(p => p.Role == PortRole.In2);
    public Port A => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q => Ports.Single(p => p.Role == PortRole.Out0);

    public _3MUX()
    {
        this.AddPorts([
            (nameof(Sel), PortRole.In0),
            (nameof(C), PortRole.In1),
            (nameof(B), PortRole.In2),
            (nameof(A), PortRole.In3),
            (nameof(Q), PortRole.Out0)]);

        var ZD0PPPPPP = this.AddLogicGate("ZD0PPPPPP");
        var ZD0ZD0PPP = this.AddLogicGate("ZD0ZD0PPP");

        this.AddWires([
            (Sel, ZD0PPPPPP.C),
            (B, ZD0PPPPPP.B),
            (A, ZD0PPPPPP.A),

            (Sel, ZD0ZD0PPP.C),
            (C, ZD0ZD0PPP.B),
            (ZD0PPPPPP.Q, ZD0ZD0PPP.A),

            (ZD0ZD0PPP.Q, Q)]);
    }
}
