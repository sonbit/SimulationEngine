using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public class Basys3Emitter : IXdcEmitter
{
    private static readonly string[] SwitchPins = ["V17", "V16", "W16", "W17", "W15", "V15", "W14", "W13", "V2", "T3", "T2", "R3", "W2", "U1", "T1", "R2"];
    private static readonly string[] LedPins = ["U16", "E19", "U19", "V19", "W18", "U15", "U14", "V14", "V13", "V3", "W3", "U3", "P3", "N3", "P1", "L1"];
    private static readonly string[] ButtonPins = ["T18", "V18", "V17", "W19", "T17"];

    public string EmitSubCircuit(SubCircuit subCircuit)
    {
        int switchIndex = 0;
        var ledIndex = 0;

        var sb = new StringBuilder();
        sb.AppendLine("## Switches");

        foreach (var port in subCircuit.Inputs)
        {
            if (port.IsBinary())
            {
                Assert(switchIndex < SwitchPins.Length);
                sb.AppendLine($"set_property -dict {{ PACKAGE_PIN {SwitchPins[switchIndex]} IOSTANDARD LVCMOS33 }} [get_ports {{{San(port.Title)}}}]");
                switchIndex += 1;
            }
            else
            {
                Assert(switchIndex + 1 < SwitchPins.Length);
                sb.AppendLine($"set_property -dict {{ PACKAGE_PIN {SwitchPins[switchIndex]} IOSTANDARD LVCMOS33 }} [get_ports {{{San(port.Title)}[0]}}]");
                sb.AppendLine($"set_property -dict {{ PACKAGE_PIN {SwitchPins[switchIndex + 1]} IOSTANDARD LVCMOS33 }} [get_ports {{{San(port.Title)}[1]}}]");
                switchIndex += 2;
            }
        }

        sb.AppendLine();
        sb.AppendLine("## LEDs");

        foreach (var port in subCircuit.Outputs)
        {
            if (port.IsBinary())
            {
                Assert(ledIndex < LedPins.Length);
                sb.AppendLine($"set_property -dict {{ PACKAGE_PIN {LedPins[ledIndex]} IOSTANDARD LVCMOS33 }} [get_ports {{{San(port.Title)}}}]");
                ledIndex += 1;
            }
            else
            {
                Assert(ledIndex + 1 < LedPins.Length);
                sb.AppendLine($"set_property -dict {{ PACKAGE_PIN {LedPins[ledIndex]} IOSTANDARD LVCMOS33 }} [get_ports {{{San(port.Title)}[0]}}]");
                sb.AppendLine($"set_property -dict {{ PACKAGE_PIN {LedPins[ledIndex + 1]} IOSTANDARD LVCMOS33 }} [get_ports {{{San(port.Title)}[1]}}]");
                ledIndex += 2;
            }
        }

        sb.AppendLine();
        sb.AppendLine("## Configuration options, can be used for all designs");
        sb.AppendLine("set_property CONFIG_VOLTAGE 3.3 [current_design]");
        sb.AppendLine("set_property CFGBVS VCCO [current_design]");

        sb.AppendLine();
        sb.AppendLine("## SPI configuration mode options for QSPI boot, can be used for all designs");
        sb.AppendLine("set_property BITSTREAM.GENERAL.COMPRESS TRUE [current_design]");
        sb.AppendLine("set_property BITSTREAM.CONFIG.CONFIGRATE 33 [current_design]");
        sb.AppendLine("set_property CONFIG_MODE SPIx4 [current_design]");
        
        sb.AppendLine();
        sb.Append("## Reference https://github.com/Digilent/digilent-xdc/blob/master/Basys-3-Master.xdc");

        return sb.ToString();
    }

    private static void Assert(bool condition)
    {
        if (!condition) 
            throw new InvalidOperationException("Not enough board pins for this mapping.");
    }

    private static string San(string s) => Regex.Replace(s ?? "p", @"[^A-Za-z0-9_]", "_");
}