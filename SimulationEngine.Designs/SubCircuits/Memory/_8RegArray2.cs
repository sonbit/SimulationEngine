using SimulationEngine.Designs.SubCircuits.Latches;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class _8RegArray2 : SubCircuit
{
    public Port Clk8 => Ports.Single(p => p.Role == PortRole.In0);
    public Port Clk7 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Clk6 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Clk5 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Clk4 => Ports.Single(p => p.Role == PortRole.In4);
    public Port Clk3 => Ports.Single(p => p.Role == PortRole.In5);
    public Port Clk2 => Ports.Single(p => p.Role == PortRole.In6);
    public Port Clk1 => Ports.Single(p => p.Role == PortRole.In7);
    public Port Clk0 => Ports.Single(p => p.Role == PortRole.In8);
    public Port Din1 => Ports.Single(p => p.Role == PortRole.In9);
    public Port Din0 => Ports.Single(p => p.Role == PortRole.In10);
    public Port Q81 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q80 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q71 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Q70 => Ports.Single(p => p.Role == PortRole.Out3);
    public Port Q61 => Ports.Single(p => p.Role == PortRole.Out4);
    public Port Q60 => Ports.Single(p => p.Role == PortRole.Out5);
    public Port Q51 => Ports.Single(p => p.Role == PortRole.Out6);
    public Port Q50 => Ports.Single(p => p.Role == PortRole.Out7);
    public Port Q41 => Ports.Single(p => p.Role == PortRole.Out8);
    public Port Q40 => Ports.Single(p => p.Role == PortRole.Out9);
    public Port Q31 => Ports.Single(p => p.Role == PortRole.Out10);
    public Port Q30 => Ports.Single(p => p.Role == PortRole.Out11);
    public Port Q21 => Ports.Single(p => p.Role == PortRole.Out12);
    public Port Q20 => Ports.Single(p => p.Role == PortRole.Out13);
    public Port Q11 => Ports.Single(p => p.Role == PortRole.Out14);
    public Port Q10 => Ports.Single(p => p.Role == PortRole.Out15);
    public Port Q01 => Ports.Single(p => p.Role == PortRole.Out16);
    public Port Q00 => Ports.Single(p => p.Role == PortRole.Out17);

    public _8RegArray2()
    {
        this.AddPorts([
            (nameof(Clk8), PortRole.In0),
            (nameof(Clk7), PortRole.In1),
            (nameof(Clk6), PortRole.In2),
            (nameof(Clk5), PortRole.In3),
            (nameof(Clk4), PortRole.In4),
            (nameof(Clk3), PortRole.In5),
            (nameof(Clk2), PortRole.In6),
            (nameof(Clk1), PortRole.In7),
            (nameof(Clk0), PortRole.In8),
            (nameof(Din1), PortRole.In9),
            (nameof(Din0), PortRole.In10),
            (nameof(Q81), PortRole.Out0),
            (nameof(Q80), PortRole.Out1),
            (nameof(Q71), PortRole.Out2),
            (nameof(Q70), PortRole.Out3),
            (nameof(Q61), PortRole.Out4),
            (nameof(Q60), PortRole.Out5),
            (nameof(Q51), PortRole.Out6),
            (nameof(Q50), PortRole.Out7),
            (nameof(Q41), PortRole.Out8),
            (nameof(Q40), PortRole.Out9),
            (nameof(Q31), PortRole.Out10),
            (nameof(Q30), PortRole.Out11),
            (nameof(Q21), PortRole.Out12),
            (nameof(Q20), PortRole.Out13),
            (nameof(Q11), PortRole.Out14),
            (nameof(Q10), PortRole.Out15),
            (nameof(Q01), PortRole.Out16),
            (nameof(Q00), PortRole.Out17)]);

        var _2Latch2_0 = new _2Latch2();
        var _2Latch2_1 = new _2Latch2();
        var _2Latch2_2 = new _2Latch2();
        var _2Latch2_3 = new _2Latch2();
        var _2Latch2_4 = new _2Latch2();
        var _2Latch2_5 = new _2Latch2();
        var _2Latch2_6 = new _2Latch2();
        var _2Latch2_7 = new _2Latch2();
        var _2Latch2_8 = new _2Latch2();
        SubCircuits = [_2Latch2_0, _2Latch2_1, _2Latch2_2, _2Latch2_3, _2Latch2_4, _2Latch2_5, _2Latch2_6, _2Latch2_7, _2Latch2_8];

        this.AddWires([
            (Clk8, _2Latch2_0.Clk),
            (Din1, _2Latch2_0.A1),
            (Din0, _2Latch2_0.A0),

            (Clk7, _2Latch2_1.Clk),
            (Din1, _2Latch2_1.A1),
            (Din0, _2Latch2_1.A0),

            (Clk6, _2Latch2_2.Clk),
            (Din1, _2Latch2_2.A1),
            (Din0, _2Latch2_2.A0),

            (Clk5, _2Latch2_3.Clk),
            (Din1, _2Latch2_3.A1),
            (Din0, _2Latch2_3.A0),

            (Clk4, _2Latch2_4.Clk),
            (Din1, _2Latch2_4.A1),
            (Din0, _2Latch2_4.A0),

            (Clk3, _2Latch2_5.Clk),
            (Din1, _2Latch2_5.A1),
            (Din0, _2Latch2_5.A0),

            (Clk2, _2Latch2_6.Clk),
            (Din1, _2Latch2_6.A1),
            (Din0, _2Latch2_6.A0),

            (Clk1, _2Latch2_7.Clk),
            (Din1, _2Latch2_7.A1),
            (Din0, _2Latch2_7.A0),

            (Clk0, _2Latch2_8.Clk),
            (Din1, _2Latch2_8.A1),
            (Din0, _2Latch2_8.A0),

            (_2Latch2_0.Q1, Q81),
            (_2Latch2_0.Q0, Q80),
            (_2Latch2_1.Q1, Q71),
            (_2Latch2_1.Q0, Q70),
            (_2Latch2_2.Q1, Q61),
            (_2Latch2_2.Q0, Q60),
            (_2Latch2_3.Q1, Q51),
            (_2Latch2_3.Q0, Q50),
            (_2Latch2_4.Q1, Q41),
            (_2Latch2_4.Q0, Q40),
            (_2Latch2_5.Q1, Q31),
            (_2Latch2_5.Q0, Q30),
            (_2Latch2_6.Q1, Q21),
            (_2Latch2_6.Q0, Q20),
            (_2Latch2_7.Q1, Q11),
            (_2Latch2_7.Q0, Q10),
            (_2Latch2_8.Q1, Q01),
            (_2Latch2_8.Q0, Q00)]);
    }
}
