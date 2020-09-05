namespace p02.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            const string replaceStr = "REPLACE({0}, {1})";
            const string deleteStr = "DELETE({0})";
            const string insertStr = "INSERT({0}, {1})";


            var replaceCost = 0;
            var insertCost = 0;
            var deleteCost = 0;

            var firstStr = string.Empty;
            var secondStr = string.Empty;

            string line;
            for (int i = 0; i < 5; i++)
            {
                line = Console.ReadLine();
                var tokens = line.Split('=').Select(e => e.Trim()).ToArray();
                if (line.Contains("cost"))
                {
                    var operationName = tokens[0].Split('-')[1];
                    var value = int.Parse(tokens[1]);
                    switch (operationName)
                    {
                        case "replace": replaceCost = value; break;
                        case "insert": insertCost = value; break;
                        case "delete": deleteCost = value; break;
                    }
                }
                else if (line.Contains("s1"))
                {
                    firstStr = tokens[1];
                }
                else
                {
                    secondStr = tokens[1];
                }
            }

            var matrix = new Node[secondStr.Length + 1, firstStr.Length + 1];
            matrix[0, 0] = new Node(0);
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                var previousNode = matrix[0, col - 1];
                var deleteOperation = string.Format(deleteStr, col - 1, firstStr[col - 1]);
                matrix[0, col] = new Node(previousNode.Cost + deleteCost, deleteOperation, previousNode);
            }
            //Col
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                var previousNode = matrix[row - 1, 0];
                var insertOperation = FormatOperation(insertStr, row - 1, secondStr[row - 1]);
                matrix[row, 0] = new Node(previousNode.Cost + insertCost, insertOperation, previousNode);
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (secondStr[row - 1] == firstStr[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                        continue;
                    }

                    var replaceResult = matrix[row - 1, col - 1].Cost + replaceCost;
                    var insertResult = matrix[row - 1, col].Cost + insertCost;
                    var deleteResult = matrix[row, col - 1].Cost + deleteCost;

                    var result = Math.Min(replaceResult, Math.Min(insertResult, deleteResult));
                    if (replaceResult == result)
                    {
                        var replaceOperation = FormatOperation(replaceStr, col - 1, secondStr[row - 1]);
                        matrix[row, col] = new Node(result, replaceOperation, matrix[row - 1, col - 1]);
                    }
                    //else if (deleteResult == result)
                    else if (insertResult == result)
                    {
                        //var deleteOperation = FormatOperation(deleteStr, col - 1);
                        //matrix[row, col] = new Node(result, deleteOperation, matrix[row, col - 1]);
                        var insertOperation = FormatOperation(insertStr, col - 1, secondStr[row - 1]);
                        matrix[row, col] = new Node(result, insertOperation, matrix[row - 1, col]);
                    }
                    else
                    {
                        var deleteOperation = FormatOperation(deleteStr, col - 1);
                        matrix[row, col] = new Node(result, deleteOperation, matrix[row, col - 1]);
                        //var insertOperation = FormatOperation(insertStr, col - 1, secondStr[row - 1]);
                        //matrix[row, col] = new Node(result, insertOperation, matrix[row - 1, col]);
                    }
                }
            }

            //PrintOutput(matrix);
            var last = matrix[secondStr.Length, firstStr.Length];
            var minimumDistSum = last.Cost;
            var operations = new Stack<string>();
            
            while (last.Parent != null)
            {
                operations.Push(last.Opeartion);
                last = last.Parent;
            }
            Console.WriteLine($"Minimum edit distance: {minimumDistSum}");
            if (operations.Count > 0)
                Console.WriteLine(string.Join(Environment.NewLine, operations.ToArray()));
        }

        public static string FormatOperation(string operation, params dynamic[] args)
        {
            return string.Format(operation, args);
        }

        //private static void PrintOutput(Node[,] cellMatrix)
        //{
        //    for (int i = 0; i < cellMatrix.GetLength(0); i++)
        //    {
        //        var sb = new StringBuilder();
        //        for (int j = 0; j < cellMatrix.GetLength(1); j++)
        //            sb.Append($"{cellMatrix[i, j].Cost,3} ");
        //        Console.WriteLine(sb.ToString());
        //    }
        //}

        public class Node
        {
            public Node(int cost)
            {
                this.Cost = cost;
                this.Parent = null;
            }

            public Node(int cost, string operation, Node parent)
                : this(cost)
            {
                this.Parent = parent;
                this.Opeartion = operation;
            }

            public Node Parent { get; set; }
            public int Cost { get; set; }
            public string Opeartion { get; set; }

            public override string ToString()
            {
                return $"{this.Cost}{(this.Parent != null ? $" - {this.Parent}" : "")}";
            }
        }
    }
}
