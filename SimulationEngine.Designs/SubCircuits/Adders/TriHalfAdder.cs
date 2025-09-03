using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Adders;

public class TriHalfAdder : SubCircuit
{
    public Port B => Ports.Single(p => p.Role == PortRole.In0);
    public Port A => Ports.Single(p => p.Role == PortRole.In1);
    public Port Cout => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q => Ports.Single(p => p.Role == PortRole.Out1);

    public TriHalfAdder()
    {
        this.AddPorts([
            (nameof(B), PortRole.In0),
            (nameof(A), PortRole.In1),
            (nameof(Cout), PortRole.Out0),
            (nameof(Q), PortRole.Out1)]);

        var RDC = this.AddLogicGate("RDC");
        var _7PB = this.AddLogicGate("7PB");

        this.AddWires([
            (B, RDC.B),
            (A, RDC.A),

            (B, _7PB.B),
            (A, _7PB.A),

            (RDC.Q, Cout),
            (_7PB.Q, Q)]);
    }
}
