using SimulationEngine.Designs.SubCircuits.Counters;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Converters;
public class TT_UM_TernaryPC_RadixConverter : SubCircuit
{
    public Port Clk => Ports.Single(p => p.Role == PortRole.In0);
    public Port LdEn => Ports.Single(p => p.Role == PortRole.In1);
    public Port A3 => Ports.Single(p => p.Role == PortRole.In2);
    public Port A2 => Ports.Single(p => p.Role == PortRole.In3);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In4);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In5);
    public Port Dir => Ports.Single(p => p.Role == PortRole.In6);
    public Port PC3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port PC2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port PC1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port PC0 => Ports.Single(p => p.Role == PortRole.Out3);
    public Port RC2 => Ports.Single(p => p.Role == PortRole.Out4);
    public Port RC1 => Ports.Single(p => p.Role == PortRole.Out5);
    public Port RC0 => Ports.Single(p => p.Role == PortRole.Out6);

    public TT_UM_TernaryPC_RadixConverter()
    {
        this.AddPorts([
            (nameof(Clk), PortRole.In0),
            (nameof(LdEn), PortRole.In1),
            (nameof(A3), PortRole.In2),
            (nameof(A2), PortRole.In3),
            (nameof(A1), PortRole.In4),
            (nameof(A0), PortRole.In5),
            (nameof(Dir), PortRole.In6),
            (nameof(PC3), PortRole.Out0),
            (nameof(PC2), PortRole.Out1),
            (nameof(PC1), PortRole.Out2),
            (nameof(PC0), PortRole.Out3),
            (nameof(RC2), PortRole.Out4),
            (nameof(RC1), PortRole.Out5),
            (nameof(RC0), PortRole.Out6)]);

        var syTriDirLoadCounter4 = new SyTriDirLoadCounter4();
        var bTSignedRadixConverter = new BTSignedRadixConverter4();
        var signedBTRadixConverter4 = new SignedBTRadixConverter4();
        SubCircuits = [syTriDirLoadCounter4, bTSignedRadixConverter, signedBTRadixConverter4];

        this.AddWires([
            (Clk, syTriDirLoadCounter4.Clk),
            (LdEn, syTriDirLoadCounter4.LdEn),
            (A3, syTriDirLoadCounter4.A3),
            (A2, syTriDirLoadCounter4.A2),
            (A1, syTriDirLoadCounter4.A1),
            (A0, syTriDirLoadCounter4.A0),
            (Dir, syTriDirLoadCounter4.Dir),

            (A2, bTSignedRadixConverter.A2),
            (A1, bTSignedRadixConverter.A1),
            (A0, bTSignedRadixConverter.A0),

            (bTSignedRadixConverter.Q3, signedBTRadixConverter4.Sign),
            (bTSignedRadixConverter.Q2, signedBTRadixConverter4.A2),
            (bTSignedRadixConverter.Q1, signedBTRadixConverter4.A1),
            (bTSignedRadixConverter.Q0, signedBTRadixConverter4.A0),

            (syTriDirLoadCounter4.Q3, PC3),
            (syTriDirLoadCounter4.Q2, PC2),
            (syTriDirLoadCounter4.Q1, PC1),
            (syTriDirLoadCounter4.Q0, PC0),
            (signedBTRadixConverter4.Q2, RC2),
            (signedBTRadixConverter4.Q1, RC1),
            (signedBTRadixConverter4.Q0, RC0)]);
    }
}