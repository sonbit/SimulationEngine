namespace SimulationEngine.Cli.Renderers;

public interface IPaginator<T>
{
    int Page { get; }
    int PageSize { get; }
    int TotalItems { get; }
    int TotalPages { get; }
    IEnumerable<T> CurrentPageItems(IEnumerable<T> source);
    bool Next();
    bool Previous();
}
