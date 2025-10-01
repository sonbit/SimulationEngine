using System.Text;

namespace SimulationEngine.Application.Export.Emitters.Models;

public record Verilog
{
    public List<VerilogModule> SubCircuitModules { get; set; } = [];
    public List<VerilogModule> LogicGateModules { get; set; } = [];

    public string GetAllModules()
    {
        var builder = new StringBuilder();

        foreach (var subCircuit in SubCircuitModules)
            builder.AppendLine(subCircuit.Content).AppendLine();

        foreach (var logicGate in LogicGateModules)
            builder.AppendLine(logicGate.Content).AppendLine();

        var newLineLength = Environment.NewLine.Length * 2;
        builder.Remove(builder.Length - newLineLength, newLineLength);

        return builder.ToString();
    }
}