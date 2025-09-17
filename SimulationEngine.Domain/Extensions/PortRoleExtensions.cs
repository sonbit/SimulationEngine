using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Domain.Extensions;

public static class PortRoleExtensions
{
    public static bool IsInput(this PortRole role) => role.ToString().StartsWith(nameof(PortRole.In0)[..2]);

    public static bool IsOutput(this PortRole role) => role.ToString().StartsWith(nameof(PortRole.Out0)[..3]);
}