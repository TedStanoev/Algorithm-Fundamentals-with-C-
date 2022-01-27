using System;
using System.Collections.Generic;
using System.Linq;

namespace Paths
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static Dictionary<int, bool> visited;
        public static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();
            visited = new Dictionary<int, bool>();

            for (int i = 0; i < nodes; i++)
            {
                var nodeChildren = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (nodeChildren.Count > 0)
                    graph.Add(i, nodeChildren);
                else
                    graph.Add(i, new List<int>());
            }

            var lastNode = graph.Keys.Last();
            var path = new List<int>();

            for (int i = 0; i < nodes; i++)
            {
                DFS(i, new List<int>());
            }
        }

        private static void DFS(int node, List<int> path)
        {
            if (visited.ContainsKey(node))
                return;

            path.Add(node);
            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, path);
                visited[child] = false;
            }

            Console.WriteLine(string.Join(" ", path));
        }
    }
}
