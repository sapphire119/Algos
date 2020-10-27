namespace p04.BellmanFord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = new List<Edge>()
            {
                new Edge(0, 1, 5),

                new Edge(1, 2, 20),
                new Edge(1, 5, 30),
                new Edge(1, 6, 60),

                new Edge(2, 3, 10),
                new Edge(2, 4, 75),

                new Edge(3, 2, -15),

                new Edge(4, 9, 100),

                new Edge(5, 4, 25),
                new Edge(5, 6, 5),
                new Edge(5, 8, 50),

                new Edge(6, 7, -50),

                new Edge(7, 8, -10)
            };


            var nodes = input.Select(e => e.From)
                .Union(input.Select(e => e.To))
                .Distinct()
                .OrderBy(x => x)
                .ToHashSet();

            var graph = new List<Edge>[nodes.Count];
            for (int i = 0; i < graph.Length; i++) graph[i] = new List<Edge>();
            input.ForEach(e => graph[e.From].Add(e));

            var startNode = nodes.First();
            var distances = new int[nodes.Count];
            var predecessors = new int[nodes.Count];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
                predecessors[i] = i;
            }
            distances[startNode] = 0;


            for (int i = 0; i < nodes.Count - 1; i++)
            {
                foreach (var edges in graph)
                {
                    foreach (var edge in edges)
                    {
                        if (distances[edge.From] + edge.Weight < distances[edge.To])
                        {
                            distances[edge.To] = distances[edge.From] + edge.Weight;
                            predecessors[edge.To] = edge.From;
                        }
                    }
                }
            }

            for (int i = 0; i < nodes.Count - 1; i++)
            {
                foreach (var edges in graph)
                {
                    foreach (var edge in edges)
                    {
                        if (distances[edge.From] + edge.Weight < distances[edge.To])
                            distances[edge.To] = int.MinValue;
                    }
                }
            }

            //for (int i = 0; i < distances.Length; i++)
            //{
            //    Console.WriteLine($"{startNode} - {i} :: {(distances[i] != int.MinValue ? distances[i].ToString() : "cycle")}");
            //}
        }
    }

    public class Edge
    {
        public Edge(int firstNode, int secondNode, int weight)
        {
            this.From = firstNode;
            this.To = secondNode;
            this.Weight = weight;
        }

        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.From} -> {this.To} :: {this.Weight}";
        }
    }
}