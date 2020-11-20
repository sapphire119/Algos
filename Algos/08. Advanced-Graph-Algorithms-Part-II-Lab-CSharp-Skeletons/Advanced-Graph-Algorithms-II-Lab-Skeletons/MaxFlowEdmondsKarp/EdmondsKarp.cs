using System;
using System.Collections.Generic;
using System.Linq;

public class EdmondsKarp
{
    private static int[][] graph;
    private static int[] parents;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        graph = targetGraph;
        parents = Enumerable.Repeat(-1, targetGraph.Length).ToArray();

        var start = 0;
        var end = graph.Length - 1;
        var maxFlow = 0;

        while (Bfs(start, end))
        {
            var pathFlow = int.MaxValue;
            var currentNode = end;
            while (currentNode != start)
            {
                var prevNode = parents[currentNode];
                var currentFlow = targetGraph[prevNode][currentNode];
                if (currentFlow > 0 && currentFlow < pathFlow) pathFlow = currentFlow;

                currentNode = prevNode;
            }

            currentNode = end;
            while (currentNode != start)
            {
                var prevNode = parents[currentNode];

                targetGraph[prevNode][currentNode] -= pathFlow;
                targetGraph[currentNode][prevNode] += pathFlow;

                currentNode = prevNode;
            }

            maxFlow += pathFlow;
        }

        
        return maxFlow;
    }

    private static bool Bfs(int start, int end)
    {
        var visited = new bool[graph.Length];
        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            for (int child = 0; child < graph[node].Length; child++)
            {
                if(graph[node][child] > 0 && !visited[child])
                {
                    parents[child] = node;
                    queue.Enqueue(child);
                    visited[child] = true;
                }
            }
        }

        return visited[end];
    }
}
