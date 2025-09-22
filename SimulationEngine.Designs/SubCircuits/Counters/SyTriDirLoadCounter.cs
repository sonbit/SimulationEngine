using SimulationEngine.Designs.SubCircuits.Latches;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Counters;

public class SyTriDirLoadCounter : SubCircuit
{
    public Port Clk => Inputs[0];
    public Port LdEn => Inputs[1];
    public Port A => Inputs[2];
    public Port Dir => Inputs[3];
    public Port Q => Outputs[0];

    public SyTriDirLoadCounter()
    {
        this.AddBinaryInputs(nameof(Clk), nameof(LdEn));
        this.AddInputs(nameof(A), nameof(Dir));
        this.AddOutputs(nameof(Q));

        var _7PB = this.AddLogicGate("7PB");
        var PPPPPPZD0 = this.AddLogicGate("PPPPPPZD0");

        var tff = this.AddSubCircuit(new TFlipFlop());

        this.AddWires([
            (Clk, tff.Clk),
            (PPPPPPZD0.Q, tff.A),

            (Dir, _7PB.B),
            (tff.Q, _7PB.A),

            (LdEn, PPPPPPZD0.C),
            (A, PPPPPPZD0.B),
            (_7PB.Q, PPPPPPZD0.A),

            (tff.Q, Q)
        ]);
    }

    public override string GetTests() => """
        00-0 -
        10-0 -
        00-+ -
        10-+ 0
        00-+ 0
        10-+ +
        00-+ +
        10-+ -
        00-- -
        10-- +
        00-- +
        10-- 0
        00-- 0
        10-- -
        010- -
        110- 0
        01+- 0
        11+- +
        01+- +
        11+0 +
        01+0 +
        11+0 +
        01++ +
        11++ +
        01-+ +
        11-+ -
        00-+ -
        10-+ 0
        00-+ 0
        10-+ +
        00-+ +
        10-- -
        00-- -
    """;
}