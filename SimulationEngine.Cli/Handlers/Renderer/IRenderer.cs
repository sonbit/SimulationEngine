using Spectre.Console;
using Spectre.Console.Rendering;
using System.Reflection;
using System.Text;

namespace SimulationEngine.Cli.Handlers.Renderer;

public interface IRenderer
{
    void Clear();
    void NameValueTable(IEnumerable<(string Name, object? Value)> rows, string? title = null);
    void PropertyTable<T>(IEnumerable<T> rows, params string[] propertyOrder);
    void PropertyTable<T>(IEnumerable<T> rows, params (string Property, string? Header)[] columns);
    void DrawError(string error);
    void DrawHeader(string text, string color = "grey");
    void DrawPanel(string title, string body);
    void DrawPanel(string title, List<(string name, object value)> rows);
    void DrawRule(string title, string color = "grey");
    void DrawTable<T>(IEnumerable<T> rows);
    void DrawTable<T>(IEnumerable<T> rows, params (string Header, Func<T, object?> Value)[] columns);
    void DrawTableAuto<T>(IEnumerable<T> rows, Func<PropertyInfo, bool>? filter = null);
    void DrawTree(string rootLabel, Action<Tree> build);
    void DrawWarning(string warning);
    IRenderable HistoryPanel(IEnumerable<(string In, string Out)> history, string header = "History", bool newestFirst = false, int? max = null);
    public IRenderable HistoryPanel(
        IEnumerable<(string Input, string Output)> history,
        string panelHeader,
        string leftHeader,
        string rightHeader);
    IRenderable InputPanel(StringBuilder buffer, int maxLen, string? status = null, bool statusIsError = false, string prompt = "› ");
    IRenderable Stack(params IRenderable[] blocks);
}