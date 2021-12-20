using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ConnectedAreas
{
    public class Program
    {
        private const char visited = 'v';
        static char[,] matrix;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var columnElements = Console.ReadLine();

                for (int col = 0; col < columnElements.Length; col++)
                {
                    matrix[row, col] = columnElements[col];
                }
            }

            var areas = new List<Area>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    var area = new Area() { Row = r, Col = c};

                    ExploreArea(r, c, area);

                    if (area.Size > 0)
                        areas.Add(area);
                }
            }

            var sorted = areas
                .OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {sorted.Count}");

            for (int i = 1; i < sorted.Count + 1; i++)
            {
                var currentArea = sorted[i - 1];
                Console.WriteLine($"Area #{i} at ({currentArea.Row}, {currentArea.Col}), size: {currentArea.Size}");
            }
        }

        private static void ExploreArea(int row, int col, Area area)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
                return;

            area.Size++;
            matrix[row, col] = visited;

            ExploreArea(row + 1, col, area);
            ExploreArea(row - 1, col, area);
            ExploreArea(row, col + 1, area);
            ExploreArea(row, col - 1, area);
        }

        private static bool IsVisited(int row, int col)
            => matrix[row, col] == visited;

        private static bool IsWall(int row, int col)
            => matrix[row, col] == '*';

        private static bool IsOutside(int row, int col)
            => row < 0 
            || col < 0 
            || row >= matrix.GetLength(0) 
            || col >= matrix.GetLength(1);
    }
}
