using SimulationEngine.Designs.SubCircuits.Adders;
using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class AddSub2 : SubCircuit
{
    public Port Sel => Ports.Single(p => p.Role == PortRole.In0);
    public Port B1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out2);

    public AddSub2()
    {
        this.AddPorts([
            (nameof(Sel), PortRole.In0),
            (nameof(B1), PortRole.In1),
            (nameof(B0), PortRole.In2),
            (nameof(A1), PortRole.In3),
            (nameof(A0), PortRole.In4),
            (nameof(Q2), PortRole.Out0),
            (nameof(Q1), PortRole.Out1),
            (nameof(Q0), PortRole.Out2)]);

        var inv0 = this.AddLogicGate("5");
        var inv1 = this.AddLogicGate("5");

        var _2MUX2 = new _2MUX2();
        var _2TritAdder = new _2TritAdder();
        SubCircuits = [_2MUX2, _2TritAdder];

        this.AddWires([
            (B1, inv0.A),
            (B0, inv1.A),

            (Sel, _2MUX2.Sel),
            (inv0.Q, _2MUX2.B1),
            (inv1.Q, _2MUX2.B0),
            (B1, _2MUX2.A1),
            (B0, _2MUX2.A0),

            (_2MUX2.Q1, _2TritAdder.B1),
            (_2MUX2.Q0, _2TritAdder.B0),
            (A1, _2TritAdder.A1),
            (A0, _2TritAdder.A0),

            (_2TritAdder.Cout, Q2),
            (_2TritAdder.Q1, Q1),
            (_2TritAdder.Q0, Q0)]);
    }
}
