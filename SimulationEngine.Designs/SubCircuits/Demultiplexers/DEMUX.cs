using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Demultiplexers;

public class DEMUX : SubCircuit
{
    public Port Sel1 => Inputs[0];
    public Port Sel0 => Inputs[1];
    public Port Clk => Inputs[2];
    public Port ClkQ8 => Outputs[0];
    public Port ClkQ7 => Outputs[1];
    public Port ClkQ6 => Outputs[2];
    public Port ClkQ5 => Outputs[3];
    public Port ClkQ4 => Outputs[4];
    public Port ClkQ3 => Outputs[5];
    public Port ClkQ2 => Outputs[6];
    public Port ClkQ1 => Outputs[7];
    public Port ClkQ0 => Outputs[8];

    public DEMUX()
    {
        this.AddInputs(nameof(Sel1), nameof(Sel0));
        this.AddBinaryInput(nameof(Clk));
        this.AddBinaryOutputs(
            nameof(ClkQ8), nameof(ClkQ7), nameof(ClkQ6),
            nameof(ClkQ5), nameof(ClkQ4), nameof(ClkQ3),
            nameof(ClkQ2), nameof(ClkQ1), nameof(ClkQ0));

        var _3DEMUX_0 = this.AddSubCircuit(new _3DEMUX());
        var _3DEMUX_1 = this.AddSubCircuit(new _3DEMUX());
        var _3DEMUX_2 = this.AddSubCircuit(new _3DEMUX());
        var _3DEMUX_3 = this.AddSubCircuit(new _3DEMUX());

        this.AddWires([
            (Sel1, _3DEMUX_0.Din),
            (Clk, _3DEMUX_0.Clk),

            (Sel0, _3DEMUX_1.Din),
            (_3DEMUX_0.Q2, _3DEMUX_1.Clk),

            (Sel0, _3DEMUX_2.Din),
            (_3DEMUX_0.Q1, _3DEMUX_2.Clk),

            (Sel0, _3DEMUX_3.Din),
            (_3DEMUX_0.Q0, _3DEMUX_3.Clk),

            (_3DEMUX_1.Q2, ClkQ8),
            (_3DEMUX_1.Q1, ClkQ7),
            (_3DEMUX_1.Q0, ClkQ6),
            (_3DEMUX_2.Q2, ClkQ5),
            (_3DEMUX_2.Q1, ClkQ4),
            (_3DEMUX_2.Q0, ClkQ3),
            (_3DEMUX_3.Q2, ClkQ2),
            (_3DEMUX_3.Q1, ClkQ1),
            (_3DEMUX_3.Q0, ClkQ0)
        ]);
    }
}