using System;
using System.Collections.Generic;
using System.Linq;

namespace AllPathsInALabyrinth
{
    class Program
    {
        public static char[,] labyrinth;
        public static List<char> directions = new List<char>();

        static void Main(string[] args)
        {
            // Input values
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            labyrinth = new char[rows, cols];

            // Create labyrinth
            for (int row = 0; row < rows; row++)
            {
                var lineInput = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = lineInput[col];
                }
            }

            Move(0, 0, 'S');
        }

        public static void Move(int row, int col, char direction)
        {
            if (IsInBounds(row, col) == false)
                return;
                

            if (direction != 'S')
                directions.Add(direction);

            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (IsVisited(row, col) == false && IsWall(row, col) == false)
            {
                // Mark as visited and continue on moving
                Mark(row, col);
                Move(row, col + 1, 'R');
                Move(row, col - 1, 'L');
                Move(row + 1, col, 'D');
                Move(row - 1, col, 'U');
                Unmark(row, col);
            }

            if (directions.Any())
                directions.RemoveAt(directions.Count - 1);
        }

        private static void PrintPath()
            => Console.WriteLine(string.Join("", directions));

        private static bool IsExit(int row, int col)
            => labyrinth[row, col] == 'e';

        private static bool IsWall(int row, int col)
            => labyrinth[row, col] == '*';

        private static bool IsVisited(int row, int col)
            => labyrinth[row, col] == 'v';

        private static void Mark(int row, int col)
            => labyrinth[row, col] = 'v';

        private static void Unmark(int row, int col)
            => labyrinth[row, col] = '-';

        private static bool IsInBounds(int row, int col)
            => row >= 0 &&
                col >= 0 &&
                row < labyrinth.GetLength(0) &&
                col < labyrinth.GetLength(1);
    }
}
