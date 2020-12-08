namespace p02.FindBiConnectedComponents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    public class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int?[] parents;
        private static int[] lowpoints;
        private static int[] depths;
        private static List<int> articulationPoints;
        private static Stack<Edge> edges;
        private static Dictionary<int, List<Edge>> nodeEdges;
        private static int componentCounter;

        public static void Main()
        {
            var nodes = ParseInput();
            var edgesCount = ParseInput();

            graph = new List<int>[nodes];
            visited = new bool[graph.Length];
            parents = new int?[graph.Length];
            lowpoints = new int[graph.Length];
            depths = new int[graph.Length];
            articulationPoints = new List<int>();
            edges = new Stack<Edge>();
            nodeEdges = new Dictionary<int, List<Edge>>();
            componentCounter = 0;

            for (int i = 0; i < graph.Length; i++) graph[i] = new List<int>();
            for (int i = 0; i < edgesCount; i++)
            {
                int[] edges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var source = edges[0];
                var dest = edges[1];

                graph[source].Add(dest);
                graph[dest].Add(source);
            }


            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    //FindBiconnectedComponents(node, 1);
                    FindByConnectedComponents(node, 1);
                    while (edges.Count > 0)
                    {
                        if (!nodeEdges.ContainsKey(componentCounter)) nodeEdges[componentCounter] = new List<Edge>();
                        nodeEdges[componentCounter].Add(edges.Pop());
                    }
                }
            }

            Console.WriteLine($"Number of bi-connected components: {nodeEdges.Count}");

            //foreach (var edgeItems in nodeEdges.Values)
            //{
            //    var result = new List<int>();
            //    foreach (var edge in edgeItems)
            //    {
            //        if (!result.Contains(edge.From)) result.Add(edge.From);
            //        if (!result.Contains(edge.To)) result.Add(edge.To);
            //    }

            //    Console.WriteLine(string.Join(", ", result.OrderBy(x => x)));
            //}
        }

        private static void FindByConnectedComponents(int node, int depth)
        {
            visited[node] = true;
            depths[node] = depth;
            lowpoints[node] = depth;
            var childCount = 0;
            foreach (var child in graph[node])
            {
                var currentEdge = new Edge(node, child);
                if (!visited[child])
                {
                    parents[child] = node;
                    edges.Push(currentEdge);
                    childCount++;

                    FindByConnectedComponents(child, depth + 1);

                    lowpoints[node] = Math.Min(lowpoints[node], lowpoints[child]);
                    if (parents[node] == null && childCount > 1)
                    {
                        PrintFromEdges(currentEdge);
                    }
                    if (parents[node] != null && lowpoints[child] >= depths[node])
                    {
                        PrintFromEdges(currentEdge);
                    }
                }
                else if (parents[node] != child &&
                    (depths[child] > 0 && lowpoints[node] > 0) &&
                    depths[child] < lowpoints[node])
                {
                    lowpoints[node] = depths[child];
                    edges.Push(currentEdge);
                }
            }
        }

        private static void PrintFromEdges(Edge currentEdge)
        {
            var lastEdge = edges.Peek();
            while (lastEdge != currentEdge)
            {
                if (!nodeEdges.ContainsKey(componentCounter)) nodeEdges[componentCounter] = new List<Edge>();
                nodeEdges[componentCounter].Add(edges.Pop());
                lastEdge = edges.Peek();
            }

            if (!nodeEdges.ContainsKey(componentCounter)) nodeEdges[componentCounter] = new List<Edge>();
            nodeEdges[componentCounter].Add(edges.Pop());
            componentCounter++;
        }

        private static int ParseInput()
        {
            return int.Parse(Console.ReadLine().Split(' ')[1]);
        }
    }

    public class Edge : IComparable<Edge>
    {
        public Edge(int from, int to)
        {
            this.From = from;
            this.To = to;
        }

        public int From { get; set; }
        public int To { get; set; }

        public int CompareTo(Edge other)
        {
            if (this.From == other.From && this.To == other.To) return 0;
            return -1;
        }

        public int GetHashCode([DisallowNull] Edge obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{this.From} - {this.To}";
        }
    }
}
