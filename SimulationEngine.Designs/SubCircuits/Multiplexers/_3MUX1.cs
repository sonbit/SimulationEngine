using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class _3MUX1 : SubCircuit
{
    public Port Sel => Ports.Single(p => p.Role == PortRole.In0);
    public Port C => Ports.Single(p => p.Role == PortRole.In1);
    public Port B => Ports.Single(p => p.Role == PortRole.In2);
    public Port A => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q => Ports.Single(p => p.Role == PortRole.Out0);

    public _3MUX1() {
        this.AddPorts([
            (nameof(Sel), PortRole.In0),
            (nameof(C), PortRole.In1),
            (nameof(B), PortRole.In2),
            (nameof(A), PortRole.In3),
            (nameof(Q), PortRole.Out0)]);

        var PPPPPPZD0 = this.AddLogicGate("PPPPPPZD0");
        var PPPZD0ZD0 = this.AddLogicGate("PPPZD0ZD0");

        this.AddWires([
            (Sel, PPPPPPZD0.C),
            (B, PPPPPPZD0.B),
            (A, PPPPPPZD0.A),

            (Sel, PPPZD0ZD0.C),
            (C, PPPZD0ZD0.B),
            (PPPPPPZD0.Q, PPPZD0ZD0.A),

            (PPPZD0ZD0.Q, Q)]);
    }
}
