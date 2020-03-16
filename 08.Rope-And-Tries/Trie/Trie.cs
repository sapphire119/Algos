using System;
using System.Collections.Generic;

public class Trie<T>
{
    private Node root;

    private class Node
    {
        public T val;
        public bool isTerminal;
        public Dictionary<char, Node> next = new Dictionary<char, Node>();
    }

    public T GetValue(string key)
    {
        var x = this.GetNode(this.root, key, 0);
        if (x == null || !x.isTerminal)
        {
            throw new InvalidOperationException();
        }

        return x.val;
    }

    public bool Contains(string key)
    {
        var node = this.GetNode(this.root, key, 0);
        return node != null && node.isTerminal;
    }

    public IEnumerable<string> GetByPrefix(string prefix)
    {
        var results = new Queue<string>();
        var x = GetNode(root, prefix, 0);

        this.Collect(x, prefix, results);
        
        return results;
    }

    private Node GetNode(Node x, string key, int d)
    {
        if (x == null)
        {
            return null;
        }

        if (d == key.Length)
        {
            return x;
        }

        Node node = null;
        char c = key[d];

        if (x.next.ContainsKey(c))
        {
            node = x.next[c];
        }

        return GetNode(node, key, d + 1);
    }

    public void Insert(string key, T val)
    {
        this.root = this.Insert(root, key, val, 0);
    }

    private Node Insert(Node node, string key, T value, int startIndex)
    {
       //ToDo: Create insert
       throw new NotImplementedException();
    }

    private void Collect(Node x, string prefix, Queue<string> results)
    {
        if (x == null)
        {
            return;
        }

        if (x.val != null && x.isTerminal)
        {
            results.Enqueue(prefix);
        }

        foreach (var c in x.next.Keys)
        {
            Collect(x.next[c], prefix + c, results);
        }
    }
}