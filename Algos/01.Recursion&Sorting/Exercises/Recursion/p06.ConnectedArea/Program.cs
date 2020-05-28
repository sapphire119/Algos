namespace p06.ConnectedArea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputRows = int.Parse(Console.ReadLine());
            var inputColumns = int.Parse(Console.ReadLine());

            var points = new HashSet<MatrixPoint>();

            var wallChar = '*';

            var matrix = new char[inputRows, inputColumns];
            var matrixCellVisited = new bool[inputRows, inputColumns];
            for (int i = 0; i < inputRows; i++)
            {
                var inputMatrixRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < inputMatrixRow.Length; j++)
                {
                    var currentCell = inputMatrixRow[j];
                    matrix[i, j] = currentCell;
                    if (currentCell == wallChar) matrixCellVisited[i, j] = true;
                }
            }

            for (int startRow = 0; startRow < matrix.GetLength(0); startRow++)
            {
                for (int startCol = 0; startCol < matrix.GetLength(1); startCol++)
                {
                    if (!matrixCellVisited[startRow, startCol])
                    {
                        var point = new MatrixPoint(startRow, startCol, 0);
                        points.Add(point);
                        TraverseArea(startRow, startCol, point, matrixCellVisited);
                    }
                }
            }

            PrintResult(points);
        }

        private static bool WithinBounds<T>(int startRow, int startCol, T[,] matrix)
        {
            return (startRow < matrix.GetLength(0) && startCol < matrix.GetLength(1)) &&
                (startRow >= 0 && startCol >= 0);
        }

        private static void TraverseArea(int currentRow, int currentCol, MatrixPoint point, bool[,] matrixCellVisited)
        {
            if (!WithinBounds(currentRow, currentCol, matrixCellVisited) || matrixCellVisited[currentRow, currentCol]) return;
            matrixCellVisited[currentRow, currentCol] = true;
            point.Size++;
            //Right
            TraverseArea(currentRow, currentCol + 1, point, matrixCellVisited);
            //Down                                                                   
            TraverseArea(currentRow + 1, currentCol, point, matrixCellVisited);
            //Left                                                                  
            TraverseArea(currentRow, currentCol - 1, point, matrixCellVisited);
            //Up
            TraverseArea(currentRow - 1, currentCol, point, matrixCellVisited);
        }

        private static void PrintResult(HashSet<MatrixPoint> points)
        {
            var result = points.OrderByDescending(x => x.Size).ThenBy(x => x.RowStart).ThenBy(x => x.ColStart).ToArray();
            Console.WriteLine($"Total areas found: {result.Length}");
            for (int i = 0, areaId = 1; i < result.Length; i++, areaId++)
            {
                var point = result[i];
                Console.WriteLine($"Area #{areaId} at {point}");
            }
        }

        public class MatrixPoint
        {
            public MatrixPoint(int rowStart, int colStart, int size)
            {
                this.RowStart = rowStart;
                this.ColStart = colStart;
                this.Size = size;
            }

            public int RowStart { get; set; }
            public int ColStart { get; set; }

            public int Size { get; set; }

            public override string ToString()
            {
                return $"({this.RowStart}, {this.ColStart}), size: {this.Size}";
            }
        }
    }
}
