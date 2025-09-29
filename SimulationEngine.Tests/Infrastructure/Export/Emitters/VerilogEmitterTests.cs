using SimulationEngine.Designs.REBEL2.ALU;
using SimulationEngine.Designs.REBEL2.Decode;
using SimulationEngine.Designs.REBEL2.Fetch;
using SimulationEngine.Designs.SubCircuits.Memory;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.Exporters.Verilog;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Infrastructure.Export.Emitters;

public class VerilogEmitterTests(ITestOutputHelper testOutputHelper) : BaseEmitterTest(testOutputHelper)
{
    [Fact]
    public void ALU2_Validate() => BaseVerilogValidate(new ALU2(), "Baselines/REBEL2/ALU2/ALU2_Expected.txt");

    [Fact]
    public void Decode_Validate() => BaseVerilogValidate(new Decode(), "Baselines/REBEL2/Decode_Expected.txt");

    [Fact]
    public void Fetch_Validate() => BaseVerilogValidate(new Fetch(), "Baselines/REBEL2/Fetch_Expected.txt");

    [Fact]
    public void Register9_Validate() => BaseVerilogValidate(new Register9(), "Baselines/Register9/Register9_Expected.txt");

    private void BaseVerilogValidate(SubCircuit subCircuit, string filePath, bool skipEvaluation = false)
    {
        var output = new VerilogEmitter().EmitSubCircuit(subCircuit).Trim();
        Validate(filePath, output, skipEvaluation);
    }
}