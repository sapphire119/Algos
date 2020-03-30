using System;

public class KdTree
{
    private Node root;
    private const int CurrentDimensions = 2;

    public Node Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(Point2D point)
    {
        return this.Contains(this.root, point, 0);
    }

    private bool Contains(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return false;
        }

        var comparison = CompareTwoPoints(node.Point, point, depth);
        if (comparison < 0)
        {
            return this.Contains(node.Left, point, depth + 1);
        }
        else if (comparison > 0)
        {
            return this.Contains(node.Right, point, depth + 1);
        }

        return true;
    }

    public void Insert(Point2D point)
    {
        this.root = this.Insert(point, this.root, 0);
    }

    private Node Insert(Point2D point, Node node, int depth)
    {
        if (node == null)
        {
            return new Node(point);
        }

        var comparison = CompareTwoPoints(node.Point, point, depth);
        if (comparison < 0)
        {
            node.Left = this.Insert(point, node.Left, depth + 1);
        }
        else if (comparison > 0)
        {
            node.Right = this.Insert(point, node.Right, depth + 1);
        }

        return node;
    }

    private int CompareTwoPoints(Point2D nodePoint, Point2D currentPoint, int depth)
    {
        if (depth % CurrentDimensions == 0)
        {
            return PointUtils.CompareByX(nodePoint, currentPoint);
        }
        else if (depth % CurrentDimensions == 1)
        {
            return PointUtils.CompareByY(nodePoint, currentPoint);
        }

        return default;
    }

    public void EachInOrder(Action<Point2D> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<Point2D> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Point);
        this.EachInOrder(node.Right, action);
    }
}
