using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Converters.SubCircuits;

public class ConditionalSTI4 : SubCircuit
{
    public Port Sign => Ports.Single(p => p.Role == PortRole.In0);
    public Port A3 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A2 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port Q3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out3);

    public ConditionalSTI4()
    {
        this.AddPorts([
            (nameof(Sign), PortRole.In0),
            (nameof(A3), PortRole.In1),
            (nameof(A2), PortRole.In2),
            (nameof(A1), PortRole.In3),
            (nameof(A0), PortRole.In4),
            (nameof(Q3), PortRole.Out0),
            (nameof(Q2), PortRole.Out1),
            (nameof(Q1), PortRole.Out2),
            (nameof(Q0), PortRole.Out3)]);

        var condSTI_0 = this.AddLogicGate("5DP");
        var condSTI_1 = this.AddLogicGate("5DP");
        var condSTI_2 = this.AddLogicGate("5DP");
        var condSTI_3 = this.AddLogicGate("5DP");

        this.AddWires([
            (Sign, condSTI_0.B),
            (A3, condSTI_0.A),

            (Sign, condSTI_1.B),
            (A2, condSTI_1.A),

            (Sign, condSTI_2.B),
            (A1, condSTI_2.A),

            (Sign, condSTI_3.B),
            (A0, condSTI_3.A),

            (condSTI_0.Q, Q3),
            (condSTI_1.Q, Q2),
            (condSTI_2.Q, Q1),
            (condSTI_3.Q, Q0)]);
    }
}
