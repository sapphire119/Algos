namespace p03.Array_Move_Down_Right
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {

            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var inputValues = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = inputValues[j];
                }
            }

            //Top-down approach
            var matrixValues = new int[rows, cols];
            matrixValues[0, 0] = matrix[0, 0];
            //first row
            for (int j = 1; j < cols; j++)
            {
                matrixValues[0, j] = matrixValues[0, j - 1] + matrix[0, j];
            }
            //first col
            for (int i = 1; i < rows; i++)
            {
                matrixValues[i, 0] = matrixValues[i - 1, 0] + matrix[i, 0];
            }
            //rest
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    var topCell = matrixValues[i - 1, j];
                    var leftCell = matrixValues[i, j - 1];
                    if (topCell > leftCell) matrixValues[i, j] = matrix[i, j] + topCell;
                    else matrixValues[i, j] = matrix[i, j] + leftCell;
                }
            }

            var startRow = matrix.GetLength(0) - 1;
            var startCol = matrix.GetLength(1) - 1;

            var startCell = matrixValues[startRow, startCol];
            var solutions = new Stack<string>();
            solutions.Push($"[{startRow}, {startCol}]");

            while (startRow > 0 || startCol > 0)
            {
                int topCell = -1;
                if (startRow - 1 >= 0) topCell = matrixValues[startRow - 1, startCol];

                int leftCell = -1;
                if (startCol - 1 >= 0) leftCell = matrixValues[startRow, startCol - 1];

                if (topCell > leftCell)
                {
                    startRow--;
                }
                else
                {
                    startCol--;
                }

                if (topCell > 0 || leftCell > 0)
                    solutions.Push($"[{startRow}, {startCol}]");
            }

            Console.WriteLine(string.Join(" ", solutions.ToArray()));
        }
    }
}
