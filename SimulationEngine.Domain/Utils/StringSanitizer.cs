using System.Text.RegularExpressions;

namespace SimulationEngine.Domain.Utils;

public static partial class StringSanitizer
{
    public static string Sanitize(string str) => str != null ? Regex().Replace(str, "_") : string.Empty;
    [GeneratedRegex(@"[^A-Za-z0-9_]")] private static partial Regex Regex();
}