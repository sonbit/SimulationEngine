using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Demultiplexers;

public class _3BDEMUX : SubCircuit
{
    public Port Din => Ports.Single(p => p.Role == PortRole.In0);
    public Port Clk => Ports.Single(p => p.Role == PortRole.In1);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out2);

    public _3BDEMUX()
    {
        this.AddPorts([
            (nameof(Din), PortRole.In0),
            (nameof(Clk), PortRole.In1),
            (nameof(Q2), PortRole.Out0),
            (nameof(Q1), PortRole.Out1),
            (nameof(Q0), PortRole.Out2)]);

        var K00 = this.AddLogicGate("K00");     
        var _600 = this.AddLogicGate("600");
        var _200 = this.AddLogicGate("200");

        this.AddWires([
            (Din, K00.B),
            (Din, _600.B),
            (Din, _200.B),

            (Clk, K00.A),
            (Clk, _600.A),
            (Clk, _200.A),

            (K00.Q, Q2),
            (_600.Q, Q1),
            (_200.Q, Q0)]);
    }
}
