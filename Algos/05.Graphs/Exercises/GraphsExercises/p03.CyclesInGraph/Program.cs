namespace p03.CyclesInGraph
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string line;
            var graph = new List<Edge>();
            var visited = new Dictionary<string, bool>();
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                var tokens = line.Split('–');
                var source = tokens[0];
                var dest = tokens[1];
                graph.Add(new Edge(source, dest));

                if (!visited.ContainsKey(source)) visited[source] = false;
                if (!visited.ContainsKey(dest))   visited[dest] = false;
            }

            var isAcyclic = true;
            foreach (var edge in graph)
            {
                FindIfAcyclic(edge, visited, ref isAcyclic);
            }
            Console.WriteLine("Acyclic: {0}", isAcyclic ? "Yes" : "No");
        }

        private static bool IsVisited(Edge edge, Dictionary<string, bool> visited)
        {
            return visited[edge.Source] && visited[edge.Destination];
        }

        private static void FindIfAcyclic(Edge edge, Dictionary<string, bool> visited, ref bool isAcyclic)
        {
            if (IsVisited(edge, visited)) isAcyclic = false;
            if (!isAcyclic) return;
            visited[edge.Source] = true;
            visited[edge.Destination] = true;
        }
    }

    public class Edge
    {
        public Edge(string source, string dest)
        {
            this.Source = source;
            this.Destination = dest;
        }

        public string Source { get; set; }
        public string Destination { get; set; }

        public override string ToString()
        {
            return $"{this.Source} -> {this.Destination}";
        }
    }
}
