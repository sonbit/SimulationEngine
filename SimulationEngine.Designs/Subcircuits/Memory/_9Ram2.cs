using SimulationEngine.Designs.Subcircuits.Demultiplexers;
using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Memory;

public class _9Ram2 : Subcircuit
{
    public Port RdAddr11 => Inputs[0];
    public Port RdAddr10 => Inputs[1];
    public Port RdAddr21 => Inputs[2];
    public Port RdAddr20 => Inputs[3];
    public Port WrAddr1 => Inputs[4];
    public Port WrAddr0 => Inputs[5];
    public Port WrData1 => Inputs[6];
    public Port WrData0 => Inputs[7];
    public Port Clk => Inputs[8];
    public Port WrEnable => Inputs[9];  
    public Port RdData11 => Outputs[0];
    public Port RdData10 => Outputs[1];
    public Port RdData21 => Outputs[2];
    public Port RdData20 => Outputs[3];

    public Port Q81 => Outputs[4];
    public Port Q80 => Outputs[5];
    public Port Q71 => Outputs[6];
    public Port Q70 => Outputs[7];
    public Port Q61 => Outputs[8];
    public Port Q60 => Outputs[9];
    public Port Q51 => Outputs[10];
    public Port Q50 => Outputs[11];
    //public Port Q41 => Outputs[8]; x0
    //public Port Q40 => Outputs[9]; x0
    public Port Q31 => Outputs[12];
    public Port Q30 => Outputs[13];
    public Port Q21 => Outputs[14];
    public Port Q20 => Outputs[15];
    public Port Q11 => Outputs[16];
    public Port Q10 => Outputs[17];
    public Port Q01 => Outputs[18];
    public Port Q00 => Outputs[19];

    public _9Ram2()
    {
        this.AddInputs(
            nameof(RdAddr11), nameof(RdAddr10), nameof(RdAddr21), nameof(RdAddr20),
            nameof(WrAddr1), nameof(WrAddr0), nameof(WrData1), nameof(WrData0));
        this.AddBinaryInputs(nameof(Clk), nameof(WrEnable));
        this.AddOutputs(nameof(RdData11), nameof(RdData10), nameof(RdData21), nameof(RdData20));
        this.AddOutputs(
            nameof(Q81),
            nameof(Q80),
            nameof(Q71),
            nameof(Q70),
            nameof(Q61),
            nameof(Q60),
            nameof(Q51),
            nameof(Q50),
            nameof(Q31),
            nameof(Q30),
            nameof(Q21),
            nameof(Q20),
            nameof(Q11),
            nameof(Q10),
            nameof(Q01),
            nameof(Q00));

        var _9BDEMUX = this.AddSubcircuit(new _9BDEMUX());
        var _8Reg2 = this.AddSubcircuit(new _8Reg2());
        var _9MUX2_0 = this.AddSubcircuit(new _9MUX2());
        var _9MUX2_1 = this.AddSubcircuit(new _9MUX2());
        var _K00 = this.AddLogicGate("K00");


        var hardwired00 = this.AddLogicGate("ZTZDDD030");
        var hardwired01 = this.AddLogicGate("ZTZDDD030");
        var hardwired10 = this.AddLogicGate("ZTZDDD030");
        var hardwired11 = this.AddLogicGate("ZTZDDD030");


        this.AddWires([
            (Clk, _K00.A),
            (WrEnable, _K00.B),
        
            (WrAddr1, _9BDEMUX.Sel1),
            (WrAddr0, _9BDEMUX.Sel0),
            (_K00.Q, _9BDEMUX.Clk),

            (_9BDEMUX.ClkQ8, _8Reg2.Clk8),
            (_9BDEMUX.ClkQ7, _8Reg2.Clk7),
            (_9BDEMUX.ClkQ6, _8Reg2.Clk6),
            (_9BDEMUX.ClkQ5, _8Reg2.Clk5),
            (_9BDEMUX.ClkQ4, _8Reg2.Clk4),
            (_9BDEMUX.ClkQ3, _8Reg2.Clk3),
            (_9BDEMUX.ClkQ2, _8Reg2.Clk2),
            (_9BDEMUX.ClkQ1, _8Reg2.Clk1),
            (_9BDEMUX.ClkQ0, _8Reg2.Clk0),
            (WrData1, _8Reg2.Din1),
            (WrData0, _8Reg2.Din0),

            (RdAddr11, _9MUX2_0.Sel1),
            (RdAddr10, _9MUX2_0.Sel0),
            (_8Reg2.Q81, _9MUX2_0.D81),
            (_8Reg2.Q80, _9MUX2_0.D80),
            (_8Reg2.Q71, _9MUX2_0.D71),
            (_8Reg2.Q70, _9MUX2_0.D70),
            (_8Reg2.Q61, _9MUX2_0.D61),
            (_8Reg2.Q60, _9MUX2_0.D60),
            (_8Reg2.Q51, _9MUX2_0.D51),
            (_8Reg2.Q50, _9MUX2_0.D50),
            (_8Reg2.Q41, _9MUX2_0.D41),
            (_8Reg2.Q40, _9MUX2_0.D40),
            (_8Reg2.Q31, _9MUX2_0.D31),
            (_8Reg2.Q30, _9MUX2_0.D30),
            (_8Reg2.Q21, _9MUX2_0.D21),
            (_8Reg2.Q20, _9MUX2_0.D20),
            (_8Reg2.Q11, _9MUX2_0.D11),
            (_8Reg2.Q10, _9MUX2_0.D10),
            (_8Reg2.Q01, _9MUX2_0.D01),
            (_8Reg2.Q00, _9MUX2_0.D00),

            (RdAddr21, _9MUX2_1.Sel1),
            (RdAddr20, _9MUX2_1.Sel0),
            (_8Reg2.Q81, _9MUX2_1.D81),
            (_8Reg2.Q80, _9MUX2_1.D80),
            (_8Reg2.Q71, _9MUX2_1.D71),
            (_8Reg2.Q70, _9MUX2_1.D70),
            (_8Reg2.Q61, _9MUX2_1.D61),
            (_8Reg2.Q60, _9MUX2_1.D60),
            (_8Reg2.Q51, _9MUX2_1.D51),
            (_8Reg2.Q50, _9MUX2_1.D50),
            (_8Reg2.Q41, _9MUX2_1.D41),
            (_8Reg2.Q40, _9MUX2_1.D40),
            (_8Reg2.Q31, _9MUX2_1.D31),
            (_8Reg2.Q30, _9MUX2_1.D30),
            (_8Reg2.Q21, _9MUX2_1.D21),
            (_8Reg2.Q20, _9MUX2_1.D20),
            (_8Reg2.Q11, _9MUX2_1.D11),
            (_8Reg2.Q10, _9MUX2_1.D10),
            (_8Reg2.Q01, _9MUX2_1.D01),
            (_8Reg2.Q00, _9MUX2_1.D00),

            (_9MUX2_0.Q1, hardwired01.C),
            (_9MUX2_0.Q0, hardwired00.C),
            (_9MUX2_1.Q1, hardwired11.C),
            (_9MUX2_1.Q0, hardwired10.C),

            (RdAddr11, hardwired01.B),
            (RdAddr11, hardwired00.B),
            (RdAddr10, hardwired01.A),
            (RdAddr10, hardwired00.A),

            (RdAddr21, hardwired11.B),
            (RdAddr21, hardwired10.B),
            (RdAddr20, hardwired11.A),
            (RdAddr20, hardwired10.A),

            (hardwired01.Q, RdData11),
            (hardwired00.Q, RdData10),
            (hardwired11.Q, RdData21),
            (hardwired10.Q, RdData20),

            (_8Reg2.Q81, Q81),
            (_8Reg2.Q80, Q80),
            (_8Reg2.Q71, Q71),
            (_8Reg2.Q70, Q70),
            (_8Reg2.Q61, Q61),
            (_8Reg2.Q60, Q60),
            (_8Reg2.Q51, Q51),
            (_8Reg2.Q50, Q50),
            (_8Reg2.Q31, Q31),
            (_8Reg2.Q30, Q30),
            (_8Reg2.Q21, Q21),
            (_8Reg2.Q20, Q20),
            (_8Reg2.Q11, Q11),
            (_8Reg2.Q10, Q10),
            (_8Reg2.Q01, Q01),
            (_8Reg2.Q00, Q00),
        ]);
    }

    public override string GetTestString() => """
        0000000000 0000
        --------00 ----
        --------11 ----
        --------00 ----
        ------0011 0000
        ------0000 0000
        ------++11 ++++
        ----00--00 ++++
        ----00--11 ++++
        ----000000 ++++
        ----000011 ++++
        --00000000 ++00
        ----000000 ++++
        0000000000 0000
        ++++000000 ----
        ++00000000 --00
        00++000000 00--
    """;
}