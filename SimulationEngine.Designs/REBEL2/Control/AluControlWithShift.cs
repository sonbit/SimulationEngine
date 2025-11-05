using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Control;

public class AluControlWithShift : Subcircuit
{
    public Port Op1 => Inputs[0];
    public Port Op0 => Inputs[1];
    public Port Rd1 => Inputs[2];
    public Port Rd0 => Inputs[3];

    public Port Func2 => Outputs[0];
    public Port Func1 => Outputs[1];
    public Port Func0 => Outputs[2];
    
    public AluControlWithShift()
    {
        this.AddInputs(
            nameof(Op1),
            nameof(Op0),
            nameof(Rd1),
            nameof(Rd0));

        this.AddOutputs(
            nameof(Func2),
            nameof(Func1),
            nameof(Func0));

        var gdd = this.AddLogicGate("GDD");

        var aluControlFlow = this.AddSubcircuit(new AluControlFlow());
        var _2MUX2 = this.AddSubcircuit(new _2MUX2());

        this.AddWires([
            (Op1, gdd.B),
            (Op0, gdd.A),

            (Op1, aluControlFlow.Op1),
            (Op0, aluControlFlow.Op0),
            (Rd1, aluControlFlow.Rd1),
            (Rd0, aluControlFlow.Rd0),

            (gdd.Q, _2MUX2.Sel),
            (Rd1, _2MUX2.B1),
            (Rd0, _2MUX2.B0),
            (aluControlFlow.Func1, _2MUX2.A1),
            (aluControlFlow.Func0, _2MUX2.A0),

            (aluControlFlow.Func2, Func2),
            (_2MUX2.Q1, Func1),
            (_2MUX2.Q0, Func0)
        ]);
    }
}