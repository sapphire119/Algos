namespace p01.BinomialCoefficient
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            var dpTable = new long[n + 1, k + 1];
            
            var result = BinomialCoefficient(n, k, dpTable);
            Console.WriteLine(result);
        }

        private static long BinomialCoefficient(int n, int k, long[,] dpTable)
        {
            if (dpTable[n, k] > 0) return dpTable[n, k];
            if (k == 0) return 1;
            if (n == k) return 1;
            var firstPart = BinomialCoefficient(n - 1, k - 1, dpTable);
            var secondPart = BinomialCoefficient(n - 1, k, dpTable);
            dpTable[n, k] = firstPart + secondPart;
            var result = firstPart + secondPart;
            return result;
        }
    }
}
