using SimulationEngine.Designs.REBEL2.ALU;
using SimulationEngine.Designs.REBEL2.Decode;
using SimulationEngine.Designs.REBEL2.Fetch;
using SimulationEngine.Designs.SubCircuits.Memory;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.Export.Emitters;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Infrastructure.Export.Emitters;

public class Basys3EmitterTests(ITestOutputHelper testOutputHelper) : BaseEmitterTest(testOutputHelper)
{
    [Fact]
    public void ALU2_Top_7Seg_Validate() => BaseTopValidate(new ALU2(), "Baselines/REBEL2/ALU2/ALU2_Top_7Seg_Expected.txt", true);

    [Fact]
    public void ALU2_Top_Validate() => BaseTopValidate(new ALU2(), "Baselines/REBEL2/ALU2/ALU2_Top_Expected.txt", false);

    [Fact]
    public void ALU2_Xdc_7Seg_Validate() => BaseXdcValidate(new ALU2(), "Baselines/REBEL2/ALU2/ALU2_Xdc_7Seg_Expected.txt", true);

    [Fact]
    public void ALU2_Xdc_Validate() => BaseXdcValidate(new ALU2(), "Baselines/REBEL2/ALU2/ALU2_Xdc_Expected.txt", false);

    [Fact]
    public void Decode_Validate_ThrowsError() => 
        Assert.Throws<InvalidOperationException>(() => new Basys3Emitter().EmitTopModule(new Decode(), false));

    [Fact]
    public void Decode_Xdc_Validate_ThrowsError() =>
        Assert.Throws<InvalidOperationException>(() => new Basys3Emitter().EmitXdc(new Decode(), false));

    [Fact]
    public void Emit_7Seg_Display_Module() => Validate("Baselines/SevenSegment_Expected.txt", 
        new Basys3Emitter().Emit7SegmentDisplayModule().Content.Trim());

    [Fact]
    public void Fetch_Validate_ThrowsError() =>
        Assert.Throws<InvalidOperationException>(() => new Basys3Emitter().EmitTopModule(new Fetch(), false));

    [Fact]
    public void Fetch_Xdc_Validate_ThrowsError() =>
        Assert.Throws<InvalidOperationException>(() => new Basys3Emitter().EmitXdc(new Fetch(), false));

    [Fact]
    public void Register9_Top_7Seg_Validate() => BaseTopValidate(new Register9(), "Baselines/Register9/Register9_Top_7Seg_Expected.txt", true);

    [Fact]
    public void Register9_Top_Validate() => BaseTopValidate(new Register9(), "Baselines/Register9/Register9_Top_Expected.txt", false);

    [Fact]
    public void Register9_Xdc_7Seg_Validate() => BaseXdcValidate(new Register9(), "Baselines/Register9/Register9_Xdc_7Seg_Expected.txt", true);

    [Fact]
    public void Register9_Xdc_Validate() => BaseXdcValidate(new Register9(), "Baselines/Register9/Register9_Xdc_Expected.txt", false);

    private void BaseTopValidate(SubCircuit subCircuit, string filePath, bool include7SegmentDisplay, bool skipEvaluation = false)
    {
        var output = new Basys3Emitter().EmitTopModule(subCircuit, include7SegmentDisplay).Content.Trim();
        Validate(filePath, output, skipEvaluation);
    }

    private void BaseXdcValidate(SubCircuit subCircuit, string filePath, bool include7SegmentDisplay, bool skipEvaluation = false)
    {
        var output = new Basys3Emitter().EmitXdc(subCircuit, include7SegmentDisplay).Trim();
        Validate(filePath, output, skipEvaluation);
    }
}