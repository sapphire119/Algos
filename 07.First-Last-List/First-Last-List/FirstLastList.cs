using System;
using System.Collections.Generic;
//using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private List<T> list = new List<T>();
    private AVL<T> avlTree = new AVL<T>();

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
        this.list.Add(element);
        //throw new NotImplementedException();
    }

    public void Clear()
    {
        this.avlTree.Clear();
        this.list.Clear();
        //throw new NotImplementedException();
    }

    public IEnumerable<T> First(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        //can be done with LINQ but f it
        var arr = new T[count];
        for (int i = 0; i < count; i++)
        {
            arr[i] = this.list[i];
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
        for (int i = this.list.Count - 1; i >= this.list.Count - count; i--)
        {
            arr[i] = this.list[i];
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
        this.EachInOrder(this.avlTree.Root, tempList.Add, ref tempCounter, count);

        return tempList;
    }

    private void EachInOrder(Node<T> node, Action<T> action, ref int count, int limit)
    {
        if (node == null)
        {
            return;
        }

        if (count >= limit)
        {
            return;
        }

        this.EachInOrder(node.Left, action, ref count, limit);
        count++;
        action(node.Value);
        this.EachInOrder(node.Right, action, ref count, limit);
    }

    private IEnumerable<T> Min(int count, Node<T> node)
    {
        if (node == null)
        {
            return null;
        }

        //if (tempCount > count)
        //{
        //    return default;
        //}


        this.Min(count, node.Left);
        //tempCount++;
        this.Min(count, node.Right);



        return default;
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        throw new NotImplementedException();
    }

    public int RemoveAll(T element)
    {
        throw new NotImplementedException();
    }
}
