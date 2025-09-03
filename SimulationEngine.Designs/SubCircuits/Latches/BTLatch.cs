using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Latches;

public class BTLatch : SubCircuit
{
    public Port Clk => Ports.Single(p => p.Role == PortRole.In0);
    public Port Din => Ports.Single(p => p.Role == PortRole.In1);
    public Port Dout => Ports.Single(p => p.Role == PortRole.Out0);

    public BTLatch()
    {
        this.AddPorts([
            (nameof(Clk), PortRole.In0), 
            (nameof(Din), PortRole.In1), 
            (nameof(Dout), PortRole.Out0)]);

        var ZD0PPPPPP = this.AddLogicGate("ZD0PPPPPP");

        this.AddWires([
            (Clk, ZD0PPPPPP.C),
            (Din, ZD0PPPPPP.A),

            (ZD0PPPPPP.Q, ZD0PPPPPP.B),
            (ZD0PPPPPP.Q, Dout)]);
    }
}