using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Converters.SubCircuits;

public class XOR3 : SubCircuit
{
    public Port Sign => Ports.Single(p => p.Role == PortRole.In0);
    public Port A2 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out2);

    public XOR3()
    {
        this.AddPorts([
            (nameof(Sign), PortRole.In0),
            (nameof(A2), PortRole.In1),
            (nameof(A1), PortRole.In2),
            (nameof(A0), PortRole.In3),
            (nameof(Q2), PortRole.Out0),
            (nameof(Q1), PortRole.Out1),
            (nameof(Q0), PortRole.Out2)]);

        var xor0 = this.AddLogicGate("20K");
        var xor1 = this.AddLogicGate("20K");
        var xor2 = this.AddLogicGate("20K");

        this.AddWires([
            (Sign, xor0.B),
            (A2, xor0.A),

            (Sign, xor1.B),
            (A1, xor1.A),

            (Sign, xor2.B),
            (A0, xor2.A),

            (xor0.Q, Q2),
            (xor1.Q, Q1),
            (xor2.Q, Q0)]);
    }
}
