using SimulationEngine.Designs.Subcircuits.Demultiplexers;
using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Memory;

public class _9Rom2 : Subcircuit
{
    public Port RdAddr1 => Inputs[0];
    public Port RdAddr0 => Inputs[1];
    public Port WrAddr1 => Inputs[2];
    public Port WrAddr0 => Inputs[3];
    public Port WrData1 => Inputs[4];
    public Port WrData0 => Inputs[5];
    public Port Clk => Inputs[6];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public _9Rom2()
    {
        this.AddInputs(nameof(RdAddr1), nameof(RdAddr0), nameof(WrAddr1), nameof(WrAddr0), nameof(WrData1), nameof(WrData0));
        this.AddBinaryInput(nameof(Clk));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var _9BDEMUX = this.AddSubcircuit(new _9BDEMUX());
        var _8REG2 = this.AddSubcircuit(new _8Reg2());
        var _9MUX2 = this.AddSubcircuit(new _9MUX2());

        this.AddWires([
            (WrAddr1, _9BDEMUX.Sel1),
            (WrAddr0, _9BDEMUX.Sel0),
            (Clk, _9BDEMUX.Clk),

            (_9BDEMUX.ClkQ8, _8REG2.Clk8),
            (_9BDEMUX.ClkQ7, _8REG2.Clk7),
            (_9BDEMUX.ClkQ6, _8REG2.Clk6),
            (_9BDEMUX.ClkQ5, _8REG2.Clk5),
            (_9BDEMUX.ClkQ4, _8REG2.Clk4),
            (_9BDEMUX.ClkQ3, _8REG2.Clk3),
            (_9BDEMUX.ClkQ2, _8REG2.Clk2),
            (_9BDEMUX.ClkQ1, _8REG2.Clk1),
            (_9BDEMUX.ClkQ0, _8REG2.Clk0),
            (WrData1, _8REG2.Din1),
            (WrData0, _8REG2.Din0),

            (RdAddr1, _9MUX2.Sel1),
            (RdAddr0, _9MUX2.Sel0),
            (_8REG2.Q81, _9MUX2.D81),
            (_8REG2.Q80, _9MUX2.D80),
            (_8REG2.Q71, _9MUX2.D71),
            (_8REG2.Q70, _9MUX2.D70),
            (_8REG2.Q61, _9MUX2.D61),
            (_8REG2.Q60, _9MUX2.D60),
            (_8REG2.Q51, _9MUX2.D51),
            (_8REG2.Q50, _9MUX2.D50),
            (_8REG2.Q41, _9MUX2.D41),
            (_8REG2.Q40, _9MUX2.D40),
            (_8REG2.Q31, _9MUX2.D31),
            (_8REG2.Q30, _9MUX2.D30),
            (_8REG2.Q21, _9MUX2.D21),
            (_8REG2.Q20, _9MUX2.D20),
            (_8REG2.Q11, _9MUX2.D11),
            (_8REG2.Q10, _9MUX2.D10),
            (_8REG2.Q01, _9MUX2.D01),
            (_8REG2.Q00, _9MUX2.D00),

            (_9MUX2.Q1, Q1),
            (_9MUX2.Q0, Q0)
        ]);
    }
}