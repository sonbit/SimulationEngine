using SimulationEngine.Domain.Models;
using System.Collections.Concurrent;
using System.Reflection;

namespace SimulationEngine.Designs;

public static class DesignUtils
{
    private static readonly ConcurrentDictionary<string, string> RuntimeTestStrings =
        new(StringComparer.OrdinalIgnoreCase);

    public static void RegisterTestString(string subcircuitTitle, string testString)
    {
        if (string.IsNullOrWhiteSpace(subcircuitTitle) || string.IsNullOrWhiteSpace(testString))
            return;

        RuntimeTestStrings[subcircuitTitle] = testString;
    }

    public static void UnregisterTestString(string subcircuitTitle)
    {
        if (string.IsNullOrWhiteSpace(subcircuitTitle))
            return;

        RuntimeTestStrings.TryRemove(subcircuitTitle, out _);
    }

    public static string? GetTestString(string subcircuitTitle)
    {
        if (string.IsNullOrWhiteSpace(subcircuitTitle))
            return null;

        if (RuntimeTestStrings.TryGetValue(subcircuitTitle, out var runtimeTest))
            return runtimeTest;

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
