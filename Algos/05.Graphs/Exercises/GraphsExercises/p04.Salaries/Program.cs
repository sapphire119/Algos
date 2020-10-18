namespace p04.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsCols = int.Parse(Console.ReadLine());
            var graph = new int[rowsCols, rowsCols];

            var nodeSalary = new Dictionary<int, int>();
            for (int i = 0; i < graph.GetLength(0); i++) nodeSalary[i] = 0;
            string line;
            for (int i = 0; i < rowsCols; i++)
            {
                line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (i != j && line[j] == 'Y') graph[i, j] = 1;
                }
            }


            //PrintGraph(graph);
            for (int nodeRow = 0; nodeRow < graph.GetLength(0); nodeRow++)
            {
                CalculateSalary(nodeRow, graph, nodeSalary);
            }

            var totalSum = nodeSalary.Sum(x => x.Value);
            Console.WriteLine(totalSum);
        }

        private static int CalculateSalary(int nodeRow, int[,] graph, Dictionary<int, int> nodeSalary)
        {
            if (nodeSalary[nodeRow] != 0) return nodeSalary[nodeRow];

            var hasManager = false;
            for (int child = 0; child < graph.GetLength(1); child++)
            {
                var isManaged = graph[nodeRow, child];

                if (isManaged == 1)
                {
                    hasManager = true;
                    nodeSalary[nodeRow] += CalculateSalary(child, graph, nodeSalary);
                }
            }

            if (!hasManager) nodeSalary[nodeRow]++;

            return nodeSalary[nodeRow];
        }

        private static void PrintGraph(int[,] graph)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write($"{graph[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        //private static void SetSalaries(int node, Dictionary<int, int> nodeSalary, bool[,] graph)
        //{
        //    if (!nodeSalary.ContainsKey(node))
        //    {
        //        for (int child = 0; child < graph.GetLength(1); child++)
        //        {
        //            if(graph[node, child])
        //            {
        //                SetSalaries(child, nodeSalary, graph);
        //                if (!nodeSalary.ContainsKey(node)) nodeSalary[node] = 0;
        //                nodeSalary[node] += nodeSalary[child];
        //            }
        //        }
        //    }
        //}
    }
}
