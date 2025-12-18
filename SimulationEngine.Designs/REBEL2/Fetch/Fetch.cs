using SimulationEngine.Designs.Subcircuits.Memory;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Fetch;

public class Fetch : Subcircuit
{
    public Port LdEn => Inputs[0];
    public Port LdAddr1 => Inputs[1];
    public Port LdAddr0 => Inputs[2];
    public Port WrAddr1 => Inputs[3];
    public Port WrAddr0 => Inputs[4];
    public Port WrData9 => Inputs[5];
    public Port WrData8 => Inputs[6];
    public Port WrData7 => Inputs[7];
    public Port WrData6 => Inputs[8];
    public Port WrData5 => Inputs[9];
    public Port WrData4 => Inputs[10];
    public Port WrData3 => Inputs[11];
    public Port WrData2 => Inputs[12];
    public Port WrData1 => Inputs[13];
    public Port WrData0 => Inputs[14];
    public Port Clk => Inputs[15];
    public Port WrClk => Inputs[16];
    public Port Pc1 => Outputs[0];
    public Port Pc0 => Outputs[1];
    public Port Op1 => Outputs[2];
    public Port Op0 => Outputs[3];
    public Port Rs11 => Outputs[4];
    public Port Rs10 => Outputs[5];
    public Port Rs01 => Outputs[6];
    public Port Rs00 => Outputs[7];
    public Port Rd11 => Outputs[8];
    public Port Rd10 => Outputs[9];
    public Port Rd01 => Outputs[10];
    public Port Rd00 => Outputs[11];

    public Fetch()
    {
        this.AddInputs(
            nameof(LdEn), nameof(LdAddr1), nameof(LdAddr0), nameof(WrAddr1), nameof(WrAddr0), 
            nameof(WrData9), nameof(WrData8), nameof(WrData7), nameof(WrData6), nameof(WrData5), 
            nameof(WrData4), nameof(WrData3), nameof(WrData2), nameof(WrData1), nameof(WrData0));
        this.AddBinaryInputs(nameof(Clk), nameof(WrClk));
        this.AddOutputs(
            nameof(Pc1), nameof(Pc0), nameof(Op1), nameof(Op0), 
            nameof(Rs11), nameof(Rs10), nameof(Rs01), nameof(Rs00), 
            nameof(Rd11), nameof(Rd10), nameof(Rd01), nameof(Rd00));

        var progCtr2 = this.AddSubcircuit(new ProgCtr2());
        var _9Reg10_1 = this.AddSubcircuit(new _9Reg10_1());

        this.AddWires([
            (LdEn, progCtr2.LdEn),
            (LdAddr1, progCtr2.LdAddr1),
            (LdAddr0, progCtr2.LdAddr0),
            (Clk, progCtr2.Clk),

            (progCtr2.Pc1, _9Reg10_1.RdAddr1),
            (progCtr2.Pc0, _9Reg10_1.RdAddr0),
            (WrAddr1, _9Reg10_1.WrAddr1),
            (WrAddr0, _9Reg10_1.WrAddr0),
            (WrData9, _9Reg10_1.WrData9),
            (WrData8, _9Reg10_1.WrData8),
            (WrData7, _9Reg10_1.WrData7),
            (WrData6, _9Reg10_1.WrData6),
            (WrData5, _9Reg10_1.WrData5),
            (WrData4, _9Reg10_1.WrData4),
            (WrData3, _9Reg10_1.WrData3),
            (WrData2, _9Reg10_1.WrData2),
            (WrData1, _9Reg10_1.WrData1),
            (WrData0, _9Reg10_1.WrData0),
            (WrClk, _9Reg10_1.Clk),

            (progCtr2.Pc1, Pc1),
            (progCtr2.Pc0, Pc0),
            (_9Reg10_1.Op1, Op1),
            (_9Reg10_1.Op0, Op0),
            (_9Reg10_1.Rs11, Rs11),
            (_9Reg10_1.Rs10, Rs10),
            (_9Reg10_1.Rs01, Rs01),
            (_9Reg10_1.Rs00, Rs00),
            (_9Reg10_1.Rd11, Rd11),
            (_9Reg10_1.Rd10, Rd10),
            (_9Reg10_1.Rd01, Rd01),
            (_9Reg10_1.Rd00, Rd00)
        ]);
    }

    public override string GetTestString() => """
        ---------------00 ------------
        ---------------01 ------------
        ----0-0-0-0-0-000 ------------
        ----0-0-0-0-0-001 ------------
        ----+-+-+-+-+-+00 ------------
        ----+-+-+-+-+-+01 ------------
        ---0-0-0-0-0-0-00 ------------
        ---0-0-0-0-0-0-01 ------------
        ---00000000000000 ------------
        ---00000000000001 ------------
        ---0+0+0+0+0+0+00 ------------
        ---0+0+0+0+0+0+01 ------------
        ---+-+-+-+-+-+-00 ------------
        ---+-+-+-+-+-+-01 ------------
        ---+0+0+0+0+0+000 ------------
        ---+0+0+0+0+0+001 ------------
        ---++++++++++++00 ------------
        ---++++++++++++01 ------------
        ---------------00 ------------
        +--------------10 ------------
        +-0------------00 -0-0-0-0-0-0
        +-0------------10 -0-0-0-0-0-0
        +-+------------00 -+++++++++++
        +-+------------10 -+++++++++++
        +0-------------00 0-0-0-0-0-0-
        +0-------------10 0-0-0-0-0-0-
        +00------------00 000000000000
        +00------------10 000000000000
        +0+------------00 0+0+0+0+0+0+
        +0+------------10 0+0+0+0+0+0+
        ++-------------00 +-+-+-+-+-+-
        ++-------------10 +-+-+-+-+-+-
        ++0------------00 +0+0+0+0+0+0
        ++0------------10 +0+0+0+0+0+0
        +++------------00 ++++++++++++
        +++------------10 ++++++++++++
        +++------------00 ++++++++++++
        ---------------00 ++++++++++++
        ---------------01 ++++++++++++
        ----0-0-0-0-0-000 ++++++++++++
        ----0-0-0-0-0-001 ++++++++++++
        ----+-+-+-+-+-+00 ++++++++++++
        ----+-+-+-+-+-+01 ++++++++++++
        ---0-0-0-0-0-0-00 ++++++++++++
        ---0-0-0-0-0-0-01 ++++++++++++
        ---00000000000000 ++++++++++++
        ---00000000000001 ++++++++++++
        ---0+0+0+0+0+0+00 ++++++++++++
        ---0+0+0+0+0+0+01 ++++++++++++
        ---+-+-+-+-+-+-00 ++0+0+0+0+0+
        ---+-+-+-+-+-+-01 ++0+0+0+0+0+
        ---+0+0+0+0+0+000 ++0+0+0+0+0+
        ---+0+0+0+0+0+001 ++0+0+0+0+0+
        ---++++++++++++00 ++++++++++++
        ---++++++++++++01 ++++++++++++
        ---------------00 ++++++++++++
        +--------------10 ++++++++++++
        +-0------------00 -0-0-0-0-0-0
        +-0------------10 -0-0-0-0-0-0
        +-+------------00 -+++++++++++
        +-+------------10 -+++++++++++
        +0-------------00 0-0-0-0-0-0-
        +0-------------10 0-0-0-0-0-0-
        +00------------00 000000000000
        +00------------10 000000000000
        +0+------------00 0+0+0+0+0+0+
        +0+------------10 0+0+0+0+0+0+
        ++-------------00 +-+-+-+-+-+-
        ++-------------10 +-+-+-+-+-+-
        ++0------------00 +0+0+0+0+0+0
        ++0------------10 +0+0+0+0+0+0
        +++------------00 ++++++++++++
        +++------------10 ++++++++++++
        +++------------00 ++++++++++++
        ---------------00 ++++++++++++
        +--------------10 ++++++++++++
        +-0------------00 -0-0-0-0-0-0
        +-0------------10 -0-0-0-0-0-0
        +-+------------00 -+++++++++++
        +-+------------10 -+++++++++++
        +0-------------00 0-0-0-0-0-0-
        +0-------------10 0-0-0-0-0-0-
        +00------------00 000000000000
        +00------------10 000000000000
        +0+------------00 0+0+0+0+0+0+
        +0+------------10 0+0+0+0+0+0+
        ++-------------00 +-+-+-+-+-+-
        ++-------------10 +-+-+-+-+-+-
        ++0------------00 +0+0+0+0+0+0
        ++0------------10 +0+0+0+0+0+0
        +++------------00 ++++++++++++
        +++------------10 ++++++++++++
        +++------------00 ++++++++++++
        ---------------00 ++++++++++++
        +--------------10 ++++++++++++
        +-0------------00 -0-0-0-0-0-0
        +-0------------10 -0-0-0-0-0-0
        +-+------------00 -+++++++++++
        +-+------------10 -+++++++++++
        +0-------------00 0-0-0-0-0-0-
    """;
}