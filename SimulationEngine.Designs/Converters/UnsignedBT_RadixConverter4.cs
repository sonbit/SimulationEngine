using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Converters;

public class UnsignedBT_RadixConverter4 : SubCircuit
{
    public Port B3 => Ports.Single(p => p.Role == PortRole.In0);
    public Port B2 => Ports.Single(p => p.Role == PortRole.In1);
    public Port B1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out3);

    public UnsignedBT_RadixConverter4()
    {
        this.AddPorts([
            (nameof(B3), PortRole.In0),
            (nameof(B2), PortRole.In1),
            (nameof(B1), PortRole.In2),
            (nameof(B0), PortRole.In3),
            (nameof(Q3), PortRole.Out0),
            (nameof(Q2), PortRole.Out1),
            (nameof(Q1), PortRole.Out2),
            (nameof(Q0), PortRole.Out3)]);

        var HHDDXXDDD = this.AddLogicGate("HHDDXXDDD");
        var HE4 = this.AddLogicGate("HE4");
        var ZZR = this.AddLogicGate("ZZR");
        var _5XX = this.AddLogicGate("5XX");
        var _5XC = this.AddLogicGate("5XC");
        var DD4 = this.AddLogicGate("DD4");
        var RRDRDDDDD = this.AddLogicGate("RRDRDDDDD");
        var RRD = this.AddLogicGate("RRD");
        var _88R = this.AddLogicGate("88R");
        var XE2 = this.AddLogicGate("XE2");
        var H4K = this.AddLogicGate("H4K");

        this.AddWires([
            (B2, HHDDXXDDD.C),
            (B1, HHDDXXDDD.B),
            (B0, HHDDXXDDD.A),

            (B1, HE4.B),
            (B0, HE4.A),

            (HHDDXXDDD.Q, ZZR.B),
            (B1, ZZR.A),

            (B2, _5XX.B),
            (ZZR.Q, _5XX.A),

            (B2, _5XC.B),
            (HE4.Q, _5XC.A),

            (B3, DD4.B),
            (_5XC.Q, DD4.A),

            (DD4.Q, RRDRDDDDD.C),
            (B2, RRDRDDDDD.B),
            (ZZR.Q, RRDRDDDDD.A),

            (RRDRDDDDD.Q, RRD.B),
            (B3, RRD.A),

            (RRDRDDDDD.Q, _88R.B),
            (B3, _88R.A),

            (DD4.Q, XE2.B),
            (_5XX.Q, XE2.A),

            (B3, H4K.B),
            (_5XC.Q, H4K.A),

            (RRD.Q, Q3),
            (_88R.Q, Q2),
            (XE2.Q, Q1),
            (H4K.Q, Q0)]);
    }
}
