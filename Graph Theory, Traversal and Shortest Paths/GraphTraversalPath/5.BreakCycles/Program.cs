using System;
using System.Linq;
using System.Collections.Generic;

namespace _5.BreakCycles
{
    public class Edge
    {
        public string First { get; set; }

        public string Second { get; set; }

        public string Reverse()
        {
            return $"{this.Second} - {this.First}";
        }

        public override string ToString()
        {
            return $"{this.First} - {this.Second}";
        }
    }
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var nodeAndChildren = Console.ReadLine().Split(" -> ");

                var node = nodeAndChildren[0];
                var children = nodeAndChildren[1].Split().ToList();

                graph[node] = children;

                foreach (var child in children)
                {
                    edges.Add(new Edge()
                    {
                        First = node,
                        Second = child
                    });
                }
            }

            edges = edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();

            var removedEdges = new List<Edge>();
            var reversedEdges = new HashSet<string>();

            foreach (var edge in edges)
            {
                if (reversedEdges.Contains(edge.ToString()))
                    continue;

                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                if (BFS(edge.First, edge.Second))
                {
                    reversedEdges.Add(edge.Reverse());
                    removedEdges.Add(edge);
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges)
            {
                Console.WriteLine(edge);
            }
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);

            var visited = new HashSet<string> { start };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                    return true;

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                        continue;

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }
    }
}
