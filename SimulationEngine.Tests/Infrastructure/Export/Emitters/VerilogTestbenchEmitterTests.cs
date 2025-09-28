using SimulationEngine.Designs.REBEL2.ALU;
using SimulationEngine.Designs.REBEL2.Decode;
using SimulationEngine.Designs.REBEL2.Fetch;
using SimulationEngine.Designs.SubCircuits.Memory;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.Export.Emitters;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Infrastructure.Export.Emitters;

public class VerilogTestbenchEmitterTests(ITestOutputHelper testOutputHelper) : BaseEmitterTest(testOutputHelper)
{
    [Fact]
    public void ALU2_Validate() => BaseTestbenchValidate(new ALU2(), "Baselines/REBEL2/ALU2/ALU2_TB_Expected.v");

    [Fact]
    public void Decode_Validate() => BaseTestbenchValidate(new Decode(), "Baselines/REBEL2/Decode_TB_Expected.v");

    [Fact]
    public void Fetch_Validate() => BaseTestbenchValidate(new Fetch(), "Baselines/REBEL2/Fetch_TB_Expected.v");

    [Fact]
    public void Register9_Validate() => BaseTestbenchValidate(new Register9(), "Baselines/Register9/Register9_TB_Expected.v");

    private void BaseTestbenchValidate(SubCircuit subCircuit, string filePath, bool skipEvaluation = false)
    {
        var output = new VerilogTestbenchEmitter().EmitTestbench(subCircuit, subCircuit.GetTestString()).Trim();
        Validate(filePath, output, skipEvaluation);
    }
}