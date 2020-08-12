namespace p03.DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int minDiff = int.MaxValue;
        private static int maxCount = -1;
        private static List<int> resultingIndexes;

        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var positionSum = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    positionSum[i] += input[j];
                }
            }

            var totalSum = input.Sum();
            var alansHalf = totalSum / 2;
            var bensHalf = totalSum - alansHalf;

            FetchAlansPresents(input, totalSum, bensHalf, new List<int>(), input.Length - 1, 0, 1, positionSum);
            

            var difference = (bensHalf - alansHalf) + 2 * minDiff;
            Console.WriteLine($"Difference: {difference}");

            var alanRemaining = alansHalf - minDiff;
            var benRemaining = totalSum - alanRemaining;
            Console.WriteLine($"Alan:{alanRemaining} Bob:{benRemaining}");

            var remainingAlansSorted = input.Where((_, i) => !resultingIndexes.Contains(i)).Reverse().ToArray();
            Console.WriteLine($"Alan takes: {string.Join(" ", remainingAlansSorted)}");
            Console.WriteLine($"Bob takes the rest.");
        }

        private static void FetchAlansPresents(
            int[] input, int totalSum, int bensHalf, List<int> indexes, 
            int startIndex, int accumulatedSum, int elementsCount, int[] positionSum)
        {
            for (int i = startIndex, iteration = 1; i >= 0; i--, iteration++)
            {
                var currentEntry = input[i];
                if (startIndex >= 0 && currentEntry + accumulatedSum + positionSum[i] < bensHalf) break;

                var totalLeft = totalSum - currentEntry;
                if (totalLeft > bensHalf)
                {
                    indexes.Add(i);
                    FetchAlansPresents(input, totalLeft, bensHalf, indexes, startIndex - iteration,
                        accumulatedSum + currentEntry, elementsCount + 1, positionSum);
                    indexes.RemoveAt(indexes.Count - 1);
                }

                var newDiff = accumulatedSum + currentEntry - bensHalf;
                if (accumulatedSum + currentEntry >= bensHalf && newDiff <= minDiff)
                {
                    if (elementsCount > maxCount || newDiff < minDiff)
                    {
                        indexes.Add(i);
                        resultingIndexes = new List<int>(indexes);
                        maxCount = elementsCount;
                        minDiff = newDiff;
                        indexes.RemoveAt(indexes.Count - 1);
                    }
                }
            }
        }
    }
}