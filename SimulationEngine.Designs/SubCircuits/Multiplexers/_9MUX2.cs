using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class _9MUX2 : SubCircuit
{
    public Port Sel1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port Sel0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port D81 => Ports.Single(p => p.Role == PortRole.In2);
    public Port D80 => Ports.Single(p => p.Role == PortRole.In3);
    public Port D71 => Ports.Single(p => p.Role == PortRole.In4);
    public Port D70 => Ports.Single(p => p.Role == PortRole.In5);
    public Port D61 => Ports.Single(p => p.Role == PortRole.In6);
    public Port D60 => Ports.Single(p => p.Role == PortRole.In7);
    public Port D51 => Ports.Single(p => p.Role == PortRole.In8);
    public Port D50 => Ports.Single(p => p.Role == PortRole.In9);
    public Port D41 => Ports.Single(p => p.Role == PortRole.In10);
    public Port D40 => Ports.Single(p => p.Role == PortRole.In11);
    public Port D31 => Ports.Single(p => p.Role == PortRole.In12);
    public Port D30 => Ports.Single(p => p.Role == PortRole.In13);
    public Port D21 => Ports.Single(p => p.Role == PortRole.In14);
    public Port D20 => Ports.Single(p => p.Role == PortRole.In15);
    public Port D11 => Ports.Single(p => p.Role == PortRole.In16);
    public Port D10 => Ports.Single(p => p.Role == PortRole.In17);
    public Port D01 => Ports.Single(p => p.Role == PortRole.In18);
    public Port D00 => Ports.Single(p => p.Role == PortRole.In19);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public _9MUX2()
    {
        this.AddPorts([
            (nameof(Sel1), PortRole.In0),
            (nameof(Sel0), PortRole.In1),
            (nameof(D81), PortRole.In2),
            (nameof(D80), PortRole.In3),
            (nameof(D71), PortRole.In4),
            (nameof(D70), PortRole.In5),
            (nameof(D61), PortRole.In6),
            (nameof(D60), PortRole.In7),
            (nameof(D51), PortRole.In8),
            (nameof(D50), PortRole.In9),
            (nameof(D41), PortRole.In10),
            (nameof(D40), PortRole.In11),
            (nameof(D31), PortRole.In12),
            (nameof(D30), PortRole.In13),
            (nameof(D21), PortRole.In14),
            (nameof(D20), PortRole.In15),
            (nameof(D11), PortRole.In16),
            (nameof(D10), PortRole.In17),
            (nameof(D01), PortRole.In18),
            (nameof(D00), PortRole.In19),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var _3MUX2_0 = new _3MUX2 { Parent = this };
        var _3MUX2_1 = new _3MUX2 { Parent = this };
        var _3MUX2_2 = new _3MUX2 { Parent = this };
        var _3MUX2_3 = new _3MUX2 { Parent = this };
        SubCircuits = [_3MUX2_0, _3MUX2_1, _3MUX2_2, _3MUX2_3];

        this.AddWires([
            (Sel0, _3MUX2_0.Sel),
            (D81, _3MUX2_0.C1),
            (D80, _3MUX2_0.C0),
            (D71, _3MUX2_0.B1),
            (D70, _3MUX2_0.B0),
            (D61, _3MUX2_0.A1),
            (D60, _3MUX2_0.A0),

            (Sel0, _3MUX2_1.Sel),
            (D51, _3MUX2_1.C1),
            (D50, _3MUX2_1.C0),
            (D41, _3MUX2_1.B1),
            (D40, _3MUX2_1.B0),
            (D31, _3MUX2_1.A1),
            (D30, _3MUX2_1.A0),

            (Sel0, _3MUX2_2.Sel),
            (D21, _3MUX2_2.C1),
            (D20, _3MUX2_2.C0),
            (D11, _3MUX2_2.B1),
            (D10, _3MUX2_2.B0),
            (D01, _3MUX2_2.A1),
            (D00, _3MUX2_2.A0),

            (Sel1, _3MUX2_3.Sel),
            (_3MUX2_0.Q1, _3MUX2_3.C1),
            (_3MUX2_0.Q0, _3MUX2_3.C0),
            (_3MUX2_1.Q1, _3MUX2_3.B1),
            (_3MUX2_1.Q0, _3MUX2_3.B0),
            (_3MUX2_2.Q1, _3MUX2_3.A1),
            (_3MUX2_2.Q0, _3MUX2_3.A0),

            (_3MUX2_3.Q1, Q1),
            (_3MUX2_3.Q0, Q0)]);
    }
}
