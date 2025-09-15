using Spectre.Console;
using Spectre.Console.Rendering;
using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace SimulationEngine.Cli.Handlers.Renderer;

public sealed class Renderer(IAnsiConsole console) : IRenderer
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> Cache = new();

    public void DrawError(string error) =>
        console.MarkupLine($"[red]{Markup.Escape(error)}[/]");

    public void DrawHeader(string text, string color = "grey") => 
        console.Write(new Rule($"[bold]{Markup.Escape(text)}[/]").RuleStyle(color));

    public void DrawPanel(string title, string body) => 
        console.Write(new Panel(Markup.Escape(body)).Header(Markup.Escape(title)).Border(BoxBorder.Rounded));

    public void DrawRule(string title, string color = "grey") => 
        console.Write(new Rule($"[bold]{Markup.Escape(title)}[/]").RuleStyle(color));

    public void DrawTable<T>(IEnumerable<T> rows)
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => !IsEnumerableButNotString(p.PropertyType))
            .ToArray();

        var table = new Table().RoundedBorder().Expand();

        foreach (var property in properties) 
            table.AddColumn(property.Name);

        static string CellText(object? value)
        {
            if (value is null) 
                return string.Empty;

            if (value is IEnumerable e && value is not string)
            {
                var items = new List<string>();
                foreach (var item in e)
                    items.Add(item?.ToString() ?? string.Empty);

                return Markup.Escape(string.Join(", ", items));
            }

            return Markup.Escape(value.ToString() ?? string.Empty);
        }

        foreach (var row in rows)
        {
            var cells = properties
                .Select(p => new Markup(CellText(p.GetValue(row))))
                .ToArray(); 

            table.AddRow(cells);
        }

        console.Write(table);
    }

    public void DrawTable<T>(IEnumerable<T> rows, params (string Header, Func<T, object?> Value)[] columns)
    {
        var table = new Table().RoundedBorder().BorderColor(Color.Grey).Expand();

        foreach (var (header, _) in columns) 
            table.AddColumn(Markup.Escape(header));

        foreach (var row in rows) 
            table.AddRow(columns.Select(column => Cell(column.Value(row))).ToArray());

        console.Write(table);
    }

    public void DrawTableAuto<T>(IEnumerable<T> rows, Func<PropertyInfo, bool>? filter = null)
    {
        var properties = Cache.GetOrAdd(typeof(T), t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance));
        var filteredProperties = (filter is null
            ? properties.Where(property => property.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(property.PropertyType) == false)
            : properties.Where(filter)).ToArray();

        var table = new Table().RoundedBorder().BorderColor(Color.Grey).Expand();

        foreach (var property in filteredProperties) 
            table.AddColumn(Markup.Escape(property.Name));

        foreach (var row in rows) 
            table.AddRow(filteredProperties.Select(propertyInfo => Cell(propertyInfo.GetValue(row))).ToArray());

        console.Write(table);
    }

    public void DrawTree(string rootLabel, Action<Tree> build)
    {
        var tree = new Tree(rootLabel);
        build(tree);
        console.Write(tree);
    }

    public IRenderable HistoryPanel(IEnumerable<(string In, string Out)> history, string header = "History", bool selectedNewestFirst = false, int? max = null)
    {
        var sortedHistory = selectedNewestFirst ? history.Reverse() : history;

        if (max is not null) 
            sortedHistory = sortedHistory.Take(max.Value);

        var rows = new Rows([.. sortedHistory
            .Select(history => new Text($"{history.In} {history.Out}"))
            .Cast<IRenderable>()]);

        return new Panel(rows).Header(header).RoundedBorder();
    }

    public IRenderable InputPanel(StringBuilder buffer, int maxLen, string? status = null, bool statusIsError = false, string prompt = "> ")
    {
        var remainingInputs = Math.Max(0, maxLen - buffer.Length);

        var line = new Text($"{prompt}{buffer}{new string('·', remainingInputs)}  [{buffer.Length}/{maxLen}]");

        var parts = new List<IRenderable> { line };

        if (!string.IsNullOrWhiteSpace(status))
            parts.Add(new Text(status!, new Style(statusIsError ? Color.Red : Color.Grey)));

        return new Panel(new Rows(parts)).RoundedBorder();
    }

    public IRenderable Stack(params IRenderable[] blocks) => new Rows(blocks);

    private static IRenderable Cell(object? value)
    {
        if (value is null) 
            return new Markup("[grey]—[/]");

        if (value is not IEnumerable enumerable || value is string)
            return new Markup(Markup.Escape(value.ToString() ?? ""));
     
        var items = new List<string>();

        foreach (var item in enumerable) 
            items.Add(item?.ToString() ?? "");

        return new Markup(Markup.Escape(string.Join(", ", items)));
    }

    private static bool IsEnumerableButNotString(Type t) => t != typeof(string) && typeof(IEnumerable).IsAssignableFrom(t);
}
