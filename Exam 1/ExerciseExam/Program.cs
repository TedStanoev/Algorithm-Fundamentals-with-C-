using System;
using System.Collections.Generic;

namespace ExerciseExam
{
    public class Program
    {
        private const char visited = 'v';
        private static char[,] matrix;
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var row = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = row[c];
                }
            }

            var tunnels = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (IsVisited(r, c) || IsDirt(r, c))
                        continue;

                    ExploreTunnel(r, c);

                    tunnels++;
                }
            }

            Console.WriteLine(tunnels);
        }

        private static void ExploreTunnel(int r, int c)
        {
            if (IsOutOfBounds(r, c) || IsVisited(r, c) || IsDirt(r, c))
                return;

            matrix[r, c] = visited;

            ExploreTunnel(r - 1, c - 1);
            ExploreTunnel(r - 1, c);
            ExploreTunnel(r - 1, c + 1);
            ExploreTunnel(r, c + 1);
            ExploreTunnel(r + 1, c + 1);
            ExploreTunnel(r + 1, c);
            ExploreTunnel(r + 1, c - 1);
            ExploreTunnel(r, c - 1);
        }

        private static bool IsOutOfBounds(int r, int c)
            => r < 0
            || c < 0
            || r >= matrix.GetLength(0)
            || c >= matrix.GetLength(1);

        private static bool IsDirt(int r, int c)
            => matrix[r, c] == 'd';

        private static bool IsVisited(int r, int c)
            => matrix[r, c] == visited;
    }
}
