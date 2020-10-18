namespace p05.BreakCycle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {

            var graph = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split(new char[] { '–', '>' }).Select(x => x.Trim()).Where(x => x != string.Empty).ToArray();
                var node = tokens[0];
                var children = tokens[1].Split(' ');
                if (!graph.ContainsKey(tokens[0])) graph[node] = new List<string>();
                graph[node].AddRange(children);
            }


            graph = graph.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value.OrderBy(y => y).ToList());
            var result = new List<string>();
            foreach (var node in graph.Keys)
            {
                var children = graph[node].ToList();
                foreach (var child in children)
                {
                    RemoveNodeChild(node, child, graph);
                    var isThereAPath = FindPath(node, child, graph);
                    if (!isThereAPath) AddNodeChild(node, child, graph);
                    else result.Add($"{node} - {child}");
                }
            }

            //Edges to remove: 2
            //1 - 2
            //6 – 7
            Console.WriteLine($"Edges to remove: {result.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static bool FindPath(string node, string child, Dictionary<string, List<string>> graph)
        {
            var visited = new HashSet<string>();
            DepthFirstSearch(node, child, visited, graph);
            if (visited.Contains(node) && visited.Contains(child)) return true;
            return false;
        }

        private static void DepthFirstSearch(string node, string targetNode, HashSet<string> visited, Dictionary<string, List<string>> graph)
        {
            if (visited.Contains(node) && visited.Contains(targetNode)) return;
            if (!visited.Contains(node))
            {
                visited.Add(node);
                var children = graph[node];
                foreach (var child in children)
                {
                    DepthFirstSearch(child, targetNode, visited, graph);
                }
            }
        }

        private static void RemoveNodeChild(string node, string child, Dictionary<string, List<string>> graph)
        {
            graph[node].Remove(child);
            graph[child].Remove(node);
        }

        private static void AddNodeChild(string node, string child, Dictionary<string, List<string>> graph)
        {
            graph[node].Add(child);
            graph[child].Add(node);
        }
    }
}
