namespace p03.DijkstraAlgo
{
    using System.Collections.Generic;
    using System.Linq;

    //using Wintellect.PowerCollections;

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


            var distances = new Dictionary<int, int>();
            var prev = new Dictionary<int, int>();
            foreach (var node in nodes)
            {
                distances[node] = int.MaxValue;
                prev[node] = -1;
            }

            distances[nodes.First()] = 0;

            var nodeEdges = new Dictionary<int, List<Edge>>();
            foreach (var edge in edges)
            {
                if (!nodeEdges.ContainsKey(edge.FirstNode)) nodeEdges[edge.FirstNode] = new List<Edge>();
                if (!nodeEdges.ContainsKey(edge.SecondNode)) nodeEdges[edge.SecondNode] = new List<Edge>();
                nodeEdges[edge.FirstNode].Add(edge);
                nodeEdges[edge.SecondNode].Add(edge);
            }
            var queue = new SortedSet<int>(Comparer<int>.Create((f, s) => distances[f] - distances[s]));
            queue.Add(nodes.First());

            while (queue.Count != 0)
            {
                var minNode = queue.Min;
                queue.Remove(minNode);

                if (distances[minNode] == int.MaxValue) break;

                foreach (var childEdge in nodeEdges[minNode])
                {
                    var firstNode = childEdge.FirstNode;
                    var secondNode = childEdge.SecondNode;

                    var otherNode = firstNode == minNode ? secondNode : firstNode;
                    if (distances[otherNode] == int.MaxValue)
                    {
                        queue.Add(otherNode);
                    }

                    var newDistance = distances[minNode] + childEdge.Weight;
                    if(newDistance < distances[otherNode])
                    {
                        distances[otherNode] = newDistance;
                        prev[otherNode] = minNode;
                        queue = new SortedSet<int>(queue, Comparer<int>.Create((f, s) => distances[f] - distances[s]));
                    }
                }
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
