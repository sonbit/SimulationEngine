using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public partial class Basys3Emitter
{
    private static readonly string[] LedPinsReversedAndPairwiseFlipped = 
        ["P1","L1","P3","N3","W3","U3","V13","V3","U14","V14","W18","U15","U19","V19","U16","E19"];
    private static readonly string[] SwitchPinsReversedAndPairwiseFlipped = 
        ["T1","R2","W2","U1","T2","R3","V2","T3","W14","W13","W15","V15","W16","W17","V17","V16"];
    private static readonly string[] SegPinsReversed = ["U7","V5","U5","V8","U8","W6","W7"];

    public string EmitXdc(SubCircuit subCircuit, bool include7SegmentDisplay = false)
    {
        (var inputBits, var outputBits) = ValidateAndReturnBits(subCircuit);

        Builder.Clear();

        Builder.AppendLine("## Pins have been reversed, and leds and switches are pairwise flipped due to 2 bits to 1 trit mapping and ordering");
        Builder.AppendLine().AppendLine();

        if (include7SegmentDisplay)
            AddClock();

        Builder.AppendLine("## Switches");
        for (var i = 0; i < inputBits; i++)
            Builder.AppendLine($"set_property -dict {{ PACKAGE_PIN {SwitchPinsReversedAndPairwiseFlipped[i]} IOSTANDARD LVCMOS33 }} [get_ports {{sw[{i}]}}]");
        Builder.AppendLine().AppendLine();

        Builder.AppendLine("## LEDs");
        for (var i = 0; i < outputBits; i++)
            Builder.AppendLine($"set_property -dict {{ PACKAGE_PIN {LedPinsReversedAndPairwiseFlipped[i]} IOSTANDARD LVCMOS33 }} [get_ports {{led[{i}]}}]");
        Builder.AppendLine().AppendLine();

        if (include7SegmentDisplay)
            Add7SegmentDisplayPins();

        Builder.AppendLine("## Configuration options, can be used for all designs");
        Builder.AppendLine("set_property CONFIG_VOLTAGE 3.3 [current_design]");
        Builder.AppendLine("set_property CFGBVS VCCO [current_design]");
        Builder.AppendLine();

        Builder.AppendLine("## SPI configuration mode options for QSPI boot, can be used for all designs");
        Builder.AppendLine("set_property BITSTREAM.GENERAL.COMPRESS TRUE [current_design]");
        Builder.AppendLine("set_property BITSTREAM.CONFIG.CONFIGRATE 33 [current_design]");
        Builder.AppendLine("set_property CONFIG_MODE SPIx4 [current_design]");
        Builder.AppendLine().AppendLine();

        Builder.Append("## Reference https://github.com/Digilent/digilent-xdc/blob/master/Basys-3-Master.xdc");

        return Builder.ToString();
    }

    private void Add7SegmentDisplayPins()
    {
        Builder.AppendLine("## 7 Segment Display");

        for (var i = 0; i < SegPinsReversed.Length; i++)
            Builder.AppendLine($"set_property -dict {{ PACKAGE_PIN {SegPinsReversed[i]} IOSTANDARD LVCMOS33 }} [get_ports {{seg[{i}]}}]");
        Builder.AppendLine();

        Builder.AppendLine("set_property -dict { PACKAGE_PIN V7   IOSTANDARD LVCMOS33 } [get_ports dp]");
        Builder.AppendLine();

        Builder.AppendLine("set_property -dict { PACKAGE_PIN U2   IOSTANDARD LVCMOS33 } [get_ports {an[0]}]");
        Builder.AppendLine("set_property -dict { PACKAGE_PIN U4   IOSTANDARD LVCMOS33 } [get_ports {an[1]}]");
        Builder.AppendLine("set_property -dict { PACKAGE_PIN V4   IOSTANDARD LVCMOS33 } [get_ports {an[2]}]");
        Builder.AppendLine("set_property -dict { PACKAGE_PIN W4   IOSTANDARD LVCMOS33 } [get_ports {an[3]}]");
        Builder.AppendLine().AppendLine();
    }

    private void AddClock()
    {
        Builder.AppendLine("## Clock signal");
        Builder.AppendLine("set_property -dict { PACKAGE_PIN W5 IOSTANDARD LVCMOS33 } [get_ports clk]");
        Builder.AppendLine("create_clock -add -name sys_clk_pin -period 10.00 -waveform {0 5} [get_ports clk]");
        Builder.AppendLine().AppendLine();
    }
}