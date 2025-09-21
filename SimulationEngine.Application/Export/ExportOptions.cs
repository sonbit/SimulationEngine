using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Application.Export;

public sealed class ExportOptions
{
    public string SubCircuitPrefix { get; init; } = "c_";
    public string LogicGatesPrefix { get; init; } = "f_";
    public bool EmitSingleFile { get; init; } = true;
}