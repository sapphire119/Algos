namespace p02.AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowCountInput = int.Parse(Console.ReadLine()); ;

            var initialMatrix = new List<char>[rowCountInput];
            for (int i = 0; i < initialMatrix.Length; i++) initialMatrix[i] = new List<char>();


            for (int i = 0; i < rowCountInput; i++)
            {
                string line = Console.ReadLine();
                initialMatrix[i].AddRange(line);
            }

            bool[,] visited = new bool[initialMatrix.Length, initialMatrix[0].Count];
            var areas = new Dictionary<char, int>();
            for (int i = 0; i < initialMatrix.Length; i++)
            {
                for (int j = 0; j < initialMatrix[i].Count; j++)
                {
                    if (!visited[i, j])
                    {
                        var currentChar = initialMatrix[i][j];
                        if (!areas.ContainsKey(currentChar)) areas[currentChar] = 0;
                        DepthFirstSearch(i, j, initialMatrix, visited, currentChar, currentChar);
                        areas[currentChar]++;
                    }
                }
            }
            Console.WriteLine($"Areas: {areas.Sum(x => x.Value)}");
            foreach (var kvp in areas.OrderBy(x => x.Key))
            {
                var currentArea = kvp.Key;
                var areaCount = kvp.Value;
                Console.WriteLine($"Letter '{currentArea}' -> {areaCount}");
            }
        }

        private static void DepthFirstSearch(int startRow, int startCol,
            List<char>[] initialMatrix, bool[,] visited,
            char currentChar, char previousChar)
        {
            if (startCol < 0 || startCol > initialMatrix[startRow].Count) return;

            if (currentChar != previousChar) return;
            if (!visited[startRow, startCol])
            {
                visited[startRow, startCol] = true;

                //Right
                if(startCol + 1 < initialMatrix[startRow].Count)
                    DepthFirstSearch(startRow, startCol + 1, initialMatrix, visited, previousChar, initialMatrix[startRow][startCol + 1]);
                //Down
                if(startRow + 1 < initialMatrix.Length)
                    DepthFirstSearch(startRow + 1, startCol, initialMatrix, visited, previousChar, initialMatrix[startRow + 1][startCol]);
                //Left
                if(startCol - 1 > 0)
                    DepthFirstSearch(startRow, startCol - 1, initialMatrix, visited, previousChar, initialMatrix[startRow][startCol - 1]);
                //Up
                if(startRow - 1 > 0)
                    DepthFirstSearch(startRow - 1, startCol, initialMatrix, visited, previousChar, initialMatrix[startRow - 1][startCol]);
            }
        }
    }
}
