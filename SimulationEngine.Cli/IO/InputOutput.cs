using SimulationEngine.Domain.Models.Extensions;
using Spectre.Console;

namespace SimulationEngine.Cli.IO;

public sealed class InputOutput(IAnsiConsole console) : IInputOutput
{
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

    public async Task<FileInfo?> PickFileAsync(string title, string startDir, string searchPattern = "*.*")
    {
        var dir = new DirectoryInfo(startDir);
        if (!dir.Exists) dir = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (true)
        {
            var dirs = dir.GetDirectories().OrderBy(d => d.Name, StringComparer.OrdinalIgnoreCase).ToList();
            var files = dir.GetFiles(searchPattern).OrderBy(f => f.Name, StringComparer.OrdinalIgnoreCase).ToList();

            var items = new List<object>();
            if (dir.Parent is not null) items.Add("..");
            items.AddRange(dirs);
            items.AddRange(files);
            items.Add("Cancel");

            var choice = await console.PromptAsync(
                new SelectionPrompt<object>()
                    .Title($"{title}\n[grey]{Markup.Escape(dir.FullName)}[/]")
                    .UseConverter(o => o switch
                    {
                        string s when s == ".." => "[..] Parent directory",
                        string s when s == "Cancel" => "Cancel",
                        DirectoryInfo d => $"[folder] {d.Name}",
                        FileInfo f => $"[file]   {f.Name}",
                        _ => o.ToString()!
                    })
                    .AddChoices(items));

            switch (choice)
            {
                case string s when s == "Cancel":
                    return null;

                case string s when s == "..":
                    dir = dir.Parent!;
                    break;

                case DirectoryInfo d:
                    dir = d;
                    break;

                case FileInfo f:
                    return f;
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