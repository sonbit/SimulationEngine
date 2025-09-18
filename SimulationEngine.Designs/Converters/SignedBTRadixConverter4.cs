using SimulationEngine.Designs.Converters.SubCircuits;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Converters;

public class SignedBTRadixConverter4 : SubCircuit
{
    public Port Sign => Ports.Single(p => p.Role == PortRole.In0);
    public Port A2 => Ports.Single(p => p.Role == PortRole.In1);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out3);

    public SignedBTRadixConverter4()
    {
        this.AddPorts([
            (nameof(Sign), PortRole.In0),
            (nameof(A2), PortRole.In1),
            (nameof(A1), PortRole.In2),
            (nameof(A0), PortRole.In3),
            (nameof(Q3), PortRole.Out0),
            (nameof(Q2), PortRole.Out1),
            (nameof(Q1), PortRole.Out2),
            (nameof(Q0), PortRole.Out3)]);

        var xor3 = new XOR3();
        var bha3 = new BHA3();
        var unsignedBT_RadixConverter4 = new UnsignedBT_RadixConverter4();
        var conditionalSTI4 = new ConditionalSTI4();
        SubCircuits = [xor3, bha3, unsignedBT_RadixConverter4, conditionalSTI4];

        this.AddWires([
            (Sign, xor3.Sign),
            (A2, xor3.A2),
            (A1, xor3.A1),
            (A0, xor3.A0),

            (Sign, bha3.D),
            (xor3.Q2, bha3.C),
            (xor3.Q1, bha3.B),
            (xor3.Q0, bha3.A),

            (bha3.Q3, unsignedBT_RadixConverter4.B3),
            (bha3.Q2, unsignedBT_RadixConverter4.B2),
            (bha3.Q1, unsignedBT_RadixConverter4.B1),
            (bha3.Q0, unsignedBT_RadixConverter4.B0),

            (Sign, conditionalSTI4.Sign),
            (unsignedBT_RadixConverter4.Q3, conditionalSTI4.A3),
            (unsignedBT_RadixConverter4.Q2, conditionalSTI4.A2),
            (unsignedBT_RadixConverter4.Q1, conditionalSTI4.A1),
            (unsignedBT_RadixConverter4.Q0, conditionalSTI4.A0),

            (conditionalSTI4.Q3, Q3),
            (conditionalSTI4.Q2, Q2),
            (conditionalSTI4.Q1, Q1),
            (conditionalSTI4.Q0, Q0)]);
    }
}
