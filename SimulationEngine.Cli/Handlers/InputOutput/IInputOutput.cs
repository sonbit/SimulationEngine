namespace SimulationEngine.Cli.Handlers.InputOutput;

public interface IInputOutput
{
    int AskId(string title);
    Task<bool> ConfirmAsync(string prompt, bool defaultValue = true);
    Task<string> PromptAsync(string prompt);
    Task<string> PromptValidateAsync(string prompt, bool required = true);
    T? SelectOrBack<T>(string title, IEnumerable<T> choices, Func<T, string> label) where T : notnull;
}