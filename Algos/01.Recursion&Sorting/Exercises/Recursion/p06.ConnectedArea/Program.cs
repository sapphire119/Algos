namespace p06.ConnectedArea
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices.ComTypes;
    using System.Xml.Schema;

    public class Program
    {
        public static void Main()
        {
            var inputRows = int.Parse(Console.ReadLine());
            var inputColumns = int.Parse(Console.ReadLine());

            var points = new List<MatrixPoint>();

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
                        TraverseArea(startRow, startCol, point);
                    }
                    
                }
            }
            TraverseMatrix(0, 0, wallChar, matrix, matrixCellVisited, points);
        }

        private static void TraverseMatrix(
            int startRow,
            int startCol,
            char wallChar,
            char[,] matrix,
            bool[,] matrixCellVisited,
            List<MatrixPoint> points)
        {
            //if (!WithinBounds(startRow, startCol, matrix)) return;

            
            //else
            //{




            //    //for (int i = 0; i < matrix.GetLength(0); i++)
            //    //{
            //    //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    //    {
            //    //        var currentEle = matrix[i, j];
            //    //        if (currentEle == wallChar) continue;

            //    //    }
            //    //}
            //}
        }

        private static void TraverseArea(int currentRow, int currentCol, MatrixPoint point)
        {
            //Right
            //TraverseArea(startRow, startCol + 1, point);
            //Down                                                                   
            //TraverseArea(startRow + 1, startCol, wallChar, matrix, matrixCellVisited, points);
            //Left                                                                  
            //TraverseArea(startRow, startCol - 1, wallChar, matrix, matrixCellVisited, points);
            //Up                                                                   
            //TraverseArea(startRow + 1, startCol, wallChar, matrix, matrixCellVisited, points);
        }

        private static bool WithinBounds(int startRow, int startCol, char[,] matrix)
        {
            return startRow < matrix.GetLength(0) && startCol < matrix.GetLength(1);
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
        }
    }
}
