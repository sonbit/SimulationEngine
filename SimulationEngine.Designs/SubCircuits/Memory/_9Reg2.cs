using SimulationEngine.Designs.SubCircuits.Demultiplexers;
using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class _9Reg2 : SubCircuit
{
    public Port RdAddr11 => Ports.Single(p => p.Role == PortRole.In0);
    public Port RdAddr10 => Ports.Single(p => p.Role == PortRole.In1);
    public Port RdAddr01 => Ports.Single(p => p.Role == PortRole.In2);
    public Port RdAddr00 => Ports.Single(p => p.Role == PortRole.In3);
    public Port WrAddr1 => Ports.Single(p => p.Role == PortRole.In4);
    public Port WrAddr0 => Ports.Single(p => p.Role == PortRole.In5);
    public Port WrData1 => Ports.Single(p => p.Role == PortRole.In6);
    public Port WrData0 => Ports.Single(p => p.Role == PortRole.In7);
    public Port WrReg => Ports.Single(p => p.Role == PortRole.In8);
    public Port RdData11 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port RdData10 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port RdData01 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port RdData00 => Ports.Single(p => p.Role == PortRole.Out3);


    public _9Reg2()
    {
        this.AddPorts([
            (nameof(RdAddr11), PortRole.In0),
            (nameof(RdAddr10), PortRole.In1),
            (nameof(RdAddr01), PortRole.In2),
            (nameof(RdAddr00), PortRole.In3),
            (nameof(WrAddr1), PortRole.In4),
            (nameof(WrAddr0), PortRole.In5),
            (nameof(WrData1), PortRole.In6),
            (nameof(WrData0), PortRole.In7),
            (nameof(WrReg), PortRole.In8),
            (nameof(RdData11), PortRole.Out0),
            (nameof(RdData10), PortRole.Out1),
            (nameof(RdData01), PortRole.Out2),
            (nameof(RdData00), PortRole.Out3)]);

        var _9BDEMUX = new _9BDEMUX { Parent = this };
        var _8RegArray2 = new _8RegArray2 { Parent = this };
        var _9MUX2_0 = new _9MUX2 { Parent = this };
        var _9MUX2_1 = new _9MUX2 { Parent = this };
        SubCircuits = [_9BDEMUX, _8RegArray2, _9MUX2_0, _9MUX2_1];

        this.AddWires([
            (WrAddr1, _9BDEMUX.Sel1),
            (WrAddr0, _9BDEMUX.Sel0),
            (WrReg, _9BDEMUX.Clk),

            (_9BDEMUX.ClkQ8, _8RegArray2.Clk8),
            (_9BDEMUX.ClkQ7, _8RegArray2.Clk7),
            (_9BDEMUX.ClkQ6, _8RegArray2.Clk6),
            (_9BDEMUX.ClkQ5, _8RegArray2.Clk5),
            (_9BDEMUX.ClkQ4, _8RegArray2.Clk4),
            (_9BDEMUX.ClkQ3, _8RegArray2.Clk3),
            (_9BDEMUX.ClkQ2, _8RegArray2.Clk2),
            (_9BDEMUX.ClkQ1, _8RegArray2.Clk1),
            (_9BDEMUX.ClkQ0, _8RegArray2.Clk0),
            (WrData1, _8RegArray2.Din1),
            (WrData0, _8RegArray2.Din0),

            (RdAddr11, _9MUX2_0.Sel1),
            (RdAddr10, _9MUX2_0.Sel0),
            (_8RegArray2.Q81, _9MUX2_0.D81),
            (_8RegArray2.Q80, _9MUX2_0.D80),
            (_8RegArray2.Q71, _9MUX2_0.D71),
            (_8RegArray2.Q70, _9MUX2_0.D70),
            (_8RegArray2.Q61, _9MUX2_0.D61),
            (_8RegArray2.Q60, _9MUX2_0.D60),
            (_8RegArray2.Q51, _9MUX2_0.D51),
            (_8RegArray2.Q50, _9MUX2_0.D50),
            (_8RegArray2.Q41, _9MUX2_0.D41),
            (_8RegArray2.Q40, _9MUX2_0.D40),
            (_8RegArray2.Q31, _9MUX2_0.D31),
            (_8RegArray2.Q30, _9MUX2_0.D30),
            (_8RegArray2.Q21, _9MUX2_0.D21),
            (_8RegArray2.Q20, _9MUX2_0.D20),
            (_8RegArray2.Q11, _9MUX2_0.D11),
            (_8RegArray2.Q10, _9MUX2_0.D10),
            (_8RegArray2.Q01, _9MUX2_0.D01),
            (_8RegArray2.Q00, _9MUX2_0.D00),

            (RdAddr01, _9MUX2_1.Sel1),
            (RdAddr00, _9MUX2_1.Sel0),
            (_8RegArray2.Q81, _9MUX2_1.D81),
            (_8RegArray2.Q80, _9MUX2_1.D80),
            (_8RegArray2.Q71, _9MUX2_1.D71),
            (_8RegArray2.Q70, _9MUX2_1.D70),
            (_8RegArray2.Q61, _9MUX2_1.D61),
            (_8RegArray2.Q60, _9MUX2_1.D60),
            (_8RegArray2.Q51, _9MUX2_1.D51),
            (_8RegArray2.Q50, _9MUX2_1.D50),
            (_8RegArray2.Q41, _9MUX2_1.D41),
            (_8RegArray2.Q40, _9MUX2_1.D40),
            (_8RegArray2.Q31, _9MUX2_1.D31),
            (_8RegArray2.Q30, _9MUX2_1.D30),
            (_8RegArray2.Q21, _9MUX2_1.D21),
            (_8RegArray2.Q20, _9MUX2_1.D20),
            (_8RegArray2.Q11, _9MUX2_1.D11),
            (_8RegArray2.Q10, _9MUX2_1.D10),
            (_8RegArray2.Q01, _9MUX2_1.D01),
            (_8RegArray2.Q00, _9MUX2_1.D00),

            (_9MUX2_0.Q1, RdData11),
            (_9MUX2_0.Q0, RdData10),
            (_9MUX2_1.Q1, RdData01),
            (_9MUX2_1.Q0, RdData00)]);
    }
}
