using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Demultiplexers;

public class DEMUX : SubCircuit
{
    public Port Sel1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port Sel0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Clk => Ports.Single(p => p.Role == PortRole.In2);
    public Port ClkQ8 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port ClkQ7 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port ClkQ6 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port ClkQ5 => Ports.Single(p => p.Role == PortRole.Out3);
    public Port ClkQ4 => Ports.Single(p => p.Role == PortRole.Out4);
    public Port ClkQ3 => Ports.Single(p => p.Role == PortRole.Out5);
    public Port ClkQ2 => Ports.Single(p => p.Role == PortRole.Out6);
    public Port ClkQ1 => Ports.Single(p => p.Role == PortRole.Out7);
    public Port ClkQ0 => Ports.Single(p => p.Role == PortRole.Out8);

    public DEMUX()
    {
        this.AddPorts([
            (nameof(Sel1), PortRole.In0),
            (nameof(Sel0), PortRole.In1),
            (nameof(Clk), PortRole.In2),
            (nameof(ClkQ8), PortRole.Out0),
            (nameof(ClkQ7), PortRole.Out1),
            (nameof(ClkQ6), PortRole.Out2),
            (nameof(ClkQ5), PortRole.Out3),
            (nameof(ClkQ4), PortRole.Out4),
            (nameof(ClkQ3), PortRole.Out5),
            (nameof(ClkQ2), PortRole.Out6),
            (nameof(ClkQ1), PortRole.Out7),
            (nameof(ClkQ0), PortRole.Out8)]);

        var _3DEMUX_0 = new _3DEMUX { Parent = this };
        var _3DEMUX_1 = new _3DEMUX { Parent = this };
        var _3DEMUX_2 = new _3DEMUX { Parent = this };
        var _3DEMUX_3 = new _3DEMUX { Parent = this };
        SubCircuits = [_3DEMUX_0, _3DEMUX_1, _3DEMUX_2, _3DEMUX_3];

        this.AddWires([
            (Sel1, _3DEMUX_0.Din),
            (Clk, _3DEMUX_0.Clk),

            (Sel0, _3DEMUX_1.Din),
            (_3DEMUX_0.Q2, _3DEMUX_1.Clk),

            (Sel0, _3DEMUX_2.Din),
            (_3DEMUX_0.Q1, _3DEMUX_2.Clk),

            (Sel0, _3DEMUX_3.Din),
            (_3DEMUX_0.Q0, _3DEMUX_3.Clk),

            (_3DEMUX_1.Q2, ClkQ8),
            (_3DEMUX_1.Q1, ClkQ7),
            (_3DEMUX_1.Q0, ClkQ6),
            (_3DEMUX_2.Q2, ClkQ5),
            (_3DEMUX_2.Q1, ClkQ4),
            (_3DEMUX_2.Q0, ClkQ3),
            (_3DEMUX_3.Q2, ClkQ2),
            (_3DEMUX_3.Q1, ClkQ1),
            (_3DEMUX_3.Q0, ClkQ0)]);
    }
}