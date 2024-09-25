namespace DataStructures;

public class UnionFind
{
    private readonly int[] _id;

    public UnionFind(int size)
    {
        _id = Enumerable.Range(0, size).ToArray();
    }

    /// <summary>
    /// Unify 2 nodes by merge the right group (contains j) to the left group (contains i)
    /// </summary>
    /// <param name="i">index of a node</param>
    /// <param name="j">index of the other</param>
    public void Unify(int i, int j)
    {

        if (IsConnected(i, j))
        {
            return;
        }

        var iRoot = Find(i);
        var jRoot = Find(j);
        _id[jRoot] = iRoot;
    }


    /// <summary>
    /// Given the index <paramref name="i"/> return the index of its root
    /// </summary>
    /// <param name="i">the index</param>
    /// <returns>index of its root</returns>
    public int Find(int i)
    {
        var root = i;
        while (IsRoot(root) is false)
        {
            root = _id[root];
        }

        while (IsRoot(i) is false)
        {
            var parent = _id[i];
            _id[parent] = root;
            i = parent;
        }

        return root;
    }

    private bool IsRoot(int i) => _id[i] == i;

    public bool IsConnected(int i, int j) => Find(i) == Find(j);
}
