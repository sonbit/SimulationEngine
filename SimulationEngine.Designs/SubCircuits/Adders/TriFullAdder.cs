using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Adders;

public class TriFullAdder : SubCircuit
{
    public Port C => Ports.Single(p => p.Role == PortRole.In0);
    public Port B => Ports.Single(p => p.Role == PortRole.In1);
    public Port A => Ports.Single(p => p.Role == PortRole.In2);
    public Port Cout => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q => Ports.Single(p => p.Role == PortRole.Out1);

    public TriFullAdder()
    {
        this.AddPorts([
            (nameof(C), PortRole.In0),
            (nameof(B), PortRole.In1),
            (nameof(A), PortRole.In2),
            (nameof(Cout), PortRole.Out0),
            (nameof(Q), PortRole.Out1)]);

        var XRDRDCDC9 = this.AddLogicGate("XRDRDCDC9");
        var B7P7PBPB7 = this.AddLogicGate("B7P7PBPB7");

        this.AddWires([
            (C, XRDRDCDC9.C),
            (B, XRDRDCDC9.B),
            (A, XRDRDCDC9.A),

            (C, B7P7PBPB7.C),
            (B, B7P7PBPB7.B),
            (A, B7P7PBPB7.A),

            (XRDRDCDC9.Q, Cout),
            (B7P7PBPB7.Q, Q)]);
    }
}
