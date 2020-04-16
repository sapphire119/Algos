using System;
using System.Collections.Generic;
using System.Linq;

public class QuadTree<T> where T : IBoundable
{
    public const int DefaultMaxDepth = 5;

    public readonly int MaxDepth;

    private Node<T> root;

    public QuadTree(int width, int height, int maxDepth = DefaultMaxDepth)
    {
        this.root = new Node<T>(0, 0, width, height);
        this.Bounds = this.root.Bounds;
        this.MaxDepth = maxDepth;
    }

    public int Count { get; private set; }

    public Rectangle Bounds { get; private set; }


    public bool Insert(T item)
    {
        if (!item.Bounds.IsInside(this.Bounds)) return false;

        int depth = 1;
        var currentNode = this.root;
        while (currentNode.Children != null)
        {
            var quadrant = this.GetQuadrant(currentNode, item.Bounds);
            if (quadrant == -1) break;
            currentNode = currentNode.Children[quadrant];
        }

        currentNode.Items.Add(item);
        this.Split(currentNode, depth);
        this.Count++;


        return true;
    }

    private void Split(Node<T> currentNode, int nodeDepth)
    {
        if (!(currentNode.ShouldSplit && nodeDepth < MaxDepth)) return;

        var leftWidth = currentNode.Bounds.Width / 2;
        var rightWidth = currentNode.Bounds.Width - leftWidth;

        var topHeight = currentNode.Bounds.Height / 2;
        var bottomHeight = currentNode.Bounds.Height - topHeight;

        currentNode.Children = new Node<T>[4];

        currentNode.Children[0] = 
            new Node<T>(currentNode.Bounds.MidX, currentNode.Bounds.MidY, rightWidth, topHeight); // I
        currentNode.Children[1] = 
            new Node<T>(currentNode.Bounds.X1, currentNode.Bounds.MidY, leftWidth, topHeight); // II
        currentNode.Children[2] = 
            new Node<T>(currentNode.Bounds.X1, currentNode.Bounds.Y1, leftWidth, bottomHeight); // III
        currentNode.Children[3] = 
            new Node<T>(currentNode.Bounds.MidX, currentNode.Bounds.Y1, rightWidth, bottomHeight); // IV

        for (int i = 0; i < currentNode.Items.Count; i++)
        {
            var item = currentNode.Items[i];
            var quadrant = this.GetQuadrant(currentNode, item.Bounds);
            if (quadrant != -1)
            {
                var itemIndex = currentNode.Items.IndexOf(item);
                currentNode.Items.RemoveAt(itemIndex);

                var currentChild = currentNode.Children[quadrant];

                currentChild.Items.Add(item);

                //currentNode.Items.Add(item);
            }
        }

        foreach (var child in currentNode.Children)
        {
            this.Split(child, nodeDepth + 1);
        }

    }

    private int GetQuadrant(Node<T> currentNode, Rectangle itemBounds)
    {
        var midPointX = currentNode.Bounds.MidX;
        var midPointY = currentNode.Bounds.MidY;

        var inTopQuadrant = midPointY <= itemBounds.Y1 &&
                itemBounds.Y2 <= currentNode.Bounds.Y2;

        var inBottomQuadrant = currentNode.Bounds.Y1 <= itemBounds.Y1 &&
                itemBounds.Y2 <= midPointY;

        var inLeftQuadrant = currentNode.Bounds.X1 <= itemBounds.X1 &&
                itemBounds.X1 <= midPointX;
        
        var inRightQuadrant = midPointX <= itemBounds.X1 && 
                itemBounds.X2 <= currentNode.Bounds.X2;


        if (inLeftQuadrant)
        {
            if (inTopQuadrant)
            {
                return 1;
            }
            else if (inBottomQuadrant)
            {
                return 2;
            }
        }
        else if (inRightQuadrant)
        {
            if (inTopQuadrant)
            {
                return 0;
            }
            else if (inBottomQuadrant)
            {
                return 3;
            }
        }


        return -1;
    }


    public List<T> Report(Rectangle bounds)
    {
        var collisionCandidates = new List<T>();

        GetCollisionCandidates(this.root, bounds, collisionCandidates);

        return collisionCandidates;
        //throw new NotImplementedException();
    }

    private void GetCollisionCandidates(Node<T> node, Rectangle bounds, List<T> collisionCandidates)
    {
        var quadrant = this.GetQuadrant(node, bounds);
        if (quadrant == -1)
        {
            GetSubtreeContents(node, bounds, collisionCandidates);
        }
        else
        {
            if (node.Children != null)
            {
                GetCollisionCandidates(node.Children[quadrant], bounds, collisionCandidates);
            }
                //return;

            collisionCandidates.AddRange(node.Items);

        }
    }

    private void GetSubtreeContents(Node<T> node, Rectangle bounds, List<T> collisionCandidates)
    {
        if (node.Children != null)
        {
            foreach (var child in node.Children)
            {
                if (child.Bounds.Intersects(bounds))
                {
                    GetSubtreeContents(child, bounds, collisionCandidates);
                }
            }
        }

        collisionCandidates.AddRange(node.Items);
    }

    public void ForEachDfs(Action<List<T>, int, int> action)
    {
        this.ForEachDfs(this.root, action);
    }

    private void ForEachDfs(Node<T> node, Action<List<T>, int, int> action, int depth = 1, int quadrant = 0)
    {
        if (node == null)
        {
            return;
        }

        if (node.Items.Any())
        {
            action(node.Items, depth, quadrant);
        }

        if (node.Children != null)
        {
            for (int i = 0; i < node.Children.Length; i++)
            {
                ForEachDfs(node.Children[i], action, depth + 1, i);
            }
        }
    }
}
