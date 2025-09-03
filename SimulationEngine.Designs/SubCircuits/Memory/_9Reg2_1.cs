using SimulationEngine.Designs.SubCircuits.Demultiplexers;
using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class _9Reg2_1 : SubCircuit
{
    public Port RdAddr1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port RdAddr0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port WrAddr1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port WrAddr0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port WrData1 => Ports.Single(p => p.Role == PortRole.In4);
    public Port WrData0 => Ports.Single(p => p.Role == PortRole.In5);
    public Port Clk => Ports.Single(p => p.Role == PortRole.In6);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public _9Reg2_1()
    {
        this.AddPorts([
            (nameof(RdAddr1), PortRole.In0),
            (nameof(RdAddr0), PortRole.In1),
            (nameof(WrAddr1), PortRole.In2),
            (nameof(WrAddr0), PortRole.In3),
            (nameof(WrData1), PortRole.In4),
            (nameof(WrData0), PortRole.In5),
            (nameof(Clk), PortRole.In6),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var _9DEMUX = new _9DEMUX { Parent = this };
        var _8RegArray2 = new _8RegArray2 { Parent = this };
        var _9MUX2 = new _9MUX2() { Parent = this };
        SubCircuits = [_9DEMUX, _8RegArray2, _9MUX2];

        this.AddWires([
            (WrAddr1, _9DEMUX.Sel1),
            (WrAddr0, _9DEMUX.Sel0),
            (Clk, _9DEMUX.Clk),

            (_9DEMUX.ClkQ8, _8RegArray2.Clk8),
            (_9DEMUX.ClkQ7, _8RegArray2.Clk7),
            (_9DEMUX.ClkQ6, _8RegArray2.Clk6),
            (_9DEMUX.ClkQ5, _8RegArray2.Clk5),
            (_9DEMUX.ClkQ4, _8RegArray2.Clk4),
            (_9DEMUX.ClkQ3, _8RegArray2.Clk3),
            (_9DEMUX.ClkQ2, _8RegArray2.Clk2),
            (_9DEMUX.ClkQ1, _8RegArray2.Clk1),
            (_9DEMUX.ClkQ0, _8RegArray2.Clk0),
            (WrData1, _8RegArray2.Din1),
            (WrData0, _8RegArray2.Din0),

            (RdAddr1, _9MUX2.Sel1),
            (RdAddr0, _9MUX2.Sel0),
            (_8RegArray2.Q81, _9MUX2.D81),
            (_8RegArray2.Q80, _9MUX2.D80),
            (_8RegArray2.Q71, _9MUX2.D71),
            (_8RegArray2.Q70, _9MUX2.D70),
            (_8RegArray2.Q61, _9MUX2.D61),
            (_8RegArray2.Q60, _9MUX2.D60),
            (_8RegArray2.Q51, _9MUX2.D51),
            (_8RegArray2.Q50, _9MUX2.D50),
            (_8RegArray2.Q41, _9MUX2.D41),
            (_8RegArray2.Q40, _9MUX2.D40),
            (_8RegArray2.Q31, _9MUX2.D31),
            (_8RegArray2.Q30, _9MUX2.D30),
            (_8RegArray2.Q21, _9MUX2.D21),
            (_8RegArray2.Q20, _9MUX2.D20),
            (_8RegArray2.Q11, _9MUX2.D11),
            (_8RegArray2.Q10, _9MUX2.D10),
            (_8RegArray2.Q01, _9MUX2.D01),
            (_8RegArray2.Q00, _9MUX2.D00),

            (_9MUX2.Q1, Q1),
            (_9MUX2.Q0, Q0)]);
    }
}
