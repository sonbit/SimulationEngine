using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Adders;

public class _2TritAdder : SubCircuit
{
    public Port B1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Cout => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out2);

    public _2TritAdder()
    {
        this.AddPorts([
            (nameof(B1), PortRole.In0),
            (nameof(B0), PortRole.In1),
            (nameof(A1), PortRole.In2),
            (nameof(A0), PortRole.In3),
            (nameof(Cout), PortRole.Out0),
            (nameof(Q1), PortRole.Out1),
            (nameof(Q0), PortRole.Out2)]);

        var triHalfAdder = new TriHalfAdder();
        var triFullAdder = new TriFullAdder();
        SubCircuits = [triHalfAdder, triFullAdder];

        this.AddWires([
            (B1, triFullAdder.B),
            (B0, triHalfAdder.B),

            (A1, triFullAdder.A),
            (A0, triHalfAdder.A),

            (triHalfAdder.Cout, triFullAdder.C),
            (triHalfAdder.Q, Q0),

            (triFullAdder.Cout, Cout),
            (triFullAdder.Q, Q1)]);
    }
}
