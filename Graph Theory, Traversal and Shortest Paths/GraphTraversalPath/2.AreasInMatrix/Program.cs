using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.AreasInMatrix
{
    public class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            for (int r = 0; r < rows; r++)
            {
                var row = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    graph[r, c] = row[c];
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (visited[r, c])
                        continue;

                    var node = graph[r, c];

                    DFS(r, c, node);

                    if (areas.ContainsKey(node))
                        areas[node]++;
                    else
                        areas[node] = 1;
                }
            }

            Console.WriteLine($"Areas: {areas.Sum(a => a.Value)}");

            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col, char parent)
        {
            if (!IsInMatrix(row, col))
                return;
            if (visited[row, col])
                return;
            if (graph[row, col] != parent)
                return;

            visited[row, col] = true;

            DFS(row, col - 1, parent);
            DFS(row, col + 1, parent);
            DFS(row - 1, col, parent);
            DFS(row + 1, col, parent);
        }

        private static bool IsInMatrix(int row, int col)
            => row >= 0
            && col >= 0
            && row < graph.GetLength(0)
            && col < graph.GetLength(1);
    }
}
