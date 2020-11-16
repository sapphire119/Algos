using System;
using System.Collections.Generic;
using System.Linq;

public class StronglyConnectedComponents
{
    private static List<int>[] graph;
    private static List<int>[] reverseGraph;
    private static bool[] visited;
    private static List<List<int>> stronglyConnectedComponents;
    private static Stack<int> nodes = new Stack<int>();

    //Kosaraju–Sharir algorithm for finding strongly-connected-componenets.
    public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
    {
        graph = targetGraph;
        reverseGraph = new List<int>[graph.Length];
        visited = new bool[graph.Length];
        stronglyConnectedComponents = new List<List<int>>();

        BuildReverseGraph();

        for (int node = 0; node < graph.Length; node++)
        {
            if (!visited[node]) Dfs(node);
        }

        visited = new bool[reverseGraph.Length];
        while (nodes.Count > 0)
        {
            var node = nodes.Pop();
            if (!visited[node])
            {
                stronglyConnectedComponents.Add(new List<int>());
                ReverseDfs(node);
            }
        }


        return stronglyConnectedComponents
            .Select(x =>
                x.OrderBy(y => y)
                 .ToList())
            .ToList();
    }

    public static void ReverseDfs(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            stronglyConnectedComponents.Last().Add(node);
            foreach (var child in reverseGraph[node])
            {
                ReverseDfs(child);
            }
        }
    }

    public static void BuildReverseGraph()
    {
        for (int node = 0; node < reverseGraph.Length; node++) reverseGraph[node] = new List<int>();

        for (int node = 0; node < graph.Length; node++)
        {
            foreach (var child in graph[node])
            {
                reverseGraph[child].Add(node);
            }
        }
    }

    public static void Dfs(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var child in graph[node])
            {
                Dfs(child);
            }

            nodes.Push(node);
        }
    }
}
