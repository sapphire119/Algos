namespace p03.DividingPresents._01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //var input = new int[] { 7, 17, 45, 91, 11, 32, 102, 33, 6, 3 };
            var totalSum = input.Sum();
            var alansHalf = totalSum / 2;

            var alanNumbers = FetchAlansNumbers(input, alansHalf);
            var alanResultingHalf = alanNumbers.Sum();
            var bobResultingHalf = totalSum - alanResultingHalf;

            Console.WriteLine($"Difference: {bobResultingHalf - alanResultingHalf}");
            Console.WriteLine($"Alan:{alanResultingHalf} Bob:{bobResultingHalf}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alanNumbers)}");
            Console.WriteLine($"Bob takes the rest.");
        }

        private static int[] FetchAlansNumbers(int[] input, int alansHalf)
        {
            var allSums = new Dictionary<int, int>() { { 0, 0 } };
            for (int i = 0; i < input.Length; i++)
            {
                var keys = allSums.Keys.ToArray();
                foreach (var sum in keys)
                {
                    var temp = sum + input[i];
                    if (!allSums.ContainsKey(temp)) allSums.Add(temp, input[i]);
                }
            }

            while (alansHalf > 0)
            {
                if (allSums.ContainsKey(alansHalf))
                {
                    return GetAlansNumbers(allSums, alansHalf);
                }
                alansHalf--;
            }

            return new int[0];
        }

        private static int[] GetAlansNumbers(Dictionary<int, int> allSums, int alansHalf)
        {
            var result = new List<int>();
            while (alansHalf > 0)
            {
                result.Add(allSums[alansHalf]);
                alansHalf -= allSums[alansHalf];
            }

            return result.ToArray();
        }
    }
}
