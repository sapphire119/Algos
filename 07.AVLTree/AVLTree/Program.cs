using System;

class Program
{
    static void Main(string[] args)
    {
        AVL<int> tree = new AVL<int>();

        //tree.Insert(1);
        //tree.Insert(5);
        //tree.Insert(3);
        //tree.Insert(2);

        //tree.Insert(1);
        //tree.Insert(2);
        //tree.Insert(3);
        //tree.Insert(4);
        ////tree.Insert(0);
        //tree.Insert(5);
        //tree.Insert(6);


        //tree.Insert(5);
        //tree.Insert(6);
        //tree.Insert(3);
        //tree.Insert(4);
        //tree.Insert(1);
        //tree.Insert(0);

        //tree.Insert(100);
        //tree.Insert(60);
        //tree.Insert(150);
        //tree.Insert(40);
        //tree.Insert(80);
        //tree.Insert(120);
        //tree.Insert(200);
        //tree.Insert(10);
        //tree.Insert(50);
        //tree.Insert(70);
        //tree.Insert(90);
        //tree.Insert(140);
        //tree.Insert(220);
        //tree.Insert(250);

        //tree.Delete(100);

        tree.Insert(60);
        tree.Insert(40);
        tree.Insert(80);
        tree.Insert(90);
        tree.Insert(70);

        tree.Delete(40);
        ;
    }
}
