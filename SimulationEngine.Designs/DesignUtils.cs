using SimulationEngine.Domain.Models;
using System.Reflection;

namespace SimulationEngine.Designs;

public static class DesignUtils
{
    public static string? GetTestString(string subcircuitTitle)
    {
        if (string.IsNullOrWhiteSpace(subcircuitTitle))
            return null;

        var type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(type => 
                typeof(Subcircuit).IsAssignableFrom(type) && 
                type.Name.Contains(subcircuitTitle));

        if (type == null || (Subcircuit?)Activator.CreateInstance(type) is not Subcircuit subcircuit)
            return null;

        return subcircuit.GetTestString();
    }
}