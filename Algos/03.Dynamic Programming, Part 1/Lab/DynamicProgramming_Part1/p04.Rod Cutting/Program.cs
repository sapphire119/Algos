namespace p04.Rod_Cutting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var ropeLength = int.Parse(Console.ReadLine());

            //Bottom-up appraoch
            var bestPrice = new int[ropeLength + 1];
            var bestCombo = new int[ropeLength + 1];
            var maxSum = CutRod(ropeLength, bestPrice, input, bestCombo);

            Console.WriteLine(maxSum);
            var result = new List<int>();
            if (ropeLength > 0)
            {
                while (ropeLength > 0)
                {
                    result.Add(bestCombo[ropeLength]);
                    ropeLength -= bestCombo[ropeLength];
                }
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine(ropeLength);
            }

            //Top-down approach
            //var bestPriceRec = new int[ropeLength + 1];
            //var bestComboRec = new int[ropeLength + 1];
            //var maxSumRec = CutRodRec(ropeLength, input, bestPriceRec, bestComboRec);

        }

        private static int CutRodRec(int n, int[] input, int[] bestPrice, int[] bestCombo)
        {
            if (bestPrice[n] > 0) return bestPrice[n];
            if (n == 0) return 0;
            var currentBest = bestPrice[n];
            for (int i = 1; i <= n; i++)
            {
                currentBest = Math.Max(currentBest, input[i] + CutRodRec(n - i, input, bestPrice, bestCombo));
                if (currentBest > bestPrice[n])
                {
                    bestPrice[n] = currentBest;
                    bestCombo[n] = i;
                }
            }
            return bestPrice[n];
        }

        private static int CutRod(int n, int[] bestPrice, int[] price, int[] bestCombo)
        {
            for (int i = 1; i <= n; i++)
            {
                int currentBest = bestPrice[i];
                for (int j = 1; j <= i; j++)
                {
                    currentBest =
                         Math.Max(bestPrice[i], price[j] + bestPrice[i - j]);
                    if (currentBest > bestPrice[i])
                    {
                        bestPrice[i] = currentBest;
                        bestCombo[i] = j;
                    }
                }
            }
            return bestPrice[n];
        }

    }
}