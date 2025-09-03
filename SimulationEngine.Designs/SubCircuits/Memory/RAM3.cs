using SimulationEngine.Designs.SubCircuits.Latches;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class RAM3 : SubCircuit
{
    public Port Clk2 => Ports.Single(p => p.Role == PortRole.In0);
    public Port Clk1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Clk0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out2);

    public RAM3()
    {
        this.AddPorts([
            (nameof(Clk2), PortRole.In0),
            (nameof(Clk1), PortRole.In1),
            (nameof(Clk0), PortRole.In2),
            (nameof(A), PortRole.In3),
            (nameof(Q2), PortRole.Out0),
            (nameof(Q1), PortRole.Out1),
            (nameof(Q0), PortRole.Out2)]);

        var tff0 = new TFlipFlop { Parent = this };
        var tff1 = new TFlipFlop { Parent = this };
        var tff2 = new TFlipFlop { Parent = this };
        SubCircuits = [tff0, tff1, tff2];

        this.AddWires([
            (Clk2, tff0.Clk),
            (A, tff0.A),

            (Clk1, tff1.Clk),
            (A, tff1.A),

            (Clk0, tff2.Clk),
            (A, tff2.A),

            (tff0.Q, Q2),
            (tff1.Q, Q1),
            (tff2.Q, Q0)]);
    }
}
