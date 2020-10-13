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
            var graph = new bool[rowsCols, rowsCols];

            var nodeSalary = new Dictionary<int, int>();
            string line;
            for (int i = 0; i < rowsCols; i++)
            {
                line = Console.ReadLine();
                if (line.Contains('Y'))
                    for (int j = 0; j < line.Length; j++)
                    {
                        if (line[j] == 'Y') graph[i, j] = true;
                    }
                else
                    nodeSalary[i] = 1;
            }

            for (int node = 0; node < graph.GetLength(0); node++)
            {
                if(!nodeSalary.ContainsKey(node))
                    SetSalaries(node, nodeSalary, graph);
            }

            var totalSalaries = nodeSalary.Sum(x => x.Value);
            Console.WriteLine(totalSalaries);
        }

        private static void SetSalaries(int node, Dictionary<int, int> nodeSalary, bool[,] graph)
        {
            if (!nodeSalary.ContainsKey(node))
            {
                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if(graph[node, child])
                    {
                        SetSalaries(child, nodeSalary, graph);
                        if (!nodeSalary.ContainsKey(node)) nodeSalary[node] = 0;
                        nodeSalary[node] += nodeSalary[child];
                    }
                }
            }
        }
    }
}
