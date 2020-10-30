namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            var graphLength = graph.GetLength(0);

            var used = new bool[graphLength];
            var previous = new int?[graphLength];
            var distances = new int[graphLength];

            for (int i = 0; i < distances.Length; i++) distances[i] = int.MaxValue;
            distances[sourceNode] = 0;

            while (true)
            {
                var minDist = int.MaxValue;
                var minNode = 0;
                for (int node = 0; node < graphLength; node++)
                {
                    if(!used[node] && distances[node] < minDist)
                    {
                        minDist = distances[node];
                        minNode = node;
                    }
                }

                if (minDist == int.MaxValue) break;

                used[minNode] = true;

                for (int targetNode = 0; targetNode < graphLength; targetNode++)
                {
                    var currentEdge = graph[minNode, targetNode];
                    if (currentEdge > 0)
                    {
                        var currentDist = distances[minNode] + currentEdge;
                        if (currentDist < distances[targetNode])
                        {
                            distances[targetNode] = currentDist;
                            previous[targetNode] = minNode;
                        }

                    }
                }
            }

            if (distances[destinationNode] == int.MaxValue) return null;

            var path = new List<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
