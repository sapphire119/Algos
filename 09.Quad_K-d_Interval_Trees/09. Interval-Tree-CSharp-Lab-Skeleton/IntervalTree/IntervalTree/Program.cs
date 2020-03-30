using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var tree = new IntervalTree();

        tree.Insert(20.0, 36.0);
        tree.Insert(3.0, 10.0);
        tree.Insert(29.0, 99.0);
        tree.Insert(0.0, 1.0);
        tree.Insert(10.0, 15.0);
        tree.Insert(25.0, 30.0);



        //tree.SearchAny(0.5, 2.0);
        //tree.SearchAny(12, 19);

        tree.SearchAll(9, 50);
        ;
    }
}
