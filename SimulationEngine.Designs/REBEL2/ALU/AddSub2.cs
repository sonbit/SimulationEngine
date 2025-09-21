using SimulationEngine.Designs.SubCircuits.Adders;
using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class AddSub2 : SubCircuit
{
    public Port Sel => Inputs[0];
    public Port B1 => Inputs[1];
    public Port B0 => Inputs[2];
    public Port A1 => Inputs[3];
    public Port A0 => Inputs[4];
    public Port Q2 => Outputs[0];
    public Port Q1 => Outputs[1];
    public Port Q0 => Outputs[2];

    public AddSub2()
    {
        this.AddInputs(nameof(Sel), nameof(B1), nameof(B0), nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q2), nameof(Q1), nameof(Q0));

        var inv0 = this.AddLogicGate("5");
        var inv1 = this.AddLogicGate("5");

        var _2MUX2 = this.AddSubCircuit(new _2MUX2());
        var _2TritAdder = this.AddSubCircuit(new _2TritAdder());

        this.AddWires([
            (B1, inv0.A),
            (B0, inv1.A),

            (Sel, _2MUX2.Sel),
            (inv0.Q, _2MUX2.B1),
            (inv1.Q, _2MUX2.B0),
            (B1, _2MUX2.A1),
            (B0, _2MUX2.A0),

            (_2MUX2.Q1, _2TritAdder.B1),
            (_2MUX2.Q0, _2TritAdder.B0),
            (A1, _2TritAdder.A1),
            (A0, _2TritAdder.A0),

            (_2TritAdder.Cout, Q2),
            (_2TritAdder.Q1, Q1),
            (_2TritAdder.Q0, Q0)
        ]);
    }
}