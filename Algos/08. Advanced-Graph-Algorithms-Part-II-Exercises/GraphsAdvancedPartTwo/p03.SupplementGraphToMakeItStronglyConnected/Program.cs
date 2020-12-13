namespace p03.SupplementGraphToMakeItStronglyConnected
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<int>[] graph;

        public static void Main()
        {
            var nodes = ReadInput();
            var edgesCount = ReadInput();

            graph = new List<int>[nodes];
            for (int i = 0; i < edgesCount; i++)
            {
                int[] vertices = Console.ReadLine().Split("->").Select(int.Parse).ToArray();
                var from = vertices[0];
                var to = vertices[1];
                if (graph[from] == null) graph[from] = new List<int>();

                graph[from].Add(to);
            }

        }

        private static int ReadInput()
        {
            return int.Parse(Console.ReadLine().Split(' ')[1]);
        }
    }
}
