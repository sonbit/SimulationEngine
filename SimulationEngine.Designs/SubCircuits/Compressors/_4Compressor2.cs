using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.SubCircuits.Compressors;

public class _4Compressor2 : SubCircuit
{
    public Port D => Ports.Single(p => p.Role == PortRole.In0);
    public Port C => Ports.Single(p => p.Role == PortRole.In1);
    public Port B => Ports.Single(p => p.Role == PortRole.In2);
    public Port A => Ports.Single(p => p.Role == PortRole.In3);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public _4Compressor2()
    {
        this.AddPorts([
            (nameof(D), PortRole.In0),
            (nameof(C), PortRole.In1),
            (nameof(B), PortRole.In2),
            (nameof(A), PortRole.In3),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var carry = this.AddLogicGate("ZXRXRDRDCXRDRDCDC9RDCDC9C90");
        var sum = this.AddLogicGate("PB7B7P7PBB7P7PBPB77PBPB7B7P");

        this.AddWires([
            (D, carry.D),
            (C, carry.C),
            (B, carry.B),
            (A, carry.A),

            (D, sum.D),
            (C, sum.C),
            (B, sum.B),
            (A, sum.A),

            (carry.Q, Q1),
            (sum.Q, Q0)]);
    }
}
