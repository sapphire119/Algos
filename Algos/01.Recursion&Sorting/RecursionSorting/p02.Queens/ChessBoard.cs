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
        private int currentQueenIndex;

        public ChessBoard(char queenChar)
        {
            this.Board = InitialBoard;
            this.QueenChar = queenChar;
            this.NumberOfQueens = 0;
            this.currentQueenIndex = -1;
            this.avaiblePoistions = new List<QueenRowColIndex>();
            this.queensTakenPositions = new Dictionary<int, List<QueenRowColIndex>>();
            InitializeAvaiblePositions(this.avaiblePoistions);
            InitializeQueenPositions(this.queensTakenPositions);
        }

        private void InitializeAvaiblePositions(List<QueenRowColIndex> avaiblePositions)
        {
            for (int i = 0; i < this.Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.Board.GetLength(1); j++)
                {
                    avaiblePoistions.Add(new QueenRowColIndex(i, j));
                }
            }
        }

        private void InitializeQueenPositions(Dictionary<int, List<QueenRowColIndex>> queensTakenPositions)
        {
            for (int i = 0; i < 8; i++)
            {
                queensTakenPositions[i] = new List<QueenRowColIndex>();
            }
        }

        public char[,] Board { get; set; }

        public char QueenChar { get; }

        public int NumberOfQueens { get; set; }

        public bool CanPutQueen(out int rowIndex, out int columnIndex)
        {
            if (this.avaiblePoistions.Count == 0)
            {
                rowIndex = 0;
                columnIndex = 0;
                return false;
            }

            var firstKvp = this.avaiblePoistions[0];
            rowIndex = firstKvp.RowIndex;
            columnIndex = firstKvp.ColumnIndex;
            return true;
        }

        public void PutQueen(int rowIndex, int columnIndex)
        {
            this.currentQueenIndex++; // index for queenTakenPositions
            this.NumberOfQueens++; // Count of Queens

            this.Board[rowIndex, columnIndex] = this.QueenChar;

            AddAllTakenSlots(this.avaiblePoistions, this.queensTakenPositions, rowIndex, columnIndex);
        }

        private void AddAllTakenSlots(List<QueenRowColIndex> avaiblePoistions, 
            Dictionary<int, List<QueenRowColIndex>> queensTakenPositions,
            int rowIndex,
            int columnIndex)
        {
            var currentQueenSlotList = queensTakenPositions[this.currentQueenIndex];
            //All Horizontal
            var allHorizontals = this.avaiblePoistions.Where(x => x.RowIndex == rowIndex);
            //All Vertical
            var allVertical = this.avaiblePoistions.Where(x => x.ColumnIndex == columnIndex);
            //All Diagonal
            var allRightDiagonal = this.avaiblePoistions.Where(x => x.RowIndex - rowIndex == x.ColumnIndex - columnIndex);
            //All Around
            ;
            //currentQueenSlotList.AddRange();
        }

        public void RemoveQueen()
        {
            //firstKvp is where Queen is Put
            var lastKvp = this.queensTakenPositions[this.currentQueenIndex][0];
            var rowIndex = lastKvp.RowIndex;
            var columnIndex = lastKvp.ColumnIndex;

            this.Board[rowIndex, columnIndex] = DefaultChar;

            this.currentQueenIndex--;
            this.NumberOfQueens--;

            //TODO: Add Open Positions back
        }
    }
}
