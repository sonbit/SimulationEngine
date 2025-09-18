using SimulationEngine.Designs.Calculators.SubCircuits;
using SimulationEngine.Designs.SubCircuits.Deselectors;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Calculators;

public class TT3_BTCalculator : SubCircuit
{
    public Port X1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port X0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Y1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Y0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port S3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port S2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port S1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port S0 => Ports.Single(p => p.Role == PortRole.Out3);

    public TT3_BTCalculator()
    {
        this.AddPorts([
            (nameof(X1), PortRole.In0),
            (nameof(X0), PortRole.In1),
            (nameof(Y1), PortRole.In2),
            (nameof(Y0), PortRole.In3),
            (nameof(S3), PortRole.Out0),
            (nameof(S2), PortRole.Out1),
            (nameof(S1), PortRole.Out2),
            (nameof(S0), PortRole.Out3)]);

        var btm4 = new BTM4();
        var bta4 = new BTA4();
        var deselect4 = new Deselect4();
        SubCircuits = [btm4, bta4, deselect4];

        this.AddWires([
            (X1, btm4.X1),
            (X0, btm4.X0),
            (Y1, btm4.Y1),
            (Y0, btm4.Y0),

            (X1, bta4.X1),
            (X0, bta4.X0),
            (Y1, bta4.Y1),
            (Y0, bta4.Y0),

            (X1, deselect4.Sel),
            (btm4.S3, deselect4.A3),
            (btm4.S2, deselect4.A2),
            (btm4.S1, deselect4.A1),
            (btm4.S0, deselect4.A0),
            (bta4.S3, deselect4.B3),
            (bta4.S2, deselect4.B2),
            (bta4.S1, deselect4.B1),
            (bta4.S0, deselect4.B0),

            (deselect4.S3, S3),
            (deselect4.S2, S2),
            (deselect4.S1, S1),
            (deselect4.S0, S0)]);
    }
}
