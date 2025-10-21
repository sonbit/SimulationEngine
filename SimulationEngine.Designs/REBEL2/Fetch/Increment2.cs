using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Fetch;

public class Increment2 : Subcircuit
{
    public Port X1 => Inputs[0];
    public Port X0 => Inputs[1];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public Increment2()
    {
        this.AddInputs(nameof(X1), nameof(X0));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var _7PP = this.AddLogicGate("7PP");
        var _7 = this.AddLogicGate("7");

        this.AddWires([
            (X1, _7PP.B),
            (X0, _7PP.A),

            (X0, _7.A),

            (_7PP.Q, Q1),
            (_7.Q, Q0)
        ]);
    }
}