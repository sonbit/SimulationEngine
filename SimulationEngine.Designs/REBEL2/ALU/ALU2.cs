using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Designs.REBEL2.ALU;

public class ALU2 : SubCircuit
{
    public Port Func2 => Ports.Single(p => p.Role == PortRole.In0);
    public Port Func1 => Ports.Single(p => p.Role == PortRole.In1);
    public Port Func0 => Ports.Single(p => p.Role == PortRole.In2);
    public Port B1 => Ports.Single(p => p.Role == PortRole.In3);
    public Port B0 => Ports.Single(p => p.Role == PortRole.In4);
    public Port A1 => Ports.Single(p => p.Role == PortRole.In5);
    public Port A0 => Ports.Single(p => p.Role == PortRole.In6);
    public Port Cout => Ports.Single(p => p.Role == PortRole.Out0);
    public Port Q1 => Ports.Single(p => p.Role == PortRole.Out1);
    public Port Q0 => Ports.Single(p => p.Role == PortRole.Out2);

    public ALU2()
    {
        this.AddPorts([
            (nameof(Func2), PortRole.In0),
            (nameof(Func1), PortRole.In1),
            (nameof(Func0), PortRole.In2),
            (nameof(B1), PortRole.In3),
            (nameof(B0), PortRole.In4),
            (nameof(A1), PortRole.In5),
            (nameof(A0), PortRole.In6),
            (nameof(Cout), PortRole.Out0),
            (nameof(Q1), PortRole.Out1),
            (nameof(Q0), PortRole.Out2)]);

        var DGDDDDDAD = this.AddLogicGate("DGDDDDDAD");

        var shift2 = new Shift2 { Parent = this };
        var _2TritMul = new _2TritMul { Parent = this };
        var addSub2 = new AddSub2 { Parent = this };
        var cmp2 = new CMP2 { Parent = this };
        var cmp2Tritwise = new CMP2Tritwise { Parent = this };
        var _2MUX2_0 = new _2MUX2 { Parent = this };
        var _2MUX2_1 = new _2MUX2 { Parent = this };
        var _2MUX2_2 = new _2MUX2 { Parent = this };
        var _3MUX2_0 = new _3MUX2 { Parent = this };
        var _3MUX2_1 = new _3MUX2 { Parent = this };
        SubCircuits = [shift2, _2TritMul, addSub2, cmp2, cmp2Tritwise, _2MUX2_0, _2MUX2_1, _2MUX2_2, _3MUX2_0, _3MUX2_1];

        this.AddWires([
            (A1, shift2.A1),
            (A0, shift2.A0),
            (B1, shift2.Imm1),
            (B0, shift2.Imm0),
            (Func1, shift2.Dir),
            (Func0, shift2.Ins),

            (B1, _2TritMul.B1),
            (B0, _2TritMul.B0),
            (A1, _2TritMul.A1),
            (A0, _2TritMul.A0),

            (Func0, addSub2.Sel),
            (B1, addSub2.B1),
            (B0, addSub2.B0),
            (A1, addSub2.A1),
            (A0, addSub2.A0),

            (B1, cmp2.B1),
            (B0, cmp2.B0),
            (A1, cmp2.A1),
            (A0, cmp2.A0),

            (Func0, cmp2Tritwise.Mode),
            (B1, cmp2Tritwise.B1),
            (B0, cmp2Tritwise.B0),
            (A1, cmp2Tritwise.A1),
            (A0, cmp2Tritwise.A0),

            (Func0, _2MUX2_0.Sel),
            (_2TritMul.Q3, _2MUX2_0.B1),
            (_2TritMul.Q2, _2MUX2_0.B0),
            (_2TritMul.Q1, _2MUX2_0.A1),
            (_2TritMul.Q0, _2MUX2_0.A0),

            (Func0, _3MUX2_0.Sel),
            (cmp2.Max1, _3MUX2_0.C1),
            (cmp2.Max0, _3MUX2_0.C0),
            (cmp2.Cmp, _3MUX2_0.B1),
            (cmp2.Cmp, _3MUX2_0.B0),
            (cmp2.Min1, _3MUX2_0.A1),
            (cmp2.Min0, _3MUX2_0.A0),

            (addSub2.Q2, DGDDDDDAD.C),
            (Func2, DGDDDDDAD.B),
            (Func1, DGDDDDDAD.A),

            (Func1, _2MUX2_1.Sel),
            (_2MUX2_0.Q1, _2MUX2_1.B1),
            (_2MUX2_0.Q0, _2MUX2_1.B0),
            (addSub2.Q1, _2MUX2_1.A1),
            (addSub2.Q0, _2MUX2_1.A0),

            (Func1, _2MUX2_2.Sel),
            (_3MUX2_0.Q1, _2MUX2_2.B1),
            (_3MUX2_0.Q0, _2MUX2_2.B0),
            (cmp2Tritwise.Q1, _2MUX2_2.A1),
            (cmp2Tritwise.Q0, _2MUX2_2.A0),

            (Func2, _3MUX2_1.Sel),
            (shift2.Q1, _3MUX2_1.C1),
            (shift2.Q0, _3MUX2_1.C0),
            (_2MUX2_1.Q1, _3MUX2_1.B1),
            (_2MUX2_1.Q0, _3MUX2_1.B0),
            (_2MUX2_2.Q1, _3MUX2_1.A1),
            (_2MUX2_2.Q0, _3MUX2_1.A0),

            (DGDDDDDAD.Q, Cout),
            (_3MUX2_1.Q1, Q1),
            (_3MUX2_1.Q0, Q0)]);
    }
}
