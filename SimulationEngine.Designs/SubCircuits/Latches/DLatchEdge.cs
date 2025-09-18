using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Latches;

public class DLatchEdge : SubCircuit
{
    public Port Clk => Ports.Single(p => p.Role == PortRole.In0);
    public Port Din => Ports.Single(p => p.Role == PortRole.In1);
    public Port Dout => Ports.Single(p => p.Role == PortRole.Out0);

    public DLatchEdge()
    {
        this.AddPorts([
            (nameof(Clk), PortRole.In0),
            (nameof(Din), PortRole.In1),
            (nameof(Dout), PortRole.Out0)]);

        var btl0 = new BTLatch();
        var btl1 = new BTLatch();
        SubCircuits = [btl0, btl1];

        var inv0 = this.AddLogicGate("5");
        var inv1 = this.AddLogicGate("5");

        this.AddWires([
            (Clk, inv0.A),
            (inv0.Q, inv1.A),

            (inv0.Q, btl0.Clk),
            (Din, btl0.Din),

            (inv1.Q, btl1.Clk),
            (btl0.Dout, btl1.Din),

            (btl1.Dout, Dout)]);
    }
}
