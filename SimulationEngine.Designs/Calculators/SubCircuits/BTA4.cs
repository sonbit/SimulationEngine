using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Calculators.Subcircuits;

public class BTA4 : Subcircuit
{
    public Port X1 => Inputs[0];
    public Port X0 => Inputs[1];
    public Port Y1 => Inputs[2];
    public Port Y0 => Inputs[3];
    public Port S3 => Outputs[0];
    public Port S2 => Outputs[1];
    public Port S1 => Outputs[2];
    public Port S0 => Outputs[3];

    public BTA4()
    {
        this.AddInputs(nameof(X1), nameof(X0), nameof(Y1), nameof(Y0));
        this.AddOutputs(nameof(S3), nameof(S2), nameof(S1), nameof(S0));

        var bta0 = this.AddSubcircuit(new BTA());
        var bta1 = this.AddSubcircuit(new BTA());
        var bta2 = this.AddSubcircuit(new BTA());
        var bta3 = this.AddSubcircuit(new BTA());

        this.AddWires([
            (X1, bta0.X),
            (Y1, bta0.Y),

            (X0, bta1.X),
            (Y0, bta1.Y),

            (bta0.S1, bta2.X),
            (bta1.S0, bta2.Y),

            (bta0.S1, bta3.X),
            (bta2.S0, bta3.Y),

            (bta3.S1, S3),
            (bta3.S0, S2),
            (bta2.S1, S1),
            (bta1.S0, S0)
        ]);
    }
}