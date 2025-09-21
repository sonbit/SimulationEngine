using SimulationEngine.Designs.Calculators.SubCircuits;
using SimulationEngine.Designs.SubCircuits.Deselectors;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Calculators;

public class TT3_BTCalculator : SubCircuit
{
    public Port X1 => Inputs[0];
    public Port X0 => Inputs[1];
    public Port Y1 => Inputs[2];
    public Port Y0 => Inputs[3];
    public Port S3 => Outputs[0];
    public Port S2 => Outputs[1];
    public Port S1 => Outputs[2];
    public Port S0 => Outputs[3];

    public TT3_BTCalculator()
    {
        this.AddInputs(nameof(X1), nameof(X0), nameof(Y1), nameof(Y0));
        this.AddOutputs(nameof(S3), nameof(S2), nameof(S1), nameof(S0));

        var btm4 = this.AddSubCircuit(new BTM4());
        var bta4 = this.AddSubCircuit(new BTA4());
        var deselect4 = this.AddSubCircuit(new Deselect4());

        this.AddWires([
            (X1, btm4.X1),
            (X0, btm4.X0),
            (Y1, btm4.Y1),
            (Y0, btm4.Y0),

            (X1, bta4.X1),
            (X0, bta4.X0),
            (Y1, bta4.Y1),
            (Y0, bta4.Y0),

            (X1, deselect4.Sel),
            (btm4.S3, deselect4.A3),
            (btm4.S2, deselect4.A2),
            (btm4.S1, deselect4.A1),
            (btm4.S0, deselect4.A0),
            (bta4.S3, deselect4.B3),
            (bta4.S2, deselect4.B2),
            (bta4.S1, deselect4.B1),
            (bta4.S0, deselect4.B0),

            (deselect4.S3, S3),
            (deselect4.S2, S2),
            (deselect4.S1, S1),
            (deselect4.S0, S0)
        ]);
    }
}