using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class _9MUX2 : SubCircuit
{
    public Port Sel1 => Inputs[0];
    public Port Sel0 => Inputs[1];
    public Port D81 => Inputs[2];
    public Port D80 => Inputs[3];
    public Port D71 => Inputs[4];
    public Port D70 => Inputs[5];
    public Port D61 => Inputs[6];
    public Port D60 => Inputs[7];
    public Port D51 => Inputs[8];
    public Port D50 => Inputs[9];
    public Port D41 => Inputs[10];
    public Port D40 => Inputs[11];
    public Port D31 => Inputs[12];
    public Port D30 => Inputs[13];
    public Port D21 => Inputs[14];
    public Port D20 => Inputs[15];
    public Port D11 => Inputs[16];
    public Port D10 => Inputs[17];
    public Port D01 => Inputs[18];
    public Port D00 => Inputs[19];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public _9MUX2()
    {
        this.AddInputs(
            nameof(Sel1), nameof(Sel0), 
            nameof(D81), nameof(D80), nameof(D71), nameof(D70), nameof(D61), nameof(D60), 
            nameof(D51), nameof(D50), nameof(D41), nameof(D40), nameof(D31), nameof(D30), 
            nameof(D21), nameof(D20), nameof(D11), nameof(D10), nameof(D01), nameof(D00));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var _3MUX2_0 = this.AddSubCircuit(new _3MUX2());
        var _3MUX2_1 = this.AddSubCircuit(new _3MUX2());
        var _3MUX2_2 = this.AddSubCircuit(new _3MUX2());
        var _3MUX2_3 = this.AddSubCircuit(new _3MUX2());

        this.AddWires([
            (Sel0, _3MUX2_0.Sel),
            (D81, _3MUX2_0.C1),
            (D80, _3MUX2_0.C0),
            (D71, _3MUX2_0.B1),
            (D70, _3MUX2_0.B0),
            (D61, _3MUX2_0.A1),
            (D60, _3MUX2_0.A0),

            (Sel0, _3MUX2_1.Sel),
            (D51, _3MUX2_1.C1),
            (D50, _3MUX2_1.C0),
            (D41, _3MUX2_1.B1),
            (D40, _3MUX2_1.B0),
            (D31, _3MUX2_1.A1),
            (D30, _3MUX2_1.A0),

            (Sel0, _3MUX2_2.Sel),
            (D21, _3MUX2_2.C1),
            (D20, _3MUX2_2.C0),
            (D11, _3MUX2_2.B1),
            (D10, _3MUX2_2.B0),
            (D01, _3MUX2_2.A1),
            (D00, _3MUX2_2.A0),

            (Sel1, _3MUX2_3.Sel),
            (_3MUX2_0.Q1, _3MUX2_3.C1),
            (_3MUX2_0.Q0, _3MUX2_3.C0),
            (_3MUX2_1.Q1, _3MUX2_3.B1),
            (_3MUX2_1.Q0, _3MUX2_3.B0),
            (_3MUX2_2.Q1, _3MUX2_3.A1),
            (_3MUX2_2.Q0, _3MUX2_3.A0),

            (_3MUX2_3.Q1, Q1),
            (_3MUX2_3.Q0, Q0)
        ]);
    }

    public override string GetTestString() => """
        -------------------- --
        -------------------0 -0
        -------------------+ -+
        ------------------0- 0-
        ------------------00 00
        ------------------0+ 0+
        ------------------+- +-
        ------------------+0 +0
        ------------------++ ++
        -0------------------ --
        -0---------------0-- -0
        -0---------------+-- -+
        -0--------------0--- 0-
        -0--------------00-- 00
        -0--------------0+-- 0+
        -0--------------+--- +-
        -0--------------+0-- +0
        -0--------------++-- ++
        -+------------------ --
        -+-------------0---- -0
        -+-------------+---- -+
        -+------------0----- 0-
        -+------------00---- 00
        -+------------0+---- 0+
        -+------------+----- +-
        -+------------+0---- +0
        -+------------++---- ++
        0------------------- --
    """;
}