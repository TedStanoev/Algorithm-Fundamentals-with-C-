using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam2
{
    public class Program
    {
        private static List<int>[] graph;
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                var children = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (children.Count > 0)
                    graph[i] = children;
                else
                    graph[i] = new List<int>();
            }

            var lastNode = graph.Length - 1;

            for (int i = 0; i < lastNode; i++)
            {
                var path = new List<int>();
                DFS(i, lastNode, path);
            }
        }

        private static void DFS(int index, int destination, List<int> path)
        {
            if (index == destination)
            {
                path.Add(index);
                Console.WriteLine(string.Join(" ", path));
                path.Remove(index);
                return;
            }

            path.Add(index);

            foreach (var child in graph[index])
            {
                DFS(child, destination, path);
            }

            path.Remove(index);
        }
    }
}
