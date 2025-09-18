using SimulationEngine.Designs.REBEL2.ALU;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Designs.REBEL2;

public class REBEL2 : SubCircuit
{


    public REBEL2()
    {
        var fetch = new Fetch.Fetch();
        var decode = new Decode.Decode();
        var alu = new ALU2();
        SubCircuits = [fetch, decode, alu];

        this.AddWires([
            (fetch.Pc1, decode.Pc1),
            (fetch.Pc0, decode.Pc0),
            (fetch.Op1, decode.Op1),
            (fetch.Op0, decode.Op0),
            (fetch.Rs11, decode.Rs11),
            (fetch.Rs10, decode.Rs10),
            (fetch.Rs01, decode.Rs01),
            (fetch.Rs00, decode.Rs00),
            (fetch.Rd11, decode.Rd11),
            (fetch.Rd10, decode.Rd10),
            (fetch.Rd01, decode.Rd01),
            (fetch.Rd00, decode.Rd00),

            (decode.AluCtrl2, alu.Func2),
            (decode.AluCtrl1, alu.Func1),
            (decode.AluCtrl0, alu.Func0),
            (decode.Reg11, alu.A1),

            ]);
    }
}
