using System.Security.Cryptography;
using SimulationEngine.Designs.REBEL2.ALU;
using SimulationEngine.Designs.REBEL2.Control;
using SimulationEngine.Designs.REBEL2.Fetch;
using SimulationEngine.Designs.Subcircuits.Adders;
using SimulationEngine.Designs.Subcircuits.Memory;
using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2;

public class REBEL2 : Subcircuit
{
    public Port Clk => Inputs[0];
    public Port WrInst => Inputs[1];
    public Port WrData9 => Inputs[2];
    public Port WrData8 => Inputs[3];
    public Port WrData7 => Inputs[4];
    public Port WrData6 => Inputs[5];
    public Port WrData5 => Inputs[6];
    public Port WrData4 => Inputs[7];
    public Port WrData3 => Inputs[8];
    public Port WrData2 => Inputs[9];
    public Port WrData1 => Inputs[10];
    public Port WrData0 => Inputs[11];

    public Subcircuit ProgramCounter => Subcircuits[0];
    public Subcircuit ROM => Subcircuits[1];
    public Subcircuit CPUControl => Subcircuits[2];
    public Subcircuit RAM => Subcircuits[3].Subcircuits[1];
    public Subcircuit ALU => Subcircuits[8];
    public Subcircuit WrAdd => Subcircuits[9];

    public REBEL2()
    {
        this.AddBinaryInputs(
            nameof(Clk), 
            nameof(WrInst));
        this.AddInputs(
            nameof(WrData9), 
            nameof(WrData8), 
            nameof(WrData7), 
            nameof(WrData6),
            nameof(WrData5), 
            nameof(WrData4), 
            nameof(WrData3), 
            nameof(WrData2),
            nameof(WrData1), 
            nameof(WrData0));

        var _K00 = this.AddLogicGate("K00");
        var _200 = this.AddLogicGate("200");

        var prog_ctr = this.AddSubcircuit(new ProgCtr2());
        var instr_reg = this.AddSubcircuit(new _9Rom10());
        var cpuControl = this.AddSubcircuit(new CPUControl());
        var ram = this.AddSubcircuit(new _9Ram2());
        var alu_a_mux = this.AddSubcircuit(new _2MUX2());
        var alu_b_mux = this.AddSubcircuit(new _3MUX2());
        var add_a_mux = this.AddSubcircuit(new _2MUX2());
        var add_b_mux = this.AddSubcircuit(new _3MUX2());
        var alu = this.AddSubcircuit(new ALU2());
        var wr_add = this.AddSubcircuit(new _2TritAdder()); // Ignore Carry

        var hardwired00 = this.AddLogicGate("ZTZDDD030");
        var hardwired01 = this.AddLogicGate("ZTZDDD030");
        var hardwired10 = this.AddLogicGate("ZTZDDD030");
        var hardwired11 = this.AddLogicGate("ZTZDDD030");

        this.AddWires([

            (instr_reg.Rs11, hardwired01.A),
            (instr_reg.Rs10, hardwired01.B),
            (instr_reg.Rs11, hardwired00.A),
            (instr_reg.Rs10, hardwired00.B),

            (instr_reg.Rs21, hardwired11.A),
            (instr_reg.Rs20, hardwired11.B),
            (instr_reg.Rs21, hardwired10.A),
            (instr_reg.Rs20, hardwired10.B),

            (ram.RdData20, hardwired00.C),
            (ram.RdData21, hardwired01.C),
            (ram.RdData10, hardwired10.C),
            (ram.RdData11, hardwired11.C),

            (Clk, prog_ctr.Clk),
            (cpuControl.Prog_Ctr, prog_ctr.LdEn),
            (wr_add.Q1, prog_ctr.LdAddr1),
            (wr_add.Q0, prog_ctr.LdAddr0),

            (WrInst, _K00.B),
            (Clk, _K00.A),

            (WrInst , _200.B),
            (Clk , _200.A),

            (_K00.Q, instr_reg.Clk),
            (prog_ctr.Pc1, instr_reg.RdAddr1),
            (prog_ctr.Pc0, instr_reg.RdAddr0),
            (prog_ctr.Pc1, instr_reg.WrAddr1),
            (prog_ctr.Pc0, instr_reg.WrAddr0),
            (WrData9, instr_reg.WrData9),
            (WrData8, instr_reg.WrData8),
            (WrData7, instr_reg.WrData7),
            (WrData6, instr_reg.WrData6),
            (WrData5, instr_reg.WrData5),
            (WrData4, instr_reg.WrData4),
            (WrData3, instr_reg.WrData3),
            (WrData2, instr_reg.WrData2),
            (WrData1, instr_reg.WrData1),
            (WrData0, instr_reg.WrData0),

            (instr_reg.Op1, cpuControl.Op1),
            (instr_reg.Op0, cpuControl.Op0),
            (instr_reg.Rd21, cpuControl.Rd21),
            (instr_reg.Rd20, cpuControl.Rd20),
            (alu.Q0, cpuControl.Cmp),

            (_200.Q, ram.Clk),
            (instr_reg.Rs11, ram.RdAddr11),
            (instr_reg.Rs10, ram.RdAddr10),
            (instr_reg.Rs21, ram.RdAddr21),
            (instr_reg.Rs20, ram.RdAddr20),
            (instr_reg.Rd11, ram.WrAddr1),
            (instr_reg.Rd10, ram.WrAddr0),
            (cpuControl.Wb_Ctr, ram.WrEnable),

            (cpuControl.Alu_A_Mux_Ctrl, alu_a_mux.Sel),
            (prog_ctr.Pc1, alu_a_mux.B1),
            (prog_ctr.Pc0, alu_a_mux.B0),
            (hardwired11.Q, alu_a_mux.A1),
            (hardwired10.Q, alu_a_mux.A0),

            (cpuControl.Alu_B_Mux_Ctrl, alu_b_mux.Sel),
            (hardwired01.Q, alu_b_mux.C1),
            (hardwired00.Q, alu_b_mux.C0),
            //(, alu_b_mux.B1), // Always 0 - Not necessary to handle, heptaindex independent of B
            //(, alu_b_mux.B0), // Always 1 - Not necessary to handle, heptaindex independent of B
            (instr_reg.Rs21, alu_b_mux.A1),
            (instr_reg.Rs20, alu_b_mux.A0),

            (cpuControl.Add_A_Mux_Ctrl, add_a_mux.Sel),
            (ram.RdData11, add_a_mux.B1),
            (ram.RdData10, add_a_mux.B0),
            (prog_ctr.Pc1, add_a_mux.A1),
            (prog_ctr.Pc0, add_a_mux.A0),

            (cpuControl.Add_B_Mux_Ctrl, add_b_mux.Sel),
            (instr_reg.Rs21, add_b_mux.C1),
            (instr_reg.Rs20, add_b_mux.C0),
            (instr_reg.Rd11, add_b_mux.B1),
            (instr_reg.Rd10, add_b_mux.B0),
            (instr_reg.Rd21, add_b_mux.A1),
            (instr_reg.Rd20, add_b_mux.A0),

            (cpuControl.Alu_Func2, alu.Func2),
            (cpuControl.Alu_Func1, alu.Func1),
            (cpuControl.Alu_Func0, alu.Func0),
            (alu_a_mux.Q1, alu.B1),
            (alu_a_mux.Q0, alu.B0),
            (alu_b_mux.Q1, alu.A1),
            (alu_b_mux.Q0, alu.A0),

            (add_a_mux.Q1, wr_add.B1),
            (add_a_mux.Q0, wr_add.B0),
            (add_b_mux.Q1, wr_add.A1),
            (add_b_mux.Q0, wr_add.A0),
           
            //(alu.Cout, ), 
            (alu.Q1, ram.WrData1),
            (alu.Q0, ram.WrData0),
        ]);
    }

    // Handled by a custom test
    //public override string GetTestString() => """

    //""";
}