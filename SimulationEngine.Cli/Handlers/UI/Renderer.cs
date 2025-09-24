using Spectre.Console;
using Spectre.Console.Rendering;
using System.Collections;
using System.Reflection;
using System.Text;

namespace SimulationEngine.Cli.Handlers.UI;

public sealed class Renderer(IAnsiConsole console) : IRenderer
{
    public void Clear() => console.Clear();

    public void DrawError(string error) =>
        console.MarkupLine($"[red]{Markup.Escape(error)}[/]");

    public void DrawHeader(string text) => 
        console.Write(new Rule($"[bold]{Markup.Escape(text)}[/]").RuleStyle("grey"));

    public IRenderable DrawHistoryPanel(
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

    public IRenderable DrawInputPanel(StringBuilder buffer, int maxLength, string? status, bool statusIsError)
    {
        var remainingInputs = Math.Max(0, maxLength - buffer.Length);

        var line = new Text($"> {buffer}{new string('·', remainingInputs)}  [{buffer.Length}/{maxLength}]");

        var parts = new List<IRenderable> { line };

        if (!string.IsNullOrWhiteSpace(status) && statusIsError)
            parts.Add(new Text(status, new Style(Color.Red)));

        return new Panel(new Rows(parts)).RoundedBorder();
    }

    public void DrawLine(string text) =>
        console.MarkupLine(text);

    public void DrawPanel(string title, string body) => 
        console.Write(new Panel(Markup.Escape(body)).Header(Markup.Escape(title)).Border(BoxBorder.Rounded));

    public IRenderable DrawStack(params IRenderable[] blocks) => 
        new Rows(blocks);

    public void DrawTableWithNameValuePairs(IEnumerable<(string Name, object? Value)> rows)
    {
        var table = new Table().RoundedBorder().BorderColor(Color.Grey).Expand();

        table.AddColumn(new TableColumn(string.Empty).NoWrap());
        table.AddColumn(new TableColumn(string.Empty).NoWrap());
        table.ShowHeaders = false;

        foreach (var (name, value) in rows)
        {
            table.AddRow(
                new Markup($"[grey]{Markup.Escape(name)}[/]"),
                new Markup(FormatCell(value))
            );
        }

        console.Write(table);
    }

    public void DrawTableFromPropertiesWithColumnNames<T>(IEnumerable<T> rows, bool expand = true, params string[] propertyOrder)
        => DrawTableFromProperties(rows, expand, [.. propertyOrder.Select(propertyName => (propertyName, (string?)null))]);

    public void DrawWarning(string warning) =>
        console.MarkupLine($"[yellow]{Markup.Escape(warning)}[/]");

    public void Write(IRenderable renderable) =>
        console.Write(renderable);

    private void DrawTableFromProperties<T>(IEnumerable<T> rows, bool expand = true, params (string Property, string? Header)[] columns)
    {
        var properties = GetProperties(typeof(T), columns.Select(column => column.Property));

        var table = new Table().RoundedBorder().BorderColor(Color.Grey);

        if (expand)
            table.Expand();

        for (int i = 0; i < columns.Length; i++)
            table.AddColumn(new TableColumn(Markup.Escape(columns[i].Header ?? properties[i].Name)));

        foreach (var row in rows)
            table.AddRow(properties.Select(property => new Markup(FormatCell(property.GetValue(row)))).ToArray());

        console.Write(table);
    }

    private static PropertyInfo[] GetProperties(Type type, IEnumerable<string> names)
    {
        var propertyMap = type
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(property => property.Name, StringComparer.OrdinalIgnoreCase);

        var properties = new List<PropertyInfo>();

        foreach (var name in names)
        {
            if (!propertyMap.TryGetValue(name, out var property))
                throw new ArgumentException($"Property '{name}' not found on {type.Name}");

            properties.Add(property);
        }

        return [.. properties];
    }

    private static string FormatCell(object? value)
    {
        if (value is null) 
            return "[grey]—[/]";

        if (value is IEnumerable enumerable && value is not string)
        {
            var parts = new List<string>();

            foreach (var item in enumerable)
                parts.Add(item?.ToString() ?? "");

            return Markup.Escape($"[{string.Join(", ", parts)}]");
        }

        return Markup.Escape(value.ToString() ?? "");
    }
}