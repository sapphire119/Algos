namespace Dijkstra
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            int?[] previous = new int?[graph.Count];
            bool[] visited = new bool[graph.Count];

            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            foreach (var pair in graph)
            {
                var key = pair.Key;
                key.DistanceFromStart = double.PositiveInfinity;
                var otherKeys = pair.Value.Keys;
                foreach (var node in otherKeys)
                {
                    node.DistanceFromStart = double.PositiveInfinity;
                }
            }

            sourceNode.DistanceFromStart = 0;
            priorityQueue.Enqueue(sourceNode);

            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.ExtractMin();

                if (currentNode == destinationNode) break;

                var children = graph[currentNode];
                foreach (var edge in children)
                {
                    var neigbouringNode = edge.Key;

                    if (!visited[neigbouringNode.Id])
                    {
                        priorityQueue.Enqueue(neigbouringNode);
                        visited[neigbouringNode.Id] = true;
                    }

                    var currentDist = currentNode.DistanceFromStart + edge.Value;
                    if (currentDist < neigbouringNode.DistanceFromStart)
                    {
                        neigbouringNode.DistanceFromStart = currentDist;
                        previous[neigbouringNode.Id] = currentNode.Id;
                        priorityQueue.DecreaseKey(neigbouringNode);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.DistanceFromStart)) return null;

            List<int> path = new List<int>();
            int? current = destinationNode.Id;
            while (current != null)
            {
                path.Add(current.Value);
                current = previous[current.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
