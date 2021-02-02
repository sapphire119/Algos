namespace p01.Index
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rows = ReadInput();
            var columns = ReadInput();

            var matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = tokens[j];
                }
            }

            var numberOfNodes = rows * columns;
            var id = 0;
            var nodes = new List<Node>();
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    nodes.Add(new Node(id++, matrix[i, j]));


            InitializeNodes(nodes, numberOfNodes, rows, columns);
            nodes[0].DistanceFromStart = 0;
            var distanceQueue = new PriorityQueue<Node>();
            distanceQueue.Enqueue(nodes[0]);

            var visited = new bool[nodes.Count];

            FindPath(distanceQueue, visited);
            PrintResult(nodes[nodes.Count - 1]);
        }

        private static void PrintResult(Node node)
        {
            var path = new List<int>();
            var totalLength = node.DistanceFromStart;
            while (node.Parent != null)
            {
                path.Add(node.Value);
                node = node.Parent;
            }
            path.Add(node.Value);
            path.Reverse();
            totalLength += node.Value;
            Console.WriteLine($"Length: {totalLength}");
            Console.WriteLine($"Path: {string.Join(" ", path)}");
        }

        private static void FindPath(PriorityQueue<Node> distanceQueue, bool[] visited)
        {
            while (distanceQueue.Count > 0)
            {
                var currentNode = distanceQueue.Dequeue();
                if (!visited[currentNode.Id])
                {
                    visited[currentNode.Id] = true;
                    foreach (var childNode in currentNode.Children)
                    {
                        var currentSum = currentNode.DistanceFromStart + childNode.Value;
                        if (currentSum < childNode.DistanceFromStart) childNode.Parent = currentNode;
                        childNode.DistanceFromStart = Math.Min(childNode.DistanceFromStart, currentSum);
                        if (!distanceQueue.Contains(childNode))
                        {
                            distanceQueue.Enqueue(childNode);
                        }
                        else
                        {
                            distanceQueue.DecreaseKey(childNode);
                        }
                    }
                }
            }
        }

        private static void InitializeNodes(List<Node> nodes, int numberOfNodes, int rows, int columns)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                AddToNode(nodes[i], nodes, numberOfNodes, rows, columns, i);
            }
        }


        private static void AddToNode(Node node, List<Node> nodes, int numberOfNodes, int rows, int columns, int currentIndex)
        {
            if (currentIndex % columns != columns - 1 &&
                currentIndex + 1 < numberOfNodes)
            {
                node.Children.Add(nodes[currentIndex + 1]);
            }
            if (currentIndex + columns < numberOfNodes)
            {
                node.Children.Add(nodes[currentIndex + columns]);
            }
            if (currentIndex > columns &&
                currentIndex % columns > 0 &&
                currentIndex + columns < numberOfNodes)
            {
                node.Children.Add(nodes[currentIndex - 1]);
            }
            if (currentIndex > columns &&
                currentIndex != numberOfNodes - 1)
            {
                node.Children.Add(nodes[currentIndex - columns]);
            }
        }

        private static int ReadInput()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}