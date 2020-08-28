namespace p02.SubsetSumNoRepeats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] subset = { 3, 5, -1, 10, 5, 7 };
            var targetSum = 19;

            var sums = new Dictionary<int, int>();
            sums.Add(0, 0);

            for (int i = 0; i < subset.Length; i++)
            {
                var currentNumber = subset[i];
                var temp = new Dictionary<int, int>(sums);
                foreach (var sum in temp.Keys)
                {
                    var newSum = sum + currentNumber;
                    if (!sums.ContainsKey(newSum))
                        sums.Add(newSum, currentNumber);
                }
            }

            var result = new List<int>();
            while (targetSum > 0)
            {
                var number = sums[targetSum];
                result.Add(number);
                targetSum -= number;
            }

            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
