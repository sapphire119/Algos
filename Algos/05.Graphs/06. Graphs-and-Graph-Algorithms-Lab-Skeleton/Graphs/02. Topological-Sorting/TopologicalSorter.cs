﻿using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private Dictionary<string, int> predecesorCount;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
        this.predecesorCount = new Dictionary<string, int>();
    }

    public ICollection<string> TopSort()
    {
        LinkedList<string> sorted = new LinkedList<string>();
        HashSet<string> visited = new HashSet<string>();
        HashSet<string> cycles = new HashSet<string>();
        foreach (var node in this.graph.Keys)
        {
            DepthFirstSearch(node, visited, cycles, sorted);
        }
        return sorted;
    }

    private void DepthFirstSearch(string node, HashSet<string> visited, HashSet<string> cycles, LinkedList<string> sorted)
    {
        if (cycles.Contains(node))
        {
            throw new InvalidOperationException("Cycle detected.");
        }

        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycles.Add(node);
            var children = this.graph[node];
            foreach (var childNode in children)
            {
                DepthFirstSearch(childNode, visited, cycles, sorted);
            }
            cycles.Remove(node);
            sorted.AddFirst(node);
        }
    }

    //public ICollection<string> TopSort()
    //{
    //    GetPredecessorCount(this.graph);
    //    var result = new List<string>();

    //    while (true)
    //    {
    //        var nodeToRemove = predecesorCount.Keys.Where(node => predecesorCount[node] == 0).FirstOrDefault();
    //        if (nodeToRemove == null) break;

    //        var children = this.graph[nodeToRemove];
    //        foreach (var child in children)
    //        {
    //            predecesorCount[child]--;
    //        }

    //        result.Add(nodeToRemove);
    //        this.graph.Remove(nodeToRemove);
    //        this.predecesorCount.Remove(nodeToRemove);
    //    }

    //    if (graph.Count > 0)
    //    {
    //        throw new InvalidOperationException();
    //    }

    //    return result;
    //}

    //private void GetPredecessorCount(Dictionary<string, List<string>> graph)
    //{
    //    foreach (var kvp in graph)
    //    {
    //        var node = kvp.Key;
    //        var children = kvp.Value;

    //        if (!predecesorCount.ContainsKey(node)) predecesorCount[node] = 0;
    //        foreach (var child in children)
    //        {
    //            if (!predecesorCount.ContainsKey(child)) predecesorCount[child] = 0;
    //            predecesorCount[child]++;
    //        }
    //    }
    //}
}
