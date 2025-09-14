namespace SimulationEngine.Cli.Handlers.IO;

public interface IInputOutput
{
    int AskId(string title);
    Task<bool> ConfirmAsync(string prompt, bool defaultValue = true);
    Task<List<T>> MultiSelectAsync<T>(string title, IEnumerable<T> choices) where T : notnull;
    Task<string> PromptAsync(string prompt);
    Task<string> PromptValidateAsync(string prompt, bool required = true);
    Task<T> SelectAsync<T>(string title, IEnumerable<T> choices) where T : notnull;
    T? SelectOrBack<T>(string title, IEnumerable<T> choices, Func<T, string> label);
}
