using First_Last_List;
using System;
using System.Collections.Generic;
//using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    //private List<T> list = new List<T>();
    private AVL<T> avlTree = new AVL<T>();
    private DoubleLinkedList<T> list = new DoubleLinkedList<T>();

    public int Count
    {
        get
        {
            return this.list.Count;
        }
    }

    public void Add(T element)
    {
        this.avlTree.Insert(element);
        this.list.Insert(element);
    }

    public void Clear()
    {
        this.avlTree.Clear();
        this.list.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        //can be done with LINQ but f it
        var arr = new T[count];

        var currentTail = this.list.Tail;
        for (int i = 0; i < count; i++)
        {
            arr[i] = currentTail.Value;
            currentTail = currentTail.Head;
        }

        return arr;
    }

    public IEnumerable<T> Last(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var arr = new T[count];
        for (int i = this.list.Count - 1, j = 0; i >= this.list.Count - count; i--, j++)
        {
            arr[j] = this.list[i];
        }

        return arr;
    }

    public IEnumerable<T> Min(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var tempList = new List<T>();
        var tempCounter = 0;
        this.MinEachInOrder(this.avlTree.Root, tempList.Add, ref tempCounter, count);

        return tempList;
    }

    private void MinEachInOrder(Node<T> node, Action<T> action, ref int count, int limit)
    {
        if (node == null)
        {
            return;
        }

        //if (count >= limit) return;

        this.MinEachInOrder(node.Left, action, ref count, limit);

        if (count >= limit) return;

        count++;
        action(node.Value);
        if (node.Duplicates.Count > 0)
        {
            for (int i = 0; i < node.Duplicates.Count && count < limit; i++, count++)
            {
                action(node.Duplicates[i].Value);
            }
        }
        this.MinEachInOrder(node.Right, action, ref count, limit);
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var tempList = new List<T>();
        var tempCounter = 0;
        this.MaxEachInOrder(this.avlTree.Root, tempList.Add, ref tempCounter, count);

        return tempList;
    }

    private void MaxEachInOrder(Node<T> node, Action<T> action, ref int count, int limit)
    {
        if (node == null)
        {
            return;
        }


        this.MaxEachInOrder(node.Right, action, ref count, limit);

        if (count >= limit) return;

        count++;
        action(node.Value);
        if (node.Duplicates.Count > 0)
        {
            for (int i = 0; i < node.Duplicates.Count && count < limit; i++, count++)
            {
                action(node.Duplicates[i].Value);
            }
        }
        this.MaxEachInOrder(node.Left, action, ref count, limit);
    }

    public int RemoveAll(T element)
    {
        var nodeElement = this.avlTree.Search(element);
        if (nodeElement is null)
        {
            return default;
        }
        this.avlTree.Delete(element);
        var count = this.list.RemoveAll(e => e.CompareTo(nodeElement.Value) == 0);
        return count;
    }
}
