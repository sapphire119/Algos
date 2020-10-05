namespace p01.DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numberOfVertices = int.Parse(Console.ReadLine());
            var numberOfPairs = int.Parse(Console.ReadLine());

            var graph = new Dictionary<int, List<int>>();

            string line;
            for (int i = 0; i < numberOfVertices; i++)
            {
                line = Console.ReadLine();
                var tokens = line.Split(':');
                var node = int.Parse(tokens[0]);

                if (!graph.ContainsKey(node)) graph[node] = new List<int>();

                if (!string.IsNullOrWhiteSpace(tokens[1]))
                {
                    var childrenValues = tokens[1].Split(' ').Select(int.Parse).ToArray();
                    graph[node].AddRange(childrenValues);
                }
            }

            
            for (int j = 0; j < numberOfPairs; j++)
            {
                line = Console.ReadLine();
                var tokens = line.Split('-').Select(int.Parse).ToArray();
                var source = tokens[0];
                var dest = tokens[1];

                var distance = BreadthFirstSearch(source, dest, graph);
                Console.WriteLine($"{{{source}, {dest}}} -> {distance}");
            }
        }

        private static int BreadthFirstSearch(int source, int destination, Dictionary<int, List<int>> graph)
        {
            var visited = new HashSet<int>();
            var nodesParents = new Dictionary<int, int>();
            foreach (var node in graph.Keys)
            {
                nodesParents[node] = -1;
            }
            var queue = new Queue<int>();
            queue.Enqueue(source);
            visited.Add(source);

            while (queue.Count > 0)
            {
                if (queue.Contains(destination))
                {
                    return GetDestinationCount(nodesParents, destination);
                }

                var currentNodeValue = queue.Dequeue();
                
                var childNodes = graph[currentNodeValue];

                foreach (var child in childNodes)
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                        nodesParents[child] = currentNodeValue;
                    }
                }
            }
            return -1;
        }

        private static int GetDestinationCount(Dictionary<int, int> nodesParents, int destination)
        {
            var result = 0;
            var currentNode = destination;
            while (nodesParents[currentNode] != -1)
            {
                result++;
                currentNode = nodesParents[currentNode];
            }
            return result;
        }
    }
}
