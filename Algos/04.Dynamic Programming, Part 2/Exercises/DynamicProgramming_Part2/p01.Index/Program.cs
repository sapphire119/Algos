namespace p01.Index
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var cables = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var orderedCables = cables.OrderBy(x => x).ToArray();

            var matrixCables = new int[orderedCables.Length + 1, cables.Length + 1];
            for (int row = 1; row <= orderedCables.Length; row++)
            {
                for (int col = 1; col <= cables.Length; col++)
                {
                    var up = matrixCables[row - 1, col];
                    var left = matrixCables[row, col - 1];

                    var tempResult = Math.Max(up, left);
                    if (orderedCables[row - 1] == cables[col - 1])
                    {
                        tempResult = Math.Max(tempResult, (1 + matrixCables[row - 1, col - 1]));
                    }
                    matrixCables[row, col] = tempResult;
                }
            }

            var sequence = new List<int>();
            var startRow = orderedCables.Length;
            var startCol = cables.Length;

            while (startRow > 0 && startCol > 0)
            {
                if (orderedCables[startRow - 1] == cables[startCol - 1])
                {
                    sequence.Add(cables[startCol - 1]);
                    startRow--;
                    startCol--;
                }
                else if(matrixCables[startRow, startCol - 1] > matrixCables[startRow - 1, startCol])
                {
                    startCol--;
                }
                else
                {
                    startRow--;
                }
            }

            //Maximum pairs connected: 5
            Console.WriteLine($"Maximum pairs connected: {string.Join(" ", sequence.Count)}");
        }
    }
}
