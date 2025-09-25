using SimulationEngine.Domain.Models;
using System.Reflection;

namespace SimulationEngine.Designs;

public static class DesignUtils
{
    public static string? GetTestString(string subCircuitTitle)
    {
        var type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(type => 
                typeof(SubCircuit).IsAssignableFrom(type) && 
                type.Name.Contains(subCircuitTitle));

        if (type == null || (SubCircuit?)Activator.CreateInstance(type) is not SubCircuit subCircuit)
            return null;

        return subCircuit.GetTestString();
    }
}