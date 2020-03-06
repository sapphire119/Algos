using First_Last_List;
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
        //FirstLastList<int> list = new FirstLastList<int>();
        //list.Add(1);
        //list.Add(2);
        //list.Add(3);
        //list.Add(4);

        //list.Min(2);
        ////Console.WriteLine();

        //var avlTree = new AVL<int>();
        //var test = new List<Node<int>>();

        //avlTree.Insert(10);
        //avlTree.Insert(10);
        //var currentNode = avlTree.Search(10);
        //test.Add(currentNode);

        var testing = new DoubleLinkedList<int>();

        testing.Insert(10);
        testing.Insert(20);
        testing.Insert(30);
        testing.Insert(50);
        testing.Insert(100);


        var secondList = new FirstLastList<Product>();
        secondList.Add(new Product(1.11m, "first"));
        secondList.Add(new Product(0.50m, "coffee"));
        secondList.Add(new Product(1.20m, "mint drops"));
        secondList.Add(new Product(1.20m, "beer"));
        secondList.Add(new Product(0.50m, "candy"));
        secondList.Add(new Product(1.20m, "cola"));
        secondList.Add(new Product(2.99m, "chocolate"));

        secondList.Min(5);
        secondList.Max(5);

        var count = secondList.RemoveAll(new Product(200m, null));
        //var productTree = new AVL<Product>();
        //productTree.Insert(new Product(1.11m, "first"));
        //productTree.Insert(new Product(0.50m, "coffee"));
        //productTree.Insert(new Product(1.20m, "mint drops"));
        //productTree.Insert(new Product(1.20m, "beer"));
        //productTree.Insert(new Product(0.50m, "candy"));
        //productTree.Insert(new Product(1.20m, "cola"));
        //productTree.Insert(new Product(2.99m, "chocolate"));

        

        //Delete
        //var searchedNode = avlTree.Search(10);
        //avlTree.Delete(10);
        //test.Remove(searchedNode);

        //test

        //var listA = new List<Node<int>>();
        //var listB = new List<Node<int>>();

        //var node = new Node<int>(10);
        //listA.Add(node);
        //listB.Add(node);

        //var deletionNode = listA.Find(e => e == node);
        //deletionNode.Value = 5;
        //node.Value = 7;
    }

    
}

