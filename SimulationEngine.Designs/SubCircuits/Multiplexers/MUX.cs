using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Multiplexers;

public class MUX : SubCircuit
{
    public Port Addr1 => Inputs[0];
    public Port Addr0 => Inputs[1];
    public Port C2 => Inputs[2];
    public Port C1 => Inputs[3];
    public Port C0 => Inputs[4];
    public Port B2 => Inputs[5];
    public Port B1 => Inputs[6];
    public Port B0 => Inputs[7];
    public Port A2 => Inputs[8];
    public Port A1 => Inputs[9];
    public Port A0 => Inputs[10];
    public Port Q => Outputs[0];

    public MUX()
    {
        this.AddInputs(
            nameof(Addr1), nameof(Addr0), 
            nameof(C2), nameof(C1), nameof(C0), 
            nameof(B2), nameof(B1), nameof(B0), 
            nameof(A2), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q));

        var _3MUX_0 = this.AddSubCircuit(new _3MUX());
        var _3MUX_1 = this.AddSubCircuit(new _3MUX());
        var _3MUX_2 = this.AddSubCircuit(new _3MUX());
        var _3MUX_3 = this.AddSubCircuit(new _3MUX());

        this.AddWires([
            (Addr0, _3MUX_0.Sel),
            (C2, _3MUX_0.C),
            (C1, _3MUX_0.B),
            (C0, _3MUX_0.A),

            (Addr0, _3MUX_1.Sel),
            (B2, _3MUX_1.C),
            (B1, _3MUX_1.B),
            (B0, _3MUX_1.A),

            (Addr0, _3MUX_2.Sel),
            (A2, _3MUX_2.C),
            (A1, _3MUX_2.B),
            (A0, _3MUX_2.A),

            (Addr1, _3MUX_3.Sel),
            (_3MUX_0.Q, _3MUX_3.C),
            (_3MUX_1.Q, _3MUX_3.B),
            (_3MUX_2.Q, _3MUX_3.A),

            (_3MUX_3.Q, Q)
        ]);
    }

    public override string GetTestString() => """
        ----------- -
        --0-------- 0
        --+-------- +
        -0--------- -
        -0-0------- 0
        -0-+------- +
        -+--------- -
        -+--0------ 0
        -+--+------ +
        0---------- -
        0----0----- 0
        0----+----- +
        00--------- -
        00----0---- 0
        00----+---- +
        0+--------- -
        0+-----0--- 0
        0+-----+--- +
        +---------- -
        +-------0-- 0
        +-------+-- +
        +0--------- -
        +0-------0- 0
        +0-------+- +
        ++--------- -
        ++--------0 0
        ++--------+ +
        ----------- -
    """;
}