using Spectre.Console;
using Spectre.Console.Rendering;
using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace SimulationEngine.Cli.UI;

public sealed class Renderer(IAnsiConsole console) : IRenderer
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> Cache = new();

    public void Clear() => console.Clear();

    public void DrawError(string error) =>
        console.MarkupLine($"[red]{Markup.Escape(error)}[/]");

    public void DrawHeader(string text, string color = "grey") => 
        console.Write(new Rule($"[bold]{Markup.Escape(text)}[/]").RuleStyle(color));

    public void DrawPanel(string title, string body) => 
        console.Write(new Panel(Markup.Escape(body)).Header(Markup.Escape(title)).Border(BoxBorder.Rounded));

    public void DrawPanel(string title, List<(string name, object value)> rows)
    {
        var content = rows.Select(row => $"[bold]{Markup.Escape(row.name)}: {Markup.Escape(row.value?.ToString() ?? string.Empty)}").ToList();
        var body = string.Join(Environment.NewLine + "[/]", content);
        console.Write(new Panel(body + "[/]").Header(Markup.Escape(title)).Border(BoxBorder.Rounded));
    }

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

    public void DrawWarning(string warning) =>
        console.MarkupLine($"[yellow]{Markup.Escape(warning)}[/]");

    //public void DrawTable<T>(IEnumerable<T> rows, params (string Header, Func<T, object?> Value)[] columns)
    //{
    //    var table = new Table().RoundedBorder().BorderColor(Color.Grey).Expand();

    //    //foreach (var (header, _) in columns)
    //    //    table.AddColumn(Markup.Escape(header));

    //    foreach (var row in rows)
    //        table.AddRow(columns.Select(column => Cell(column.Value(row))).ToArray());

    //    console.Write(table);
    //}

    public void NameValueTable(IEnumerable<(string Name, object? Value)> rows, string? title = null)
    {
        var table = new Table()
            .RoundedBorder()
            .BorderColor(Color.Grey)
            .Expand();

        // two columns, hide headers
        table.AddColumn(new TableColumn(string.Empty).NoWrap());
        table.AddColumn(new TableColumn(string.Empty).NoWrap());
        table.ShowHeaders = false;

        if (!string.IsNullOrWhiteSpace(title))
            table.Title($"[bold]{Markup.Escape(title)}[/]");

        foreach (var (name, value) in rows)
        {
            table.AddRow(
                new Markup($"[grey]{Markup.Escape(name)}[/]"),
                new Markup(FormatCell(value))
            );
        }

        console.Write(table);
    }

    // ---------- 2a) Property table by property names ----------
    public void PropertyTable<T>(IEnumerable<T> rows, params string[] propertyOrder)
        => PropertyTable(rows, propertyOrder.Select(n => (n, (string?)null)).ToArray());

    // ---------- 2b) Property table with custom headers ----------
    public void PropertyTable<T>(IEnumerable<T> rows, params (string Property, string? Header)[] columns)
    {
        var props = ResolveProperties(typeof(T), columns.Select(c => c.Property));

        var table = new Table()
            .RoundedBorder()
            .BorderColor(Color.Grey)
            .Expand();

        // headers: custom text if given, else property name
        for (int i = 0; i < columns.Length; i++)
        {
            var headerText = columns[i].Header ?? props[i].Name;
            table.AddColumn(new TableColumn(Markup.Escape(headerText)));
        }

        foreach (var row in rows)
        {
            var cells = props.Select(p => new Markup(FormatCell(p.GetValue(row)))).ToArray();
            table.AddRow(cells);
        }

        console.Write(table);
    }

    // ---------- helpers ----------
    private static PropertyInfo[] ResolveProperties(Type t, IEnumerable<string> names)
    {
        var map = t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                   .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);

        var result = new List<PropertyInfo>();
        foreach (var n in names)
        {
            if (!map.TryGetValue(n, out var pi))
                throw new ArgumentException($"Property '{n}' not found on {t.Name}");
            result.Add(pi);
        }
        return result.ToArray();
    }

    private static string FormatCell(object? value)
    {
        if (value is null) 
            return "[grey]—[/]";

        if (value is IEnumerable e && value is not string)
        {
            var parts = new List<string>();
            foreach (var item in e)
                parts.Add(item?.ToString() ?? "");
            return Markup.Escape($"[{string.Join(", ", parts)}]");
        }

        return Markup.Escape(value.ToString() ?? "");
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

    public IRenderable HistoryPanel(
        IEnumerable<(string Input, string Output)> history,
        string panelHeader,
        string leftHeader, 
        string rightHeader)
    {
        var table = new Table();
        table.AddColumn(new TableColumn(Markup.Escape(leftHeader)).NoWrap());
        table.AddColumn(new TableColumn(Markup.Escape(rightHeader)).NoWrap());

        foreach (var (input, output) in history)
        {
            table.AddRow(
                new Markup(Markup.Escape(input ?? "")),
                new Markup(Markup.Escape(output ?? "")));
        }

        return new Panel(table).Header(Markup.Escape(panelHeader));
    }

    public IRenderable InputPanel(StringBuilder buffer, int maxLen, string? status = null, bool statusIsError = false, string prompt = "> ")
    {
        var remainingInputs = Math.Max(0, maxLen - buffer.Length);

        var line = new Text($"{prompt}{buffer}{new string('·', remainingInputs)}  [{buffer.Length}/{maxLen}]");

        var parts = new List<IRenderable> { line };

        if (!string.IsNullOrWhiteSpace(status) && statusIsError)
            parts.Add(new Text(status!, new Style(Color.Red)));

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
