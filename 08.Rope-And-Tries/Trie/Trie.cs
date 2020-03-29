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

    private Node GetNode(Node currentNode, string key, int index)
    {
        if (currentNode == null)
        {
            return null;
        }

        if (index == key.Length)
        {
            return currentNode;
        }

        Node node = null;
        char currentChar = key[index];

        if (currentNode.next.ContainsKey(currentChar))
        {
            node = currentNode.next[currentChar];
        }

        return GetNode(node, key, index + 1);
    }

    public void Insert(string key, T val)
    {
        this.root = this.Insert(root, key, val, 0);
    }

    private Node Insert(Node currentNode, string key, T value, int startIndex)
    {
        if (currentNode == null)
        {
            currentNode = new Node();
        }

        if (key.Length == startIndex)
        {
            currentNode.isTerminal = true;
            currentNode.val = value;
            return currentNode;
        }

        Node node = null;
        char currentChar = key[startIndex];
        if (currentNode.next.ContainsKey(currentChar))
        {
            node = currentNode.next[currentChar];
        }

        currentNode.next[currentChar] = this.Insert(node, key, value, startIndex + 1);

        return currentNode;
    }

    private void Collect(Node currentNode, string prefix, Queue<string> results)
    {
        if (currentNode == null)
        {
            return;
        }

        if (currentNode.val != null && currentNode.isTerminal)
        {
            results.Enqueue(prefix);
        }

        foreach (var key in currentNode.next.Keys)
        {
            Collect(currentNode.next[key], prefix + key, results);
        }
    }
}