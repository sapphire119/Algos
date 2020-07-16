namespace p02.LongestIncreasingSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var solutionsCount = new int[input.Length];
            var orderOfSequence = new int[input.Length];
            for (int i = 0; i < orderOfSequence.Length; i++) orderOfSequence[i] = -1;
            for (int i = 0; i < solutionsCount.Length; i++) solutionsCount[i] = 1;

            var currentMaxIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var currentNumb = input[i];
                var prevSolution = 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = input[j];
                    if (previousNumber < currentNumb &&
                        prevSolution < solutionsCount[j] + 1)
                    {
                        prevSolution = solutionsCount[j];
                        orderOfSequence[i] = j;
                        solutionsCount[i] = prevSolution + 1;
                    }
                }

                if (solutionsCount[i] > solutionsCount[currentMaxIndex]) currentMaxIndex = i;
            }

            var numbers = new Stack<int>();
            while (currentMaxIndex != -1)
            {
                numbers.Push(input[currentMaxIndex]);
                currentMaxIndex = orderOfSequence[currentMaxIndex];
            }

            Console.WriteLine($"{string.Join(" ", numbers.ToArray())}");
        }
    }
}
