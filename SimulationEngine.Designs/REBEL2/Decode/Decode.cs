using SimulationEngine.Designs.SubCircuits.Memory;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Decode;

public class Decode : SubCircuit
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
    public Port AluCtrl2 => Outputs[0];
    public Port AluCtrl1 => Outputs[1];
    public Port AluCtrl0 => Outputs[2];
    public Port AluASel => Outputs[3];
    public Port AluBSel => Outputs[4];
    public Port AluAddSel1 => Outputs[5];
    public Port AluAddSel0 => Outputs[6];
    public Port AluTarSel => Outputs[7];
    public Port Reg11 => Outputs[8];
    public Port Reg10 => Outputs[9];
    public Port Reg01 => Outputs[10];
    public Port Reg00 => Outputs[11];
    public Port Imm11 => Outputs[12];
    public Port Imm10 => Outputs[13];
    public Port TarAddr1 => Outputs[14];
    public Port TarAddr0 => Outputs[15];
    public Port Imm01 => Outputs[16];
    public Port Imm00 => Outputs[17];

    public Decode()
    {
        this.AddInputs(
            nameof(Pc1), nameof(Pc0), nameof(Op1), nameof(Op0),nameof(Rs11), nameof(Rs10), nameof(Rs01), nameof(Rs00),
            nameof(Rd11), nameof(Rd10), nameof(Rd01), nameof(Rd00), nameof(WbReg), nameof(WrAddr1), nameof(WrAddr0), 
            nameof(WrData1), nameof(WrData0), nameof(Clk));
        this.AddOutputs(
            nameof(AluCtrl2), nameof(AluCtrl1), nameof(AluCtrl0), nameof(AluASel), nameof(AluBSel), nameof(AluAddSel1), nameof(AluAddSel0), 
            nameof(AluTarSel), nameof(Reg11), nameof(Reg10), nameof(Reg01), nameof(Reg00), 
            nameof(Imm11), nameof(Imm10), nameof(TarAddr1), nameof(TarAddr0), nameof(Imm01), nameof(Imm00));

        var K00 = this.AddLogicGate("K00");

        var execCtrl = this.AddSubCircuit(new ExecCtrl());
        var _9Reg2 = this.AddSubCircuit(new _9Reg2());

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
            (Rd00, Imm00)
        ]);
    }
}