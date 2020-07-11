namespace p03.Knight_s_Tour
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var inputRowsColumns = int.Parse(Console.ReadLine());
            var cellMatrix = new Cell[inputRowsColumns, inputRowsColumns];
            //Mark start
            var startRow = 0;
            var startCol = 0;
            for (int i = 0; i < cellMatrix.GetLength(0); i++)
                for (int j = 0; j < cellMatrix.GetLength(1); j++)
                    cellMatrix[i, j] = new Cell(i, j);

            var counter = 1;
            cellMatrix[startRow, startCol].IsVisited = true;
            cellMatrix[startRow, startCol].Position = counter;
            while (true)
            {
                Cell[] avaibleCells = GetAvabileCells(cellMatrix[startRow, startCol], cellMatrix);

                var nextCell = avaibleCells?.OrderBy(x => x.AvaibleSpaces).FirstOrDefault();
                if (nextCell == null) break;
                nextCell.IsVisited = true;
                nextCell.Position = ++counter;
                startRow = nextCell.Row;
                startCol = nextCell.Col;
            }

            PrintOutput(cellMatrix);
        }

        private static void PrintOutput(Cell[,] cellMatrix)
        {
            for (int i = 0; i < cellMatrix.GetLength(0); i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < cellMatrix.GetLength(1); j++)
                    sb.Append($"{cellMatrix[i, j].Position,3} ");
                Console.WriteLine(sb.ToString());
            }
        }

        private static Cell[] GetAvabileCells(Cell currentCell, Cell[,] cellMatrix)
        {
            var tempCells = GetCells(currentCell, cellMatrix);

            for (int i = 0; i < tempCells.Length; i++)
            {
                var tempCell = tempCells[i];
                tempCell.AvaibleSpaces = GetCells(tempCell, cellMatrix)
                    .Where(x => x != currentCell).Count();
            }

            return tempCells;
        }

        private static Cell[] GetCells(Cell currentCell, Cell[,] cellMatrix)
        {
            //horizontal
            var horizontalLeftUp = GetHorizontalLeftUp(currentCell.Row, currentCell.Col, cellMatrix);
            var horizontalLeftDown = GetHorizontalLeftDown(currentCell.Row, currentCell.Col, cellMatrix);

            var horizontalRightUp = GetHorizontalRightUp(currentCell.Row, currentCell.Col, cellMatrix);
            var horizontalRightDown = GetHorizontalRightDown(currentCell.Row, currentCell.Col, cellMatrix);
            //vertical
            var verticalUpLeft = GetVerticalUpLeft(currentCell.Row, currentCell.Col, cellMatrix);
            var verticalUpRight = GetVerticalUpRight(currentCell.Row, currentCell.Col, cellMatrix);

            var verticalDownLeft = GetVerticalDownLeft(currentCell.Row, currentCell.Col, cellMatrix);
            var verticalDownRight = GetVerticalDownRight(currentCell.Row, currentCell.Col, cellMatrix);

            var cells = new Cell[]
            {
                //Follow this order or it won't pass judge
                //rightBottom,rightTop,leftBottom, leftTop, bottomRight, topRight, topLeft, bottomLeft

                horizontalRightDown,
                horizontalRightUp,
                horizontalLeftDown,
                horizontalLeftUp,
                verticalDownRight,
                verticalUpRight,
                verticalUpLeft,
                verticalDownLeft,
            }.Where(x => x != null && !x.IsVisited).ToArray();

            return cells;
        }

        private static Cell GetHorizontalLeftUp(int row, int col, Cell[,] matrix)
        {
            //Horizontal Left
            var tempCol = col - 2;
            //Up
            var tempRow = row - 1;

            if (!CheckIfAvaibleToPlace(tempRow, tempCol, matrix)) return default(Cell);
            return matrix[tempRow, tempCol];
        }
        private static Cell GetHorizontalLeftDown(int row, int col, Cell[,] matrix)
        {
            //Horizontal Left
            var tempCol = col - 2;
            //Down
            var tempRow = row + 1;

            if (!CheckIfAvaibleToPlace(tempRow, tempCol, matrix)) return default(Cell);
            return matrix[tempRow, tempCol];
        }
        private static Cell GetHorizontalRightUp(int row, int col, Cell[,] matrix)
        {
            //Horizontal Right
            var tempCol = col + 2;
            //Up
            var tempRow = row - 1;

            if (!CheckIfAvaibleToPlace(tempRow, tempCol, matrix)) return default(Cell);
            return matrix[tempRow, tempCol];
        }
        private static Cell GetHorizontalRightDown(int row, int col, Cell[,] matrix)
        {
            //Horizontal Right
            var tempCol = col + 2;
            //Down
            var tempRow = row + 1;

            if (!CheckIfAvaibleToPlace(tempRow, tempCol, matrix)) return default(Cell);
            return matrix[tempRow, tempCol];
        }
        private static Cell GetVerticalUpLeft(int row, int col, Cell[,] matrix)
        {
            //Vertical Up
            var tempRow = row - 2;
            //Left
            var tempCol = col - 1;

            if (!CheckIfAvaibleToPlace(tempRow, tempCol, matrix)) return default(Cell);
            return matrix[tempRow, tempCol];
        }
        private static Cell GetVerticalUpRight(int row, int col, Cell[,] matrix)
        {
            //Vertical Up
            var tempRow = row - 2;
            //Right
            var tempCol = col + 1;

            if (!CheckIfAvaibleToPlace(tempRow, tempCol, matrix)) return default(Cell);
            return matrix[tempRow, tempCol];
        }
        private static Cell GetVerticalDownLeft(int row, int col, Cell[,] matrix)
        {
            //Vertical Down
            var tempRow = row + 2;
            //Left
            var tempCol = col - 1;

            if (!CheckIfAvaibleToPlace(tempRow, tempCol, matrix)) return default(Cell);
            return matrix[tempRow, tempCol];
        }
        private static Cell GetVerticalDownRight(int row, int col, Cell[,] matrix)
        {
            //Vertical Down
            var tempRow = row + 2;
            //Right
            var tempCol = col + 1;

            if (!CheckIfAvaibleToPlace(tempRow, tempCol, matrix)) return default(Cell);
            return matrix[tempRow, tempCol];
        }


        private static bool CheckIfAvaibleToPlace(int row, int col, Cell[,] matrix)
        {
            if (0 <= row && row < matrix.GetLength(0) && 
                0 <= col && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }

    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.IsVisited = false;
            this.AvaibleSpaces = 0;
        }

        public Cell(int row, int col, int position)
            : this(row, col)
        {
            this.Position = position;
            this.IsVisited = true;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsVisited { get; set; }
        public int AvaibleSpaces { get; set; }
        public int Position { get; set; }

        public override string ToString()
        {
            return $"{this.Row} - {this.Col}";
        }
    }
}
