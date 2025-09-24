using Spectre.Console.Rendering;
using System.Text;

namespace SimulationEngine.Cli.Handlers.UI;

public interface IRenderer
{
    void Clear();
    void DrawError(string error);
    void DrawHeader(string text);
    public IRenderable DrawHistoryPanel(IEnumerable<(string Input, string Output)> history, string panelHeader, string leftHeader, string rightHeader);
    IRenderable DrawInputPanel(StringBuilder buffer, int maxLength, string? status, bool statusIsError);
    void DrawLine(string text);
    void DrawPanel(string title, string body);
    IRenderable DrawStack(params IRenderable[] blocks);
    void DrawTableWithNameValuePairs(IEnumerable<(string Name, object? Value)> rows);
    void DrawTableFromPropertiesWithColumnNames<T>(IEnumerable<T> rows, bool expand = true, params string[] propertyOrder);
    void DrawWarning(string warning);
    void Write(IRenderable renderable);
    void Write(string text);
}