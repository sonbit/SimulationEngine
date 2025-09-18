using SimulationEngine.Designs.SubCircuits.Demultiplexers;
using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class Register9 : SubCircuit
{
    public Port RdAddr1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port RdAddr0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port WrAddr1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port WrAddr0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Clk => Ports.Single(p => p.Role == PortRole.In4);
    public Port WrData => Ports.Single(p => p.Role == PortRole.In5);
    public Port Q => Ports.Single(p => p.Role == PortRole.Out0);

    public Register9()
    {
        this.AddPorts([
            (nameof(RdAddr1), PortRole.In0),
            (nameof(RdAddr0), PortRole.In1),
            (nameof(WrAddr1), PortRole.In2),
            (nameof(WrAddr0), PortRole.In3),
            (nameof(Clk), PortRole.In4),
            (nameof(WrData), PortRole.In5),
            (nameof(Q), PortRole.Out0)]);

        var demux = new DEMUX();
        var ram3_0 = new RAM3();
        var ram3_1 = new RAM3();
        var ram3_2 = new RAM3();
        var mux = new MUX();
        SubCircuits = [demux, ram3_0, ram3_1, ram3_2, mux];

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

            (mux.Q, Q)]);
    }
}
