using Spectre.Console;
using System.Threading.Tasks;

namespace SimulationEngine.Cli.Handlers.IO;

public sealed class InputOutput(IAnsiConsole console) : IInputOutput
{
    public Task<bool> ConfirmAsync(string prompt, bool defaultValue = true) =>
        console.PromptAsync(new ConfirmationPrompt(prompt) { DefaultValue = defaultValue });

    public Task<string> PromptAsync(string prompt) =>
        console.PromptAsync(new TextPrompt<string>(prompt));

    public Task<List<T>> MultiSelectAsync<T>(string title, IEnumerable<T> choices) where T : notnull =>
        console.PromptAsync(new MultiSelectionPrompt<T>().Title(title).AddChoices(choices));

    public Task<string> PromptValidateAsync(string prompt, bool required = true) =>
        console.PromptAsync(new TextPrompt<string>(prompt).Validate(v =>
            !required || !string.IsNullOrWhiteSpace(v)
                ? ValidationResult.Success()
                : ValidationResult.Error("Required")));

    public Task<T> SelectAsync<T>(string title, IEnumerable<T> choices) where T : notnull =>
        console.PromptAsync(new SelectionPrompt<T>().Title(title).AddChoices(choices));

    public T? SelectOrBack<T>(string title, IEnumerable<T> choices, Func<T, string> label) where T : notnull
    {
        var items = choices.ToList();
        if (items.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]No items.[/]");
            return default;
        }

        var prompt = new SelectionPrompt<object>()
            .Title(title)
            .AddChoices(items.Cast<object>().Append("Back"))
            .UseConverter(o => o is T t ? label(t) : o.ToString()!);

        var choice = AnsiConsole.Prompt(prompt);
        return choice is T tVal ? tVal : default;
    }

    public int AskId(string title)
    {
        var txt = AnsiConsole.Prompt(
            new TextPrompt<string>(title)
                .ValidationErrorMessage("[red]Invalid GUID[/]")
                .Validate(s => int.TryParse(s, out _) ? ValidationResult.Success() : ValidationResult.Error("Invalid")));
        return int.Parse(txt);
    }
}
