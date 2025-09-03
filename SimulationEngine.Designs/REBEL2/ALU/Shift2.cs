using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class Shift2 : SubCircuit
{
    public Port A1 => Ports.Single(p => p.Role == PortRole.In0);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Imm1 => Ports.Single(p => p.Role == PortRole.In2);
    public Port Imm0 => Ports.Single(p => p.Role == PortRole.In3);
    public Port Dir => Ports.Single(p => p.Role == PortRole.In4);
    public Port Ins => Ports.Single(p => p.Role == PortRole.In5);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out1);

    public Shift2()
    {
        this.AddPorts([
            (nameof(A1), PortRole.In0),
            (nameof(A0), PortRole.In1),
            (nameof(Imm1), PortRole.In2),
            (nameof(Imm0), PortRole.In3),
            (nameof(Dir), PortRole.In4),
            (nameof(Ins), PortRole.In5),
            (nameof(Q1), PortRole.Out0),
            (nameof(Q0), PortRole.Out1)]);

        var _063TGT360 = this.AddLogicGate("063TGT360");
        var _630GTG036 = this.AddLogicGate("630GTG036");

        var _3MUX1_0 = new _3MUX { Parent = this };
        var _3MUX1_1 = new _3MUX { Parent = this };
        SubCircuits = [_3MUX1_0, _3MUX1_1];

        this.AddWires([
            (Dir, _063TGT360.C),
            (Imm1, _063TGT360.B),
            (Imm0, _063TGT360.A),

            (Dir, _630GTG036.C),
            (Imm1, _630GTG036.B),
            (Imm0, _630GTG036.A),

            (_063TGT360.Q, _3MUX1_0.Sel),
            (A1, _3MUX1_0.C),
            (A0, _3MUX1_0.B),
            (Ins, _3MUX1_0.A),


            (_630GTG036.Q, _3MUX1_1.Sel),
            (A1, _3MUX1_1.C),
            (A0, _3MUX1_1.B),
            (Ins, _3MUX1_1.A),

            (_3MUX1_0.Q, Q1),
            (_3MUX1_1.Q, Q0)]);
    }
}
