using SimulationEngine.Designs.SubCircuits.Latches;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class RAM3 : SubCircuit
{
    public Port Clk2 => Inputs[0];
    public Port Clk1 => Inputs[1];
    public Port Clk0 => Inputs[2];
    public Port A => Inputs[3];
    public Port Q2 => Outputs[0];
    public Port Q1 => Outputs[1];
    public Port Q0 => Outputs[2];

    public RAM3()
    {
        this.AddBinaryInputs(nameof(Clk2), nameof(Clk1), nameof(Clk0));
        this.AddInput(nameof(A));
        this.AddOutputs(nameof(Q2), nameof(Q1), nameof(Q0));

        var tff0 = this.AddSubCircuit(new TFlipFlop());
        var tff1 = this.AddSubCircuit(new TFlipFlop());
        var tff2 = this.AddSubCircuit(new TFlipFlop());

        this.AddWires([
            (Clk2, tff0.Clk),
            (A, tff0.A),

            (Clk1, tff1.Clk),
            (A, tff1.A),

            (Clk0, tff2.Clk),
            (A, tff2.A),

            (tff0.Q, Q2),
            (tff1.Q, Q1),
            (tff2.Q, Q0)
        ]);
    }
}