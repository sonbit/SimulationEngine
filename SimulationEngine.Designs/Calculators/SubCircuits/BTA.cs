using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Calculators.SubCircuits;

public class BTA : SubCircuit
{
    public Port X => Inputs[0];
    public Port Y => Inputs[1];
    public Port S1 => Outputs[0];
    public Port S0 => Outputs[1];

    public BTA()
    {
        this.AddInputs(nameof(X), nameof(Y));
        this.AddOutputs(nameof(S1), nameof(S0));

        var rdc = this.AddLogicGate("RDC");
        var _7PB = this.AddLogicGate("7PB");

        this.AddWires([
            (X, rdc.B),
            (Y, rdc.A),

            (X, _7PB.B),
            (Y, _7PB.A),

            (rdc.Q, S1),
            (_7PB.Q, S0)
        ]);
    }
}