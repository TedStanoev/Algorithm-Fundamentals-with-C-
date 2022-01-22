using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (input.Count > 0)
                    graph.Add(i, input);
                else
                    graph.Add(i, new List<int>());
            }

            var p = int.Parse(Console.ReadLine());

            for (int i = 0; i < p; i++)
            {
                var sequence = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                var graphSequence = new List<int>();

                DFS(sequence[0], 0, sequence, graphSequence);

                if (graphSequence.SequenceEqual(sequence))
                    Console.WriteLine("yes");
                else
                    Console.WriteLine("no");
            }
        }

        private static void DFS(int node, int step, List<int> sequence, List<int> graphSequence)
        {
            if (step >= sequence.Count || node != sequence[step])
                return;

            graphSequence.Add(node);
            step++;

            foreach (var child in graph[node])
            {
                DFS(child, step, sequence, graphSequence);
            }
        }
    }
}
