using System;
using System.Collections.Generic;
using System.Text;

namespace p02.Queens
{
    public class QueenRowColIndex
    {
        public QueenRowColIndex(int rowIndex, int columnIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
            this.IsVisited = false;
        }

        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public bool IsVisited { get; set; }
    }
}
