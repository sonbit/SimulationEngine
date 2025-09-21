using SimulationEngine.Designs.SubCircuits.Latches;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class _8RegArray2 : SubCircuit
{
    public Port Clk8 => Inputs[0];
    public Port Clk7 => Inputs[1];
    public Port Clk6 => Inputs[2];
    public Port Clk5 => Inputs[3];
    public Port Clk4 => Inputs[4];
    public Port Clk3 => Inputs[5];
    public Port Clk2 => Inputs[6];
    public Port Clk1 => Inputs[7];
    public Port Clk0 => Inputs[8];
    public Port Din1 => Inputs[9];
    public Port Din0 => Inputs[10];
    public Port Q81 => Outputs[0];
    public Port Q80 => Outputs[1];
    public Port Q71 => Outputs[2];
    public Port Q70 => Outputs[3];
    public Port Q61 => Outputs[4];
    public Port Q60 => Outputs[5];
    public Port Q51 => Outputs[6];
    public Port Q50 => Outputs[7];
    public Port Q41 => Outputs[8];
    public Port Q40 => Outputs[9];
    public Port Q31 => Outputs[10];
    public Port Q30 => Outputs[11];
    public Port Q21 => Outputs[12];
    public Port Q20 => Outputs[13];
    public Port Q11 => Outputs[14];
    public Port Q10 => Outputs[15];
    public Port Q01 => Outputs[16];
    public Port Q00 => Outputs[17];

    public _8RegArray2()
    {
        this.AddBinaryInputs(
            nameof(Clk8), nameof(Clk7), nameof(Clk6),
            nameof(Clk5), nameof(Clk4), nameof(Clk3),
            nameof(Clk2), nameof(Clk1), nameof(Clk0));
        this.AddInputs(nameof(Din1), nameof(Din0));
        this.AddOutputs(
            nameof(Q81), nameof(Q80), nameof(Q71), nameof(Q70), nameof(Q61), nameof(Q60), 
            nameof(Q51), nameof(Q50), nameof(Q41), nameof(Q40), nameof(Q31), nameof(Q30), 
            nameof(Q21), nameof(Q20), nameof(Q11), nameof(Q10), nameof(Q01), nameof(Q00));

        var _2Latch2_0 = this.AddSubCircuit(new _2Latch2());
        var _2Latch2_1 = this.AddSubCircuit(new _2Latch2());
        var _2Latch2_2 = this.AddSubCircuit(new _2Latch2());
        var _2Latch2_3 = this.AddSubCircuit(new _2Latch2());
        var _2Latch2_4 = this.AddSubCircuit(new _2Latch2());
        var _2Latch2_5 = this.AddSubCircuit(new _2Latch2());
        var _2Latch2_6 = this.AddSubCircuit(new _2Latch2());
        var _2Latch2_7 = this.AddSubCircuit(new _2Latch2());
        var _2Latch2_8 = this.AddSubCircuit(new _2Latch2());

        this.AddWires([
            (Clk8, _2Latch2_0.Clk),
            (Din1, _2Latch2_0.A1),
            (Din0, _2Latch2_0.A0),

            (Clk7, _2Latch2_1.Clk),
            (Din1, _2Latch2_1.A1),
            (Din0, _2Latch2_1.A0),

            (Clk6, _2Latch2_2.Clk),
            (Din1, _2Latch2_2.A1),
            (Din0, _2Latch2_2.A0),

            (Clk5, _2Latch2_3.Clk),
            (Din1, _2Latch2_3.A1),
            (Din0, _2Latch2_3.A0),

            (Clk4, _2Latch2_4.Clk),
            (Din1, _2Latch2_4.A1),
            (Din0, _2Latch2_4.A0),

            (Clk3, _2Latch2_5.Clk),
            (Din1, _2Latch2_5.A1),
            (Din0, _2Latch2_5.A0),

            (Clk2, _2Latch2_6.Clk),
            (Din1, _2Latch2_6.A1),
            (Din0, _2Latch2_6.A0),

            (Clk1, _2Latch2_7.Clk),
            (Din1, _2Latch2_7.A1),
            (Din0, _2Latch2_7.A0),

            (Clk0, _2Latch2_8.Clk),
            (Din1, _2Latch2_8.A1),
            (Din0, _2Latch2_8.A0),

            (_2Latch2_0.Q1, Q81),
            (_2Latch2_0.Q0, Q80),
            (_2Latch2_1.Q1, Q71),
            (_2Latch2_1.Q0, Q70),
            (_2Latch2_2.Q1, Q61),
            (_2Latch2_2.Q0, Q60),
            (_2Latch2_3.Q1, Q51),
            (_2Latch2_3.Q0, Q50),
            (_2Latch2_4.Q1, Q41),
            (_2Latch2_4.Q0, Q40),
            (_2Latch2_5.Q1, Q31),
            (_2Latch2_5.Q0, Q30),
            (_2Latch2_6.Q1, Q21),
            (_2Latch2_6.Q0, Q20),
            (_2Latch2_7.Q1, Q11),
            (_2Latch2_7.Q0, Q10),
            (_2Latch2_8.Q1, Q01),
            (_2Latch2_8.Q0, Q00)
        ]);
    }
}