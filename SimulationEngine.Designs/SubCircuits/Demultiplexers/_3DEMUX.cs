using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Demultiplexers;

public class _3DEMUX : SubCircuit
{
    public Port Din => Inputs[0];
    public Port Clk => Inputs[1];
    public Port Q2 => Outputs[0];
    public Port Q1 => Outputs[1];
    public Port Q0 => Outputs[2];

    public _3DEMUX()
    {
        this.AddInput(nameof(Din));
        this.AddBinaryInput(nameof(Clk));
        this.AddBinaryOutputs(nameof(Q2), nameof(Q1), nameof(Q0));

        var _200 = this.AddLogicGate("200");
        var _600 = this.AddLogicGate("600");
        var K00 = this.AddLogicGate("K00");

        this.AddWires([
            (Din, _200.B),
            (Din, _600.B),
            (Din, K00.B),

            (Clk, _200.A),
            (Clk, _600.A),
            (Clk, K00.A),

            (_200.Q, Q2),
            (_600.Q, Q1),
            (K00.Q, Q0)
        ]);
    }

    public override string GetTests() => """
        -0 000
        -1 100
        00 000
        01 010
        00 000
        +1 001
        +0 000
        -1 100
        01 010
        +1 001
        00 000
        +0 000
        -0 000
    """;
}