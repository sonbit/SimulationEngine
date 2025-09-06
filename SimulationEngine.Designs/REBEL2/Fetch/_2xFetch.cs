using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.Fetch;

public class _2xFetch : SubCircuit
{
    public Port LdEn => Ports.Single(p => p.Role == PortRole.In0);
    public Port LdAddr1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port LdAddr0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port WrAddr1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port WrAddr0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port WrData9 => Ports.Single(p => p.Role == PortRole.In5);
    public Port WrData8 => Ports.Single(p => p.Role == PortRole.In6);
    public Port WrData7 => Ports.Single(p => p.Role == PortRole.In7);
    public Port WrData6 => Ports.Single(p => p.Role == PortRole.In8);
    public Port WrData5 => Ports.Single(p => p.Role == PortRole.In9);
    public Port WrData4 => Ports.Single(p => p.Role == PortRole.In10);
    public Port WrData3 => Ports.Single(p => p.Role == PortRole.In11);
    public Port WrData2 => Ports.Single(p => p.Role == PortRole.In12);
    public Port WrData1 => Ports.Single(p => p.Role == PortRole.In13);
    public Port WrData0 => Ports.Single(p => p.Role == PortRole.In14);
    public Port Clk => Ports.Single(p => p.Role == PortRole.In15);
    public Port WrClk => Ports.Single(p => p.Role == PortRole.In16);

    public Port Pc1_0 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Pc0_0 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Op1_0 => Ports.Single(p => p.Role == PortRole.Out2);
    public Port Op0_0 => Ports.Single(p => p.Role == PortRole.Out3);
    public Port Rs11_0 => Ports.Single(p => p.Role == PortRole.Out4);
    public Port Rs10_0 => Ports.Single(p => p.Role == PortRole.Out5);
    public Port Rs01_0 => Ports.Single(p => p.Role == PortRole.Out6);
    public Port Rs00_0 => Ports.Single(p => p.Role == PortRole.Out7);
    public Port Rd11_0 => Ports.Single(p => p.Role == PortRole.Out8);
    public Port Rd10_0 => Ports.Single(p => p.Role == PortRole.Out9);
    public Port Rd01_0 => Ports.Single(p => p.Role == PortRole.Out10);
    public Port Rd00_0 => Ports.Single(p => p.Role == PortRole.Out11);

    public Port Pc1_1 => Ports.Single(p => p.Role == PortRole.Out12);
    public Port Pc0_1 => Ports.Single(p => p.Role == PortRole.Out13);
    public Port Op1_1 => Ports.Single(p => p.Role == PortRole.Out14);
    public Port Op0_1 => Ports.Single(p => p.Role == PortRole.Out15);
    public Port Rs11_1 => Ports.Single(p => p.Role == PortRole.Out16);
    public Port Rs10_1 => Ports.Single(p => p.Role == PortRole.Out17);
    public Port Rs01_1 => Ports.Single(p => p.Role == PortRole.Out18);
    public Port Rs00_1 => Ports.Single(p => p.Role == PortRole.Out19);
    public Port Rd11_1 => Ports.Single(p => p.Role == PortRole.Out20);
    public Port Rd10_1 => Ports.Single(p => p.Role == PortRole.Out21);
    public Port Rd01_1 => Ports.Single(p => p.Role == PortRole.Out22);
    public Port Rd00_1 => Ports.Single(p => p.Role == PortRole.Out23);

    public _2xFetch()
    {
        this.AddPorts([
            (nameof(LdEn), PortRole.In0),
            (nameof(LdAddr1), PortRole.In1),
            (nameof(LdAddr0), PortRole.In2),
            (nameof(WrAddr1), PortRole.In3),
            (nameof(WrAddr0), PortRole.In4),
            (nameof(WrData9), PortRole.In5),
            (nameof(WrData8), PortRole.In6),
            (nameof(WrData7), PortRole.In7),
            (nameof(WrData6), PortRole.In8),
            (nameof(WrData5), PortRole.In9),
            (nameof(WrData4), PortRole.In10),
            (nameof(WrData3), PortRole.In11),
            (nameof(WrData2), PortRole.In12),
            (nameof(WrData1), PortRole.In13),
            (nameof(WrData0), PortRole.In14),
            (nameof(Clk), PortRole.In15),
            (nameof(WrClk), PortRole.In16),

            (nameof(Pc1_0), PortRole.Out0),
            (nameof(Pc0_0), PortRole.Out1),
            (nameof(Op1_0), PortRole.Out2),
            (nameof(Op0_0), PortRole.Out3),
            (nameof(Rs11_0), PortRole.Out4),
            (nameof(Rs10_0), PortRole.Out5),
            (nameof(Rs01_0), PortRole.Out6),
            (nameof(Rs00_0), PortRole.Out7),
            (nameof(Rd11_0), PortRole.Out8),
            (nameof(Rd10_0), PortRole.Out9),
            (nameof(Rd01_0), PortRole.Out10),
            (nameof(Rd00_0), PortRole.Out11),

            (nameof(Pc1_1), PortRole.Out12),
            (nameof(Pc0_1), PortRole.Out13),
            (nameof(Op1_1), PortRole.Out14),
            (nameof(Op0_1), PortRole.Out15),
            (nameof(Rs11_1), PortRole.Out16),
            (nameof(Rs10_1), PortRole.Out17),
            (nameof(Rs01_1), PortRole.Out18),
            (nameof(Rs00_1), PortRole.Out19),
            (nameof(Rd11_1), PortRole.Out20),
            (nameof(Rd10_1), PortRole.Out21),
            (nameof(Rd01_1), PortRole.Out22),
            (nameof(Rd00_1), PortRole.Out23)]);

        var fetch_0 = new Fetch { Parent = this };
        var fetch_1 = new Fetch { Parent = this };
        SubCircuits = [fetch_0, fetch_1];

        this.AddWires([
            (LdEn, fetch_0.LdEn),
            (LdAddr1, fetch_0.LdAddr1),
            (LdAddr0, fetch_0.LdAddr0),
            (WrAddr1, fetch_0.WrAddr1),
            (WrAddr0, fetch_0.WrAddr0),
            (WrData9, fetch_0.WrData9),
            (WrData8, fetch_0.WrData8),
            (WrData7, fetch_0.WrData7),
            (WrData6, fetch_0.WrData6),
            (WrData5, fetch_0.WrData5),
            (WrData4, fetch_0.WrData4),
            (WrData3, fetch_0.WrData3),
            (WrData2, fetch_0.WrData2),
            (WrData1, fetch_0.WrData1),
            (WrData0, fetch_0.WrData2),
            (Clk, fetch_0.Clk),
            (WrClk, fetch_0.WrClk),

            (LdEn, fetch_1.LdEn),
            (LdAddr1, fetch_1.LdAddr1),
            (LdAddr0, fetch_1.LdAddr0),
            (WrAddr1, fetch_1.WrAddr1),
            (WrAddr0, fetch_1.WrAddr0),
            (WrData9, fetch_1.WrData9),
            (WrData8, fetch_1.WrData8),
            (WrData7, fetch_1.WrData7),
            (WrData6, fetch_1.WrData6),
            (WrData5, fetch_1.WrData5),
            (WrData4, fetch_1.WrData4),
            (WrData3, fetch_1.WrData3),
            (WrData2, fetch_1.WrData2),
            (WrData1, fetch_1.WrData1),
            (WrData0, fetch_1.WrData2),
            (Clk, fetch_1.Clk),
            (WrClk, fetch_1.WrClk),

            (fetch_0.Pc1, Pc1_0),
            (fetch_0.Pc0, Pc0_0),
            (fetch_0.Op1, Op1_0),
            (fetch_0.Op0, Op0_0),
            (fetch_0.Rs11, Rs11_0),
            (fetch_0.Rs10, Rs10_0),
            (fetch_0.Rs01, Rs01_0),
            (fetch_0.Rs00, Rs00_0),
            (fetch_0.Rd11, Rd11_0),
            (fetch_0.Rd10, Rd10_0),
            (fetch_0.Rd01, Rd01_0),
            (fetch_0.Rd00, Rd00_0),

            (fetch_1.Pc1, Pc1_1),
            (fetch_1.Pc0, Pc0_1),
            (fetch_1.Op1, Op1_1),
            (fetch_1.Op0, Op0_1),
            (fetch_1.Rs11, Rs11_1),
            (fetch_1.Rs10, Rs10_1),
            (fetch_1.Rs01, Rs01_1),
            (fetch_1.Rs00, Rs00_1),
            (fetch_1.Rd11, Rd11_1),
            (fetch_1.Rd10, Rd10_1),
            (fetch_1.Rd01, Rd01_1),
            (fetch_1.Rd00, Rd00_1)]);
    }
}
