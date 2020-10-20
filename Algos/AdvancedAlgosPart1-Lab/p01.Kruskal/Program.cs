namespace p01.Kruskal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var edges = new List<Edge>
            {
                //A = 1, B = 2, C = 3, D = 4, E = 5, F = 6, G = 7, H = 8, I = 9
                new Edge(1, 3, 5),
                new Edge(1, 2, 4),
                new Edge(1, 4, 9),
                //A -> B, A -> C, A -> D
                new Edge(2, 4, 2),
                // B -> D
                new Edge(3, 4, 20),
                new Edge(3, 5, 7),
                // C -> D, C -> E
                new Edge(4, 5, 8),
                // D -> E
                new Edge(5, 6, 12),
                // E -> F
                new Edge(7, 9, 10),
                new Edge(7, 8, 8),
                //G -> I
                new Edge(8, 9, 7),
                // H -> I
            };

            var nodes = edges
                .Select(e => e.FirstNode)
                .Union(edges.Select(e => e.SecondNode))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var parent = new int[nodes.Max() + 1];
            foreach (var node in nodes)
            {
                parent[node] = node;
            }

            var orderedEdges = edges.OrderBy(x => x.Weight).ToHashSet();

            foreach (var edge in orderedEdges)
            {
                var firstRoot = FindRoot(edge.FirstNode, parent);
                var secondRoot = FindRoot(edge.SecondNode, parent);

                if (firstRoot != secondRoot)
                {
                    Console.WriteLine($"{edge.FirstNode} - {edge.SecondNode}");
                    parent[firstRoot] = secondRoot;
                }
            }
        }

        private static int FindRoot(int node, int[] parent)
        {
            var root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            while (node != root)
            {
                var oldRoot = parent[node];
                parent[node] = root;
                node = oldRoot;
            }

            return node;
        }
    }

    public class Edge
    {
        public Edge(int firstNode, int secondNode, int weight)
        {
            this.FirstNode = firstNode;
            this.SecondNode = secondNode;
            this.Weight = weight;
        }

        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.FirstNode} -> {this.SecondNode} :: {this.Weight}";
        }
    }
}
