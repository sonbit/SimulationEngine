namespace SimulationEngine.Application.Export.Emitters.Models;

public record VerilogModule
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}