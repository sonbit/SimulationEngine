using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Converters;

public class BTSignedRadixConverter4 : SubCircuit
{
    public Port A2 => Inputs[0];
    public Port A1 => Inputs[1];
    public Port A0 => Inputs[2];
    public Port Q3 => Outputs[0];
    public Port Q2 => Outputs[1];
    public Port Q1 => Outputs[2];
    public Port Q0 => Outputs[3];

    public BTSignedRadixConverter4()
    {
        this.AddInputs(nameof(A2), nameof(A1), nameof(A0));
        this.AddBinaryOutputs(nameof(Q3), nameof(Q2), nameof(Q1), nameof(Q0));

        var EDCRC9DD4 = this.AddLogicGate("EDCRC9DD4");
        var CC9 = this.AddLogicGate("CC9");
        var _6N6 = this.AddLogicGate("6N6");
        var _228 = this.AddLogicGate("228");
        var N28 = this.AddLogicGate("N28");
        var _2N6 = this.AddLogicGate("2N6");
        var _60N = this.AddLogicGate("60N");

        this.AddWires([
            (A2, EDCRC9DD4.C),
            (A1, EDCRC9DD4.B),
            (A0, EDCRC9DD4.A),

            (A1, CC9.B),
            (EDCRC9DD4.Q, CC9.A),

            (A1, _6N6.B),
            (A0, _6N6.A),

            (A2, _228.B),
            (CC9.Q, _228.A),

            (A1, N28.B),
            (EDCRC9DD4.Q, N28.A),

            (A1, _2N6.B),
            (EDCRC9DD4.Q, _2N6.A),

            (A2, _60N.B),
            (_6N6.Q, _60N.A),

            (_228.Q, Q3),
            (N28.Q, Q2),
            (_2N6.Q, Q1),
            (_60N.Q, Q0)
        ]);
    }

    public override string GetTestString() => """
        --- 1111
        --0 1110
        --+ 1111
        -0- 1000
        -00 1001
        -0+ 1000
        -+- 1001
        -+0 1010
        -++ 1011
        0-- 1100
        0-0 1101
        0-+ 1110
        00- 1111
        000 0000
        00+ 0001
        0+- 0010
        0+0 0011
        0++ 0100
        +-- 0101
        +-0 0110
        +-+ 0111
        +0- 0000
        +00 0001
        +0+ 0000
        ++- 0011
        ++0 0010
        +++ 0011
    """;
}