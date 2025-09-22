using SimulationEngine.Designs.SubCircuits.Demultiplexers;
using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class Register9 : SubCircuit
{
    public Port RdAddr1 => Inputs[0];
    public Port RdAddr0 => Inputs[1];
    public Port WrAddr1 => Inputs[2];
    public Port WrAddr0 => Inputs[3];
    public Port Clk => Inputs[4];
    public Port WrData => Inputs[5];
    public Port Q => Outputs[0];

    public Register9()
    {
        this.AddInputs(nameof(RdAddr1), nameof(RdAddr0), nameof(WrAddr1), nameof(WrAddr0));
        this.AddBinaryInput(nameof(Clk));
        this.AddInput(nameof(WrData));
        this.AddOutput(nameof(Q));

        var demux = this.AddSubCircuit(new DEMUX());
        var ram3_0 = this.AddSubCircuit(new RAM3());
        var ram3_1 = this.AddSubCircuit(new RAM3());
        var ram3_2 = this.AddSubCircuit(new RAM3());
        var mux = this.AddSubCircuit(new MUX());

        this.AddWires([
            (WrAddr1, demux.Sel1),
            (WrAddr0, demux.Sel0),
            (Clk, demux.Clk),

            (demux.ClkQ8, ram3_0.Clk2),
            (demux.ClkQ7, ram3_0.Clk1),
            (demux.ClkQ6, ram3_0.Clk0),
            (WrData, ram3_0.A),

            (demux.ClkQ5, ram3_1.Clk2),
            (demux.ClkQ4, ram3_1.Clk1),
            (demux.ClkQ3, ram3_1.Clk0),
            (WrData, ram3_1.A),

            (demux.ClkQ2, ram3_2.Clk2),
            (demux.ClkQ1, ram3_2.Clk1),
            (demux.ClkQ0, ram3_2.Clk0),
            (WrData, ram3_2.A),

            (RdAddr1, mux.Addr1),
            (RdAddr0, mux.Addr0),
            (ram3_0.Q2, mux.C2),
            (ram3_0.Q1, mux.C1),
            (ram3_0.Q0, mux.C0),
            (ram3_1.Q2, mux.B2),
            (ram3_1.Q1, mux.B1),
            (ram3_1.Q0, mux.B0),
            (ram3_2.Q2, mux.A2),
            (ram3_2.Q1, mux.A1),
            (ram3_2.Q0, mux.A0),

            (mux.Q, Q)
        ]);
    }
}