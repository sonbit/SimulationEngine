using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.Decode;

public class ALUCtrl2 : SubCircuit
{
    public Port Op1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port Op0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Rd1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Rd0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port AluCtrl2 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port AluCtrl1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port AluCtrl0 => Ports.Single(p => p.Role == PortRole.Out2);

    public ALUCtrl2()
    {
        this.AddPorts([
            (nameof(Op1), PortRole.In0),
            (nameof(Op0), PortRole.In1),
            (nameof(Rd1), PortRole.In2),
            (nameof(Rd0), PortRole.In3),
            (nameof(AluCtrl2), PortRole.Out0),
            (nameof(AluCtrl1), PortRole.Out1),
            (nameof(AluCtrl0), PortRole.Out2)]);

        var GDD = this.AddLogicGate("GDD");
        var D17 = this.AddLogicGate("D17");
        var ZTZ = this.AddLogicGate("ZTZ");
        var D48G74DDD = this.AddLogicGate("D48G74DDD");
        var PPPZD0ZD0_0 = this.AddLogicGate("PPPZD0ZD0");
        var PPPZD0ZD0_1 = this.AddLogicGate("PPPZD0ZD0");

        this.AddWires([
            (Op1, GDD.B),
            (Op0, GDD.A),

            (Op1, D17.B),
            (Op0, D17.A),

            (Rd1, ZTZ.B),
            (Rd0, ZTZ.A),

            (ZTZ.Q, D48G74DDD.C),
            (Op1, D48G74DDD.B),
            (Op0, D48G74DDD.A),
            
            (GDD.Q, PPPZD0ZD0_0.C),
            (Rd1, PPPZD0ZD0_0.B),
            (D17.Q, PPPZD0ZD0_0.A),

            (GDD.Q, PPPZD0ZD0_1.C),
            (Rd0, PPPZD0ZD0_1.B),
            (D48G74DDD.Q, PPPZD0ZD0_1.A),

            (GDD.Q, AluCtrl2),
            (PPPZD0ZD0_0.Q, AluCtrl1),
            (PPPZD0ZD0_1.Q, AluCtrl0)]);
    }
}
