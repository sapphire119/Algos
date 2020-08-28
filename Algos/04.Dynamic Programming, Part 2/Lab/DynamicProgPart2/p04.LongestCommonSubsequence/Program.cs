namespace p04.LongestCommonSubsequence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var firstStr = Console.ReadLine();
            var secondStr = Console.ReadLine();

            var lcs = new int[firstStr.Length + 1, secondStr.Length + 1];
            for (int row = 1; row <= firstStr.Length; row++)
            {
                for (int col = 1; col <= secondStr.Length; col++)
                {
                    var up = lcs[row - 1, col];
                    var left = lcs[row, col - 1];

                    var result = Math.Max(up, left);
                    if (firstStr[row - 1] == secondStr[col - 1])
                    {
                        result = Math.Max(result, 1 + lcs[row - 1, col - 1]);
                    }
                    lcs[row, col] = result;
                }
            }

            var startRow = firstStr.Length;
            var startCol = secondStr.Length;
            var sequence = new List<char>();
            while (startRow > 0 && startCol > 0)
            {
                if (firstStr[startRow - 1] == secondStr[startCol - 1])
                {
                    sequence.Add(firstStr[startRow - 1]);
                    startRow--;
                    startCol--;
                }
                else if (lcs[startRow, startCol - 1] > lcs[startRow - 1, startCol])
                {
                    startCol--;
                }
                else
                {
                    startRow--;
                }
            }

            Console.WriteLine(sequence.Count);
        }
    }
}
