using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class _2MUX2 : SubCircuit
{
    public Port Sel => Ports.Single(p => p.Role == PortRole.In0);
    public Port B1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public _2MUX2()
    {
        this.AddPorts([
            (nameof(Sel), PortRole.In0),
            (nameof(B1), PortRole.In1),
            (nameof(B0), PortRole.In2),
            (nameof(A1), PortRole.In3),
            (nameof(A0), PortRole.In4),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var PPPZD0ZD0_0 = this.AddLogicGate("PPPZD0ZD0");
        var PPPZD0ZD0_1 = this.AddLogicGate("PPPZD0ZD0");

        this.AddWires([
            (Sel, PPPZD0ZD0_0.C),
            (B1, PPPZD0ZD0_0.B),
            (A1, PPPZD0ZD0_0.A),

            (Sel, PPPZD0ZD0_1.C),
            (B0, PPPZD0ZD0_1.B),
            (A0, PPPZD0ZD0_1.A),

            (PPPZD0ZD0_0.Q, Q1),
            (PPPZD0ZD0_1.Q, Q0)]);
    }
}
