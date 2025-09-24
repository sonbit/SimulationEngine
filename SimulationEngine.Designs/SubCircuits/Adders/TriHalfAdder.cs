using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Adders;

public class TriHalfAdder : SubCircuit
{
    public Port B => Inputs[0];
    public Port A => Inputs[1];
    public Port Cout => Outputs[0];
    public Port Q => Outputs[1];

    public TriHalfAdder()
    {
        this.AddInputs(nameof(B), nameof(A));
        this.AddOutputs(nameof(Cout), nameof(Q));

        var RDC = this.AddLogicGate("RDC");
        var _7PB = this.AddLogicGate("7PB");

        this.AddWires([
            (B, RDC.B),
            (A, RDC.A),

            (B, _7PB.B),
            (A, _7PB.A),

            (RDC.Q, Cout),
            (_7PB.Q, Q)
        ]);
    }

    public override string GetTestString() => """
        -- -+
        -0 0-
        -+ 00
        0- 0-
        00 00
        0+ 0+
        +- 00
        +0 0+
        ++ +-
    """;
}