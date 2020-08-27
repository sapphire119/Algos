namespace p05.SumWithLimitedCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var sum = int.Parse(Console.ReadLine());
            var combinations = 0;

            var list = new List<int>();
            list.Add(0);
            for (int i = 0; i < input.Length; i++)
            {
                var currentNum = input[i];
                var oldList = new List<int>(list);
                foreach (var numb in oldList)
                {
                    var temp = numb + currentNum;
                    if (sum == temp)
                    { combinations++; break; }
                    list.Add(temp);
                }
            }
            Console.WriteLine(combinations);
        }
    }
}
