using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Decode;

public class _2xDecode : SubCircuit
{
    public Port Pc1 => Inputs[0];
    public Port Pc0 => Inputs[1];
    public Port Op1 => Inputs[2];
    public Port Op0 => Inputs[3];
    public Port Rs11 => Inputs[4];
    public Port Rs10 => Inputs[5];
    public Port Rs01 => Inputs[6];
    public Port Rs00 => Inputs[7];
    public Port Rd11 => Inputs[8];
    public Port Rd10 => Inputs[9];
    public Port Rd01 => Inputs[10];
    public Port Rd00 => Inputs[11];
    public Port WbReg => Inputs[12];
    public Port WrAddr1 => Inputs[13];
    public Port WrAddr0 => Inputs[14];
    public Port WrData1 => Inputs[15];
    public Port WrData0 => Inputs[16];
    public Port Clk => Inputs[17];

    public Port AluCtrl2_0 => Outputs[0];
    public Port AluCtrl1_0 => Outputs[1];
    public Port AluCtrl0_0 => Outputs[2];
    public Port AluASel_0 => Outputs[3];
    public Port AluBSel_0 => Outputs[4];
    public Port AluAddSel1_0 => Outputs[5];
    public Port AluAddSel0_0 => Outputs[6];
    public Port AluTarSel_0 => Outputs[7];
    public Port Reg11_0 => Outputs[8];
    public Port Reg10_0 => Outputs[9];
    public Port Reg01_0 => Outputs[10];
    public Port Reg00_0 => Outputs[11];
    public Port Imm11_0 => Outputs[12];
    public Port Imm10_0 => Outputs[13];
    public Port TarAddr1_0 => Outputs[14];
    public Port TarAddr0_0=> Outputs[15];
    public Port Imm01_0 => Outputs[16];
    public Port Imm00_0 => Outputs[17];

    public Port AluCtrl2_1 => Outputs[18];
    public Port AluCtrl1_1 => Outputs[19];
    public Port AluCtrl0_1 => Outputs[20];
    public Port AluASel_1 => Outputs[21];
    public Port AluBSel_1 => Outputs[22];
    public Port AluAddSel1_1 => Outputs[23];
    public Port AluAddSel0_1 => Outputs[24];
    public Port AluTarSel_1 => Outputs[25];
    public Port Reg11_1 => Outputs[26];
    public Port Reg10_1 => Outputs[27];
    public Port Reg01_1 => Outputs[28];
    public Port Reg00_1 => Outputs[29];
    public Port Imm11_1 => Outputs[30];
    public Port Imm10_1 => Outputs[31];
    public Port TarAddr1_1 => Outputs[32];
    public Port TarAddr0_1 => Outputs[33];
    public Port Imm01_1 => Outputs[34];
    public Port Imm00_1 => Outputs[35];

    public _2xDecode()
    {
        this.AddInputs(
            nameof(Pc1), nameof(Pc0), nameof(Op1), nameof(Op0), nameof(Rs11), nameof(Rs10), nameof(Rs01), nameof(Rs00),
            nameof(Rd11), nameof(Rd10), nameof(Rd01), nameof(Rd00), nameof(WbReg), nameof(WrAddr1), nameof(WrAddr0),
            nameof(WrData1), nameof(WrData0), nameof(Clk));
        this.AddOutputs(
            nameof(AluCtrl2_0), nameof(AluCtrl1_0), nameof(AluCtrl0_0), nameof(AluASel_0), nameof(AluBSel_0), nameof(AluAddSel1_0), 
            nameof(AluAddSel0_0), nameof(AluTarSel_0), nameof(Reg11_0), nameof(Reg10_0), nameof(Reg01_0), nameof(Reg00_0), 
            nameof(Imm11_0), nameof(Imm10_0), nameof(TarAddr1_0), nameof(TarAddr0_0), nameof(Imm01_0), nameof(Imm00_0), 

            nameof(AluCtrl2_1), nameof(AluCtrl1_1), nameof(AluCtrl0_1), nameof(AluASel_1), nameof(AluBSel_1), nameof(AluAddSel1_1), 
            nameof(AluAddSel0_1), nameof(AluTarSel_1), nameof(Reg11_1), nameof(Reg10_1), nameof(Reg01_1), nameof(Reg00_1), 
            nameof(Imm11_1), nameof(Imm10_1), nameof(TarAddr1_1), nameof(TarAddr0_1), nameof(Imm01_1), nameof(Imm00_1));

        var decode_0 = this.AddSubCircuit(new Decode());
        var decode_1 = this.AddSubCircuit(new Decode());

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
            (decode_1.Imm00, Imm00_1)
        ]);
    }

    public override string GetTestString() => """
        ------------------ 00+00+++----------00+00+++----------
        ------------+----+ 00+00+++----------00+00+++----------
        ------------+-0-0- 00+00+++----------00+00+++----------
        ------------+-0-0+ 00+00+++----------00+00+++----------
        ------------+-+-++ 00+00+++----------00+00+++----------
        ------------+0-0-- 00+00+++----------00+00+++----------
        ------------+0-0-+ 00+00+++----------00+00+++----------
        ------------+0000- 00+00+++----------00+00+++----------
        ------------+0000+ 00+00+++----------00+00+++----------
        ------------+0+0+- 00+00+++----------00+00+++----------
        ------------+0+0++ 00+00+++----------00+00+++----------
        ------------++-+-- 00+00+++----------00+00+++----------
        ------------++-+-+ 00+00+++----------00+00+++----------
        ------------++0+0- 00+00+++----------00+00+++----------
        ------------++0+0+ 00+00+++----------00+00+++----------
        ------------+++++- 00+00+++----------00+00+++----------
        ------------++++++ 00+00+++----------00+00+++----------
        ------------------ 00+00+++----------00+00+++----------
        -----0-0---------- 00+00+++-0-0-0----00+00+++-0-0-0----
        -----+-+---------- 00+00+++-+-+-+----00+00+++-+-+-+----
        ----0-0----------- 00+00+++0-0-0-----00+00+++0-0-0-----
        ----0000---------- 00+00+++000000----00+00+++000000----
        ----0+0+---------- 00+00+++0+0+0+----00+00+++0+0+0+----
        ----+-+----------- 00+00++++-+-+-----00+00++++-+-+-----
        ----+0+0---------- 00+00++++0+0+0----00+00++++0+0+0----
        ----++++---------- 00+00+++++++++----00+00+++++++++----
        ------------------ 00+00+++----------00+00+++----------
        ------------+----+ 00+00+++----------00+00+++----------
        ------------+-0-0- 00+00+++----------00+00+++----------
        ------------+-0-0+ 00+00+++----------00+00+++----------
        ------------+-+-++ 00+00+++----------00+00+++----------
        ------------+0-0-- 00+00+++----------00+00+++----------
        ------------+0-0-+ 00+00+++----------00+00+++----------
        ------------+0000- 00+00+++----------00+00+++----------
        ------------+0000+ 00+00+++----------00+00+++----------
        ------------+0+0+- 00+00+++----------00+00+++----------
        ------------+0+0++ 00+00+++----------00+00+++----------
        ------------++-+-- 00+00+++----------00+00+++----------
        ------------++-+-+ 00+00+++----------00+00+++----------
        ------------++0+0- 00+00+++----------00+00+++----------
        ------------++0+0+ 00+00+++----------00+00+++----------
        ------------+++++- 00+00+++----------00+00+++----------
        ------------++++++ 00+00+++----------00+00+++----------
        ------------------ 00+00+++----------00+00+++----------
        -----0-0---------- 00+00+++-0-0-0----00+00+++-0-0-0----
        -----+-+---------- 00+00+++-+-+-+----00+00+++-+-+-+----
        ----0-0----------- 00+00+++0-0-0-----00+00+++0-0-0-----
        ----0000---------- 00+00+++000000----00+00+++000000----
        ----0+0+---------- 00+00+++0+0+0+----00+00+++0+0+0+----
        ----+-+----------- 00+00++++-+-+-----00+00++++-+-+-----
        ----+0+0---------- 00+00++++0+0+0----00+00++++0+0+0----
        ----++++---------- 00+00+++++++++----00+00+++++++++----
        ------------+----+ 00+00+++----------00+00+++----------
        ------------+-0--- 00+00+++----------00+00+++----------
        ------------+-0--+ 00+00+++----------00+00+++----------
        ------------+-+--- 00+00+++----------00+00+++----------
        ------------+-+--+ 00+00+++----------00+00+++----------
        ------------+0---- 00+00+++----------00+00+++----------
        ------------+0---+ 00+00+++----------00+00+++----------
        ------------+00--- 00+00+++----------00+00+++----------
        ------------+00--+ 00+00+++----------00+00+++----------
        ------------+0+--- 00+00+++----------00+00+++----------
        ------------+0+--+ 00+00+++----------00+00+++----------
        ------------++---- 00+00+++----------00+00+++----------
        ------------++---+ 00+00+++----------00+00+++----------
        ------------++0--- 00+00+++----------00+00+++----------
        ------------++0--+ 00+00+++----------00+00+++----------
        ------------+++--- 00+00+++----------00+00+++----------
        ------------+++--+ 00+00+++----------00+00+++----------
        ------------------ 00+00+++----------00+00+++----------
        ------------+----+ 00+00+++----------00+00+++----------
        ------------+-0-0- 00+00+++----------00+00+++----------
        ------------+-0-0+ 00+00+++----------00+00+++----------
        ------------+-+-+- 00+00+++----------00+00+++----------
        ------------+-+-++ 00+00+++----------00+00+++----------
        ------------+0-0-- 00+00+++----------00+00+++----------
        ------------+0-0-+ 00+00+++----------00+00+++----------
        ------------+0000- 00+00+++----------00+00+++----------
        ------------+0000+ 00+00+++----------00+00+++----------
        ------------+0+0+- 00+00+++----------00+00+++----------
        ------------+0+0++ 00+00+++----------00+00+++----------
        ------------++-+-- 00+00+++----------00+00+++----------
        ------------++-+-+ 00+00+++----------00+00+++----------
        ------------++0+0- 00+00+++----------00+00+++----------
        ------------++0+0+ 00+00+++----------00+00+++----------
        ------------+++++- 00+00+++----------00+00+++----------
        ------------++++++ 00+00+++----------00+00+++----------
        ------------------ 00+00+++----------00+00+++----------
        ------------------ 00+00+++----------00+00+++----------
        ------------+----+ 00+00+++----------00+00+++----------
        ------------+-0-0- 00+00+++----------00+00+++----------
        ------------+-0-0+ 00+00+++----------00+00+++----------
        ------------+-+-++ 00+00+++----------00+00+++----------
        ------------+0-0-- 00+00+++----------00+00+++----------
        ------------+0-0-+ 00+00+++----------00+00+++----------
        ------------+0000- 00+00+++----------00+00+++----------
        ------------+0000+ 00+00+++----------00+00+++----------
        ------------+0+0+- 00+00+++----------00+00+++----------
        ------------+0+0++ 00+00+++----------00+00+++----------
        ------------++-+-- 00+00+++----------00+00+++----------
    """;
}