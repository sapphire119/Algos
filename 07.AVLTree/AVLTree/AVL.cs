using System;

public class AVL<T> where T : IComparable<T>
{
    //Height, Balance Factor
    private Node<T> root;

    public Node<T> Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(T item)
    {
        var node = this.Search(this.root, item);
        return node != null;
    }

    public void Insert(T item)
    {
        this.root = this.Insert(this.root, item);
    }

    private Node<T> Insert(Node<T> node, T item)
    {
        if (node == null)
        {
            return new Node<T>(item);
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            node.Left = this.Insert(node.Left, item);
        }
        else if (cmp > 0)
        {
            node.Right = this.Insert(node.Right, item);
        }

        return Balance(node);
    }

    private Node<T> Balance(Node<T> node)
    {
        node.Height = FixHeight(node);

        var balanceFactor = this.BalanceFactor(node.Left, node.Right);
        if (Math.Abs(balanceFactor) >= 2)
        {
            var tempChild = GetNodeChild(node);
            var childBalanceFactor = this.BalanceFactor(tempChild.Left, tempChild.Right);

            //sign can be equal to 0
            //consider
            var signOfParent = Math.Sign(balanceFactor);
            var signOfChild = Math.Sign(childBalanceFactor);

            //Do rotations
            node = this.Rotate(node, tempChild, signOfParent, signOfChild);
        }

        return node;
    }

    private Node<T> Rotate(Node<T> node, Node<T> child, int signOfParent, int signOfChild)
    {
        if (signOfParent != 0 && signOfChild != 0 && signOfParent != signOfChild)
        {
            var childPosition = this.GetChildPosition(node, child);

            child = this.ChildRotation(child, signOfChild);
            if (childPosition) node.Left = child;
            else node.Right = child;
        }

        node = this.Rotation(node, signOfParent);

        return node;
    }

    private bool GetChildPosition(Node<T> node, Node<T> child)
    {
        return node.Left == child;
    }

    private Node<T> ChildRotation(Node<T> node, int childSign)
    {
        if (childSign < 0)
        {
            node = this.RotateLeftChild(node);
        }
        else if (childSign > 0)
        {
            node = this.RotateRightChild(node);
        }

        return node;
    }

    private Node<T> RotateRightChild(Node<T> node)
    {
        var temp = node;
        node = temp.Left;
        node.Height = temp.Height;
        temp.Height = node.Height - 1;

        temp.Left = null;
        //temp.Right = null;

        node.Right = temp;

        return node;
    }

    private Node<T> RotateLeftChild(Node<T> node)
    {
        var temp = node;
        node = temp.Right;
        node.Height = temp.Height;
        temp.Height = node.Height - 1;
        //temp.Left = null;
        temp.Right = null;

        node.Left = temp;

        return node;
    }

    private Node<T> Rotation(Node<T> node, int signOfElement)
    {
        if (signOfElement < 0)
        {
            //Left Rotation
            node = this.LeftRotation(node);
        }
        else if (signOfElement > 0)
        {
            //Right Rotation
            node = this.RightRotation(node);
        }

        return node;
    }

    private Node<T> LeftRotation(Node<T> node)
    {
        var temp = node;
        node = temp.Right;

        //node.Height = temp.Right.Height;
        temp.Height = node.Height - 1;
        //node.Height = temp.Height;

        temp.Right = null;
        //temp.Left = null;

        if (node.Left != null) temp.Right = node.Left;
        node.Left = temp;

        return node;
    }

    private Node<T> RightRotation(Node<T> node)
    {
        var temp = node;
        node = temp.Left;
        //node.Height = temp.Right.Height;
        temp.Height = node.Height - 1;

        //temp.Right = null;
        temp.Left = null;
        if (node.Right != null) temp.Left = node.Right;
        node.Right = temp;

        return node;
    }

    //private Node<T> DoubleRotation(Node<T> node, int signOfParent)
    //{
    //    if (signOfParent < 0)
    //    {
    //        node = this.LeftRotation(node);
    //    }
    //    else if (signOfParent > 0)
    //    {
    //        node = this.RightRotation(node);
    //    }

    //    return node;
    //}

    private Node<T> GetNodeChild(Node<T> node)
    {
        return node.Left ?? node.Right;
    }

    private int FixHeight(Node<T> node)
    {
        var leftNodeHeight = this.HeightOfNode(node.Left);
        var rightNodeHeight = this.HeightOfNode(node.Right);

        if (node.Left != null || node.Right != null)
        {
            var currentHeight = Math.Max(leftNodeHeight, rightNodeHeight) + 1;
            return currentHeight;
        }

        return node.Height;
        //return node.Left != null ? 1 + node.Left.Height :
        //    node.Right != null ? 1 + node.Right.Height : node.Height;
    }

    private int BalanceFactor(Node<T> leftNode, Node<T> rightNode)
    {
        return HeightOfNode(leftNode) - HeightOfNode(rightNode);
    }

    private int HeightOfNode(Node<T> node)
    {
        return node != null ? node.Height : 0;
    }

    //private Node<T> Rotate(Node<T> node)
    //{

    //    return node;
    //}

    //private Node<T> RotateLeftRight(Node<T> node)
    //{
    //    return node;
    //}



    public void Delete(T item)
    {
        if (!this.Contains(item))
        {
            throw new ArgumentException();
        }

        this.root = this.Delete(item, this.root);
    }

    private Node<T> Delete(T item, Node<T> node)
    {
        var comparison = item.CompareTo(node.Value);
        if (comparison < 0)
        {
            node.Left = this.Delete(item, node.Left);
        }
        else if (comparison > 0)
        {
            node.Right = this.Delete(item, node.Right);
        }
        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            var temp = node;
            //node = this.FindMind(temp.Right);
            node = this.FindMind(temp.Right);
            node.Right = this.DeleteMin(temp.Right);
            node.Left = temp.Left;
        }

        return Balance(node);
    }

    private Node<T> FindMind(Node<T> node)
    {
        if (node.Left == null)
        {
            return node;
        }

        return this.FindMind(node.Left);
    }

    private Node<T> DeleteMin(Node<T> node)
    {
        if (node.Left == null)
        {
            return node.Right;
        }

        node.Left = this.DeleteMin(node.Left);

        return node;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private Node<T> Search(Node<T> node, T item)
    {
        if (node == null)
        {
            return null;
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            return Search(node.Left, item);
        }
        else if (cmp > 0)
        {
            return Search(node.Right, item);
        }

        return node;
    }
}
