namespace p07.NChooseKCount
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var k = long.Parse(Console.ReadLine());


            var result = BinomialCoeff(n, k);
            Console.WriteLine(result);
        }

        private static long BinomialCoeff(long n, long k)
        {
            if (k > n)
                return 0;
            if (k == 0 || k == n)
                return 1;
            return BinomialCoeff(n - 1, k - 1) + BinomialCoeff(n - 1, k);
        }
    }
}
