using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Converters.SubCircuits;

public class BHA3 : SubCircuit
{
    public Port D => Ports.Single(p => p.Role == PortRole.In0);
    public Port C => Ports.Single(p => p.Role == PortRole.In1);
    public Port B => Ports.Single(p => p.Role == PortRole.In2);
    public Port A => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out3);

    public BHA3()
    {
        this.AddPorts([
            (nameof(D), PortRole.In0),
            (nameof(C), PortRole.In1),
            (nameof(B), PortRole.In2),
            (nameof(A), PortRole.In3),
            (nameof(Q3), PortRole.Out0),
            (nameof(Q2), PortRole.Out1),
            (nameof(Q1), PortRole.Out2),
            (nameof(Q0), PortRole.Out3)]);

        var bha0 = new BHA { Parent = this };
        var bha1 = new BHA { Parent = this };
        var bha2 = new BHA { Parent = this };
        SubCircuits = [bha0, bha1, bha2];

        this.AddWires([
            (D, bha0.B),
            (A, bha0.A),

            (B, bha1.B),
            (bha0.Q1, bha1.A),

            (C, bha2.B),
            (bha1.Q1, bha2.A),

            (bha2.Q1, Q3),
            (bha2.Q0, Q2),
            (bha1.Q0, Q1),
            (bha0.Q0, Q0)]);
    }
}
