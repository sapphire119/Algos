namespace p03.DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        private static int minDiff = int.MaxValue;
        private static int maxCount = -1;
        private static List<int> resultingIndexes;

        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var tempArr = new int[input.Length];
            var positionSum = new int[input.Length];

            Array.Copy(input, tempArr, input.Length);
            Array.Sort(tempArr);

            for (int i = 0; i < tempArr.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    positionSum[i] += tempArr[j];
                }
            }
            var totalSum = input.Sum();
            var alansHalf = totalSum / 2;
            var bensHalf = totalSum - alansHalf;

            FetchAlansPresents(tempArr, totalSum, totalSum - alansHalf, new List<int>(), input.Length - 1, 0, 1, positionSum);

            var difference = (bensHalf - alansHalf) + 2 * minDiff;
            Console.WriteLine($"Difference: {difference}");

            var alanRemaining = alansHalf - minDiff;
            var benRemaining = totalSum - alanRemaining;
            Console.WriteLine($"Alan:{alanRemaining} Bob:{benRemaining}");

            var remainingAlansSorted = tempArr.Where((_, i) => !resultingIndexes.Contains(i)).Reverse().ToArray();
            Console.WriteLine($"Alan takes: {string.Join(" ", remainingAlansSorted)}");
            Console.WriteLine($"Bob takes the rest.");
        }

        private static void FetchAlansPresents(
            int[] input, int totalSum, int alansHalf, List<int> indexes, 
            int startIndex, int accumulatedSum, int elementsCount, int[] positionSum)
        {
            for (int i = startIndex, iteration = 1; i >= 0; i--, iteration++)
            {
                var currentEntry = input[i];
                if (startIndex >= 0 && currentEntry + accumulatedSum + positionSum[i] < alansHalf) break;

                var totalLeft = totalSum - currentEntry;
                if (totalLeft > alansHalf)
                {
                    indexes.Add(i);
                    FetchAlansPresents(input, totalLeft, alansHalf, indexes, startIndex - iteration,
                        accumulatedSum + currentEntry, elementsCount + 1, positionSum);
                    indexes.RemoveAt(indexes.Count - 1);
                }

                if (accumulatedSum + currentEntry >= alansHalf && accumulatedSum + currentEntry - alansHalf <= minDiff)
                {
                    var newDiff = accumulatedSum + currentEntry - alansHalf;
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