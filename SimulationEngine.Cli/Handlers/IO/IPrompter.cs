namespace SimulationEngine.Cli.Handlers.IO;

public interface IPrompter
{
    Task<string> AskAsync(string title);
    Task<int> AskIdAsync(string title);
    Task<int> AskPositiveIntAsync(string title, int defaultValue = 10);
    Task<FileInfo?> PickFileAsync(string title, string startDir, string searchPattern = "*.*");
    Task<TEnum> SelectEnumAsync<TEnum>(string title) where TEnum : struct, Enum;
    Task<T?> SelectOrBackAsync<T>(string title, List<T> choices, Func<T, string> label, string emptyMessage = "") where T : notnull;
}
