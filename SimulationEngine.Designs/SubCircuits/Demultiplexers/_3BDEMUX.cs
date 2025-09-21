using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Demultiplexers;

public class _3BDEMUX : SubCircuit
{
    public Port Din => Inputs[0];
    public Port Clk => Inputs[1];
    public Port Q2 => Outputs[0];
    public Port Q1 => Outputs[1];
    public Port Q0 => Outputs[2];

    public _3BDEMUX()
    {
        this.AddInput(nameof(Din));
        this.AddBinaryInput(nameof(Clk));
        this.AddBinaryOutputs(nameof(Q2), nameof(Q1), nameof(Q0));

        var K00 = this.AddLogicGate("K00");     
        var _600 = this.AddLogicGate("600");
        var _200 = this.AddLogicGate("200");

        this.AddWires([
            (Din, K00.B),
            (Din, _600.B),
            (Din, _200.B),

            (Clk, K00.A),
            (Clk, _600.A),
            (Clk, _200.A),

            (K00.Q, Q2),
            (_600.Q, Q1),
            (_200.Q, Q0)
        ]);
    }
}