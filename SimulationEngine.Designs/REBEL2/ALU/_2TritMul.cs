using SimulationEngine.Designs.SubCircuits.Adders;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class _2TritMul : SubCircuit
{
    public Port B1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out3);

    public _2TritMul()
    {
        this.AddPorts([
            (nameof(B1), PortRole.In0),
            (nameof(B0), PortRole.In1),
            (nameof(A1), PortRole.In2),
            (nameof(A0), PortRole.In3),
            (nameof(Q3), PortRole.Out0),
            (nameof(Q2), PortRole.Out1),
            (nameof(Q1), PortRole.Out2),
            (nameof(Q0), PortRole.Out3)]);

        var PD5_0 = this.AddLogicGate("PD5");
        var PD5_1 = this.AddLogicGate("PD5");
        var PD5_2 = this.AddLogicGate("PD5");
        var PD5_3 = this.AddLogicGate("PD5");

        var triHalfAdder_0 = new TriHalfAdder { Parent = this };
        var triHalfAdder_1 = new TriHalfAdder { Parent = this };
        SubCircuits = [triHalfAdder_0, triHalfAdder_1];

        this.AddWires([
            (B1, PD5_0.B),
            (A1, PD5_0.A),

            (B0, PD5_1.B),
            (A1, PD5_1.A),

            (B1, PD5_2.B),
            (A0, PD5_2.A),

            (B0, PD5_3.B),
            (A0, PD5_3.A),
            
            (PD5_1.Q, triHalfAdder_0.B),
            (PD5_2.Q, triHalfAdder_0.A),

            (PD5_0.Q, triHalfAdder_1.B),
            (triHalfAdder_0.Cout, triHalfAdder_1.A),

            (triHalfAdder_1.Cout, Q3),
            (triHalfAdder_1.Q, Q2),
            (triHalfAdder_0.Q, Q1),
            (PD5_3.Q, Q0)]);
    }
}
