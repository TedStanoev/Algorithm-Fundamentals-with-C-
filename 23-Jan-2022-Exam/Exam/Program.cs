using System;

namespace Exam
{
    public class Program
    {
        private static long[,] grid;
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            grid = new long[rows, cols];

            var moves = Move(0, 0);

            Console.WriteLine(moves);
        }

        public static long Move(int row, int col)
        {
            if (IsInBounds(row, col) == false)
                return 0;

            if (row == grid.GetLength(0) - 1
                && col == grid.GetLength(1) - 1)
            {
                return 1;
            }

            if (grid[row, col] == 0)
            {
                grid[row, col] += Move(row, col + 1);
                grid[row, col] += Move(row + 1, col);
            }

            return grid[row, col];
        }
        private static bool IsInBounds(int row, int col)
            => row < grid.GetLength(0)
            && col < grid.GetLength(1);
    }
}
