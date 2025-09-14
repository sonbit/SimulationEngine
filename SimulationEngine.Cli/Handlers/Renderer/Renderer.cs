using Spectre.Console;
using System.Collections;
using System.Reflection;

namespace SimulationEngine.Cli.Handlers.Renderer;

public sealed class Renderer(IAnsiConsole console) : IRenderer
{
    public void DrawError(string error) =>
        console.MarkupLine($"[red]{error}[/]");

    public void DrawHeader(string text, string color = "grey") => 
        console.Write(new Rule($"[bold]{text}[/]").RuleStyle(color));

    public void DrawPanel(string title, string body) => 
        console.Write(new Panel(body).Header(title).Border(BoxBorder.Rounded));

    public void DrawRule(string title) => 
        console.Write(new Rule($"[bold]{title}[/]").RuleStyle("grey"));

    public Table DrawTable<T>(IEnumerable<T> rows)
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => !IsEnumerableButNotString(p.PropertyType))
            .ToArray();

        var table = new Table().RoundedBorder().Expand();

        foreach (var property in properties) 
            table.AddColumn(property.Name);

        static string CellText(object? value)
        {
            if (value is null) return string.Empty;

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

        return table;
    }

    public void DrawTree(string rootLabel, Action<Tree> build)
    {
        var tree = new Tree(rootLabel);
        build(tree);
        console.Write(tree);
    }

    private static bool IsEnumerableButNotString(Type t) => t != typeof(string) && typeof(IEnumerable).IsAssignableFrom(t);
}
