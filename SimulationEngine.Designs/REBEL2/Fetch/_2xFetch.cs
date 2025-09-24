using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Fetch;

public class _2xFetch : SubCircuit
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

    public Port Pc1_0 => Outputs[0];
    public Port Pc0_0 => Outputs[1];
    public Port Op1_0 => Outputs[2];
    public Port Op0_0 => Outputs[3];
    public Port Rs11_0 => Outputs[4];
    public Port Rs10_0 => Outputs[5];
    public Port Rs01_0 => Outputs[6];
    public Port Rs00_0 => Outputs[7];
    public Port Rd11_0 => Outputs[8];
    public Port Rd10_0 => Outputs[9];
    public Port Rd01_0 => Outputs[10];
    public Port Rd00_0 => Outputs[11];

    public Port Pc1_1 => Outputs[12];
    public Port Pc0_1 => Outputs[13];
    public Port Op1_1 => Outputs[14];
    public Port Op0_1 => Outputs[15];
    public Port Rs11_1 => Outputs[16];
    public Port Rs10_1 => Outputs[17];
    public Port Rs01_1 => Outputs[18];
    public Port Rs00_1 => Outputs[19];
    public Port Rd11_1 => Outputs[20];
    public Port Rd10_1 => Outputs[21];
    public Port Rd01_1 => Outputs[22];
    public Port Rd00_1 => Outputs[23];

    public _2xFetch()
    {
        this.AddInputs(
            nameof(LdEn), nameof(LdAddr1), nameof(LdAddr0), nameof(WrAddr1), nameof(WrAddr0),
            nameof(WrData9), nameof(WrData8), nameof(WrData7), nameof(WrData6), nameof(WrData5),
            nameof(WrData4), nameof(WrData3), nameof(WrData2), nameof(WrData1), nameof(WrData0));
        this.AddBinaryInputs(nameof(Clk), nameof(WrClk)); 
        this.AddOutputs(
            nameof(Pc1_0), nameof(Pc0_0), nameof(Op1_0), nameof(Op0_0), nameof(Rs11_0), nameof(Rs10_0), nameof(Rs01_0), nameof(Rs00_0), 
            nameof(Rd11_0), nameof(Rd10_0), nameof(Rd01_0), nameof(Rd00_0), 

            nameof(Pc1_1), nameof(Pc0_1), nameof(Op1_1), nameof(Op0_1), nameof(Rs11_1), nameof(Rs10_1), nameof(Rs01_1), nameof(Rs00_1), 
            nameof(Rd11_1), nameof(Rd10_1), nameof(Rd01_1), nameof(Rd00_1));

        var fetch_0 = this.AddSubCircuit(new Fetch());
        var fetch_1 = this.AddSubCircuit(new Fetch());

        this.AddWires([
            (LdEn, fetch_0.LdEn),
            (LdAddr1, fetch_0.LdAddr1),
            (LdAddr0, fetch_0.LdAddr0),
            (WrAddr1, fetch_0.WrAddr1),
            (WrAddr0, fetch_0.WrAddr0),
            (WrData9, fetch_0.WrData9),
            (WrData8, fetch_0.WrData8),
            (WrData7, fetch_0.WrData7),
            (WrData6, fetch_0.WrData6),
            (WrData5, fetch_0.WrData5),
            (WrData4, fetch_0.WrData4),
            (WrData3, fetch_0.WrData3),
            (WrData2, fetch_0.WrData2),
            (WrData1, fetch_0.WrData1),
            (WrData0, fetch_0.WrData2),
            (Clk, fetch_0.Clk),
            (WrClk, fetch_0.WrClk),

            (LdEn, fetch_1.LdEn),
            (LdAddr1, fetch_1.LdAddr1),
            (LdAddr0, fetch_1.LdAddr0),
            (WrAddr1, fetch_1.WrAddr1),
            (WrAddr0, fetch_1.WrAddr0),
            (WrData9, fetch_1.WrData9),
            (WrData8, fetch_1.WrData8),
            (WrData7, fetch_1.WrData7),
            (WrData6, fetch_1.WrData6),
            (WrData5, fetch_1.WrData5),
            (WrData4, fetch_1.WrData4),
            (WrData3, fetch_1.WrData3),
            (WrData2, fetch_1.WrData2),
            (WrData1, fetch_1.WrData1),
            (WrData0, fetch_1.WrData2),
            (Clk, fetch_1.Clk),
            (WrClk, fetch_1.WrClk),

            (fetch_0.Pc1, Pc1_0),
            (fetch_0.Pc0, Pc0_0),
            (fetch_0.Op1, Op1_0),
            (fetch_0.Op0, Op0_0),
            (fetch_0.Rs11, Rs11_0),
            (fetch_0.Rs10, Rs10_0),
            (fetch_0.Rs01, Rs01_0),
            (fetch_0.Rs00, Rs00_0),
            (fetch_0.Rd11, Rd11_0),
            (fetch_0.Rd10, Rd10_0),
            (fetch_0.Rd01, Rd01_0),
            (fetch_0.Rd00, Rd00_0),

            (fetch_1.Pc1, Pc1_1),
            (fetch_1.Pc0, Pc0_1),
            (fetch_1.Op1, Op1_1),
            (fetch_1.Op0, Op0_1),
            (fetch_1.Rs11, Rs11_1),
            (fetch_1.Rs10, Rs10_1),
            (fetch_1.Rs01, Rs01_1),
            (fetch_1.Rs00, Rs00_1),
            (fetch_1.Rd11, Rd11_1),
            (fetch_1.Rd10, Rd10_1),
            (fetch_1.Rd01, Rd01_1),
            (fetch_1.Rd00, Rd00_1)
        ]);
    }

    public override string GetTestString() => """
        ---------------00 ------------------------
        ---------------01 ------------------------
        ----0-0-0-0-0-000 ------------------------
        ----0-0-0-0-0-001 ------------------------
        ----+-+-+-+-+-+00 ------------------------
        ----+-+-+-+-+-+01 ------------------------
        ---0-0-0-0-0-0-00 ------------------------
        ---0-0-0-0-0-0-01 ------------------------
        ---00000000000000 ------------------------
        ---00000000000001 ------------------------
        ---0+0+0+0+0+0+00 ------------------------
        ---0+0+0+0+0+0+01 ------------------------
        ---+-+-+-+-+-+-00 ------------------------
        ---+-+-+-+-+-+-01 ------------------------
        ---+0+0+0+0+0+000 ------------------------
        ---+0+0+0+0+0+001 ------------------------
        ---++++++++++++00 ------------------------
        ---++++++++++++01 ------------------------
        ---------------00 ------------------------
        +--------------10 ------------------------
        +-0------------00 ------------------------
        +-0------------10 -0-0-0-0-0-0-0-0-0-0-0-0
        +-+------------00 -0-0-0-0-0-0-0-0-0-0-0-0
        +-+------------10 -+++++++++++-+++++++++++
        +0-------------00 -+++++++++++-+++++++++++
        +0-------------10 0-0-0-0-0-0-0-0-0-0-0-0-
        +00------------00 0-0-0-0-0-0-0-0-0-0-0-0-
        +00------------10 000000000000000000000000
        +0+------------00 000000000000000000000000
        +0+------------10 0+0+0+0+0+0+0+0+0+0+0+0+
        ++-------------00 0+0+0+0+0+0+0+0+0+0+0+0+
        ++-------------10 +-+-+-+-+-+-+-+-+-+-+-+-
        ++0------------00 +-+-+-+-+-+-+-+-+-+-+-+-
        ++0------------10 +0+0+0+0+0+0+0+0+0+0+0+0
        +++------------00 +0+0+0+0+0+0+0+0+0+0+0+0
        +++------------10 ++++++++++++++++++++++++
        +++------------00 ++++++++++++++++++++++++
        ---------------00 ++++++++++++++++++++++++
        ---------------01 ++++++++++++++++++++++++
        ----0-0-0-0-0-000 ++++++++++++++++++++++++
        ----0-0-0-0-0-001 ++++++++++++++++++++++++
        ----+-+-+-+-+-+00 ++++++++++++++++++++++++
        ----+-+-+-+-+-+01 ++++++++++++++++++++++++
        ---0-0-0-0-0-0-00 ++++++++++++++++++++++++
        ---0-0-0-0-0-0-01 ++++++++++++++++++++++++
        ---00000000000000 ++++++++++++++++++++++++
        ---00000000000001 ++++++++++++++++++++++++
        ---0+0+0+0+0+0+00 ++++++++++++++++++++++++
        ---0+0+0+0+0+0+01 ++++++++++++++++++++++++
        ---+-+-+-+-+-+-00 ++0+0+0+0+0+++0+0+0+0+0+
        ---+-+-+-+-+-+-01 ++0+0+0+0+0+++0+0+0+0+0+
        ---+0+0+0+0+0+000 ++0+0+0+0+0+++0+0+0+0+0+
        ---+0+0+0+0+0+001 ++0+0+0+0+0+++0+0+0+0+0+
        ---++++++++++++00 ++++++++++++++++++++++++
        ---++++++++++++01 ++++++++++++++++++++++++
        ---------------00 ++++++++++++++++++++++++
        +--------------10 ------------------------
        +-0------------00 ------------------------
        +-0------------10 -0-0-0-0-0-0-0-0-0-0-0-0
        +-+------------00 -0-0-0-0-0-0-0-0-0-0-0-0
        +-+------------10 -+++++++++++-+++++++++++
        +0-------------00 -+++++++++++-+++++++++++
        +0-------------10 0-0-0-0-0-0-0-0-0-0-0-0-
        +00------------00 0-0-0-0-0-0-0-0-0-0-0-0-
        +00------------10 000000000000000000000000
        +0+------------00 000000000000000000000000
        +0+------------10 0+0+0+0+0+0+0+0+0+0+0+0+
        ++-------------00 0+0+0+0+0+0+0+0+0+0+0+0+
        ++-------------10 +-+-+-+-+-+-+-+-+-+-+-+-
        ++0------------00 +-+-+-+-+-+-+-+-+-+-+-+-
        ++0------------10 +0+0+0+0+0+0+0+0+0+0+0+0
        +++------------00 +0+0+0+0+0+0+0+0+0+0+0+0
        +++------------10 ++++++++++++++++++++++++
        +++------------00 ++++++++++++++++++++++++
        +--------------10 ------------------------
        +-0------------00 ------------------------
        +-0------------10 -0-0-0-0-0-0-0-0-0-0-0-0
        +-+------------00 -0-0-0-0-0-0-0-0-0-0-0-0
        +-+------------10 -+++++++++++-+++++++++++
        +0-------------00 -+++++++++++-+++++++++++
        +0-------------10 0-0-0-0-0-0-0-0-0-0-0-0-
        +00------------00 0-0-0-0-0-0-0-0-0-0-0-0-
        +00------------10 000000000000000000000000
        +0+------------00 000000000000000000000000
        +0+------------10 0+0+0+0+0+0+0+0+0+0+0+0+
        ++-------------00 0+0+0+0+0+0+0+0+0+0+0+0+
        ++-------------10 +-+-+-+-+-+-+-+-+-+-+-+-
        ++0------------00 +-+-+-+-+-+-+-+-+-+-+-+-
        ++0------------10 +0+0+0+0+0+0+0+0+0+0+0+0
        +++------------00 +0+0+0+0+0+0+0+0+0+0+0+0
        +++------------10 ++++++++++++++++++++++++
        +++------------00 ++++++++++++++++++++++++
        +--------------10 ------------------------
        +-0------------00 ------------------------
        +-0------------10 -0-0-0-0-0-0-0-0-0-0-0-0
        +-+------------00 -0-0-0-0-0-0-0-0-0-0-0-0
        +-+------------10 -+++++++++++-+++++++++++
        +0-------------00 -+++++++++++-+++++++++++
        +0-------------10 0-0-0-0-0-0-0-0-0-0-0-0-
        +00------------00 0-0-0-0-0-0-0-0-0-0-0-0-
    """;
}