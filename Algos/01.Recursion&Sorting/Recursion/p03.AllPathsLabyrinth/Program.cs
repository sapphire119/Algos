namespace p03.AllPathsLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var columns = int.Parse(Console.ReadLine());

            char[,] arr = SetInput(rows, columns);

            var startRow = 0;
            var startColumn = 0;
            FindAllExits(arr, startRow, startColumn, rows, columns, new List<char>(), default(char));
        }

        private static void FindAllExits(char[,] arr, 
            int startRow, 
            int startColumn, 
            int rowsCount, 
            int columnsCount, 
            List<char> takenSteps, 
            char currentStep)
        {
            if (startRow < 0 || startColumn < 0 || 
                rowsCount - 1< startRow || columnsCount - 1< startColumn || 
                arr[startRow, startColumn] == '*' || arr[startRow, startColumn] == 'x') 
                return;

            if (currentStep != default(char))
            {
                takenSteps.Add(currentStep);
            }

            if (arr[startRow, startColumn] == 'e')
            {
                PrintSolution(takenSteps);
                takenSteps.RemoveAt(takenSteps.Count - 1);
            }
            else
            {
                arr[startRow, startColumn] = 'x';
                //RIGHT
                FindAllExits(arr, startRow, startColumn + 1, rowsCount, columnsCount, takenSteps, 'R');
                //DOWN
                FindAllExits(arr, startRow + 1, startColumn, rowsCount, columnsCount, takenSteps, 'D');
                //LEFT
                FindAllExits(arr, startRow, startColumn - 1, rowsCount, columnsCount, takenSteps, 'L');
                //UP
                FindAllExits(arr, startRow - 1, startColumn, rowsCount, columnsCount, takenSteps, 'U');

                arr[startRow, startColumn] = '-';
                if (takenSteps.Count > 0) takenSteps.RemoveAt(takenSteps.Count - 1);
            }
        }

        private static void PrintSolution(List<char> takenSteps)
        {
            Console.WriteLine(string.Join("", takenSteps));
        }

        private static char[,] SetInput(int rows, int columns)
        {
            var arr = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                var tokens = Console.ReadLine().ToCharArray();
                for (int j = 0; j < columns; j++)
                {
                    arr[i, j] = tokens[j];
                }
            }
            return arr;
        }
    }
}