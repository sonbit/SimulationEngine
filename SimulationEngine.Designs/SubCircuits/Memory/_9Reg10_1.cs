using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class _9Reg10_1 : SubCircuit
{
    public Port RdAddr1 => Inputs[0];
    public Port RdAddr0 => Inputs[1];
    public Port WrAddr1 => Inputs[2];
    public Port WrAddr0 => Inputs[3];
    public Port WrData9 => Inputs[4];
    public Port WrData8 => Inputs[5];
    public Port WrData7 => Inputs[6];
    public Port WrData6 => Inputs[7];
    public Port WrData5 => Inputs[8];
    public Port WrData4 => Inputs[9];
    public Port WrData3 => Inputs[10];
    public Port WrData2 => Inputs[11];
    public Port WrData1 => Inputs[12];
    public Port WrData0 => Inputs[13];
    public Port Clk => Inputs[14];
    public Port Op1 => Outputs[0];
    public Port Op0 => Outputs[1];
    public Port Rs11 => Outputs[2];
    public Port Rs10 => Outputs[3];
    public Port Rs01 => Outputs[4];
    public Port Rs00 => Outputs[5];
    public Port Rd11 => Outputs[6];
    public Port Rd10 => Outputs[7];
    public Port Rd01 => Outputs[8];
    public Port Rd00 => Outputs[9];

    public _9Reg10_1()
    {
        this.AddInputs(
            nameof(RdAddr1), nameof(RdAddr0), nameof(WrAddr1), nameof(WrAddr0),
            nameof(WrData9), nameof(WrData8), nameof(WrData7), nameof(WrData6),
            nameof(WrData5), nameof(WrData4), nameof(WrData3), nameof(WrData2),
            nameof(WrData1), nameof(WrData0)); 
        this.AddBinaryInput(nameof(Clk));
        this.AddOutputs(
            nameof(Op1), nameof(Op0), 
            nameof(Rs11), nameof(Rs10), nameof(Rs01), nameof(Rs00), 
            nameof(Rd11), nameof(Rd10), nameof(Rd01), nameof(Rd00));

        var _9Reg21_0 = this.AddSubCircuit(new _9Reg2_1());
        var _9Reg21_1 = this.AddSubCircuit(new _9Reg2_1());
        var _9Reg21_2 = this.AddSubCircuit(new _9Reg2_1());
        var _9Reg21_3 = this.AddSubCircuit(new _9Reg2_1());
        var _9Reg21_4 = this.AddSubCircuit(new _9Reg2_1());

        this.AddWires([
            (RdAddr1, _9Reg21_0.RdAddr1),
            (RdAddr0, _9Reg21_0.RdAddr0),
            (WrAddr1, _9Reg21_0.WrAddr1),
            (WrAddr0, _9Reg21_0.WrAddr0),
            (WrData9, _9Reg21_0.WrData1),
            (WrData8, _9Reg21_0.WrData0),
            (Clk, _9Reg21_0.Clk),

            (RdAddr1, _9Reg21_1.RdAddr1),
            (RdAddr0, _9Reg21_1.RdAddr0),
            (WrAddr1, _9Reg21_1.WrAddr1),
            (WrAddr0, _9Reg21_1.WrAddr0),
            (WrData9, _9Reg21_1.WrData1),
            (WrData8, _9Reg21_1.WrData0),
            (Clk, _9Reg21_1.Clk),

            (RdAddr1, _9Reg21_2.RdAddr1),
            (RdAddr0, _9Reg21_2.RdAddr0),
            (WrAddr1, _9Reg21_2.WrAddr1),
            (WrAddr0, _9Reg21_2.WrAddr0),
            (WrData9, _9Reg21_2.WrData1),
            (WrData8, _9Reg21_2.WrData0),
            (Clk, _9Reg21_2.Clk),

            (RdAddr1, _9Reg21_3.RdAddr1),
            (RdAddr0, _9Reg21_3.RdAddr0),
            (WrAddr1, _9Reg21_3.WrAddr1),
            (WrAddr0, _9Reg21_3.WrAddr0),
            (WrData9, _9Reg21_3.WrData1),
            (WrData8, _9Reg21_3.WrData0),
            (Clk, _9Reg21_3.Clk),

            (RdAddr1, _9Reg21_4.RdAddr1),
            (RdAddr0, _9Reg21_4.RdAddr0),
            (WrAddr1, _9Reg21_4.WrAddr1),
            (WrAddr0, _9Reg21_4.WrAddr0),
            (WrData9, _9Reg21_4.WrData1),
            (WrData8, _9Reg21_4.WrData0),
            (Clk, _9Reg21_4.Clk),

            (_9Reg21_0.Q1, Op1),
            (_9Reg21_0.Q0, Op0),
            (_9Reg21_1.Q1, Rs11),
            (_9Reg21_1.Q0, Rs10),
            (_9Reg21_2.Q1, Rs01),
            (_9Reg21_2.Q0, Rs00),
            (_9Reg21_3.Q1, Rd11),
            (_9Reg21_3.Q0, Rd10),
            (_9Reg21_4.Q1, Rd01),
            (_9Reg21_4.Q0, Rd00)
        ]);
    }

    public override string GetTestString() => """
        --------------0 ----------
        ---0-0-0-0-0-01 ----------
        ---0-0-0-0-0-00 ----------
        ---+-+-+-+-+-+1 ----------
        ---+-+-+-+-+-+0 ----------
        --0-0-0-0-0-0-1 ----------
        --0-0-0-0-0-0-0 ----------
        --0000000000001 ----------
        --0000000000000 ----------
        --0+0+0+0+0+0+1 ----------
        --0+0+0+0+0+0+0 ----------
        --+-+-+-+-+-+-1 ----------
        --+-+-+-+-+-+-0 ----------
        --+0+0+0+0+0+01 ----------
        --+0+0+0+0+0+00 ----------
        --++++++++++++1 ----------
        --++++++++++++0 ----------
        --------------1 ----------
        --------------0 ----------
        -0------------0 -0-0-0-0-0
        -+------------0 -+-+-+-+-+
        0-------------0 0-0-0-0-0-
        00------------0 0000000000
        0+------------0 0+0+0+0+0+
        +-------------0 +-+-+-+-+-
        +0------------0 +0+0+0+0+0
        ++------------0 ++++++++++
        ++-0----------0 ++++++++++
        ++-0----------1 ++++++++++
        ++-+----------0 ++++++++++
        ++-+----------1 ++++++++++
        ++0-----------0 ++++++++++
        ++0-----------1 ++++++++++
        ++00----------0 ++++++++++
        ++00----------1 ++++++++++
        ++0+----------0 ++++++++++
        ++0+----------1 ++++++++++
        +++-----------0 ----------
        +++-----------1 ----------
        +++0----------0 ----------
        +++0----------1 ----------
        ++++----------0 ----------
        ++++----------1 ----------
        --------------0 ----------
    """;
}