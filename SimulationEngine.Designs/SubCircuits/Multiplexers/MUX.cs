using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class MUX : SubCircuit
{
    public Port Addr1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port Addr0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port C2 => Ports.Single(p => p.Role == PortRole.In2);
    public Port C1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port C0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port B2 => Ports.Single(p => p.Role == PortRole.In5);
    public Port B1 => Ports.Single(p => p.Role == PortRole.In6);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In7);
    public Port A2 => Ports.Single(p => p.Role == PortRole.In8);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In9);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In10);
    public Port Q => Ports.Single(p => p.Role == PortRole.Out0);

    public MUX()
    {
        this.AddPorts([
            (nameof(Addr1), PortRole.In0),
            (nameof(Addr0), PortRole.In1),
            (nameof(C2), PortRole.In2),
            (nameof(C1), PortRole.In3),
            (nameof(C0), PortRole.In4),
            (nameof(B2), PortRole.In5),
            (nameof(B1), PortRole.In6),
            (nameof(B0), PortRole.In7),
            (nameof(A2), PortRole.In8),
            (nameof(A1), PortRole.In9),
            (nameof(A0), PortRole.In10),
            (nameof(Q), PortRole.Out0)]);

        var _3MUX_0 = new _3MUX();
        var _3MUX_1 = new _3MUX();
        var _3MUX_2 = new _3MUX();
        var _3MUX_3 = new _3MUX();
        SubCircuits = [_3MUX_0, _3MUX_1, _3MUX_2, _3MUX_3];

        this.AddWires([
            (Addr0, _3MUX_0.Sel),
            (C2, _3MUX_0.C),
            (C1, _3MUX_0.B),
            (C0, _3MUX_0.A),

            (Addr0, _3MUX_1.Sel),
            (B2, _3MUX_1.C),
            (B1, _3MUX_1.B),
            (B0, _3MUX_1.A),

            (Addr0, _3MUX_2.Sel),
            (A2, _3MUX_2.C),
            (A1, _3MUX_2.B),
            (A0, _3MUX_2.A),

            (Addr1, _3MUX_3.Sel),
            (_3MUX_0.Q, _3MUX_3.C),
            (_3MUX_1.Q, _3MUX_3.B),
            (_3MUX_2.Q, _3MUX_3.A),

            (_3MUX_3.Q, Q)]);
    }
}
