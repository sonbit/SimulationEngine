using Spectre.Console;

namespace SimulationEngine.Cli.Renderers;

public interface  IRenderer
{
    void DrawError(string error);
    void DrawHeader(string text, string color = "grey");
    void DrawPage<T>(IPaginator<T> paginator, IEnumerable<T> source, string title);
    void DrawPanel(string title, string body);
    void DrawRule(string title);
    Table DrawTable<T>(IEnumerable<T> rows);
    void DrawTree(string rootLabel, Action<Tree> build);
}
