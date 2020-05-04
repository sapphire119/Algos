namespace p02.Queens
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Program
    {
        //private const char DefaultChar = '_';

        public static void Main()
        {
            //var chessBoard = new char[,]
            //{
            //    { '_','_','_','_','_','_','_','_' },
            //    {'_','_','_','_','_','_','_','_', },
            //    {'_','_','_','_','_','_','_','_' },
            //    {'_','_','_','_','_','_','_','_' },
            //    {'_','_','_','_','_','_','_','_'},
            //    {'_','_','_','_','_','_','_','_'},
            //    {'_','_','_','_','_','_','_','_'},
            //    {'_','_','_','_','_','_','_','_'}
            //};

            //var a = 5.CompareTo(10);
            //Console.WriteLine(a);

            var queenChar = 'Q';

            var chessBoard = new ChessBoard(queenChar);

            FindAllSolutions(chessBoard);
        }

        private static void FindAllSolutions(ChessBoard chessBoard)
        {
            if (DoesChessBoardContain8Queens(chessBoard))
            {
                PrintSolution(chessBoard);
            }
            else
            {
                if (chessBoard.CanPutQueen(out var rowIndex, out var columnIndex))
                {
                    chessBoard.PutQueen(rowIndex, columnIndex);
                }
                else
                {
                    chessBoard.RemoveQueen();
                }

                FindAllSolutions(chessBoard);
                //if (chessBoard.CanPutQueen())
                //{
                //    chessBoard.PutQueen(chessBoard, queenChar, currentRowIndex, currentColumnIndex);
                //    FindAllSolutions(chessBoard, queenChar, limitSolutions, currentRowIndex, currentColumnIndex); 
                //}
                //else
                //{
                //    RemoveQueen(chessBoard, currentRowIndex, currentColumnIndex);
                //}
            }
        }

        private static bool DoesChessBoardContain8Queens(ChessBoard chessBoard)
        {
            return chessBoard.NumberOfQueens == 8;
        }

        private static void PrintSolution(ChessBoard chessBoard)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < chessBoard.Board.GetLength(0); i++)
            {
                var temp = new StringBuilder();
                for (int j = 0; j < chessBoard.Board.GetLength(1); j++)
                {
                    temp.Append(string.Concat(chessBoard.Board[i, j], " "));
                }

                sb.AppendLine(temp.ToString().Trim());
            }

            var result = sb.ToString().Trim();
            Console.WriteLine(result);
        }
    }
}
