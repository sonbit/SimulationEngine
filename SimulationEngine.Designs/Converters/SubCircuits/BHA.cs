using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Converters.SubCircuits;

public class BHA : SubCircuit
{
    public Port B => Ports.Single(p => p.Role == PortRole.In0);
    public Port A => Ports.Single(p => p.Role == PortRole.In1);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public BHA()
    {
        this.AddPorts([
            (nameof(B), PortRole.In0),
            (nameof(A), PortRole.In1),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var k00 = this.AddLogicGate("K00");
        var _20k = this.AddLogicGate("20K");

        this.AddWires([
            (B, k00.B),
            (A, k00.A),

            (B, _20k.B),
            (A, _20k.A),

            (k00.Q, Q1),
            (_20k.Q, Q0)]);
    }
}