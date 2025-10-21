using SimulationEngine.Designs.Subcircuits.Demultiplexers;
using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.Subcircuits.Memory;

public class Register9 : Subcircuit
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

        var demux = this.AddSubcircuit(new DEMUX());
        var ram3_0 = this.AddSubcircuit(new RAM3());
        var ram3_1 = this.AddSubcircuit(new RAM3());
        var ram3_2 = this.AddSubcircuit(new RAM3());
        var mux = this.AddSubcircuit(new MUX());

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

    public override string GetTestString() => """
        ----0- -
        ----1- -
        ----00 -
        ---010 -
        -0-00+ 0
        -0-+1+ 0
        -+-+0- +
        -+0-1- +
        0-0-00 -
        0-0010 -
        00000+ 0
        000+1+ 0
        0+0+0- +
        0++-1- +
        +-+-00 -
        +-+010 -
        +0+00+ 0
        +0++1+ 0
        ++++00 +
        ++--10 +
        ++--00 +
        ++-+10 +
        ++-+00 +
        ++0-10 +
        ++0-00 +
        ++0+10 +
        ++0+00 +
        +++-10 +
        +++-00 +
        ++++10 0
        --000+ 0
        -0--1+ 0
        -0--0- 0
        -+-01- 0
        -+-00+ 0
        000-1+ 0
        000-0- 0
        0+001- 0
        0+000+ 0
        +0+-1+ 0
        +0+-0- 0
        +++01- 0
        --0000 +
        -00010 -
        -+0000 0
        0-0010 +
        000000 0
        0+0010 0
        +-0000 +
        +00010 -
        ++0000 0
        ++--10 0
        ++--0+ 0
        ++-01+ 0
        ++--0- 0
        ++-+1- 0
        ++--00 0
        +++-10 0
        ++-+10 0
        ++-+00 0
        ++0010 0
        ++0000 0
        ++0+10 0
        +++-00 0
        +++010 0
        +++000 0
        ++++10 0
        --0000 0
        -00010 +
        -+0000 0
        0-0010 +
        000000 0
        0+0010 0
        +-0000 0
        +00010 0
        ++0000 0
        ++-010 0
        ++-000 0
        ++-+10 0
        ++-+00 0
        ++0010 0
        ++0000 0
        ++0+10 0
        +++-00 0
        +++010 0
        +++000 0
        ++++10 0
        --0000 0
        -+0010 0
        -00000 0
        0-0010 +
        000000 0
        0+0010 0
        +-0000 0
        +00010 0
        ++0000 0
        000010 0
        000000 0
        000000 0
        ----0- 0
    """;
}