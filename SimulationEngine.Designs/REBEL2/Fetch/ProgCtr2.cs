using SimulationEngine.Designs.Subcircuits.Latches;
using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Fetch;

public class ProgCtr2 : Subcircuit
{
    public Port Clk => Inputs[0];
    public Port LdEn => Inputs[1];
    public Port LdAddr1 => Inputs[2];
    public Port LdAddr0 => Inputs[3];
    public Port Pc1 => Outputs[0];
    public Port Pc0 => Outputs[1];

    public ProgCtr2()
    {
        this.AddBinaryInput(nameof(Clk));
        this.AddInputs(nameof(LdEn), nameof(LdAddr1), nameof(LdAddr0));
        this.AddOutputs(nameof(Pc1), nameof(Pc0));

        var _2MUX2 = this.AddSubcircuit(new _2MUX2());
        var dle0 = this.AddSubcircuit(new DLatchEdge());
        var dle1 = this.AddSubcircuit(new DLatchEdge());
        var inc2 = this.AddSubcircuit(new Increment2());

        this.AddWires([
            (LdEn, _2MUX2.Sel),
            (LdAddr1, _2MUX2.B1),
            (LdAddr0, _2MUX2.B0),
            (inc2.Q1, _2MUX2.A1),
            (inc2.Q0, _2MUX2.A0),

            (Clk, dle0.Clk),
            (_2MUX2.Q1, dle0.Din),

            (Clk, dle1.Clk),
            (_2MUX2.Q0, dle1.Din),

            (dle0.Dout, inc2.X1),
            (dle1.Dout, inc2.X0),

            (dle0.Dout, Pc1),
            (dle1.Dout, Pc0)
        ]);
    }

    public override string GetTestString() => """
        0--- --
        1--- -0
        0--- -0
        1--- -+
        0--- -+
        1--- 0-
        0--- 0-
        1--- 00
        0--- 00
        1--- 0+
        0--- 0+
        1--- +-
        0--- +-
        1--- +0
        0--- +0
        1--- ++
        0--- ++
        1--- --
        0--- --
        1--- -0
        0--- -0
        1--- -+
        0--- -+
        1--- 0-
        0--- 0-
        1--- 00
        0--- 00
        1--- 0+
        0--- 0+
        1--- +-
        0--- +-
        1--- +0
        0--- +0
        1--- ++
        0--- ++
        1--- --
        0+00 --
        1+00 00
    """;
}