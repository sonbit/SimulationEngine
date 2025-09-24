using SimulationEngine.Domain.Models.Extensions;
using Spectre.Console;

namespace SimulationEngine.Cli.Handlers.IO;

public sealed class Prompter(IAnsiConsole console) : IPrompter
{
    private const string Cancel = "Cancel";
    private const string ParentDirectory = "..";

    public async Task<int> AskIdAsync(string title)
    {
        var idString = await AnsiConsole
            .PromptAsync(new TextPrompt<string>(title)
            .ValidationErrorMessage("[red]Invalid Id[/]")
            .Validate(str => int.TryParse(str, out _) 
                ? ValidationResult.Success() 
                : ValidationResult.Error("Invalid Id")));

        return int.Parse(idString);
    }

    public async Task<FileInfo?> PickFileAsync(string title, string startDirectoryName, string searchPattern = "*.*")
    {
        var startDirectory = new DirectoryInfo(startDirectoryName);

        if (!startDirectory.Exists) 
            startDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (true)
        {
            var directories = startDirectory.GetDirectories().OrderBy(d => d.Name, StringComparer.OrdinalIgnoreCase).ToList();
            var files = startDirectory.GetFiles(searchPattern).OrderBy(f => f.Name, StringComparer.OrdinalIgnoreCase).ToList();

            var items = new List<object>();
            if (startDirectory.Parent is not null) 
                items.Add("..");

            items.AddRange(directories);
            items.AddRange(files);
            items.Add(Cancel);

            var choice = await console.PromptAsync(
                new SelectionPrompt<object>()
                    .Title($"{title}\n[grey]{Markup.Escape(startDirectory.FullName)}[/]")
                    .PageSize(25)
                    .UseConverter(obj => obj switch
                    {
                        string str when str == ParentDirectory => "[grey]..[/]",
                        DirectoryInfo directoryInfo => $"[yellow]{Markup.Escape(directoryInfo.Name)}[/]",
                        FileInfo fileInfo => $"[grey]{Markup.Escape(fileInfo.Name)}[/]",
                        string str when str == Cancel => "[red]Cancel[/]",
                        _ => Markup.Escape(obj?.ToString() ?? string.Empty)
                    })
                    .AddChoices(items));

            switch (choice)
            {
                case string str when str == ParentDirectory:
                    startDirectory = startDirectory.Parent!;
                    break;
                case DirectoryInfo directoryInfo:
                    startDirectory = directoryInfo;
                    break;
                case FileInfo file:
                    return file;
                case string str when str == Cancel:
                    return null;
            }
        }
    }

    public Task<TEnum> SelectEnumAsync<TEnum>(string title) where TEnum : struct, Enum
    {
        var prompt = new SelectionPrompt<TEnum>()
            .Title(title)
            .AddChoices(Enum.GetValues<TEnum>())
            .UseConverter(e => e.GetDescription());

        return console.PromptAsync(prompt);
    }

    public async Task<T?> SelectOrBackAsync<T>(string title, List<T> choices, Func<T, string> label, string emptyMessage = "") where T : notnull
    {
        if (choices.Count == 0)
        {
            AnsiConsole.MarkupLine($"[yellow]{(!string.IsNullOrWhiteSpace(emptyMessage) ? emptyMessage : "No items in list")}[/]");
            return default;
        }

        var prompt = new SelectionPrompt<object>()
            .Title(title)
            .PageSize(20)
            .AddChoices("Back")
            .AddChoices(choices.Cast<object>())
            .UseConverter(obj => obj is T t ? label(t) : obj.ToString()!);

        var choice = await AnsiConsole.PromptAsync(prompt);
        return choice is T value ? value : default;
    }
}