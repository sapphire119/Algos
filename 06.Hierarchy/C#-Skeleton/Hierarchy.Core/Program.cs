namespace Hierarchy.Core
{
    using System;

    class Program
    {
        static void Main()
        {

            //var hierarchy = new Hierarchy<string>("Leonidas");
            var hierarchy = new Hierarchy<int>(5);
            hierarchy.Add(5, 50);
            hierarchy.Add(5, 70);
            hierarchy.Add(70, 100);
            hierarchy.Add(50, 200);
            hierarchy.Add(70, 120);
            hierarchy.Add(70, 110);
            hierarchy.Add(110, 0);
            hierarchy.Add(200, 201);
            hierarchy.Add(201, 202);
            hierarchy.Add(50, 300);

            //hierarchy.Add("Leonidas", "Xena The Princess Warrior");
            //hierarchy.Add("Leonidas", "General Protos");
            //hierarchy.Add("Xena The Princess Warrior", "Gorok");
            //hierarchy.Add("Xena The Princess Warrior", "Bozot");
            //hierarchy.Add("General Protos", "Subotli");
            //hierarchy.Add("General Protos", "Kira");
            //hierarchy.Add("General Protos", "Zaler");
            //hierarchy.Add("Kira", "test1");
            //hierarchy.Add("Kira", "test2");
            //hierarchy.Add("Kira", "test3");
            //hierarchy.Add("test3", "Depth4");
            //var test = hierarchy.Count;
            //hierarchy.GetParent("Leonidas");
            //hierarchy.GetParent("Bai ivan");

            //hierarchy.Remove("General Protos");

            //var children = hierarchy.GetChildren("Leonidas");
            //Console.WriteLine(string.Join(", ", children));

            //var parent = hierarchy.GetParent("Kira");
            //Console.WriteLine(parent);

            //hierarchy.Remove("General Protos");
            //children = hierarchy.GetChildren("Leonidas");
            //Console.WriteLine(string.Join(", ", children));

            foreach (var item in hierarchy)
            {
                Console.WriteLine(item);
            }
        }
    }
}
