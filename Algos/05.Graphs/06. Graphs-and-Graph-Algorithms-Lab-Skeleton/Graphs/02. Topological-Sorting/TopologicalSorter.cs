using System;
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
        GetPredecessorCount(this.graph);
        var result = new List<string>();

        while (true)
        {
            var nodeToRemove = predecesorCount.Keys.Where(node => predecesorCount[node] == 0).FirstOrDefault();
            if (nodeToRemove == null) break;

            var children = this.graph[nodeToRemove];
            foreach (var child in children)
            {
                predecesorCount[child]--;
            }

            result.Add(nodeToRemove);
            this.graph.Remove(nodeToRemove);
            this.predecesorCount.Remove(nodeToRemove);
        }

        if (graph.Count > 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }
    private void GetPredecessorCount(Dictionary<string, List<string>> graph)
    {
        foreach (var kvp in graph)
        {
            var node = kvp.Key;
            var children = kvp.Value;

            if (!predecesorCount.ContainsKey(node)) predecesorCount[node] = 0;
            foreach (var child in children)
            {
                if (!predecesorCount.ContainsKey(child)) predecesorCount[child] = 0;
                predecesorCount[child]++;
            }
        }
    }
}
