using System;
using System.Collections.Generic;

public class Node<T> where T : IComparable<T>
{
    public T Value;
    public Node<T> Left;
    public Node<T> Right;
    public int Height;
    public List<Node<T>> Duplicates { get; }

    public Node(T value)
    {
        this.Value = value;
        this.Height = 1;
        this.Duplicates = new List<Node<T>>();
    }
}
