using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Calculators.SubCircuits;

public class BTA4 : SubCircuit
{
    public Port X1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port X0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Y1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Y0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port S3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port S2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port S1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port S0 => Ports.Single(p => p.Role == PortRole.Out3);

    public BTA4()
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

        var bta0 = new BTA();
        var bta1 = new BTA();
        var bta2 = new BTA();
        var bta3 = new BTA();
        SubCircuits = [bta0, bta1, bta2, bta3];

        this.AddWires([
            (X1, bta0.X),
            (Y1, bta0.Y),

            (X0, bta1.X),
            (Y0, bta1.Y),

            (bta0.S1, bta2.X),
            (bta1.S0, bta2.Y),

            (bta0.S1, bta3.X),
            (bta2.S0, bta3.Y),

            (bta3.S1, S3),
            (bta3.S0, S2),
            (bta2.S1, S1),
            (bta1.S0, S0)]);
    }
}
