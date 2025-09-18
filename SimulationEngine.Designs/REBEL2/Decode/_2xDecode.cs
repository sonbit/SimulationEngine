using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.Decode;

public class _2xDecode : SubCircuit
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

    public Port AluCtrl2_0 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port AluCtrl1_0 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port AluCtrl0_0 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port AluASel_0 => Ports.Single(p => p.Role == PortRole.Out3);
    public Port AluBSel_0 => Ports.Single(p => p.Role == PortRole.Out4);
    public Port AluAddSel1_0 => Ports.Single(p => p.Role == PortRole.Out5);
    public Port AluAddSel0_0 => Ports.Single(p => p.Role == PortRole.Out6);
    public Port AluTarSel_0 => Ports.Single(p => p.Role == PortRole.Out7);
    public Port Reg11_0 => Ports.Single(p => p.Role == PortRole.Out8);
    public Port Reg10_0 => Ports.Single(p => p.Role == PortRole.Out9);
    public Port Reg01_0 => Ports.Single(p => p.Role == PortRole.Out10);
    public Port Reg00_0 => Ports.Single(p => p.Role == PortRole.Out11);
    public Port Imm11_0 => Ports.Single(p => p.Role == PortRole.Out12);
    public Port Imm10_0 => Ports.Single(p => p.Role == PortRole.Out13);
    public Port TarAddr1_0 => Ports.Single(p => p.Role == PortRole.Out14);
    public Port TarAddr0_0=> Ports.Single(p => p.Role == PortRole.Out15);
    public Port Imm01_0 => Ports.Single(p => p.Role == PortRole.Out16);
    public Port Imm00_0 => Ports.Single(p => p.Role == PortRole.Out17);

    public Port AluCtrl2_1 => Ports.Single(p => p.Role == PortRole.Out18);
    public Port AluCtrl1_1 => Ports.Single(p => p.Role == PortRole.Out19);
    public Port AluCtrl0_1 => Ports.Single(p => p.Role == PortRole.Out20);
    public Port AluASel_1 => Ports.Single(p => p.Role == PortRole.Out21);
    public Port AluBSel_1 => Ports.Single(p => p.Role == PortRole.Out22);
    public Port AluAddSel1_1 => Ports.Single(p => p.Role == PortRole.Out23);
    public Port AluAddSel0_1 => Ports.Single(p => p.Role == PortRole.Out24);
    public Port AluTarSel_1 => Ports.Single(p => p.Role == PortRole.Out25);
    public Port Reg11_1 => Ports.Single(p => p.Role == PortRole.Out26);
    public Port Reg10_1 => Ports.Single(p => p.Role == PortRole.Out27);
    public Port Reg01_1 => Ports.Single(p => p.Role == PortRole.Out28);
    public Port Reg00_1 => Ports.Single(p => p.Role == PortRole.Out29);
    public Port Imm11_1 => Ports.Single(p => p.Role == PortRole.Out30);
    public Port Imm10_1 => Ports.Single(p => p.Role == PortRole.Out31);
    public Port TarAddr1_1 => Ports.Single(p => p.Role == PortRole.Out32);
    public Port TarAddr0_1 => Ports.Single(p => p.Role == PortRole.Out33);
    public Port Imm01_1 => Ports.Single(p => p.Role == PortRole.Out34);
    public Port Imm00_1 => Ports.Single(p => p.Role == PortRole.Out35);

    public _2xDecode()
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

            (nameof(AluCtrl2_0), PortRole.Out0),
            (nameof(AluCtrl1_0), PortRole.Out1),
            (nameof(AluCtrl0_0), PortRole.Out2),
            (nameof(AluASel_0), PortRole.Out3),
            (nameof(AluBSel_0), PortRole.Out4),
            (nameof(AluAddSel1_0), PortRole.Out5),
            (nameof(AluAddSel0_0), PortRole.Out6),
            (nameof(AluTarSel_0), PortRole.Out7),
            (nameof(Reg11_0), PortRole.Out8),
            (nameof(Reg10_0), PortRole.Out9),
            (nameof(Reg01_0), PortRole.Out10),
            (nameof(Reg00_0), PortRole.Out11),
            (nameof(Imm11_0), PortRole.Out12),
            (nameof(Imm10_0), PortRole.Out13),
            (nameof(TarAddr1_0), PortRole.Out14),
            (nameof(TarAddr0_0), PortRole.Out15),
            (nameof(Imm01_0), PortRole.Out16),
            (nameof(Imm00_0), PortRole.Out17),

            (nameof(AluCtrl2_1), PortRole.Out18),
            (nameof(AluCtrl1_1), PortRole.Out19),
            (nameof(AluCtrl0_1), PortRole.Out20),
            (nameof(AluASel_1), PortRole.Out21),
            (nameof(AluBSel_1), PortRole.Out22),
            (nameof(AluAddSel1_1), PortRole.Out23),
            (nameof(AluAddSel0_1), PortRole.Out24),
            (nameof(AluTarSel_1), PortRole.Out25),
            (nameof(Reg11_1), PortRole.Out26),
            (nameof(Reg10_1), PortRole.Out27),
            (nameof(Reg01_1), PortRole.Out28),
            (nameof(Reg00_1), PortRole.Out29),
            (nameof(Imm11_1), PortRole.Out30),
            (nameof(Imm10_1), PortRole.Out31),
            (nameof(TarAddr1_1), PortRole.Out32),
            (nameof(TarAddr0_1), PortRole.Out33),
            (nameof(Imm01_1), PortRole.Out34),
            (nameof(Imm00_1), PortRole.Out35)]);

        var decode_0 = new Decode();
        var decode_1 = new Decode();
        SubCircuits = [decode_0, decode_1];

        this.AddWires([
            (Pc1, decode_0.Pc1),
            (Pc0, decode_0.Pc0),
            (Op1, decode_0.Op1),
            (Op0, decode_0.Op0),
            (Rs11, decode_0.Rs11),
            (Rs10, decode_0.Rs10),
            (Rs01, decode_0.Rs01),
            (Rs00, decode_0.Rs00),
            (Rd11, decode_0.Rd11),
            (Rd10, decode_0.Rd10),
            (Rd01, decode_0.Rd01),
            (Rd00, decode_0.Rd00),
            (WbReg, decode_0.WbReg),
            (WrAddr1, decode_0.WrAddr1),
            (WrAddr0, decode_0.WrAddr0),
            (WrData1, decode_0.WrData1),
            (WrData0, decode_0.WrData0),
            (Clk, decode_0.Clk),

            (Pc1, decode_1.Pc1),
            (Pc0, decode_1.Pc0),
            (Op1, decode_1.Op1),
            (Op0, decode_1.Op0),
            (Rs11, decode_1.Rs11),
            (Rs10, decode_1.Rs10),
            (Rs01, decode_1.Rs01),
            (Rs00, decode_1.Rs00),
            (Rd11, decode_1.Rd11),
            (Rd10, decode_1.Rd10),
            (Rd01, decode_1.Rd01),
            (Rd00, decode_1.Rd00),
            (WbReg, decode_1.WbReg),
            (WrAddr1, decode_1.WrAddr1),
            (WrAddr0, decode_1.WrAddr0),
            (WrData1, decode_1.WrData1),
            (WrData0, decode_1.WrData0),
            (Clk, decode_1.Clk),

            (decode_0.AluCtrl2, AluCtrl2_0),
            (decode_0.AluCtrl1, AluCtrl1_0),
            (decode_0.AluCtrl0, AluCtrl0_0),
            (decode_0.AluASel, AluASel_0),
            (decode_0.AluBSel, AluBSel_0),
            (decode_0.AluAddSel1, AluAddSel1_0),
            (decode_0.AluAddSel0, AluAddSel0_0),
            (decode_0.AluTarSel, AluTarSel_0),
            (decode_0.Reg11, Reg11_0),
            (decode_0.Reg10, Reg10_0),
            (decode_0.Reg01, Reg01_0),
            (decode_0.Reg00, Reg00_0),
            (decode_0.Imm11, Imm11_0),
            (decode_0.Imm10, Imm10_0),
            (decode_0.TarAddr1, TarAddr1_0),
            (decode_0.TarAddr0, TarAddr0_0),
            (decode_0.Imm01, Imm01_0),
            (decode_0.Imm00, Imm00_0),

            (decode_1.AluCtrl2, AluCtrl2_1),
            (decode_1.AluCtrl1, AluCtrl1_1),
            (decode_1.AluCtrl0, AluCtrl0_1),
            (decode_1.AluASel, AluASel_1),
            (decode_1.AluBSel, AluBSel_1),
            (decode_1.AluAddSel1, AluAddSel1_1),
            (decode_1.AluAddSel0, AluAddSel0_1),
            (decode_1.AluTarSel, AluTarSel_1),
            (decode_1.Reg11, Reg11_1),
            (decode_1.Reg10, Reg10_1),
            (decode_1.Reg01, Reg01_1),
            (decode_1.Reg00, Reg00_1),
            (decode_1.Imm11, Imm11_1),
            (decode_1.Imm10, Imm10_1),
            (decode_1.TarAddr1, TarAddr1_1),
            (decode_1.TarAddr0, TarAddr0_1),
            (decode_1.Imm01, Imm01_1),
            (decode_1.Imm00, Imm00_1)]);
    }
}
