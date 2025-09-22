using SimulationEngine.Designs.SubCircuits.Demultiplexers;
using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class _9Reg2 : SubCircuit
{
    public Port RdAddr11 => Inputs[0];
    public Port RdAddr10 => Inputs[1];
    public Port RdAddr01 => Inputs[2];
    public Port RdAddr00 => Inputs[3];
    public Port WrAddr1 => Inputs[4];
    public Port WrAddr0 => Inputs[5];
    public Port WrData1 => Inputs[6];
    public Port WrData0 => Inputs[7];
    public Port WrReg => Inputs[8];
    public Port RdData11 => Outputs[0];
    public Port RdData10 => Outputs[1];
    public Port RdData01 => Outputs[2];
    public Port RdData00 => Outputs[3];

    public _9Reg2()
    {
        this.AddInputs(
            nameof(RdAddr11), nameof(RdAddr10), nameof(RdAddr01), nameof(RdAddr00),
            nameof(WrAddr1), nameof(WrAddr0), nameof(WrData1), nameof(WrData0));
        this.AddBinaryInput(nameof(WrReg));
        this.AddOutputs(nameof(RdData11), nameof(RdData10), nameof(RdData01), nameof(RdData00));

        var _9BDEMUX = this.AddSubCircuit(new _9BDEMUX());
        var _8RegArray2 = this.AddSubCircuit(new _8RegArray2());
        var _9MUX2_0 = this.AddSubCircuit(new _9MUX2());
        var _9MUX2_1 = this.AddSubCircuit(new _9MUX2());

        this.AddWires([
            (WrAddr1, _9BDEMUX.Sel1),
            (WrAddr0, _9BDEMUX.Sel0),
            (WrReg, _9BDEMUX.Clk),

            (_9BDEMUX.ClkQ8, _8RegArray2.Clk8),
            (_9BDEMUX.ClkQ7, _8RegArray2.Clk7),
            (_9BDEMUX.ClkQ6, _8RegArray2.Clk6),
            (_9BDEMUX.ClkQ5, _8RegArray2.Clk5),
            (_9BDEMUX.ClkQ4, _8RegArray2.Clk4),
            (_9BDEMUX.ClkQ3, _8RegArray2.Clk3),
            (_9BDEMUX.ClkQ2, _8RegArray2.Clk2),
            (_9BDEMUX.ClkQ1, _8RegArray2.Clk1),
            (_9BDEMUX.ClkQ0, _8RegArray2.Clk0),
            (WrData1, _8RegArray2.Din1),
            (WrData0, _8RegArray2.Din0),

            (RdAddr11, _9MUX2_0.Sel1),
            (RdAddr10, _9MUX2_0.Sel0),
            (_8RegArray2.Q81, _9MUX2_0.D81),
            (_8RegArray2.Q80, _9MUX2_0.D80),
            (_8RegArray2.Q71, _9MUX2_0.D71),
            (_8RegArray2.Q70, _9MUX2_0.D70),
            (_8RegArray2.Q61, _9MUX2_0.D61),
            (_8RegArray2.Q60, _9MUX2_0.D60),
            (_8RegArray2.Q51, _9MUX2_0.D51),
            (_8RegArray2.Q50, _9MUX2_0.D50),
            (_8RegArray2.Q41, _9MUX2_0.D41),
            (_8RegArray2.Q40, _9MUX2_0.D40),
            (_8RegArray2.Q31, _9MUX2_0.D31),
            (_8RegArray2.Q30, _9MUX2_0.D30),
            (_8RegArray2.Q21, _9MUX2_0.D21),
            (_8RegArray2.Q20, _9MUX2_0.D20),
            (_8RegArray2.Q11, _9MUX2_0.D11),
            (_8RegArray2.Q10, _9MUX2_0.D10),
            (_8RegArray2.Q01, _9MUX2_0.D01),
            (_8RegArray2.Q00, _9MUX2_0.D00),

            (RdAddr01, _9MUX2_1.Sel1),
            (RdAddr00, _9MUX2_1.Sel0),
            (_8RegArray2.Q81, _9MUX2_1.D81),
            (_8RegArray2.Q80, _9MUX2_1.D80),
            (_8RegArray2.Q71, _9MUX2_1.D71),
            (_8RegArray2.Q70, _9MUX2_1.D70),
            (_8RegArray2.Q61, _9MUX2_1.D61),
            (_8RegArray2.Q60, _9MUX2_1.D60),
            (_8RegArray2.Q51, _9MUX2_1.D51),
            (_8RegArray2.Q50, _9MUX2_1.D50),
            (_8RegArray2.Q41, _9MUX2_1.D41),
            (_8RegArray2.Q40, _9MUX2_1.D40),
            (_8RegArray2.Q31, _9MUX2_1.D31),
            (_8RegArray2.Q30, _9MUX2_1.D30),
            (_8RegArray2.Q21, _9MUX2_1.D21),
            (_8RegArray2.Q20, _9MUX2_1.D20),
            (_8RegArray2.Q11, _9MUX2_1.D11),
            (_8RegArray2.Q10, _9MUX2_1.D10),
            (_8RegArray2.Q01, _9MUX2_1.D01),
            (_8RegArray2.Q00, _9MUX2_1.D00),

            (_9MUX2_0.Q1, RdData11),
            (_9MUX2_0.Q0, RdData10),
            (_9MUX2_1.Q1, RdData01),
            (_9MUX2_1.Q0, RdData00)
        ]);
    }

    public override string GetTests() => """
        --------0 ----
        -----0-01 ----
        -----0-00 ----
        -----+-+1 ----
        -----+-+0 ----
        ----0-0-1 ----
        ----0-0-0 ----
        ----00001 ----
        ----00000 ----
        ----0+0+1 ----
        ----0+0+0 ----
        ----+-+-1 ----
        ----+-+-0 ----
        ----+0+01 ----
        ----+0+00 ----
        ----++++1 ----
        ----++++0 ----
        ---0----0 ---0
        ---+----0 ---+
        --0-----0 --0-
        --00----0 --00
        --0+----0 --0+
        --+-----0 --+-
        --+0----0 --+0
        --++----0 --++
        -0------0 -0--
        -+------0 -+--
        0-------0 0---
        00------0 00--
        0+------0 0+--
        +-------0 +---
        +0------0 +0--
        ++------0 ++--
        --------0 ----
    """;
}