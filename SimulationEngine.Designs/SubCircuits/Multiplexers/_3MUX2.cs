using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class _3MUX2 : SubCircuit
{
    public Port Sel => Ports.Single(p => p.Role == PortRole.In0);
    public Port C1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port C0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port B1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In5);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In6);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public _3MUX2()
    {
        this.AddPorts([
            (nameof(Sel), PortRole.In0),
            (nameof(C1), PortRole.In1),
            (nameof(C0), PortRole.In2),
            (nameof(B1), PortRole.In3),
            (nameof(B0), PortRole.In4),
            (nameof(A1), PortRole.In5),
            (nameof(A0), PortRole.In6),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var _3MUX1_0 = new _3MUX1();
        var _3MUX1_1 = new _3MUX1();
        SubCircuits = [_3MUX1_0, _3MUX1_1];

        this.AddWires([
            (Sel, _3MUX1_0.Sel),
            (C1, _3MUX1_0.C),
            (B1, _3MUX1_0.B),
            (A1, _3MUX1_0.A),

            (Sel, _3MUX1_1.Sel),
            (C0, _3MUX1_1.C),
            (B0, _3MUX1_1.B),
            (A0, _3MUX1_1.A),

            (_3MUX1_0.Q, Q1),
            (_3MUX1_1.Q, Q0)]);
    }
}
