using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.Fetch;

public class Increment2 : SubCircuit
{
    public Port X1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port X0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public Increment2()
    {
        this.AddPorts([
            (nameof(X1), PortRole.In0),
            (nameof(X0), PortRole.In1),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var _7PP = this.AddLogicGate("7PP");
        var _7 = this.AddLogicGate("7");

        this.AddWires([
            (X1, _7PP.B),
            (X0, _7PP.A),

            (X0, _7.A),

            (_7PP.Q, Q1),
            (_7.Q, Q0)]);
    }
}