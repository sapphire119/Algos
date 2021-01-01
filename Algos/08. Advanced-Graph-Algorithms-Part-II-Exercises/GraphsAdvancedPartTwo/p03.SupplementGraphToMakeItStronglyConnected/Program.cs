namespace p03.SupplementGraphToMakeItStronglyConnected
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<int>[] graph;

        public static void Main()
        {

            var nodes = ReadInput();
            var edgesCount = ReadInput();

            graph = new List<int>[nodes];
            for (int node = 0; node < graph.Length; node++) graph[node] = new List<int>();

            for (int i = 0; i < edgesCount; i++)
            {
                int[] vertices = Console.ReadLine().Split("->").Select(int.Parse).ToArray();
                var from = vertices[0];
                var to = vertices[1];
                graph[from].Add(to);
            }

            //graph = new List<int>[]
            //{
            //    new List<int> { 1, 2},
            //    new List<int> { 2 },
            //    new List<int> { }
            //};

            //graph = new List<int>[]
            //{
            //    new List<int> { },          //0
            //    new List<int> { 2 },        //1
            //    new List<int> { 6 },        //2
            //    new List<int> { 2, 4 },     //3
            //    new List<int> { 2 },        //4
            //    new List<int> { 2, 6 },     //5
            //    new List<int> { },          //6
            //};

            var components = StronglyConnectedComponents.FindStronglyConnectedComponents(graph);

            var compGraph = new List<int>[components.Count];
            for (int node = 0; node < compGraph.Length; node++) compGraph[node] = new List<int>();


            for (int component = 0; component < components.Count; component++)
            {
                var elements = components[component];
                foreach (var element in elements)
                {
                    var children = graph[element];
                    foreach (var child in children)
                    {
                        if (element == child) continue;
                        var currIndexComponent = FindIndexComponent(components, child);
                        
                        if (currIndexComponent != component &&
                            !compGraph[component].Contains(currIndexComponent)) 
                                compGraph[component].Add(currIndexComponent);
                    }
                }
            }

            var compOutDegree = FetchOutDegreeOfGraph(compGraph);
            var compInDegree = FetchInDegreeOfGraph(compGraph);

            Console.WriteLine($"New edges needed: {Math.Max(compOutDegree.Count, compInDegree.Count)}");
        }

        private static int FindIndexComponent(List<List<int>> components, int child)
        {
            for (int component = 0; component < components.Count; component++)
            {
                var currComp = components[component];
                if (currComp.Contains(child)) 
                    return component;
            }

            return -1;
        }

        private static List<int> FetchOutDegreeOfGraph(List<int>[] compGraph)
        {
            var result = new List<int>();
            for (int node = 0; node < compGraph.Length; node++)
            {
                if (compGraph[node].Count == 0) result.Add(node);
            }

            return result;
        }

        private static List<int> FetchInDegreeOfGraph(List<int>[] graph)
        {
            var result = new List<int>();
            for (int node = 0; node < graph.Length; node++)
            {
                var isChildNode = false;
                foreach (var childList in graph)
                {
                    //assume simple path
                    if (childList.Contains(node)) { isChildNode = true; break; }
                }
                if (!isChildNode) result.Add(node);
            }

            return result;
        }

        private static int ReadInput()
        {
            return int.Parse(Console.ReadLine().Split(' ')[1]);
        }
    }
}
