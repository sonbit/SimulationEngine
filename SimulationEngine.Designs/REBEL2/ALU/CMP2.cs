using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class CMP2 : SubCircuit
{
    public Port B1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Min1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Min0 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Max1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Max0 => Ports.Single(p => p.Role == PortRole.Out3);
    public Port Cmp => Ports.Single(p => p.Role == PortRole.Out4);

    public CMP2()
    {
        this.AddPorts([
            (nameof(B1), PortRole.In0),
            (nameof(B0), PortRole.In1),
            (nameof(A1), PortRole.In2),
            (nameof(A0), PortRole.In3),
            (nameof(Min1), PortRole.Out0),
            (nameof(Min0), PortRole.Out1),
            (nameof(Max1), PortRole.Out2),
            (nameof(Max0), PortRole.Out3),
            (nameof(Cmp), PortRole.Out4)]);

        var _2TritComp = new _2TritComp();
        var _2MUX2_0 = new _2MUX2();
        var _2MUX2_1 = new _2MUX2();
        SubCircuits = [_2TritComp, _2MUX2_0, _2MUX2_1];

        this.AddWires([
            (B1, _2TritComp.B1),
            (B0, _2TritComp.B0),
            (A1, _2TritComp.A1),
            (A0, _2TritComp.A0),

            (_2TritComp.Q, _2MUX2_0.Sel),
            (B1, _2MUX2_0.B1),
            (B0, _2MUX2_0.B0),
            (A1, _2MUX2_0.A1),
            (A0, _2MUX2_0.A0),

            (_2TritComp.Q, _2MUX2_1.Sel),
            (A1, _2MUX2_1.B1),
            (A0, _2MUX2_1.B0),
            (B1, _2MUX2_1.A1),
            (B0, _2MUX2_1.A0),

            (_2MUX2_0.Q1, Min1),
            (_2MUX2_0.Q0, Min0),
            (_2MUX2_1.Q1, Max1),
            (_2MUX2_1.Q0, Max0),
            (_2TritComp.Q, Cmp)]);
    }
}
