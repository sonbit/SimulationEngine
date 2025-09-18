using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.Decode;

public class ExecCtrl : SubCircuit
{
    public Port Op1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port Op0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Rd1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Rd0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port AluCtrl2 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port AluCtrl1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port AluCtrl0 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port AluASel => Ports.Single(p => p.Role == PortRole.Out3);
    public Port AluBSel => Ports.Single(p => p.Role == PortRole.Out4);
    public Port AluAddSel1 => Ports.Single(p => p.Role == PortRole.Out5);
    public Port AluAddSel0 => Ports.Single(p => p.Role == PortRole.Out6);
    public Port AluTarSel => Ports.Single(p => p.Role == PortRole.Out7);

    public ExecCtrl()
    {
        this.AddPorts([
            (nameof(Op1), PortRole.In0),
            (nameof(Op0), PortRole.In1),
            (nameof(Rd1), PortRole.In2),
            (nameof(Rd0), PortRole.In3),
            (nameof(AluCtrl2), PortRole.Out0),
            (nameof(AluCtrl1), PortRole.Out1),
            (nameof(AluCtrl0), PortRole.Out2),
            (nameof(AluASel), PortRole.Out3),
            (nameof(AluBSel), PortRole.Out4),
            (nameof(AluAddSel1), PortRole.Out5),
            (nameof(AluAddSel0), PortRole.Out6),
            (nameof(AluTarSel), PortRole.Out7)]);

        var RDD = this.AddLogicGate("RDD");
        var MCD = this.AddLogicGate("MCD");
        var HHH = this.AddLogicGate("HHH");
        var ZTZ = this.AddLogicGate("ZTZ");
        var HHH088088 = this.AddLogicGate("HHH088088");
        var ZXZ = this.AddLogicGate("ZXZ");

        var aluCtrl2 = new ALUCtrl2();
        SubCircuits = [aluCtrl2];

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
