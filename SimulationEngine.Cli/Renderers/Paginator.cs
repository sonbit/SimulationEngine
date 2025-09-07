namespace SimulationEngine.Cli.Renderers;

public sealed class Paginator<T>(int page, int pageSize) : IPaginator<T>
{
    public int Page { get; private set; } = Math.Max(1, page);
    public int PageSize { get; } = Math.Max(1, pageSize);
    public int TotalItems { get; private set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

    public IEnumerable<T> CurrentPageItems(IEnumerable<T> source)
    {
        var list = source as IList<T> ?? [.. source];
        TotalItems = list.Count;
        var skip = (Page - 1) * PageSize;
        return list.Skip(skip).Take(PageSize);
    }

    public bool Next() { if (Page < TotalPages) { Page++; return true; } return false; }
    public bool Previous() { if (Page > 1) { Page--; return true; } return false; }
}
