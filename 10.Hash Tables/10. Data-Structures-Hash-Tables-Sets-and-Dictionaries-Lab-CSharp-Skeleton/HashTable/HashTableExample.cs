using System;
using System.Collections.Generic;

class Example
{
    static void Main()
    {
        //Dictionary<int, int> dict = new Dictionary<int, int>();
        //dict.Keys
        //var a = -100000000;
        //var b = -4123;
        //var res = a & 0x7FFFFFFF;
        //var test = res % 16;
        //;        //var dict = new Dictionary<int, int>();
        ////dict.Add(10, 5);
        ////dict.Add(3, 5);
        ////dict.Add(4, 5);
        ////dict.Add(5, 5);

        //foreach (var kvp in dict)
        //{
        //    Console.WriteLine(kvp.Key);
        //}

        //dict.Remove(3);
        //dict.Add(6, 3);
        //foreach (var kvp in dict)
        //{
        //    Console.WriteLine(kvp.Key);
        //}
        //;

        HashTable<string, int> grades = new HashTable<string, int>();

        Console.WriteLine("Grades:" + string.Join(",", grades));
        Console.WriteLine("--------------------");

        grades.Add("Peter", 3);
        grades.Add("Maria", 6);
        grades["George"] = 5;
        Console.WriteLine("Grades:" + string.Join(",", grades));
        Console.WriteLine("--------------------");

        grades.AddOrReplace("Peter", 33);
        grades.AddOrReplace("Tanya", 4);
        grades["George"] = 55;
        Console.WriteLine("Grades:" + string.Join(",", grades));
        Console.WriteLine("--------------------");

        Console.WriteLine("Keys: " + string.Join(", ", grades.Keys));
        Console.WriteLine("Values: " + string.Join(", ", grades.Values));
        Console.WriteLine("Count = " + string.Join(", ", grades.Count));
        Console.WriteLine("--------------------");

        grades.Remove("Peter");
        grades.Remove("George");
        grades.Remove("George");
        Console.WriteLine("Grades:" + string.Join(",", grades));
        Console.WriteLine("--------------------");

        Console.WriteLine("ContainsKey[\"Tanya\"] = " + grades.ContainsKey("Tanya"));
        Console.WriteLine("ContainsKey[\"George\"] = " + grades.ContainsKey("George"));
        Console.WriteLine("Grades[\"Tanya\"] = " + grades["Tanya"]);
        Console.WriteLine("--------------------");
    }
}
