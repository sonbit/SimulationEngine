using SimulationEngine.Designs.Subcircuits.Counters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Converters;

public class TT_UM_TernaryPC_RadixConverter : Subcircuit
{
    public Port Clk => Inputs[0];
    public Port LdEn => Inputs[1];
    public Port A3 => Inputs[2];
    public Port A2 => Inputs[3];
    public Port A1 => Inputs[4];
    public Port A0 => Inputs[5];
    public Port Dir => Inputs[6];
    public Port PC3 => Outputs[0];
    public Port PC2 => Outputs[1];
    public Port PC1 => Outputs[2];
    public Port PC0 => Outputs[3];
    public Port RC2 => Outputs[4];
    public Port RC1 => Outputs[5];
    public Port RC0 => Outputs[6];

    public TT_UM_TernaryPC_RadixConverter()
    {
        this.AddBinaryInputs(nameof(Clk), nameof(LdEn));
        this.AddInputs(nameof(A3), nameof(A2), nameof(A1), nameof(A0), nameof(Dir));
        this.AddOutputs(nameof(PC3), nameof(PC2), nameof(PC1), nameof(PC0), nameof(RC2), nameof(RC1), nameof(RC0));

        var syTriDirLoadCounter4 = this.AddSubcircuit(new SyTriDirLoadCounter4());
        var bTSignedRadixConverter = this.AddSubcircuit(new BTSignedRadixConverter4());
        var signedBTRadixConverter4 = this.AddSubcircuit(new SignedBTRadixConverter4());

        this.AddWires([
            (Clk, syTriDirLoadCounter4.Clk),
            (LdEn, syTriDirLoadCounter4.LdEn),
            (A3, syTriDirLoadCounter4.A3),
            (A2, syTriDirLoadCounter4.A2),
            (A1, syTriDirLoadCounter4.A1),
            (A0, syTriDirLoadCounter4.A0),
            (Dir, syTriDirLoadCounter4.Dir),

            (A2, bTSignedRadixConverter.A2),
            (A1, bTSignedRadixConverter.A1),
            (A0, bTSignedRadixConverter.A0),

            (bTSignedRadixConverter.Q3, signedBTRadixConverter4.Sign),
            (bTSignedRadixConverter.Q2, signedBTRadixConverter4.A2),
            (bTSignedRadixConverter.Q1, signedBTRadixConverter4.A1),
            (bTSignedRadixConverter.Q0, signedBTRadixConverter4.A0),

            (syTriDirLoadCounter4.Q3, PC3),
            (syTriDirLoadCounter4.Q2, PC2),
            (syTriDirLoadCounter4.Q1, PC1),
            (syTriDirLoadCounter4.Q0, PC0),
            (signedBTRadixConverter4.Q2, RC2),
            (signedBTRadixConverter4.Q1, RC1),
            (signedBTRadixConverter4.Q0, RC0)
        ]);
    }

    public override string GetTestString() => """
        00----+ ----00-
        10----+ ---000-
        00----+ ---000-
        10----+ ---+00-
        00----+ ---+00-
        10----+ --0-00-
        00----+ --0-00-
        10----+ --0000-
        00----+ --0000-
        10----+ --0+00-
        00----+ --0+00-
        10----+ --+-00-
        00----+ --+-00-
        10----+ --+000-
        00----+ --+000-
        10----+ --++00-
        00----+ --++00-
        10----+ -0--00-
        00----+ -0--00-
        10----+ -0-000-
        00----+ -0-000-
        10----+ -0-+00-
        00----+ -0-+00-
        10----+ -00-00-
        00----+ -00-00-
        10----+ -00000-
        00----+ -00000-
        10----+ -00+00-
        00----+ -00+00-
        10----+ -0+-00-
        00----+ -0+-00-
        10----+ -0+000-
        00----+ -0+000-
        10----+ -0++00-
        00----+ -0++00-
        10----+ -+--00-
        00----+ -+--00-
        10----+ -+-000-
        00----+ -+-000-
        10----+ -+-+00-
        00----+ -+-+00-
        10----+ -+0-00-
        00----+ -+0-00-
        10----+ -+0000-
        00----+ -+0000-
        10----+ -+0+00-
        00----+ -+0+00-
        10----+ -++-00-
        00----+ -++-00-
        10----+ -++000-
        00----+ -++000-
        10----+ -+++00-
        00----+ -+++00-
        10----+ 0---00-
        00----- 0---00-
        10----- -+++00-
        00----- -+++00-
        10----- -++000-
        01----- -++000-
        11----- ----00-
        010+-0- ----+-0
        110+-0- 0+-0+-0
        01+00+- 0+-000+
        11+00+- +00+00+
        010++0- +00+0+-
        110++0- 0++00+-
        01----- 0++000-
        11----- ----00-
        00----- ----00-
        00----+ ----00-
        10----+ ---000-
        00----+ ---000-
        10----+ ---+00-
        00----+ ---+00-
        10----+ --0-00-
        00----+ --0-00-
        10----+ --0000-
        00----+ --0000-
        10----+ --0+00-
        00----+ --0+00-
        10----+ --+-00-
        00----+ --+-00-
        10----+ --+000-
        00----+ --+000-
        10----+ --++00-
        00----+ --++00-
        10----+ -0--00-
        00----+ -0--00-
        10----+ -0-000-
        00----+ -0-000-
        10----+ -0-+00-
        00----+ -0-+00-
        10----+ -00-00-
        00----+ -00-00-
        10----+ -00000-
        00----+ -00000-
        10----+ -00+00-
        00----+ -00+00-
        10----+ -0+-00-
        00----+ -0+-00-
    """;
}