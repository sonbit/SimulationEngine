using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class _2TritComp : SubCircuit
{
    public Port B1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q => Ports.Single(p => p.Role == PortRole.Out0);

    public _2TritComp()
    {
        this.AddPorts([
            (nameof(B1), PortRole.In0),
            (nameof(B0), PortRole.In1),
            (nameof(A1), PortRole.In2),
            (nameof(A0), PortRole.In3),
            (nameof(Q), PortRole.Out0)]);

        var H51 = this.AddLogicGate("H51");
        var ZZZH51000 = this.AddLogicGate("ZZZH51000");

        this.AddWires([
            (B1, H51.B),
            (A1, H51.A),

            (H51.Q, ZZZH51000.C),
            (B0, ZZZH51000.B),
            (A0, ZZZH51000.A),

            (ZZZH51000.Q, Q)]);
    }
}
