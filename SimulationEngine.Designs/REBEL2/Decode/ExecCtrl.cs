using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Decode;

public class ExecCtrl : SubCircuit
{
    public Port Op1 => Inputs[0];
    public Port Op0 => Inputs[1];
    public Port Rd1 => Inputs[2];
    public Port Rd0 => Inputs[3];
    public Port AluCtrl2 => Outputs[0];
    public Port AluCtrl1 => Outputs[1];
    public Port AluCtrl0 => Outputs[2];
    public Port AluASel => Outputs[3];
    public Port AluBSel => Outputs[4];
    public Port AluAddSel1 => Outputs[5];
    public Port AluAddSel0 => Outputs[6];
    public Port AluTarSel => Outputs[7];

    public ExecCtrl()
    {
        this.AddInputs(nameof(Op1), nameof(Op0), nameof(Rd1), nameof(Rd0));
        this.AddOutputs(
            nameof(AluCtrl2), nameof(AluCtrl1), nameof(AluCtrl0), nameof(AluASel), nameof(AluBSel), 
            nameof(AluAddSel1), nameof(AluAddSel0), nameof(AluTarSel));

        var RDD = this.AddLogicGate("RDD");
        var MCD = this.AddLogicGate("MCD");
        var HHH = this.AddLogicGate("HHH");
        var ZTZ = this.AddLogicGate("ZTZ");
        var HHH088088 = this.AddLogicGate("HHH088088");
        var ZXZ = this.AddLogicGate("ZXZ");

        var aluCtrl2 = this.AddSubCircuit(new ALUCtrl2());

        this.AddWires([
            (Op1, aluCtrl2.Op1),
            (Op0, aluCtrl2.Op0),
            (Rd1, aluCtrl2.Rd1),
            (Rd0, aluCtrl2.Rd0),

            (Op1, RDD.B),
            (Op0, RDD.A),

            (Op1, MCD.B),
            (Op0, MCD.A),

            (Op1, HHH.B),
            (Op0, HHH.A),

            (Rd1, ZTZ.B),
            (Rd0, ZTZ.A),

            (ZTZ.Q, HHH088088.C),
            (Op1, HHH088088.B),
            (Op0, HHH088088.A),

            (Op1, ZXZ.B),
            (Op0, ZXZ.A),

            (aluCtrl2.AluCtrl2, AluCtrl2),
            (aluCtrl2.AluCtrl1, AluCtrl1),
            (aluCtrl2.AluCtrl0, AluCtrl0),
            (RDD.Q, AluASel),
            (MCD.Q, AluBSel),
            (HHH.Q, AluAddSel1),
            (HHH088088.Q, AluAddSel0),
            (ZXZ.Q, AluTarSel),
        ]);
    }
}