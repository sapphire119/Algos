namespace Kurskal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();
            var parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++) parent[i] = i;
            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                var firstNodeRoot = FindRoot(edge.StartNode, parent);
                var secondNodeRoot = FindRoot(edge.EndNode, parent);
                if (firstNodeRoot != secondNodeRoot)
                {
                    spanningTree.Add(edge);
                    parent[firstNodeRoot] = secondNodeRoot;
                }
            }

            return spanningTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            var root = node;
            while (root != parent[root])
            {
                root = parent[root];
            }

            while (root != node)
            {
                var oldRoot = parent[node];
                parent[node] = root;
                node = oldRoot;
            }

            return root;
        }
    }
}
