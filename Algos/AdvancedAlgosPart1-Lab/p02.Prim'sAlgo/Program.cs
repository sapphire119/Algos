namespace p02.Prim_sAlgo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

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

            var nodeEdges = new Dictionary<int, List<Edge>>();
            foreach (var node in nodes)
            {
                if (!nodeEdges.ContainsKey(node)) nodeEdges[node] = new List<Edge>();
                nodeEdges[node].AddRange(edges.Where(x => x.FirstNode == node));
                nodeEdges[node].AddRange(edges.Where(x => x.SecondNode == node));
            }

            var priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));
            var spanningTree = new HashSet<int>();
            foreach (var node in nodes)
            {
                if (!spanningTree.Contains(node))
                {
                    Prim(node, nodeEdges, priorityQueue, spanningTree);
                }
            }
        }

        private static void Prim(int node, Dictionary<int, List<Edge>> nodeEdges, OrderedBag<Edge> priorityQueue, HashSet<int> spanningTree)
        {
            var edges = nodeEdges[node];
            spanningTree.Add(node);
            priorityQueue.AddMany(edges);

            while (priorityQueue.Count != 0)
            {
                var edge = priorityQueue.GetFirst();
                priorityQueue.Remove(edge);


                var firstNode = edge.FirstNode;
                var secondNode = edge.SecondNode;
                var nonTreeNode = -1;
                if (spanningTree.Contains(firstNode) && !spanningTree.Contains(secondNode))
                {
                    nonTreeNode = secondNode;
                }

                if (spanningTree.Contains(secondNode) && !spanningTree.Contains(firstNode))
                {
                    nonTreeNode = firstNode;
                }

                if (nonTreeNode == -1) continue;

                Console.WriteLine($"{edge.FirstNode} - {edge.SecondNode}");
                spanningTree.Add(nonTreeNode);
                priorityQueue.AddMany(nodeEdges[nonTreeNode]);
            }
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
