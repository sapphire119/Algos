namespace p02.ZigZagMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static int maxSum = -1;
        private static Cell maxCell;

        public static void Main()
        {
            var stopWatch = new Stopwatch();

            var rows = ReadInput();
            var cols = ReadInput();

            stopWatch.Start();
            var inputMatrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    inputMatrix[i, j] = nums[j];
                }
            }

            var cellMatrix = new Cell[rows, cols];
            for (int i = 0; i < cellMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < cellMatrix.GetLength(1); j++)
                {
                    cellMatrix[i, j] = new Cell(inputMatrix[i, j]);
                }
            }

            CalcSums(cellMatrix, inputMatrix, cellMatrix.GetLength(0) - 1, cellMatrix.GetLength(1) - 1);
            var sb = new StringBuilder();
            sb.Append($"{maxCell.MaxValue} = ");

            var path = new List<int>();
            while (maxCell != null)
            {
                path.Add(maxCell.Value);
                maxCell = maxCell.Child;
            }

            sb.Append($"{string.Join($" + ", path)}");

            Console.WriteLine(sb.ToString().Trim());

            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds);
            Console.WriteLine(stopWatch.Elapsed);
        }

        private static void CalcSums(Cell[,] testMatrix, int[,] inputMatrix, int rowsIndex, int columnsIndex)
        {
            for (int col = columnsIndex - 1; col >= 0; col--)
            {
                if (col % 2 == 1)
                {
                    CalcOddSums(testMatrix, rowsIndex, col);
                }
                else
                {
                    CalcEvenSums(testMatrix, rowsIndex, col);
                }
            }
        }

        private static void CalcOddSums(Cell[,] cellMatrix, int rowsIndex, int col)
        {
            for (int row = 0; row <= rowsIndex; row++)
            {
                var currentEle = cellMatrix[row, col];
                for (int nextRow = row + 1; nextRow <= rowsIndex; nextRow++)
                {
                    var nextEle = cellMatrix[nextRow, col + 1];
                    SumTwoCells(currentEle, nextEle);
                }
            }
        }

        private static void CalcEvenSums(Cell[,] cellMatrix, int rowsIndex, int col)
        {
            for (int row = rowsIndex; row >= 0; row--)
            {
                var currentEle = cellMatrix[row, col];
                for (int nextRow = row - 1; nextRow >= 0; nextRow--)
                {
                    var nextEle = cellMatrix[nextRow, col + 1];
                    SumTwoCells(currentEle, nextEle);
                }
            }
        }

        private static void SumTwoCells(Cell currentEle, Cell nextEle)
        {
            var currentSum = currentEle.Value + nextEle.MaxValue;

            if (currentEle.MaxValue < currentSum)
            {
                currentEle.MaxValue = currentSum;
                currentEle.Child = nextEle;

                if (maxSum < currentEle.MaxValue)
                {
                    maxSum = currentEle.MaxValue;
                    maxCell = currentEle;
                }
            }
        }

        private static int ReadInput()
        {
            return int.Parse(Console.ReadLine());
        }
    }

    public class Cell
    {
        public Cell(int value)
        {
            this.Value = value;
            this.MaxValue = value;
            this.Child = null;
        }

        public int Value { get; set; }

        public int MaxValue { get; set; }

        public Cell Child { get; set; }

        public override string ToString()
        {
            return $"{this.Value} -- MAX: {this.MaxValue}";
        }
    }
}
