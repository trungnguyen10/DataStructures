using DataStructures;

namespace DataStructuresTest;

public class UnionFindTest
{
    [Fact]
    public void Must_be_connected_after_unify_1()
    {
        var unionFind = new UnionFind(5);

        unionFind.Unify(1, 2);
        Assert.True(unionFind.IsConnected(1, 2));

        unionFind.Unify(1, 3);
        Assert.True(unionFind.IsConnected(2, 3));
    }

    [Fact]
    public void Must_be_connected_after_unify_2()
    {
        var unionFind = new UnionFind(5);
        var nodes = Enumerable.Range(0, 5).ToArray();

        unionFind.Unify(0, 1);
        unionFind.Unify(1, 2);
        unionFind.Unify(1, 3);
        var dict = nodes
                    .Select((v, i) => (v, i))
                    .Aggregate(new Dictionary<int, List<int>>(), (s, c) =>
                    {
                        var root = unionFind.Find(c.i);
                        if (s.ContainsKey(root) is false)
                        {
                            s.Add(root, []);
                        }
                        s[root].Add(c.v);
                        return s;
                    });

        Assert.Equal(4, dict[unionFind.Find(0)].Count);
    }

    [Fact]
    public void Must_not_be_connected_when_not_unify()
    {
        var unionFind = new UnionFind(5);

        unionFind.Unify(1, 2);
        Assert.True(unionFind.IsConnected(1, 2));

        unionFind.Unify(3, 4);
        Assert.True(unionFind.IsConnected(3, 4));

        Assert.False(unionFind.IsConnected(1, 3));
        Assert.False(unionFind.IsConnected(1, 4));
        Assert.False(unionFind.IsConnected(2, 3));
        Assert.False(unionFind.IsConnected(2, 4));
    }
}