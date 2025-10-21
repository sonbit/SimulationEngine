using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Calculators.Subcircuits;

public class BTM4 : Subcircuit
{
    public Port X1 => Inputs[0];
    public Port X0 => Inputs[1];
    public Port Y1 => Inputs[2];
    public Port Y0 => Inputs[3];
    public Port S3 => Outputs[0];
    public Port S2 => Outputs[1];
    public Port S1 => Outputs[2];
    public Port S0 => Outputs[3];

    public BTM4()
    {
        this.AddInputs(nameof(X1), nameof(X0), nameof(Y1), nameof(Y0));
        this.AddOutputs(nameof(S3), nameof(S2), nameof(S1), nameof(S0));

        var btm0 = this.AddLogicGate("PD5");
        var btm1 = this.AddLogicGate("PD5");
        var btm2 = this.AddLogicGate("PD5");
        var btm3 = this.AddLogicGate("PD5");

        var sum = this.AddLogicGate("7PB");

        var CZGDDDA0R = this.AddLogicGate("CZGDDDA0R");
        var DD4DDDEDD = this.AddLogicGate("DD4DDDEDD");

        this.AddWires([
            (X1, btm0.B),
            (Y1, btm0.A),

            (X1, btm1.B),
            (Y0, btm1.A),

            (X0, btm2.B),
            (Y1, btm2.A),

            (X0, btm3.B),
            (Y0, btm3.A),

            (btm1.Q, sum.B),
            (btm2.Q, sum.A),

            (btm0.Q, CZGDDDA0R.C),
            (sum.Q, CZGDDDA0R.B),
            (btm3.Q, CZGDDDA0R.A),

            (CZGDDDA0R.Q, DD4DDDEDD.C),
            (sum.Q, DD4DDDEDD.B),
            (btm3.Q, DD4DDDEDD.A),

            (DD4DDDEDD.Q, S3),
            (CZGDDDA0R.Q, S2),
            (sum.Q, S1),
            (btm3.Q, S0)
        ]);
    }
}