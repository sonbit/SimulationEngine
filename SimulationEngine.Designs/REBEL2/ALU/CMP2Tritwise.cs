using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class CMP2Tritwise : SubCircuit
{
    public Port Mode => Ports.Single(p => p.Role == PortRole.In0);
    public Port B1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public CMP2Tritwise()
    {
        this.AddPorts([
            (nameof(Mode), PortRole.In0),
            (nameof(B1), PortRole.In1),
            (nameof(B0), PortRole.In2),
            (nameof(A1), PortRole.In3),
            (nameof(A0), PortRole.In4),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var ZRPH51PC0_0 = this.AddLogicGate("ZRPH51PC0");
        var ZRPH51PC0_1 = this.AddLogicGate("ZRPH51PC0");

        this.AddWires([
            (Mode, ZRPH51PC0_0.C),
            (B1, ZRPH51PC0_0.B),
            (A1, ZRPH51PC0_0.A),

            (Mode, ZRPH51PC0_1.C),
            (B0, ZRPH51PC0_1.B),
            (A0, ZRPH51PC0_1.A),

            (ZRPH51PC0_0.Q, Q1),
            (ZRPH51PC0_1.Q, Q0)]);
    }
}
