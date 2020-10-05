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
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                var tokens = line.Split('-');
                var source = tokens[0];
                var dest = tokens[1];
                graph.Add(new Edge(source, dest));
                //if (!graph.ContainsKey(source)) graph[source] = new List<string>();
                //if (!graph.ContainsKey(dest)) graph[dest] = new List<string>();
                //graph[source].Add(dest);
            }

            var visited = new HashSet<string>();
            var cycles = new HashSet<string>();
            var isAcyclic = true;
            foreach (var edge in graph)
            {
                if(!visited.Contains(node))
                    TopologicalSortsDepthFirstSearch(node, graph, visited, cycles, ref isAcyclic);
            }

            Console.WriteLine("Acyclic: {0}", isAcyclic ? "Yes" : "No");
        }

        private static void TopologicalSortsDepthFirstSearch(string node, Dictionary<string, List<string>> graph, HashSet<string> visited,
            HashSet<string> cycles,
            ref bool isAcyclic)
        {
            if (cycles.Contains(node)) isAcyclic = false;
            if (!visited.Contains(node) && isAcyclic)
            {
                visited.Add(node);
                cycles.Add(node);

                var children = graph[node];
                foreach (var child in children)
                {
                    TopologicalSortsDepthFirstSearch(child, graph, visited, cycles, ref isAcyclic);
                    if (!isAcyclic) return;
                }

                cycles.Remove(node);
            }
        }
    }

    public class Edge
    {
        public Edge(string source, string dest)
        {
            this.Source = source;
            this.Dest = dest;
        }

        public string Source { get; set; }
        public string Dest { get; set; }

        public override string ToString()
        {
            return $"{this.Source} -> {this.Dest}";
        }
    }
}
