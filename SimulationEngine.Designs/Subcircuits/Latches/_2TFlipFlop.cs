using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Latches;

public class _2TFlipFlop : Subcircuit
{
    public Port Clk => Inputs[0];
    public Port A1 => Inputs[1];
    public Port A0 => Inputs[2];
    public Port Q1 => Outputs[0];
    public Port Q0 => Outputs[1];

    public _2TFlipFlop()
    {
        this.AddBinaryInput(nameof(Clk));
        this.AddInputs(nameof(A1), nameof(A0));
        this.AddOutputs(nameof(Q1), nameof(Q0));

        var ff_0 = this.AddSubcircuit(new TFlipFlop());
        var ff_1 = this.AddSubcircuit(new TFlipFlop());

        this.AddWires([
            (Clk, ff_0.Clk),
            (A1, ff_0.A),

            (Clk, ff_1.Clk),
            (A0, ff_1.A),

            (ff_0.Q, Q1),
            (ff_1.Q, Q0)
        ]);
    }
}