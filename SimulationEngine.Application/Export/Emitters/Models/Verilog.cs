using System.Text;

namespace SimulationEngine.Application.Export.Emitters.Models;

public record Verilog
{
    public List<VerilogModule> SubcircuitModules { get; set; } = [];
    public List<VerilogModule> LogicGateModules { get; set; } = [];

    public string GetAllModules()
    {
        var builder = new StringBuilder();

        foreach (var subcircuit in SubcircuitModules)
            builder.AppendLine(subcircuit.Content).AppendLine();

        foreach (var logicGate in LogicGateModules)
            builder.AppendLine(logicGate.Content).AppendLine();

        var newLineLength = Environment.NewLine.Length * 2;
        builder.Remove(builder.Length - newLineLength, newLineLength);

        return builder.ToString();
    }
}