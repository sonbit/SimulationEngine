using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Counters;

public class SyTriDirLoadCounter4 : SubCircuit
{
    public Port Clk => Ports.Single(p => p.Role == PortRole.In0);
    public Port LdEn => Ports.Single(p => p.Role == PortRole.In1);
    public Port A3 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A2 => Ports.Single(p => p.Role == PortRole.In3);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In4);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In5);
    public Port Dir => Ports.Single(p => p.Role == PortRole.In6);
    public Port Q3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out3);

    public SyTriDirLoadCounter4()
    {
        this.AddPorts([
            (nameof(Clk), PortRole.In0),
            (nameof(LdEn), PortRole.In1),
            (nameof(A3), PortRole.In2),
            (nameof(A2), PortRole.In3),
            (nameof(A1), PortRole.In4),
            (nameof(A0), PortRole.In5),
            (nameof(Dir), PortRole.In6),
            (nameof(Q3), PortRole.Out0),
            (nameof(Q2), PortRole.Out1),
            (nameof(Q1), PortRole.Out2),
            (nameof(Q0), PortRole.Out3)]);


        var cons_0 = this.AddLogicGate("RDC");
        var cons_1 = this.AddLogicGate("RDC");
        var cons_2 = this.AddLogicGate("RDC");

        var syTriDirLoadCounter4_0 = new SyTriDirLoadCounter { Parent = this };
        var syTriDirLoadCounter4_1 = new SyTriDirLoadCounter { Parent = this };
        var syTriDirLoadCounter4_2 = new SyTriDirLoadCounter { Parent = this };
        var syTriDirLoadCounter4_3 = new SyTriDirLoadCounter { Parent = this };
        SubCircuits = [syTriDirLoadCounter4_0, syTriDirLoadCounter4_1, syTriDirLoadCounter4_2, syTriDirLoadCounter4_3];

        this.AddWires([
            (Clk, syTriDirLoadCounter4_0.Clk),
            (LdEn, syTriDirLoadCounter4_0.LdEn),
            (A0, syTriDirLoadCounter4_0.A),
            (Dir, syTriDirLoadCounter4_0.Dir),

            (syTriDirLoadCounter4_0.Q, cons_0.B),
            (Dir, cons_0.A),

            (Clk, syTriDirLoadCounter4_1.Clk),
            (LdEn, syTriDirLoadCounter4_1.LdEn),
            (A1, syTriDirLoadCounter4_1.A),
            (cons_0.Q, syTriDirLoadCounter4_1.Dir),

            (syTriDirLoadCounter4_1.Q, cons_1.B),
            (cons_0.Q, cons_1.A),

            (Clk, syTriDirLoadCounter4_2.Clk),
            (LdEn, syTriDirLoadCounter4_2.LdEn),
            (A2, syTriDirLoadCounter4_2.A),
            (cons_1.Q, syTriDirLoadCounter4_2.Dir),

            (syTriDirLoadCounter4_2.Q, cons_2.B),
            (cons_1.Q, cons_2.A),

            (Clk, syTriDirLoadCounter4_3.Clk),
            (LdEn, syTriDirLoadCounter4_3.LdEn),
            (A3, syTriDirLoadCounter4_3.A),
            (cons_2.Q, syTriDirLoadCounter4_3.Dir),

            (syTriDirLoadCounter4_3.Q, Q3),
            (syTriDirLoadCounter4_2.Q, Q2),
            (syTriDirLoadCounter4_1.Q, Q1),
            (syTriDirLoadCounter4_0.Q, Q0)]);
    }
}
