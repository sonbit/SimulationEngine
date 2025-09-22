using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Counters;

public class SyTriDirLoadCounter4 : SubCircuit
{
    public Port Clk => Inputs[0];
    public Port LdEn => Inputs[1];
    public Port A3 => Inputs[2];
    public Port A2 => Inputs[3];
    public Port A1 => Inputs[4];
    public Port A0 => Inputs[5];
    public Port Dir => Inputs[6];
    public Port Q3 => Outputs[0];
    public Port Q2 => Outputs[1];
    public Port Q1 => Outputs[2];
    public Port Q0 => Outputs[3];

    public SyTriDirLoadCounter4()
    {
        this.AddBinaryInputs(nameof(Clk), nameof(LdEn));
        this.AddInputs(nameof(A3), nameof(A2), nameof(A1), nameof(A0), nameof(Dir));
        this.AddOutputs(nameof(Q3), nameof(Q2), nameof(Q1), nameof(Q0));

        var cons_0 = this.AddLogicGate("RDC");
        var cons_1 = this.AddLogicGate("RDC");
        var cons_2 = this.AddLogicGate("RDC");

        var syTriDirLoadCounter4_0 = this.AddSubCircuit(new SyTriDirLoadCounter());
        var syTriDirLoadCounter4_1 = this.AddSubCircuit(new SyTriDirLoadCounter());
        var syTriDirLoadCounter4_2 = this.AddSubCircuit(new SyTriDirLoadCounter());
        var syTriDirLoadCounter4_3 = this.AddSubCircuit(new SyTriDirLoadCounter());

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
            (syTriDirLoadCounter4_0.Q, Q0)
        ]);
    }

    public override string GetTests() => """
        00----+ ----
        10----+ ---0
        00----+ ---0
        10----+ ---+
        00----+ ---+
        10----+ --0-
        00----+ --0-
        10----+ --00
        00----+ --00
        10----+ --0+
        00----+ --0+
        10----+ --+-
        00----+ --+-
        10----+ --+0
        00----+ --+0
        10----+ --++
        00----+ --++
        10----+ -0--
        00----+ -0--
        10----+ -0-0
        00----+ -0-0
        10----+ -0-+
        00----+ -0-+
        10----+ -00-
        00----+ -00-
        10----+ -000
        00----+ -000
        10----+ -00+
        00----+ -00+
        10----+ -0+-
        00----+ -0+-
        10----+ -0+0
        00----+ -0+0
        10----+ -0++
        00----+ -0++
        10----+ -+--
        00----+ -+--
        10----+ -+-0
        00----+ -+-0
        10----+ -+-+
        00----+ -+-+
        10----+ -+0-
        00----+ -+0-
        10----+ -+00
        00----+ -+00
        10----+ -+0+
        00----+ -+0+
        10----+ -++-
        00----+ -++-
        10----+ -++0
        00----+ -++0
        10----+ -+++
        00----+ -+++
        10----+ 0---
        00----- 0---
        10----- -+++
        00----- -+++
        10----- -++0
        00----- -++0
        10----- -++-
        01---0+ -++-
        11---0+ ---0
        010++0+ ---0
        110++0+ 0++0
        01----0 0++0
        11----0 ----
        00----0 ----
        10----0 ----
        00----0 ----
    """;
}