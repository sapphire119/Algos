using System;
using System.Collections.Generic;

public class IntervalTree
{
    private Node root;

    public void Insert(double low, double high)
    {
        this.root = this.Insert(this.root, low, high);
    }

    public void EachInOrder(Action<Interval> action)
    {
        EachInOrder(this.root, action);
    }

    public Interval SearchAny(double low, double high)
    {
        var node = this.root;

        Interval interval = null;
        while (node != null)
        {
            if (node.interval.Intersects(low, high)) return node.interval;

            if (node.left != null && low < node.left.max)
            {
                node = node.left;
            }
            else
            {
                node = node.right;
            }
        }

        return interval;
    }

    public IEnumerable<Interval> SearchAll(double low, double high)
    {
        var intervals = new List<Interval>();
        
        this.EachInOrder(this.root, intervals.Add, low, high);


        return intervals;
    }


    private void EachInOrder(Node node, Action<Interval> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.left, action);
        action(node.interval);
        EachInOrder(node.right, action);
    }

    private void EachInOrder(Node node, Action<Interval> action, double low, double high)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.left, action, low, high);
        if (node.interval.Intersects(low, high))
        {
            action(node.interval);
        }
        EachInOrder(node.right, action, low, high);
    }

    private Node Insert(Node node, double low, double high)
    {
        if (node == null)
        {
            return new Node(new Interval(low, high));
        }

        int cmp = low.CompareTo(node.interval.Low);
        if (cmp < 0)
        {
            node.left = Insert(node.left, low, high);
        }
        else if (cmp > 0)
        {
            node.right = Insert(node.right, low, high);
        }
        
        return UpdateMax(node);
    }

    private Node UpdateMax(Node node)
    {
        if (node.left != null) node.max = Math.Max(node.max, node.left.max);
        if (node.right != null) node.max = Math.Max(node.max, node.right.max);

        return node;
    }

    private class Node
    {
        internal Interval interval;
        internal double max;
        internal Node right;
        internal Node left;

        public Node(Interval interval)
        {
            this.interval = interval;
            this.max = interval.High;
        }
    }
}
