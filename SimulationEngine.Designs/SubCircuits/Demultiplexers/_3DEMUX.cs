using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Demultiplexers;

public class _3DEMUX : SubCircuit
{
    public Port Din => Ports.Single(p => p.Role == PortRole.In0);
    public Port Clk => Ports.Single(p => p.Role == PortRole.In1);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out2);

    public _3DEMUX()
    {
        this.AddPorts([
            (nameof(Din), PortRole.In0),
            (nameof(Clk), PortRole.In1),
            (nameof(Q2), PortRole.Out0),
            (nameof(Q1), PortRole.Out1),
            (nameof(Q0), PortRole.Out2)]);

        var _200 = this.AddLogicGate("200");
        var _600 = this.AddLogicGate("600");
        var K00 = this.AddLogicGate("K00");

        this.AddWires([
            (Din, _200.B),
            (Din, _600.B),
            (Din, K00.B),

            (Clk, _200.A),
            (Clk, _600.A),
            (Clk, K00.A),

            (_200.Q, Q2),
            (_600.Q, Q1),
            (K00.Q, Q0)]);
    }
}
