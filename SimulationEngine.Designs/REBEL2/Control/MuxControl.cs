using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Control;

public class MuxControl : Subcircuit
{
    public Port Op1 => Inputs[0];
    public Port Op0 => Inputs[1];
    public Port Rd1 => Inputs[2];
    public Port Rd0 => Inputs[3];
    public Port Cmp => Inputs[4];

    public Port AluAMux => Outputs[0];
    public Port AluBMux => Outputs[1];
    public Port ProgCtr => Outputs[2];
    public Port AddAMux => Outputs[3];

    public MuxControl()
    {
        this.AddInputs(
            nameof(Op1),
            nameof(Op0),
            nameof(Rd1),
            nameof(Rd0),
            nameof(Cmp));

        this.AddOutputs(
            nameof(AluAMux),
            nameof(AluBMux),
            nameof(ProgCtr),
            nameof(AddAMux));

        var rdd = this.AddLogicGate("RDD");
        var _9VZ9VZ0VZ = this.AddLogicGate("9VZ9VZ0VZ");
        var _4rd = this.AddLogicGate("4RD");
        var d = this.AddLogicGate("D");
        var x = this.AddLogicGate("X");
        var h = this.AddLogicGate("H");

        var _3MUX1 = this.AddSubcircuit(new _3MUX1());

        this.AddWires([
            (Op1, rdd.B),
            (Op0, rdd.A),

            (Rd1, _9VZ9VZ0VZ.C), // Rd0 feilkobling?
            (Op1, _9VZ9VZ0VZ.B),
            (Op0, _9VZ9VZ0VZ.A),

            (Op1, _4rd.B),
            (Op0, _4rd.A),

            (Rd0, d.A),
            (Rd0, x.A),
            (Rd0, h.A),

            (rdd.Q, AluAMux),
            (_9VZ9VZ0VZ.Q, AluBMux),
            (_3MUX1.Q, ProgCtr),
            (h.Q, AddAMux)
        ]);
    }
}
