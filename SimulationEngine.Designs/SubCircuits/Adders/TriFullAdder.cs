using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Adders;

public class TriFullAdder : Subcircuit
{
    public Port C => Inputs[0];
    public Port B => Inputs[1];
    public Port A => Inputs[2];
    public Port Cout => Outputs[0];
    public Port Q => Outputs[1];

    public TriFullAdder()
    {
        this.AddInputs(nameof(C), nameof(B), nameof(A));
        this.AddOutputs(nameof(Cout), nameof(Q));

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
            (B7P7PBPB7.Q, Q)
        ]);
    }

    public override string GetTestString() => """
        --- -0
        --0 -+
        --+ 0-
        -0- -+
        -00 0-
        -0+ 00
        -+- 0-
        -+0 00
        -++ 0+
        0-- -+
        0-0 0-
        0-+ 00
        00- 0-
        000 00
        00+ 0+
        0+- 00
        0+0 0+
        0++ +-
        +-- 0-
        +-0 00
        +-+ 0+
        +0- 00
        +00 0+
        +0+ +-
        ++- 0+
        ++0 +-
        +++ +0
    """;
}