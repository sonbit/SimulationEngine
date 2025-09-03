using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Latches;

public class TFlipFlop : SubCircuit
{
    public Port Clk => Ports.Single(p => p.Role == PortRole.In0);
    public Port A => Ports.Single(p => p.Role == PortRole.In1);
    public Port Q => Ports.Single(p => p.Role == PortRole.Out0);

    public TFlipFlop()
    {
        this.AddPorts([
            (nameof(Clk), PortRole.In0),
            (nameof(A), PortRole.In1),
            (nameof(Q), PortRole.Out0)]);

        var _2 = this.AddLogicGate("2");

        var btl0 = new BTLatch { Parent = this };
        var btl1 = new BTLatch { Parent = this };
        SubCircuits = [btl0, btl1];

        this.AddWires([
            (Clk, _2.A),

            (_2.Q, btl0.Clk),
            (A, btl0.Din),

            (Clk, btl1.Clk),
            (btl0.Dout, btl1.Din),

            (btl1.Dout, Q)]);
    }
}
