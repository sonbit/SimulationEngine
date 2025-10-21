using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Multiplexers;

public class _3MUX : Subcircuit
{
    public Port Sel => Inputs[0];
    public Port C => Inputs[1];
    public Port B => Inputs[2];
    public Port A => Inputs[3];
    public Port Q => Outputs[0];

    public _3MUX()
    {
        this.AddInputs(nameof(Sel), nameof(C), nameof(B), nameof(A));
        this.AddOutputs(nameof(Q));

        var ZD0PPPPPP = this.AddLogicGate("ZD0PPPPPP");
        var ZD0ZD0PPP = this.AddLogicGate("ZD0ZD0PPP");

        this.AddWires([
            (Sel, ZD0PPPPPP.C),
            (B, ZD0PPPPPP.B),
            (A, ZD0PPPPPP.A),

            (Sel, ZD0ZD0PPP.C),
            (C, ZD0ZD0PPP.B),
            (ZD0PPPPPP.Q, ZD0ZD0PPP.A),

            (ZD0ZD0PPP.Q, Q)
        ]);
    }

    public override string GetTestString() => """
        ---- -
        -0++ 0
        -+00 +
        --00 -
        0+0+ 0
        00+0 +
        0+-+ -
        +++0 0
        +00+ +
        +++- -
        ---- -
    """;
}