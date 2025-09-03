using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Latches;

public class _2Latch2 : SubCircuit
{
    public Port Clk => Ports.Single(p => p.Role == PortRole.In0);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public _2Latch2()
    {
        this.AddPorts([
            (nameof(Clk), PortRole.In0),
            (nameof(A1), PortRole.In1),
            (nameof(A0), PortRole.In2),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var btl0 = new BTLatch { Parent = this };
        var btl1 = new BTLatch { Parent = this };
        SubCircuits = [btl0, btl1];

        this.AddWires([
            (Clk, btl0.Clk),
            (A1, btl0.Din),

            (Clk, btl1.Clk),
            (A0, btl1.Din),

            (btl0.Dout, Q1),
            (btl1.Dout, Q0)]);
    }
}
