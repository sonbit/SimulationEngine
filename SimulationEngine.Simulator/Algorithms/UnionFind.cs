namespace SimulationEngine.Simulator.Algorithms;

internal sealed class UnionFind<T>(IEqualityComparer<T> equalityComparer)
{
    private readonly Dictionary<T, T> _parent = new(equalityComparer);
    private readonly Dictionary<T, int> _rank = new(equalityComparer);

    public void Add(T x)
    {
        if (_parent.ContainsKey(x)) 
            return;

        _parent[x] = x; _rank[x] = 0;
    }

    public T Find(T x)
    {
        if (!_parent.ContainsKey(x))
            Add(x);

        var p = _parent[x];

        if (!EqualityComparer<T>.Default.Equals(p, x))
            _parent[x] = Find(p);

        return _parent[x];
    }

    public void Union(T a, T b)
    {
        Add(a); 
        Add(b);

        var ra = Find(a); 
        var rb = Find(b);

        if (EqualityComparer<T>.Default.Equals(ra, rb)) 
            return;

        var rra = _rank[ra];
        var rrb = _rank[rb];

        if (rra < rrb) 
            _parent[ra] = rb;
        else if (rra > rrb) 
            _parent[rb] = ra;
        else 
        { 
            _parent[rb] = ra; 
            _rank[ra] = rra + 1; 
        }
    }
}
