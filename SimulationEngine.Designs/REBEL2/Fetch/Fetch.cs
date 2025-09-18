using SimulationEngine.Designs.SubCircuits.Memory;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.Fetch;

public class Fetch : SubCircuit
{
    public Port LdEn => Ports.Single(p => p.Role == PortRole.In0);
    public Port LdAddr1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port LdAddr0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port WrAddr1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port WrAddr0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port WrData9 => Ports.Single(p => p.Role == PortRole.In5);
    public Port WrData8 => Ports.Single(p => p.Role == PortRole.In6);
    public Port WrData7 => Ports.Single(p => p.Role == PortRole.In7);
    public Port WrData6 => Ports.Single(p => p.Role == PortRole.In8);
    public Port WrData5 => Ports.Single(p => p.Role == PortRole.In9);
    public Port WrData4 => Ports.Single(p => p.Role == PortRole.In10);
    public Port WrData3 => Ports.Single(p => p.Role == PortRole.In11);
    public Port WrData2 => Ports.Single(p => p.Role == PortRole.In12);
    public Port WrData1 => Ports.Single(p => p.Role == PortRole.In13);
    public Port WrData0 => Ports.Single(p => p.Role == PortRole.In14);
    public Port Clk => Ports.Single(p => p.Role == PortRole.In15);
    public Port WrClk => Ports.Single(p => p.Role == PortRole.In16);
    public Port Pc1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Pc0 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Op1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Op0 => Ports.Single(p => p.Role == PortRole.Out3);
    public Port Rs11 => Ports.Single(p => p.Role == PortRole.Out4);
    public Port Rs10 => Ports.Single(p => p.Role == PortRole.Out5);
    public Port Rs01 => Ports.Single(p => p.Role == PortRole.Out6);
    public Port Rs00 => Ports.Single(p => p.Role == PortRole.Out7);
    public Port Rd11 => Ports.Single(p => p.Role == PortRole.Out8);
    public Port Rd10 => Ports.Single(p => p.Role == PortRole.Out9);
    public Port Rd01 => Ports.Single(p => p.Role == PortRole.Out10);
    public Port Rd00 => Ports.Single(p => p.Role == PortRole.Out11);

    public Fetch()
    {
        this.AddPorts([
            (nameof(LdEn), PortRole.In0),
            (nameof(LdAddr1), PortRole.In1),
            (nameof(LdAddr0), PortRole.In2),
            (nameof(WrAddr1), PortRole.In3),
            (nameof(WrAddr0), PortRole.In4),
            (nameof(WrData9), PortRole.In5),
            (nameof(WrData8), PortRole.In6),
            (nameof(WrData7), PortRole.In7),
            (nameof(WrData6), PortRole.In8),
            (nameof(WrData5), PortRole.In9),
            (nameof(WrData4), PortRole.In10),
            (nameof(WrData3), PortRole.In11),
            (nameof(WrData2), PortRole.In12),
            (nameof(WrData1), PortRole.In13),
            (nameof(WrData0), PortRole.In14),
            (nameof(Clk), PortRole.In15),
            (nameof(WrClk), PortRole.In16),
            (nameof(Pc1), PortRole.Out0),
            (nameof(Pc0), PortRole.Out1),
            (nameof(Op1), PortRole.Out2),
            (nameof(Op0), PortRole.Out3),
            (nameof(Rs11), PortRole.Out4),
            (nameof(Rs10), PortRole.Out5),
            (nameof(Rs01), PortRole.Out6),
            (nameof(Rs00), PortRole.Out7),
            (nameof(Rd11), PortRole.Out8),
            (nameof(Rd10), PortRole.Out9),
            (nameof(Rd01), PortRole.Out10),
            (nameof(Rd00), PortRole.Out11)]);

        var progCtr2 = new ProgCtr2();
        var _9Reg10_1 = new _9Reg10_1();
        SubCircuits = [progCtr2, _9Reg10_1];

        this.AddWires([
            (LdEn, progCtr2.LdEn),
            (LdAddr1, progCtr2.LdAddr1),
            (LdAddr0, progCtr2.LdAddr0),
            (Clk, progCtr2.Clk),

            (progCtr2.Pc1, _9Reg10_1.RdAddr1),
            (progCtr2.Pc0, _9Reg10_1.RdAddr0),
            (WrAddr1, _9Reg10_1.WrAddr1),
            (WrAddr0, _9Reg10_1.WrAddr0),
            (WrData9, _9Reg10_1.WrData9),
            (WrData8, _9Reg10_1.WrData8),
            (WrData7, _9Reg10_1.WrData7),
            (WrData6, _9Reg10_1.WrData6),
            (WrData5, _9Reg10_1.WrData5),
            (WrData4, _9Reg10_1.WrData4),
            (WrData3, _9Reg10_1.WrData3),
            (WrData2, _9Reg10_1.WrData2),
            (WrData1, _9Reg10_1.WrData1),
            (WrData0, _9Reg10_1.WrData0),
            (WrClk, _9Reg10_1.Clk),

            (progCtr2.Pc1, Pc1),
            (progCtr2.Pc0, Pc0),
            (_9Reg10_1.Op1, Op1),
            (_9Reg10_1.Op0, Op0),
            (_9Reg10_1.Rs11, Rs11),
            (_9Reg10_1.Rs10, Rs10),
            (_9Reg10_1.Rs01, Rs01),
            (_9Reg10_1.Rs00, Rs00),
            (_9Reg10_1.Rd11, Rd11),
            (_9Reg10_1.Rd10, Rd10),
            (_9Reg10_1.Rd01, Rd01),
            (_9Reg10_1.Rd00, Rd00)]);
    }
}
