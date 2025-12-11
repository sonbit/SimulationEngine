using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Designs.REBEL2.Control;

public class MuxControl : Subcircuit
{
    public Port Op1 => Inputs[0];
    public Port Op0 => Inputs[1];
    public Port Rd21 => Inputs[2];
    public Port Rd20 => Inputs[3];
    public Port Cmp => Inputs[4];

    public Port AluAMux => Outputs[0];
    public Port AluBMux => Outputs[1];
    public Port ProgCtr => Outputs[2];
    public Port AddAMux => Outputs[3];
    public Port AddBMux => Outputs[4];
    public Port WrEnable => Outputs[5];

    public MuxControl()
    {
        this.AddInputs(
            nameof(Op1),
            nameof(Op0),
            nameof(Rd21),
            nameof(Rd20),
            nameof(Cmp));

        this.AddOutputs(
            nameof(AluAMux),
            nameof(AluBMux),
            nameof(ProgCtr),
            nameof(AddAMux),
            nameof(AddBMux),
            nameof(WrEnable));

        var _ZZDDDDXXX = this.AddLogicGate("ZZDDDDXXX");
        var _R4D = this.AddLogicGate("R4D");
        var _9VZ = this.AddLogicGate("9VZ");
        var _4RD = this.AddLogicGate("4RD");
        var _ZHZ = this.AddLogicGate("ZHZ");
        var _CVV = this.AddLogicGate("CVV");
        var _PPK = this.AddLogicGate("PPK");
        var _RH8 = this.AddLogicGate("RH8");

        
       
       
        this.AddWires([
            //inputs to gates
            (Op1, _R4D.B),
            (Op0, _R4D.A),

            (Op1, _9VZ.B),
            (Op0, _9VZ.A),
            
            (Op1, _4RD.B),
            (Op0, _4RD.A),

            (Op1, _ZHZ.B),
            (Op0, _ZHZ.A),

             //RD(2)1 is not connected
            //(Rd1, ???),
            
            (Rd20, _CVV.A),
            (Rd20, _PPK.A),
            (Rd20, _ZZDDDDXXX.B),

            (Cmp, _RH8.A),  
            (Cmp, _ZZDDDDXXX.A),  
            
            //gate 1st column
            (_R4D.Q, _CVV.B),
            (_R4D.Q, AluAMux),
            
            (_9VZ.Q, _PPK.B),
           
            (_4RD.Q, _ZZDDDDXXX.C),
            (_4RD.Q, _RH8.B),

            (_ZHZ.Q, WrEnable),

            //gate 2nd column
             (_CVV.Q, AddAMux),

             (_PPK.Q, AluBMux),

             (_ZZDDDDXXX.Q, ProgCtr),

             (_RH8.Q, AddBMux),

        ]);
    }
}
