namespace p01.Fibonacci
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            //Fibonacci bottom up, constant space
            var input = int.Parse(Console.ReadLine());

            var fibs = new int[2];
            for (int i = 0; i <= input; i++)
            {
                if (i == 0) fibs[i] = 0;
                if (i == 1) fibs[i] = 1;
                else if (i >= 2)
                {
                    if (i % 2 == 0) fibs[i % 2] = fibs[i % 2] + fibs[i % 2 + 1];
                    else fibs[i % 2] = fibs[i % 2] + fibs[i % 2 - 1];
                }
            }

            Console.WriteLine($"Bottom up method -> Number is {fibs[input % 2]}");

            //Fibonacci Top-down
            var dpTable = new Dictionary<int, int>();
            var number = Fibonacci(input, dpTable);
            Console.WriteLine($"Top down method -> Number is {number}");
        }

        private static int Fibonacci(int n, Dictionary<int, int> dpTable)
        {
            if (dpTable.ContainsKey(n)) return dpTable[n];
            if (n == 0) return 0;
            if (n == 1) return 1;

            var result = Fibonacci(n - 1, dpTable) + Fibonacci(n - 2, dpTable);
            dpTable[n] = result;
            return result;
        }
    }
}