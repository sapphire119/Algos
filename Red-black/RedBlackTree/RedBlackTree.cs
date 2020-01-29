using System;
using System.Collections.Generic;

public class RedBlackTree<T> : IBinarySearchTree<T> where T : IComparable
{
    private const bool Red = true;
    private const bool Black = false;

    private Node root;

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }


    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private int Count(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Count;
    }

    private RedBlackTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public RedBlackTree()
    {
    }

    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
        this.root.Color = Black;
    }

    private Node Insert(T element, Node node, Node parent = null)
    {
        if (node == null)
        {
            node = new Node(element, Red, parent);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left, node);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right, node);
        }
        //if (IsRed(node) && IsRed(node.Parent) && IsRed(node.Parent.Aunt))
        if (IsRed(node) && IsRed(node.Aunt) && (IsRed(node.Left) || IsRed(node.Right)))
        {
            FlipColor(node.Parent);
        }

        if ((IsRed(node) && !IsRed(node.Aunt) && (IsRed(node.Left) || IsRed(node.Right))) && 
            ((!IsLeft(node) && IsRed(node.Left)) || (IsLeft(node) && IsRed(node.Right))))
        {
            node = this.Rotate(node);
        }

        if ((IsRed(node.Right) && IsRed(node.Right.Right)) || (IsRed(node.Left) && IsRed(node.Left.Left)))
        {
            node = this.DoubleRotate(node);
            this.FixColors(node);
        }

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return Balance(node);
    }

    private Node Balance(Node node)
    {
        return node;
    }

    private Node Rotate(Node node)
    {
        if (IsRed(node) && IsRed(node.Left) && !IsRed(node.Right))
        {
            return this.RotateRight(node);
        }

        if (IsRed(node) && IsRed(node.Right) && !IsRed(node.Left))
        {
            return this.RotateLeft(node);
        }

        return node;
    }

    private Node DoubleRotate(Node node)
    {
        bool? parentNodePosition = node.Parent != null ? IsLeft(node) : default(bool?);
        if (IsRed(node.Right) && IsRed(node.Right.Right))
        {
            return this.DoubleRedRotateLeft(node, parentNodePosition);
        }

        if (IsRed(node.Left) && IsRed(node.Left.Left))
        {
            return this.DoubleRedRotateRight(node, parentNodePosition);
        }

        return node;
    }

    private Node FixParent(Node node, bool? parentNodePosition)
    {
        if (parentNodePosition != null)
        {
            if (parentNodePosition.Value)
            {
                node.Parent.Left = node;
            }
            else
            {
                node.Parent.Right = node;
            }
        }

        return node;
    }

    private Node DoubleRedRotateLeft(Node node, bool? parentNodePosition)
    {
        var temp = node;
        node = temp.Right;
        node.Parent = temp.Parent;
        node = FixParent(node, parentNodePosition);
        temp.Right = node.Left;
        if (temp.Right != null) temp.Right.Parent = temp;
        temp.Parent = node;
        node.Left = temp;

        return node;
    }

    private Node DoubleRedRotateRight(Node node, bool? parentNodePosition)
    {
        var temp = node;
        node = temp.Left;
        node.Parent = temp.Parent;
        node = FixParent(node, parentNodePosition);
        temp.Left = node.Right;
        if (temp.Left != null) temp.Left.Parent = temp;
        temp.Parent = node;
        node.Right = temp;

        return node;
    }

    private void FixColors(Node node)
    {
        node.Color = Black;
        node.Left.Color = Red;
        node.Right.Color = Red;
    }

    private Node RotateLeft(Node node)
    {
        var temp = node;
        node = temp.Right;
        node.Parent = temp.Parent;
        node.Parent.Left = node;
        temp.Right = node.Left;
        if (temp.Right != null) temp.Right.Parent = temp;
        temp.Parent = node;
        node.Left = temp;

        return node;
    }

    private Node RotateRight(Node node)
    {
        var temp = node;
        node = temp.Left;
        node.Parent = temp.Parent;
        node.Parent.Right = node;
        temp.Left = node.Right;
        if (temp.Left != null) temp.Left.Parent = temp;
        temp.Parent = node;
        node.Right = temp;

        return node;
    }

    private void FlipColor(Node node)
    {
        node.Color = !node.Color;
        node.Left.Color = !node.Left.Color;
        node.Right.Color = !node.Right.Color;
    }

    private bool IsRed(Node node)
    {
        if (node == null)
        {
            return false;
        }

        return node.Color == Red;
    }

    private bool IsLeft(Node node)
    {
        return node.Parent.Left == node;
    }

    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    public IBinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new RedBlackTree<T>(current);
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        this.root = this.DeleteMin(this.root);
    }

    private Node DeleteMin(Node node)
    {
        if (node.Left == null)
        {
            return node.Right;
        }

        node.Left = this.DeleteMin(node.Left);
        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public virtual void Delete(T element)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }
        this.root = this.Delete(element, this.root);
    }

    private Node Delete(T element, Node node)
    {
        if (node == null)
        {
            return null;
        }

        int compare = element.CompareTo(node.Value);

        if (compare < 0)
        {
            node.Left = this.Delete(element, node.Left);
        }
        else if (compare > 0)
        {
            node.Right = this.Delete(element, node.Right);
        }
        else
        {
            if (node.Right == null)
            {
                return BalanceReplacement(node.Left, node);
            }
            if (node.Left == null)
            {
                return BalanceReplacement(node.Right, node);
            }

            Node temp = node;
            node = this.FindMin(temp.Right);
            node.Right = this.DeleteMin(temp.Right);
            node.Left = temp.Left;
            node.Parent = temp.Parent;
            CorrectChildParentRelation(node);
        }

        node.Count = this.Count(node.Left) + this.Count(node.Right) + 1;

        return node;
    }

    private void CorrectChildParentRelation(Node node)
    {
        if (node.Left != null) node.Left.Parent = node;
        if (node.Right != null) node.Right.Parent = node;
    }

    private Node BalanceReplacement(Node replacement, Node node)
    {
        if (replacement == null) return replacement;
        replacement.Parent = node.Parent;
        return replacement;
    }

    private Node FindMin(Node node)
    {
        if (node.Left == null)
        {
            return node;
        }

        return this.FindMin(node.Left);
    }

    public void DeleteMax()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        this.root = this.DeleteMax(this.root);
    }

    private Node DeleteMax(Node node)
    {
        if (node.Right == null)
        {
            return node.Left;
        }

        node.Right = this.DeleteMax(node.Right);
        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    public int Count()
    {
        return this.Count(this.root);
    }

    public int Rank(T element)
    {
        return this.Rank(element, this.root);
    }

    private int Rank(T element, Node node)
    {
        if (node == null)
        {
            return 0;
        }

        int compare = element.CompareTo(node.Value);

        if (compare < 0)
        {
            return this.Rank(element, node.Left);
        }

        if (compare > 0)
        {
            return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
        }

        return this.Count(node.Left);
    }

    public T Select(int rank)
    {
        Node node = this.Select(rank, this.root);
        if (node == null)
        {
            throw new InvalidOperationException();
        }

        return node.Value;
    }

    private Node Select(int rank, Node node)
    {
        if (node == null)
        {
            return null;
        }

        int leftCount = this.Count(node.Left);
        if (leftCount == rank)
        {
            return node;
        }

        if (leftCount > rank)
        {
            return this.Select(rank, node.Left);
        }
        else
        {
            return this.Select(rank - (leftCount + 1), node.Right);
        }
    }

    public T Ceiling(T element)
    {

        return this.Select(this.Rank(element) + 1);
    }

    public T Floor(T element)
    {
        return this.Select(this.Rank(element) - 1);
    }

    private class Node
    {
        public Node(T value, bool color, Node parent)
        {
            this.Value = value;
            this.Color = color;
            this.Parent = parent;
        }

        public T Value { get; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node Parent { get; set; }

        public Node Aunt => this.Parent != null ? (this.Parent.Left != this ? this.Parent.Left : this.Parent.Right) : null;

        public bool Color { get; set; }

        public int Count { get; set; }
    }

}

public class Launcher
{
    public static void Main(string[] args)
    {
        var rbt = new RedBlackTree<int>();

        //rbt.Insert(3);
        //rbt.Insert(1);
        //rbt.Insert(5);
        ////ColorFlip
        //rbt.Insert(7);
        ////Rotate R-L
        ////After Rotation Flip
        //rbt.Insert(6);

        ////Color Flip
        //rbt.Insert(8);
        ////Left Rotate
        //rbt.Insert(9);
        ////Color Flip
        ////Left Rotation
        //rbt.Insert(10);
        //;
        ////End Result Tree:
        ////Root -> 6
        ////3, 8 RED
        ////1, 5, 7, 9 BLACK
        ////10 Red


        rbt.Insert(30);
        rbt.Insert(20);
        rbt.Insert(50);
        rbt.Insert(10);
        rbt.Insert(60);
        rbt.Insert(40);
        rbt.Insert(45);
        rbt.Insert(42);
        rbt.Insert(47);

        rbt.Delete(30);
    }
}
