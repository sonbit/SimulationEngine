using SimulationEngine.Designs.SubCircuits.Latches;
using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.Fetch;

public class ProgCtr2 : SubCircuit
{
    public Port Clk => Ports.Single(p => p.Role == PortRole.In0);
    public Port LdEn => Ports.Single(p => p.Role == PortRole.In1);
    public Port LdAddr1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port LdAddr0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Pc1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Pc0 => Ports.Single(p => p.Role == PortRole.Out1);

    public ProgCtr2()
    {
        this.AddPorts([
            (nameof(Clk), PortRole.In0),
            (nameof(LdEn), PortRole.In1),
            (nameof(LdAddr1), PortRole.In2),
            (nameof(LdAddr0), PortRole.In3),
            (nameof(Pc1), PortRole.Out0),
            (nameof(Pc0), PortRole.Out1)]);

        var _2MUX2 = new _2MUX2() { Parent = this };
        var dle0 = new DLatchEdge() { Parent = this };
        var dle1 = new DLatchEdge() { Parent = this };
        var inc2 = new Increment2() { Parent = this };
        SubCircuits = [_2MUX2, dle0, dle1, inc2];

        this.AddWires([
            (LdEn, _2MUX2.Sel),
            (LdAddr1, _2MUX2.B1),
            (LdAddr0, _2MUX2.B0),
            (inc2.Q1, _2MUX2.A1),
            (inc2.Q0, _2MUX2.A0),

            (Clk, dle0.Clk),
            (_2MUX2.Q1, dle0.Din),

            (Clk, dle1.Clk),
            (_2MUX2.Q0, dle1.Din),

            (dle0.Dout, inc2.X1),
            (dle1.Dout, inc2.X0),

            (dle0.Dout, Pc1),
            (dle1.Dout, Pc0)]);
    }
}
