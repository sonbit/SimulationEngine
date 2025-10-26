namespace SimulationEngine.Simulator.Finders;

internal sealed class UnionFinder<T>(IEqualityComparer<T> equalityComparer) where T : notnull
{
    private readonly Dictionary<T, T> _parent = new(equalityComparer);
    private readonly Dictionary<T, int> _rank = new(equalityComparer);

    public void Add(T x)
    {
        if (_parent.ContainsKey(x)) 
            return;

        _parent[x] = x; 
        _rank[x] = 0;
    }

    public T Find(T x)
    {
        if (!_parent.ContainsKey(x))
            Add(x);

        var parent = _parent[x];

        if (!EqualityComparer<T>.Default.Equals(parent, x))
            _parent[x] = Find(parent);

        return _parent[x];
    }

    public void Union(T x, T y)
    {
        var foundX = Find(x); 
        var foundY = Find(y);

        if (EqualityComparer<T>.Default.Equals(foundX, foundY)) 
            return;

        var rankX = _rank[foundX];
        var rankY = _rank[foundY];

        if (rankX < rankY) 
            _parent[foundX] = foundY;
        else if (rankX > rankY) 
            _parent[foundY] = foundX;
        else 
        { 
            _parent[foundY] = foundX; 
            _rank[foundX] = rankX + 1; 
        }
    }
}