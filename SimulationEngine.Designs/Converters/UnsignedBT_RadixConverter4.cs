using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Converters;

public class UnsignedBT_RadixConverter4 : SubCircuit
{
    public Port B3 => Inputs[0];
    public Port B2 => Inputs[1];
    public Port B1 => Inputs[2];
    public Port B0 => Inputs[3];
    public Port Q3 => Outputs[0];
    public Port Q2 => Outputs[1];
    public Port Q1 => Outputs[2];
    public Port Q0 => Outputs[3];

    public UnsignedBT_RadixConverter4()
    {
        this.AddBinaryInputs(nameof(B3), nameof(B2), nameof(B1), nameof(B0));
        this.AddOutputs(nameof(Q3), nameof(Q2), nameof(Q1), nameof(Q0));

        var HHDDXXDDD = this.AddLogicGate("HHDDXXDDD");
        var HE4 = this.AddLogicGate("HE4");
        var ZZR = this.AddLogicGate("ZZR");
        var _5XX = this.AddLogicGate("5XX");
        var _5XC = this.AddLogicGate("5XC");
        var DD4 = this.AddLogicGate("DD4");
        var RRDRDDDDD = this.AddLogicGate("RRDRDDDDD");
        var RRD = this.AddLogicGate("RRD");
        var _88R = this.AddLogicGate("88R");
        var XE2 = this.AddLogicGate("XE2");
        var H4K = this.AddLogicGate("H4K");

        this.AddWires([
            (B2, HHDDXXDDD.C),
            (B1, HHDDXXDDD.B),
            (B0, HHDDXXDDD.A),

            (B1, HE4.B),
            (B0, HE4.A),

            (HHDDXXDDD.Q, ZZR.B),
            (B1, ZZR.A),

            (B2, _5XX.B),
            (ZZR.Q, _5XX.A),

            (B2, _5XC.B),
            (HE4.Q, _5XC.A),

            (B3, DD4.B),
            (_5XC.Q, DD4.A),

            (DD4.Q, RRDRDDDDD.C),
            (B2, RRDRDDDDD.B),
            (ZZR.Q, RRDRDDDDD.A),

            (RRDRDDDDD.Q, RRD.B),
            (B3, RRD.A),

            (RRDRDDDDD.Q, _88R.B),
            (B3, _88R.A),

            (DD4.Q, XE2.B),
            (_5XX.Q, XE2.A),

            (B3, H4K.B),
            (_5XC.Q, H4K.A),

            (RRD.Q, Q3),
            (_88R.Q, Q2),
            (XE2.Q, Q1),
            (H4K.Q, Q0)
        ]);
    }

    public override string GetTestString() => """
        0000 0000
        0001 000+
        0010 00+-
        0011 00+0
        0100 00++
        0101 0+--
        0110 0+-0
        0111 0+-+
        1000 0+0-
        1001 0+00
        1010 0+0+
        1011 0++-
        1100 0++0
        1101 0+++
        1110 +---
        1111 +--0
    """;
}