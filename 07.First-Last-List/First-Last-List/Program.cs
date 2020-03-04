using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Wintellect.PowerCollections;

public class Program
{
    public static void Main()
    {
        FirstLastList<int> list = new FirstLastList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);


        list.Min(2);
        //Console.WriteLine();

        var avlTree = new AVL<int>();
        var test = new List<Node<int>>();


        avlTree.Insert(10);
        avlTree.Insert(10);
        var currentNode = avlTree.Search(10);
        test.Add(currentNode);


        var productTree = new AVL<Product>();
        productTree.Insert(new Product(1.11m, "first"));
        productTree.Insert(new Product(0.50m, "coffee"));
        productTree.Insert(new Product(1.20m, "mint drops"));
        productTree.Insert(new Product(1.20m, "beer"));
        productTree.Insert(new Product(0.50m, "candy"));
        productTree.Insert(new Product(1.20m, "cola"));
        productTree.Insert(new Product(2.99m, "chocolate"));
        ;


        //Delete
        //var searchedNode = avlTree.Search(10);
        //avlTree.Delete(10);
        //test.Remove(searchedNode);
        ;

        //test

        var listA = new List<Node<int>>();
        var listB = new List<Node<int>>();

        var node = new Node<int>(10);
        listA.Add(node);
        listB.Add(node);

        var deletionNode = listA.Find(e => e == node);
        deletionNode.Value = 5;
        node.Value = 7;

        
    }

    
}

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

    public void Clear() => this.root = null;

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
        else if (cmp == 0)
        {
            node.Duplicates.Add(new Node<T>(item));
        }

        return Balance(node);
    }

    private Node<T> Balance(Node<T> node)
    {
        if (node == null)
        {
            return default;
        }

        node.Height = FixHeight(node);

        var balanceFactor = this.BalanceFactor(node.Left, node.Right);
        if (Math.Abs(balanceFactor) >= 2)
        {
            var signOfParent = Math.Sign(balanceFactor);

            var tempChild = GetNodeChild(node, signOfParent);
            var childBalanceFactor = this.BalanceFactor(tempChild.Left, tempChild.Right);

            //sign can be equal to 0
            //consider
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

        if (node.Right != null) { temp.Left = node.Right; temp.Height = FixHeight(temp); ; }
        node.Right = temp;

        return node;
    }

    private Node<T> RotateLeftChild(Node<T> node)
    {
        var temp = node;
        node = temp.Right;
        node.Height = temp.Height;
        temp.Height = node.Height - 1;

        temp.Right = null;

        if (node.Left != null) { temp.Right = node.Left; temp.Height = FixHeight(temp); }
        node.Left = temp;

        return node;
    }

    private Node<T> Rotation(Node<T> node, int signOfElement)
    {
        if (signOfElement < 0)
        {
            node = this.LeftRotation(node);
        }
        else if (signOfElement > 0)
        {
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

        if (node.Left != null) { temp.Right = node.Left; temp.Height = FixHeight(temp); }
        node.Left = temp;

        node.Height = FixHeight(node);

        return node;
    }

    private Node<T> RightRotation(Node<T> node)
    {
        var temp = node;
        node = temp.Left;
        temp.Height = node.Height - 1;

        temp.Left = null;
        if (node.Right != null) { temp.Left = node.Right; temp.Height = FixHeight(temp); ; }
        node.Right = temp;

        node.Height = FixHeight(node);

        return node;
    }

    private Node<T> GetNodeChild(Node<T> node, int parentSign)
    {
        return parentSign < 0 ? node.Right : node.Left;
    }

    private int FixHeight(Node<T> node)
    {
        var leftNodeHeight = this.HeightOfNode(node.Left);
        var rightNodeHeight = this.HeightOfNode(node.Right);

        var currentHeight = Math.Max(leftNodeHeight, rightNodeHeight) + 1;
        return currentHeight;
    }

    private int HeightOfNode(Node<T> node)
    {
        return node != null ? node.Height : 0;
    }

    private int BalanceFactor(Node<T> leftNode, Node<T> rightNode)
    {
        return HeightOfNode(leftNode) - HeightOfNode(rightNode);
    }

    public void Delete(T item)
    {
        if (!this.Contains(item))
        {
            return;
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
            node.Right = Balance(this.DeleteMin(temp.Right));
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
    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        this.root = this.DeleteMin(this.root);
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

    public Node<T> Search(T item)
    {
        return this.Search(this.root, item);
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

class Product : IComparable<Product>
{
    public string Title { get; set; }
    public decimal Price { get; set; }

    public Product(decimal price, string title)
    {
        this.Price = price;
        this.Title = title;
    }

    public int CompareTo(Product other)
    {
        return this.Price.CompareTo(other.Price);

    }
}


