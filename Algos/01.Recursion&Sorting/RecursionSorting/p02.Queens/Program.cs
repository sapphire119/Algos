namespace p02.Queens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Xml.Schema;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Enumerate(n);

            #region OldSolution
            //var queenChar = '*';
            //var defaultChar = '-';
            //var numberOfSolutions = 0;

            //var chessBoardChars = new char[8, 8];
            //for (int i = 0; i < chessBoardChars.GetLength(0); i++)
            //{
            //    for (int j = 0; j < chessBoardChars.GetLength(1); j++)
            //    {
            //        chessBoardChars[i, j] = defaultChar;
            //    }
            //}
            //FindAllSolutions(chessBoardChars, defaultChar, queenChar, ref numberOfSolutions, 0);
            //Console.WriteLine("Number of Solutions is: {0}", numberOfSolutions);
            #endregion
        }

        private static void Enumerate(int n)
        {
            int[] arr = new int[n];
            Enumerate(arr, 0);
        }

        private static void Enumerate(int[] arr, int rowIndex)
        {
            if (rowIndex >= arr.Length)
            {
                PrintQueens(arr);
            }
            else
            {
                for (int column = 0; column < arr.Length; column++)
                {
                    arr[rowIndex] = column;
                    if (IsConsistent(arr, rowIndex)) Enumerate(arr, rowIndex + 1);
                }
            }
        }

        private static bool IsConsistent(int[] arr, int rowIndex)
        {
            for (int i = 0; i < rowIndex; i++)
            {
                if (arr[i] == arr[rowIndex])                    return false;   // same column
                if ((arr[i] - arr[rowIndex]) == (rowIndex - i)) return false;   // same major diagonal
                if ((arr[rowIndex] - arr[i]) == (rowIndex - i)) return false;   // same minor diagonal
            }
            return true;
        }

        private static void PrintQueens(int[] arr)
        {
            //int n = q.length;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] == j) Console.Write("Q ");
                    else Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        #region Old Solution
        private static void FindAllSolutions(char[,] chessBoardChars, char defaultChar, char queenChar,
            ref int numberOfSolutions, int index)
        {
            if (index >= chessBoardChars.GetLength(0))
            {
                PrintSolution(chessBoardChars, ref numberOfSolutions, queenChar, defaultChar);
            }
            else
            {
                for (int j = 0; j < chessBoardChars.GetLength(1); j++)
                {
                    if (CanPutQueen(chessBoardChars, defaultChar, index, j))
                    {
                        var charToPut = Convert.ToChar('a' + index);
                        MarkQueenSpots(chessBoardChars, index, j, charToPut, defaultChar);
                        chessBoardChars[index, j] = queenChar;
                        FindAllSolutions(chessBoardChars, defaultChar, queenChar, ref numberOfSolutions, index + 1);
                        chessBoardChars[index, j] = defaultChar;
                        MarkQueenSpots(chessBoardChars, index, j, defaultChar, charToPut);
                    }
                }
            }
        }

        private static void MarkQueenSpots(char[,] chessBoard, int rowIndex, int columnIndex, char charToMark, char defaultChar)
        {
            //Horizontal
            for (int j = 0; j < chessBoard.GetLength(1); j++)
            {
                if (chessBoard[rowIndex, j] == defaultChar) chessBoard[rowIndex, j] = charToMark;
            }
            //Vertical
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                if (chessBoard[i, columnIndex] == defaultChar) chessBoard[i, columnIndex] = charToMark;
            }
            //Diagonal Right

            var comparer = rowIndex.CompareTo(columnIndex);

            if (comparer < 0)
            {
                //2, 3
                var diff = columnIndex - rowIndex;
                for (int i = 0, j = diff; i < chessBoard.GetLength(0) && j < chessBoard.GetLength(1); i++, j++)
                {
                    if (chessBoard[i, j] == defaultChar)
                        chessBoard[i, j] = charToMark;
                }
            }
            else if (comparer > 0)
            {
                //3, 2
                var diff = rowIndex - columnIndex;
                for (int i = diff, j = 0; i < chessBoard.GetLength(0) && j < chessBoard.GetLength(1); i++, j++)
                {
                    if (chessBoard[i, j] == defaultChar)
                        chessBoard[i, j] = charToMark;
                }
            }
            else
            {
                for (int i = 0, j = 0; i < chessBoard.GetLength(0) && j < chessBoard.GetLength(1); i++, j++)
                {
                    if (chessBoard[i, j] == defaultChar)
                        chessBoard[i, j] = charToMark;
                }
            }

            //Left Diagonal
            var startRow = rowIndex + columnIndex;
            var startColumn = 0;

            if (chessBoard.GetLength(0) - 1 < startRow)
            {
                startColumn = startRow - (chessBoard.GetLength(0) - 1);
                startRow = chessBoard.GetLength(0) - 1;
            }

            for (int i = startRow, j = startColumn; i >= 0 && j < chessBoard.GetLength(1); i--, j++)
            {
                if (chessBoard[i, j] == defaultChar)
                    chessBoard[i, j] = charToMark;
            }
        }

        private static bool CanPutQueen(char[,] chessBoard, char defaultChar, int rowIndex, int columnIndex)
        {
            return chessBoard[rowIndex, columnIndex] == defaultChar;
        }


        private static void PrintSolution(char[,] chessBoard, ref int numberOfSolutions, char queenChar, char defaultChar)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                var temp = new StringBuilder();
                for (int j = 0; j < chessBoard.GetLength(1); j++)
                {
                    if (chessBoard[i, j] == queenChar)
                        temp.Append(string.Concat(chessBoard[i, j], " "));
                    else
                        temp.Append(string.Concat(defaultChar, " "));
                }

                sb.AppendLine(temp.ToString().Trim());
            }

            var result = sb.ToString().Trim();
            Console.WriteLine(result);
            Console.WriteLine();
            numberOfSolutions++;
        }
        #endregion
    }
}
