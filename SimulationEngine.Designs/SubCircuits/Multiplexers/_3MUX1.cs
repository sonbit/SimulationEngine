using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Multiplexers;

public class _3MUX1 : Subcircuit
{
    public Port Sel => Inputs[0];
    public Port C => Inputs[1];
    public Port B => Inputs[2];
    public Port A => Inputs[3];
    public Port Q => Outputs[0];

    public _3MUX1() {
        this.AddInputs(nameof(Sel), nameof(C), nameof(B), nameof(A));
        this.AddOutputs(nameof(Q));

        var PPPPPPZD0 = this.AddLogicGate("PPPPPPZD0");
        var PPPZD0ZD0 = this.AddLogicGate("PPPZD0ZD0");

        this.AddWires([
            (Sel, PPPPPPZD0.C),
            (B, PPPPPPZD0.B),
            (A, PPPPPPZD0.A),

            (Sel, PPPZD0ZD0.C),
            (C, PPPZD0ZD0.B),
            (PPPPPPZD0.Q, PPPZD0ZD0.A),

            (PPPZD0ZD0.Q, Q)
        ]);
    }

    public override string GetTestString() => """
        ---- -
        -++0 0
        -00+ +
        -00- -
        0+0+ 0
        00+0 +
        0+-+ -
        +00+ 0
        ++00 +
        +-++ -
        ---- -
    """;
}