namespace p01.CableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var budget = int.Parse(Console.ReadLine());
            var nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            //visited same
            var visited = new bool[nodes];

            var edges = new List<Edge>();
            for (int i = 0; i < edgesCount; i++)
            {
                string line = Console.ReadLine();
                var tokens = line.Split(' ').Select(x => x.Trim()).ToArray();
                var @params = tokens.Take(3).Select(int.Parse).ToArray();
                var edge = new Edge(@params[0], @params[1], @params[2]);

                if (tokens.Length > 3 && tokens[3] == "connected")
                {
                    visited[edge.From] = true;
                    visited[edge.To] = true;
                }

                edges.Add(edge);
            }

            var ordereEdges = FetchNewEdges(edges, visited);
            ordereEdges.Sort();

            var budgetUsed = 0;
            var resultSum = budget - budgetUsed;
            while (budgetUsed <= budget && ordereEdges.Any(e => e.Weight <= resultSum))
            {
                var currentEdge = ordereEdges.First();
                ordereEdges.Remove(currentEdge);
                ordereEdges.Sort();

                if ((visited[currentEdge.From] && !visited[currentEdge.To]) ||
                    (!visited[currentEdge.From] && visited[currentEdge.To]))
                {
                    //Console.WriteLine($"Taken Edge: {currentEdge}");
                    budgetUsed += currentEdge.Weight;
                    resultSum -= currentEdge.Weight;

                    visited[currentEdge.From] = true;
                    visited[currentEdge.To] = true;

                    ordereEdges = FetchNewEdges(edges, visited);
                    ordereEdges.Sort();
                }
            }

            Console.WriteLine($"Budget used: {budgetUsed}");
        }

        private static List<Edge> FetchNewEdges(List<Edge> edges, bool[] visited)
        {
            return edges.Where(x => !(visited[x.From] && visited[x.To]) && !(!visited[x.From] && !visited[x.To])).ToList();
        }
        
    }

    public class Edge : IComparable<Edge>
    {
        public Edge(int from, int to, int weight)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }

        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }


        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return $"{this.From} - {this.To} :: {this.Weight}";
        }
    }
}
