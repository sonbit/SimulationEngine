using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Converters;

public class BTSignedRadixConverter4 : SubCircuit
{
    public Port A2 => Ports.Single(p => p.Role == PortRole.In0);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Q3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out3);

    public BTSignedRadixConverter4()
    {
        this.AddPorts([
            (nameof(A2), PortRole.In0),
            (nameof(A1), PortRole.In1),
            (nameof(A0), PortRole.In2),
            (nameof(Q3), PortRole.Out0),
            (nameof(Q2), PortRole.Out1),
            (nameof(Q1), PortRole.Out2),
            (nameof(Q0), PortRole.Out3)]);

        var EDCRC9DD4 = this.AddLogicGate("EDCRC9DD4");
        var CC9 = this.AddLogicGate("CC9");
        var _6N6 = this.AddLogicGate("6N6");
        var _228 = this.AddLogicGate("228");
        var N28 = this.AddLogicGate("N28");
        var _2N6 = this.AddLogicGate("2N6");
        var _60N = this.AddLogicGate("60N");

        this.AddWires([
            (A2, EDCRC9DD4.C),
            (A1, EDCRC9DD4.B),
            (A0, EDCRC9DD4.A),

            (A1, CC9.B),
            (EDCRC9DD4.Q, CC9.A),

            (A1, _6N6.B),
            (A0, _6N6.A),

            (A2, _228.B),
            (CC9.Q, _228.A),

            (A1, N28.B),
            (EDCRC9DD4.Q, N28.A),

            (A1, _2N6.B),
            (EDCRC9DD4.Q, _2N6.A),

            (A2, _60N.B),
            (_6N6.Q, _60N.A),

            (_228.Q, Q3),
            (N28.Q, Q2),
            (_2N6.Q, Q1),
            (_60N.Q, Q0)]);
    }
}
