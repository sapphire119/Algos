using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace p02.Queens
{
    public class ChessBoard
    {
        private const char DefaultChar = '_';
        private readonly char[,] InitialBoard = new char[,]
        {
            { '_','_','_','_','_','_','_','_' },
            {'_','_','_','_','_','_','_','_', },
            {'_','_','_','_','_','_','_','_' },
            {'_','_','_','_','_','_','_','_' },
            {'_','_','_','_','_','_','_','_'},
            {'_','_','_','_','_','_','_','_'},
            {'_','_','_','_','_','_','_','_'},
            {'_','_','_','_','_','_','_','_'}
        };

        private List<QueenRowColIndex> avaiblePoistions;
        //private List<QueenRowColIndex> takenQueensPosition;
        private Dictionary<int, List<QueenRowColIndex>> queensTakenPositions;
        private List<QueenRowColIndex> queensInitial;
        private int currentQueenIndex;

        public ChessBoard(char queenChar)
        {
            this.Board = InitialBoard;
            this.QueenChar = queenChar;
            this.NumberOfQueens = 0;
            //this.currentQueenIndex = -1;
            //this.avaiblePoistions = new List<QueenRowColIndex>();
            //this.queensTakenPositions = new Dictionary<int, List<QueenRowColIndex>>();
            //this.queensInitial = new List<QueenRowColIndex>();

            //InitializeAvaiblePositions(this.avaiblePoistions);
            //InitializeQueenPositions(this.queensTakenPositions);
        }

        //private void InitializeAvaiblePositions(List<QueenRowColIndex> avaiblePositions)
        //{
        //    for (int i = 0; i < this.Board.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < this.Board.GetLength(1); j++)
        //        {
        //            avaiblePoistions.Add(new QueenRowColIndex(i, j));
        //        }
        //    }
        //}

        //private void InitializeQueenPositions(Dictionary<int, List<QueenRowColIndex>> queensTakenPositions)
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        queensTakenPositions[i] = new List<QueenRowColIndex>();
        //    }
        //}

        public char[,] Board { get; set; }

        public char QueenChar { get; }

        public int NumberOfQueens { get; set; }

        public bool CanPutQueen(out int rowIndex, out int columnIndex)
        {
            rowIndex = default;
            columnIndex = default;
            return default;
            //if (this.avaiblePoistions.Count == 0)
            //{
            //    rowIndex = 0;
            //    columnIndex = 0;
            //    return false;
            //}

            //var firstKvp = this.avaiblePoistions[0];
            //rowIndex = firstKvp.RowIndex;
            //columnIndex = firstKvp.ColumnIndex;
            //return true;
        }

        public void PutQueen(int rowIndex, int columnIndex)
        {
            //this.currentQueenIndex++; // index for queenTakenPositions
            //this.NumberOfQueens++; // Count of Queens

            //this.Board[rowIndex, columnIndex] = this.QueenChar;

            //AddAllTakenSlots(this.avaiblePoistions, this.queensTakenPositions, rowIndex, columnIndex);
            //var position = this.queensTakenPositions[this.currentQueenIndex].FirstOrDefault(x => x.RowIndex == rowIndex && x.ColumnIndex == columnIndex);
            //this.queensInitial.Add(position);
        }

        private void AddAllTakenSlots(List<QueenRowColIndex> avaiblePoistions, 
            Dictionary<int, List<QueenRowColIndex>> queensTakenPositions,
            int rowIndex,
            int columnIndex)
        {
            //All Horizontal
            var allHorizontals = avaiblePoistions.Where(x => x.RowIndex == rowIndex);
            //All Vertical
            var allVertical = avaiblePoistions.Where(x => x.ColumnIndex == columnIndex);
            //All Diagonal
            var comparisonRightDiagonal = rowIndex.CompareTo(columnIndex);
            IEnumerable<QueenRowColIndex> rightDiagonal;
            if (comparisonRightDiagonal < 0)
            {
                //2, 3
                var difference = columnIndex - rowIndex;
                rightDiagonal = avaiblePoistions.Where(x => x.RowIndex + difference == x.ColumnIndex);
            }
            else if (comparisonRightDiagonal > 0)
            {
                //3, 2
                var difference = rowIndex - columnIndex;
                rightDiagonal = avaiblePoistions.Where(x => x.RowIndex == x.ColumnIndex + difference);
            }
            else
            {
                rightDiagonal = avaiblePoistions.Where(x => x.RowIndex == x.ColumnIndex);
            }

            IEnumerable<QueenRowColIndex> leftDiagonal;
            var sumOfRows = rowIndex + columnIndex;
            leftDiagonal = avaiblePoistions.Where(x => x.RowIndex + x.ColumnIndex == sumOfRows);


            //var temp = new List<QueenRowColIndex>();
            //temp.AddRange(allHorizontals);
            //temp.AddRange(allVertical);
            //temp.AddRange(leftDiagonal);
            //temp.AddRange(rightDiagonal);
            //queensTakenPositions[this.currentQueenIndex] = temp.Distinct().ToList();
            
            //foreach (var currentSlot in temp)
            //{
            //    avaiblePoistions.Remove(currentSlot);
            //}

        }

        public void RemoveQueen()
        {
            //firstKvp is where Queen is Put
            //var lastKvp = this.queensInitial[this.queensInitial.Count - 1];
            //var rowIndex = lastKvp.RowIndex;
            //var columnIndex = lastKvp.ColumnIndex;

            //this.Board[rowIndex, columnIndex] = DefaultChar;

            //var takenPositions = this.queensTakenPositions[this.currentQueenIndex];

            //this.currentQueenIndex--;
            //this.NumberOfQueens--;
            //this.queensInitial.RemoveAt(this.queensInitial.Count - 1);

            //foreach (var position in takenPositions)
            //{
            //    this.avaiblePoistions.Add(position);
            //}
            //takenPositions.Clear();

            //this.avaiblePoistions = this.avaiblePoistions.OrderBy(x => x.RowIndex).ThenBy(x => x.ColumnIndex).ToList();
            //this.avaiblePoistions.RemoveAt(0);
            //this.avaiblePoistions.Add(lastKvp);
        }
    }
}
