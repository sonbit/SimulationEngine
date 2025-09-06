using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.Calculators.SubCircuits;

public class BTA : SubCircuit
{
    public Port X => Ports.Single(p => p.Role == PortRole.In0);
    public Port Y => Ports.Single(p => p.Role == PortRole.In1);
    public Port S1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port S0 => Ports.Single(p => p.Role == PortRole.Out1);

    public BTA()
    {
        this.AddPorts([
            (nameof(X), PortRole.In0),
            (nameof(Y), PortRole.In1),
            (nameof(S1), PortRole.Out0),
            (nameof(S0), PortRole.Out1)]);

        var rdc = this.AddLogicGate("RDC");
        var _7PB = this.AddLogicGate("7PB");

        this.AddWires([
            (X, rdc.B),
            (Y, rdc.A),

            (X, _7PB.B),
            (Y, _7PB.A),

            (rdc.Q, S1),
            (_7PB.Q, S0)]);
    }
}
