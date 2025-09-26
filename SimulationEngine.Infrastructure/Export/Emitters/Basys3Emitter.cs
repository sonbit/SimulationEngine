using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using System;
using System.Text;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public class Basys3Emitter : IXdcEmitter
{
    private static readonly string[] LedPins = ["U16", "E19", "U19", "V19", "W18", "U15", "U14", "V14", "V13", "V3", "W3", "U3", "P3", "N3", "P1", "L1"];
    private static readonly string[] SwitchPins = ["V17", "V16", "W16", "W17", "W15", "V15", "W14", "W13", "V2", "T3", "T2", "R3", "W2", "U1", "T1", "R2"];
    
    private static readonly string[] AnPins = ["U2", "U4", "V4", "W4"];
    private const string DpPin = "V7";
    private static readonly string[] SegPins = ["W7", "W6", "U8", "V8", "U5", "V5", "U7"];
    
    public string EmitSubCircuit(SubCircuit subCircuit)
    {
        int switchIndex = 0;
        var ledIndex = 0;

        var builder = new StringBuilder();

        builder.AppendLine("## 100 MHz clock (Basys3)");
        builder.AppendLine("set_property -dict { PACKAGE_PIN W5 IOSTANDARD LVCMOS33 } [get_ports clk100]");
        builder.AppendLine("create_clock -add -name sys_clk_pin -period 10.00 -waveform {0 5} [get_ports clk100]");

        builder.AppendLine("## Switches");
        foreach (var port in subCircuit.Inputs)
        {
            if (port.IsBinary())
            {
                EnsureRemainingBoardPins(switchIndex < SwitchPins.Length);
                builder.AppendLine($"set_property -dict {{ PACKAGE_PIN {SwitchPins[switchIndex]} IOSTANDARD LVCMOS33 }} [get_ports {{{port.Title}}}]");
                switchIndex += 1;
            }
            else
            {
                EnsureRemainingBoardPins(switchIndex + 1 < SwitchPins.Length);
                builder.AppendLine($"set_property -dict {{ PACKAGE_PIN {SwitchPins[switchIndex]} IOSTANDARD LVCMOS33 }} [get_ports {{{port.Title}[0]}}]");
                builder.AppendLine($"set_property -dict {{ PACKAGE_PIN {SwitchPins[switchIndex + 1]} IOSTANDARD LVCMOS33 }} [get_ports {{{port.Title}[1]}}]");
                switchIndex += 2;
            }
        }

        builder.AppendLine();
        builder.AppendLine("## LEDs");
        foreach (var port in subCircuit.Outputs)
        {
            if (port.IsBinary())
            {
                EnsureRemainingBoardPins(ledIndex < LedPins.Length);
                builder.AppendLine($"set_property -dict {{ PACKAGE_PIN {LedPins[ledIndex]} IOSTANDARD LVCMOS33 }} [get_ports {{{port.Title}}}]");
                ledIndex += 1;
            }
            else
            {
                EnsureRemainingBoardPins(ledIndex + 1 < LedPins.Length);
                builder.AppendLine($"set_property -dict {{ PACKAGE_PIN {LedPins[ledIndex]} IOSTANDARD LVCMOS33 }} [get_ports {{{port.Title}[0]}}]");
                builder.AppendLine($"set_property -dict {{ PACKAGE_PIN {LedPins[ledIndex + 1]} IOSTANDARD LVCMOS33 }} [get_ports {{{port.Title}[1]}}]");
                ledIndex += 2;
            }
        }

        builder.AppendLine();
        builder.AppendLine("## Configuration options, can be used for all designs");
        builder.AppendLine("set_property CONFIG_VOLTAGE 3.3 [current_design]");
        builder.AppendLine("set_property CFGBVS VCCO [current_design]");

        builder.AppendLine();
        builder.AppendLine("## SPI configuration mode options for QSPI boot, can be used for all designs");
        builder.AppendLine("set_property BITSTREAM.GENERAL.COMPRESS TRUE [current_design]");
        builder.AppendLine("set_property BITSTREAM.CONFIG.CONFIGRATE 33 [current_design]");
        builder.AppendLine("set_property CONFIG_MODE SPIx4 [current_design]");
        
        builder.AppendLine();
        builder.Append("## Reference https://github.com/Digilent/digilent-xdc/blob/master/Basys-3-Master.xdc");

        return builder.ToString();
    }

    private static void EnsureRemainingBoardPins(bool condition)
    {
        if (!condition) 
            throw new InvalidOperationException("Not enough board pins for this mapping.");
    }
}