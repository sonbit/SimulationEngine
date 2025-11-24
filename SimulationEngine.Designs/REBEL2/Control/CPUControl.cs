using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Control;

public class CPUControl : Subcircuit
{
    public Port Op1 => Inputs[0];
    public Port Op0 => Inputs[1];
    public Port Rd1 => Inputs[2];
    public Port Rd0 => Inputs[3];
    public Port Cmp => Inputs[4];

    public Port Alu_Func2 => Outputs[0];
    public Port Alu_Func1 => Outputs[1];
    public Port Alu_Func0 => Outputs[2];
    public Port Alu_A_Mux_Ctrl => Outputs[3];
    public Port Alu_B_Mux_Ctrl => Outputs[4];
    public Port Add_A_Mux_Ctrl => Outputs[5];
    public Port Add_B_Mux_Ctrl => Outputs[6];
    public Port Prog_Ctr => Outputs[7];
    public Port Wb_Ctr => Outputs[8];

    public CPUControl()
    {
        this.AddInputs(
            nameof(Op1),
            nameof(Op0),
            nameof(Rd1),
            nameof(Rd0),
            nameof(Cmp));
        this.AddOutputs(
            nameof(Alu_Func2),
            nameof(Alu_Func1),
            nameof(Alu_Func0),
            nameof(Alu_A_Mux_Ctrl),
            nameof(Alu_B_Mux_Ctrl),
            nameof(Add_A_Mux_Ctrl),
            nameof(Add_B_Mux_Ctrl),
            nameof(Prog_Ctr),
            nameof(Wb_Ctr));

        var aluControl = this.AddSubcircuit(new AluControlWithShift());
        var muxControl = this.AddSubcircuit(new MuxControl());
       
        this.AddWires([
            (Op1, aluControl.Op1),
            (Op0, aluControl.Op0),
            (Rd1, aluControl.Rd1),
            (Rd0, aluControl.Rd0),

            (Op1, muxControl.Op1),
            (Op0, muxControl.Op0),
            (Rd1, muxControl.Rd1),
            (Rd0, muxControl.Rd0),
            (Cmp, muxControl.Cmp),

            (aluControl.Func2, Alu_Func2),
            (aluControl.Func1, Alu_Func1),
            (aluControl.Func0, Alu_Func0),
            (muxControl.AluAMux, Alu_A_Mux_Ctrl),
            (muxControl.AluBMux, Alu_B_Mux_Ctrl),
            (muxControl.AddAMux, Add_A_Mux_Ctrl),
            (muxControl.AddBMux, Add_B_Mux_Ctrl),
            (muxControl.ProgCtr, Prog_Ctr),
            (muxControl.WrEnable, Wb_Ctr)

        ]);
    }

    public override string GetTestString() => """
        ----- 000000000
        0---- 000000000
        +---- 000000000
        -0--- 000000000
        00--- 000000000
        +0--- 000000000
        -+--- 000000000
        0+--- 000000000
        ++--- 000000000
        --0-- 000000000
        0-0-- 000000000
        +-0-- 000000000
        -00-- 000000000
        000-- 000000000
        +00-- 000000000
        -+0-- 000000000
        0+0-- 000000000
        ++0-- 000000000
        --+-- 000000000
        0-+-- 000000000
        +-+-- 000000000
        -0+-- 000000000
        00+-- 000000000
        +0+-- 000000000
        -++-- 000000000
        0++-- 000000000
        +++-- 000000000

        ---0- 000000000
        0--0- 000000000
        +--0- 000000000
        -0-0- 000000000
        00-0- 000000000
        +0-0- 000000000
        -+-0- 000000000
        0+-0- 000000000
        ++-0- 000000000
        --00- 000000000
        0-00- 000000000
        +-00- 000000000
        -000- 000000000
        0000- 000000000
        +000- 000000000
        -+00- 000000000
        0+00- 000000000
        ++00- 000000000
        --+0- 000000000
        0-+0- 000000000
        +-+0- 000000000
        -0+0- 000000000
        00+0- 000000000
        +0+0- 000000000
        -++0- 000000000
        0++0- 000000000
        +++0- 000000000

        ---+- 000000000
        0--+- 000000000
        +--+- 000000000
        -0-+- 000000000
        00-+- 000000000
        +0-+- 000000000
        -+-+- 000000000
        0+-+- 000000000
        ++-+- 000000000
        --0+- 000000000
        0-0+- 000000000
        +-0+- 000000000
        -00+- 000000000
        000+- 000000000
        +00+- 000000000
        -+0+- 000000000
        0+0+- 000000000
        ++0+- 000000000
        --++- 000000000
        0-++- 000000000
        +-++- 000000000
        -0++- 000000000
        00++- 000000000
        +0++- 000000000
        -+++- 000000000
        0+++- 000000000
        ++++- 000000000
    """;
}