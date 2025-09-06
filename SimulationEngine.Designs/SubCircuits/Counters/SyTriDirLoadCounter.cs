using SimulationEngine.Designs.SubCircuits.Latches;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Counters;

public class SyTriDirLoadCounter : SubCircuit
{
    public Port Clk => Ports.Single(p => p.Role == PortRole.In0);
    public Port LdEn => Ports.Single(p => p.Role == PortRole.In1);
    public Port A => Ports.Single(p => p.Role == PortRole.In2);
    public Port Dir => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q => Ports.Single(p => p.Role == PortRole.Out0);

    public SyTriDirLoadCounter()
    {
        this.AddPorts([
            (nameof(Clk), PortRole.In0),
            (nameof(LdEn), PortRole.In1),
            (nameof(A), PortRole.In2),
            (nameof(Dir), PortRole.In3),
            (nameof(Q), PortRole.Out0)]);

        var _7PB = this.AddLogicGate("7PB");
        var PPPPPPZD0 = this.AddLogicGate("PPPPPPZD0");

        var tff = new TFlipFlop { Parent = this };
        SubCircuits = [tff];

        this.AddWires([
            (Clk, tff.Clk),
            (PPPPPPZD0.Q, tff.A),

            (Dir, _7PB.B),
            (tff.Q, _7PB.A),

            (LdEn, PPPPPPZD0.C),
            (A, PPPPPPZD0.B),
            (_7PB.Q, PPPPPPZD0.A),

            (tff.Q, Q)]);
    }
}
