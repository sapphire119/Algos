namespace p04.SumWithUnlimitedAmountOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var sum = int.Parse(Console.ReadLine());

            var combinations = 0;
            FetchCombinations(inputArr, sum, 0, inputArr.Length - 1, ref combinations);
            Console.WriteLine(combinations);
        }

        private static void FetchCombinations(int[] inputArr, int sum, int startIndex, int endIndex, ref int combinations)
        {
            if (sum < 0) return;
            for (int i = startIndex; i <= endIndex; i++)
            {
                var currentNumb = inputArr[i];
                if (i == 0 && sum % currentNumb == 0) combinations++;
                if (i != 0)
                {
                    FetchCombinations(inputArr, sum - currentNumb, 0, i, ref combinations);
                }
            }
        }
    }
}
