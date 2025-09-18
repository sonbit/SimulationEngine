using SimulationEngine.Designs.SubCircuits.Memory;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.Decode;

public class Decode : SubCircuit
{
    public Port Pc1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port Pc0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Op1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Op0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Rs11 => Ports.Single(p => p.Role == PortRole.In4);
    public Port Rs10 => Ports.Single(p => p.Role == PortRole.In5);
    public Port Rs01 => Ports.Single(p => p.Role == PortRole.In6);
    public Port Rs00 => Ports.Single(p => p.Role == PortRole.In7);
    public Port Rd11 => Ports.Single(p => p.Role == PortRole.In8);
    public Port Rd10 => Ports.Single(p => p.Role == PortRole.In9);
    public Port Rd01 => Ports.Single(p => p.Role == PortRole.In10);
    public Port Rd00 => Ports.Single(p => p.Role == PortRole.In11);
    public Port WbReg => Ports.Single(p => p.Role == PortRole.In12);
    public Port WrAddr1 => Ports.Single(p => p.Role == PortRole.In13);
    public Port WrAddr0 => Ports.Single(p => p.Role == PortRole.In14);
    public Port WrData1 => Ports.Single(p => p.Role == PortRole.In15);
    public Port WrData0 => Ports.Single(p => p.Role == PortRole.In16);
    public Port Clk => Ports.Single(p => p.Role == PortRole.In17);
    public Port AluCtrl2 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port AluCtrl1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port AluCtrl0 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port AluASel => Ports.Single(p => p.Role == PortRole.Out3);
    public Port AluBSel => Ports.Single(p => p.Role == PortRole.Out4);
    public Port AluAddSel1 => Ports.Single(p => p.Role == PortRole.Out5);
    public Port AluAddSel0 => Ports.Single(p => p.Role == PortRole.Out6);
    public Port AluTarSel => Ports.Single(p => p.Role == PortRole.Out7);
    public Port Reg11 => Ports.Single(p => p.Role == PortRole.Out8);
    public Port Reg10 => Ports.Single(p => p.Role == PortRole.Out9);
    public Port Reg01 => Ports.Single(p => p.Role == PortRole.Out10);
    public Port Reg00 => Ports.Single(p => p.Role == PortRole.Out11);
    public Port Imm11 => Ports.Single(p => p.Role == PortRole.Out12);
    public Port Imm10 => Ports.Single(p => p.Role == PortRole.Out13);
    public Port TarAddr1 => Ports.Single(p => p.Role == PortRole.Out14);
    public Port TarAddr0 => Ports.Single(p => p.Role == PortRole.Out15);
    public Port Imm01 => Ports.Single(p => p.Role == PortRole.Out16);
    public Port Imm00 => Ports.Single(p => p.Role == PortRole.Out17);

    public Decode()
    {
        this.AddPorts([
            (nameof(Pc1), PortRole.In0),
            (nameof(Pc0), PortRole.In1),
            (nameof(Op1), PortRole.In2),
            (nameof(Op0), PortRole.In3),
            (nameof(Rs11), PortRole.In4),
            (nameof(Rs10), PortRole.In5),
            (nameof(Rs01), PortRole.In6),
            (nameof(Rs00), PortRole.In7),
            (nameof(Rd11), PortRole.In8),
            (nameof(Rd10), PortRole.In9),
            (nameof(Rd01), PortRole.In10),
            (nameof(Rd00), PortRole.In11),
            (nameof(WbReg), PortRole.In12),
            (nameof(WrAddr1), PortRole.In13),
            (nameof(WrAddr0), PortRole.In14),
            (nameof(WrData1), PortRole.In15),
            (nameof(WrData0), PortRole.In16),
            (nameof(Clk), PortRole.In17),
            (nameof(AluCtrl2), PortRole.Out0),
            (nameof(AluCtrl1), PortRole.Out1),
            (nameof(AluCtrl0), PortRole.Out2),
            (nameof(AluASel), PortRole.Out3),
            (nameof(AluBSel), PortRole.Out4),
            (nameof(AluAddSel1), PortRole.Out5),
            (nameof(AluAddSel0), PortRole.Out6),
            (nameof(AluTarSel), PortRole.Out7),
            (nameof(Reg11), PortRole.Out8),
            (nameof(Reg10), PortRole.Out9),
            (nameof(Reg01), PortRole.Out10),
            (nameof(Reg00), PortRole.Out11),
            (nameof(Imm11), PortRole.Out12),
            (nameof(Imm10), PortRole.Out13),
            (nameof(TarAddr1), PortRole.Out14),
            (nameof(TarAddr0), PortRole.Out15),
            (nameof(Imm01), PortRole.Out16),
            (nameof(Imm00), PortRole.Out17)]);

        var K00 = this.AddLogicGate("K00");

        var execCtrl = new ExecCtrl();
        var _9Reg2 = new _9Reg2();
        SubCircuits = [execCtrl, _9Reg2];

        this.AddWires([
            (WbReg, K00.B),
            (Clk, K00.A),

            (Op1, execCtrl.Op1),
            (Op0, execCtrl.Op0),
            (Rd01, execCtrl.Rd1),
            (Rd00, execCtrl.Rd0),

            (Rs11, _9Reg2.RdAddr11),
            (Rs10, _9Reg2.RdAddr10),
            (Rs01, _9Reg2.RdAddr01),
            (Rs00, _9Reg2.RdAddr00),
            (WrAddr1, _9Reg2.WrAddr1),
            (WrAddr0, _9Reg2.WrAddr0),
            (WrData1, _9Reg2.WrData1),
            (WrData0, _9Reg2.WrData0),
            (K00.Q, _9Reg2.WrReg),

            (execCtrl.AluCtrl2, AluCtrl2),
            (execCtrl.AluCtrl1, AluCtrl1),
            (execCtrl.AluCtrl0, AluCtrl0),
            (execCtrl.AluASel, AluASel),
            (execCtrl.AluBSel, AluBSel),
            (execCtrl.AluAddSel1, AluAddSel1),
            (execCtrl.AluAddSel0, AluAddSel0),
            (execCtrl.AluTarSel, AluTarSel),

            (_9Reg2.RdData11, Reg11),
            (_9Reg2.RdData10, Reg10),
            (_9Reg2.RdData01, Reg01),
            (_9Reg2.RdData00, Reg00),

            (Rs01, Imm11),
            (Rs00, Imm10),
            (Rd11, TarAddr1),
            (Rd10, TarAddr0),
            (Rd01, Imm01),
            (Rd00, Imm00)]);
    }
}
