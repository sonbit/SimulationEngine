using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using System.Security.Cryptography.X509Certificates;

namespace SimulationEngine.Designs.Calculators.SubCircuits;

public class BTM4 : SubCircuit
{
    public Port X1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port X0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Y1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Y0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port S3 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port S2 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port S1 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port S0 => Ports.Single(p => p.Role == PortRole.Out3);

    public BTM4()
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

        var btm0 = this.AddLogicGate("PD5");
        var btm1 = this.AddLogicGate("PD5");
        var btm2 = this.AddLogicGate("PD5");
        var btm3 = this.AddLogicGate("PD5");

        var sum = this.AddLogicGate("7PB");

        var CZGDDDA0R = this.AddLogicGate("CZGDDDA0R");
        var DD4DDDEDD = this.AddLogicGate("DD4DDDEDD");

        this.AddWires([
            (X1, btm0.B),
            (Y1, btm0.A),

            (X1, btm1.B),
            (Y0, btm1.A),

            (X0, btm2.B),
            (Y1, btm2.A),

            (X0, btm3.B),
            (Y0, btm3.A),

            (btm1.Q, sum.B),
            (btm2.Q, sum.A),

            (btm0.Q, CZGDDDA0R.C),
            (sum.Q, CZGDDDA0R.B),
            (btm3.Q, CZGDDDA0R.A),

            (CZGDDDA0R.Q, DD4DDDEDD.C),
            (sum.Q, DD4DDDEDD.B),
            (btm3.Q, DD4DDDEDD.A),

            (DD4DDDEDD.Q, S3),
            (CZGDDDA0R.Q, S2),
            (sum.Q, S1),
            (btm3.Q, S0)]);
    }
}
