namespace p02.ModifiedKruskal
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class Program
    {

        public static void Main()
        {
            var nodes = InputParseSndArg();
            var edgesCount = InputParseSndArg();
            //var nodes = int.Parse(Console.ReadLine());
            //var edgesCount = int.Parse(Console.ReadLine());

            var visisted = new bool[nodes];
            var parents = new int[nodes];
            for (int i = 0; i < parents.Length; i++) parents[i] = i;

            var edges = new List<Edge>();
            for (int i = 0; i < edgesCount; i++)
            {
                int[] tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                edges.Add(new Edge(tokens[0], tokens[1], tokens[2]));
                //edges.Add(new Edge(tokens[1], tokens[0], tokens[2]));
            }

            edges.Sort();

            var result = new List<Edge>();
            foreach (var edge in edges)
            {
                var firstRoot = FetchRoot(edge.From, parents);
                var secondRoot = FetchRoot(edge.To, parents);

                if (firstRoot != secondRoot)
                {
                    parents[firstRoot] = secondRoot;
                    result.Add(edge);
                }
            }

            var totalWeight = result.Sum(x => x.Weight);
            Console.WriteLine($"Minimum spanning forest weight: {totalWeight}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static int FetchRoot(int node, int[] parents)
        {
            var root = node;
            while (root != parents[root])
            {
                root = parents[root];
            }

            while (node != root)
            {
                var oldRoot = parents[node];
                parents[node] = root;
                node = oldRoot;
            }

            return root;
        }

        private static int InputParseSndArg()
        {
            return int.Parse(Console.ReadLine().Split(' ').Select(x => x.Trim()).ToArray()[1]);
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
            return $"({this.From} {this.To}) -> {this.Weight}";
        }
    }
}