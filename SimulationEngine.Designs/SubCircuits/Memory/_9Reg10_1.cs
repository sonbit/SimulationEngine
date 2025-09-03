using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Memory;

public class _9Reg10_1 : SubCircuit
{
    public Port RdAddr1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port RdAddr0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port WrAddr1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port WrAddr0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port WrData9 => Ports.Single(p => p.Role == PortRole.In4);
    public Port WrData8 => Ports.Single(p => p.Role == PortRole.In5);
    public Port WrData7 => Ports.Single(p => p.Role == PortRole.In6);
    public Port WrData6 => Ports.Single(p => p.Role == PortRole.In7);
    public Port WrData5 => Ports.Single(p => p.Role == PortRole.In8);
    public Port WrData4 => Ports.Single(p => p.Role == PortRole.In9);
    public Port WrData3 => Ports.Single(p => p.Role == PortRole.In10);
    public Port WrData2 => Ports.Single(p => p.Role == PortRole.In11);
    public Port WrData1 => Ports.Single(p => p.Role == PortRole.In12);
    public Port WrData0 => Ports.Single(p => p.Role == PortRole.In13);
    public Port Clk => Ports.Single(p => p.Role == PortRole.In14);
    public Port Op1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Op0 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Rs11 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Rs10 => Ports.Single(p => p.Role == PortRole.Out3);
    public Port Rs01 => Ports.Single(p => p.Role == PortRole.Out4);
    public Port Rs00 => Ports.Single(p => p.Role == PortRole.Out5);
    public Port Rd11 => Ports.Single(p => p.Role == PortRole.Out6);
    public Port Rd10 => Ports.Single(p => p.Role == PortRole.Out7);
    public Port Rd01 => Ports.Single(p => p.Role == PortRole.Out8);
    public Port Rd00 => Ports.Single(p => p.Role == PortRole.Out9);

    public _9Reg10_1()
    {
        this.AddPorts([
            (nameof(RdAddr1), PortRole.In0),
            (nameof(RdAddr0), PortRole.In1),
            (nameof(WrAddr1), PortRole.In2),
            (nameof(WrAddr0), PortRole.In3),
            (nameof(WrData9), PortRole.In4),
            (nameof(WrData8), PortRole.In5),
            (nameof(WrData7), PortRole.In6),
            (nameof(WrData6), PortRole.In7),
            (nameof(WrData5), PortRole.In8),
            (nameof(WrData4), PortRole.In9),
            (nameof(WrData3), PortRole.In10),
            (nameof(WrData2), PortRole.In11),
            (nameof(WrData1), PortRole.In12),
            (nameof(WrData0), PortRole.In13),
            (nameof(Clk), PortRole.In14),
            (nameof(Op1), PortRole.Out0),
            (nameof(Op0), PortRole.Out1),
            (nameof(Rs11), PortRole.Out2),
            (nameof(Rs10), PortRole.Out3),
            (nameof(Rs01), PortRole.Out4),
            (nameof(Rs00), PortRole.Out5),
            (nameof(Rd11), PortRole.Out6),
            (nameof(Rd10), PortRole.Out7),
            (nameof(Rd01), PortRole.Out8),
            (nameof(Rd00), PortRole.Out9)]);

        var _9Reg21_0 = new _9Reg2_1 { Parent = this };
        var _9Reg21_1 = new _9Reg2_1 { Parent = this };
        var _9Reg21_2 = new _9Reg2_1 { Parent = this };
        var _9Reg21_3 = new _9Reg2_1 { Parent = this };
        var _9Reg21_4 = new _9Reg2_1 { Parent = this };
        SubCircuits = [_9Reg21_0, _9Reg21_1, _9Reg21_2, _9Reg21_3, _9Reg21_4];

        this.AddWires([
            (RdAddr1, _9Reg21_0.RdAddr1),
            (RdAddr0, _9Reg21_0.RdAddr0),
            (WrAddr1, _9Reg21_0.WrAddr1),
            (WrAddr0, _9Reg21_0.WrAddr0),
            (WrData9, _9Reg21_0.WrData1),
            (WrData8, _9Reg21_0.WrData0),
            (Clk, _9Reg21_0.Clk),

            (RdAddr1, _9Reg21_1.RdAddr1),
            (RdAddr0, _9Reg21_1.RdAddr0),
            (WrAddr1, _9Reg21_1.WrAddr1),
            (WrAddr0, _9Reg21_1.WrAddr0),
            (WrData9, _9Reg21_1.WrData1),
            (WrData8, _9Reg21_1.WrData0),
            (Clk, _9Reg21_1.Clk),

            (RdAddr1, _9Reg21_2.RdAddr1),
            (RdAddr0, _9Reg21_2.RdAddr0),
            (WrAddr1, _9Reg21_2.WrAddr1),
            (WrAddr0, _9Reg21_2.WrAddr0),
            (WrData9, _9Reg21_2.WrData1),
            (WrData8, _9Reg21_2.WrData0),
            (Clk, _9Reg21_2.Clk),

            (RdAddr1, _9Reg21_3.RdAddr1),
            (RdAddr0, _9Reg21_3.RdAddr0),
            (WrAddr1, _9Reg21_3.WrAddr1),
            (WrAddr0, _9Reg21_3.WrAddr0),
            (WrData9, _9Reg21_3.WrData1),
            (WrData8, _9Reg21_3.WrData0),
            (Clk, _9Reg21_3.Clk),

            (RdAddr1, _9Reg21_4.RdAddr1),
            (RdAddr0, _9Reg21_4.RdAddr0),
            (WrAddr1, _9Reg21_4.WrAddr1),
            (WrAddr0, _9Reg21_4.WrAddr0),
            (WrData9, _9Reg21_4.WrData1),
            (WrData8, _9Reg21_4.WrData0),
            (Clk, _9Reg21_4.Clk),

            (_9Reg21_0.Q1, Op1),
            (_9Reg21_0.Q0, Op0),
            (_9Reg21_1.Q1, Rs11),
            (_9Reg21_1.Q0, Rs10),
            (_9Reg21_2.Q1, Rs01),
            (_9Reg21_2.Q0, Rs00),
            (_9Reg21_3.Q1, Rd11),
            (_9Reg21_3.Q0, Rd10),
            (_9Reg21_4.Q1, Rd01),
            (_9Reg21_4.Q0, Rd00)]);
    }
}
