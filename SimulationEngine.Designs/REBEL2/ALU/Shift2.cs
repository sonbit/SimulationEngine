using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class Shift2 : SubCircuit
{
    public Port A1 => Inputs[0];
    public Port A0 => Inputs[1];
    public Port Imm1 => Inputs[2];
    public Port Imm0 => Inputs[3];
    public Port Dir => Inputs[4];
    public Port Ins => Inputs[5];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public Shift2()
    {
        this.AddInputs(nameof(A1), nameof(A0), nameof(Imm1), nameof(Imm0), nameof(Dir), nameof(Ins));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var _063TGT360 = this.AddLogicGate("063TGT360");
        var _630GTG036 = this.AddLogicGate("630GTG036");

        var _3MUX1_0 = this.AddSubCircuit(new _3MUX1());
        var _3MUX1_1 = this.AddSubCircuit(new _3MUX1());

        this.AddWires([
            (Dir, _063TGT360.C),
            (Imm1, _063TGT360.B),
            (Imm0, _063TGT360.A),

            (Dir, _630GTG036.C),
            (Imm1, _630GTG036.B),
            (Imm0, _630GTG036.A),

            (_063TGT360.Q, _3MUX1_0.Sel),
            (A1, _3MUX1_0.C),
            (A0, _3MUX1_0.B),
            (Ins, _3MUX1_0.A),


            (_630GTG036.Q, _3MUX1_1.Sel),
            (A1, _3MUX1_1.C),
            (A0, _3MUX1_1.B),
            (Ins, _3MUX1_1.A),

            (_3MUX1_0.Q, Q1),
            (_3MUX1_1.Q, Q0)
        ]);
    }
}