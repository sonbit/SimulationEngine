namespace SimulationEngine.Cli.IO;

public interface IInputOutput
{
    Task<int> AskIdAsync(string title);
    Task<bool> ConfirmAsync(string prompt, bool defaultValue = true);
    Task<FileInfo?> PickFileAsync(string title, string startDir, string searchPattern = "*.*");
    Task<string> PromptAsync(string prompt);
    Task<string> PromptValidateAsync(string prompt, bool required = true);
    Task<TEnum> SelectEnumAsync<TEnum>(string title) where TEnum : struct, Enum;
    T? SelectOrBack<T>(string title, IEnumerable<T> choices, Func<T, string> label, string emptyMessage = "") where T : notnull;
}