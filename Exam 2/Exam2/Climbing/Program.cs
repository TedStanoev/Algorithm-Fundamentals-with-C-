using System;
using System.Collections.Generic;
using System.Linq;

namespace Climbing
{
    public class Program
    {
        private static ulong[,] matrix;
        private static ulong[,] helperMatrix;
        private static List<ulong> path;
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new ulong[rows, cols];
            helperMatrix = new ulong[rows, cols];
            path = new List<ulong>();

            for (int r = 0; r < rows; r++)
            {
                var colElements = Console.ReadLine()
                    .Split()
                    .Select(uint.Parse)
                    .ToArray();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            if (cols > 1)
            {
                for (int col = cols - 2; col >= 0; col--)
                {
                    helperMatrix[0, col] = matrix[0, col + 1] + matrix[0, col];
                }
            }

            if (rows > 1)
            {
                for (int row = rows - 2; row >= 0; row--)
                {
                    helperMatrix[row, 0] = matrix[row + 1, 0] + matrix[row, 0];
                }
            }

            for (int row = rows - 2; row >= 0; row--)
            {
                for (int col = cols - 2; col >= 0; col--)
                {
                    helperMatrix[row, col] = Math.Max(matrix[row + 1, col], matrix[row, col + 1]) + matrix[row, col];
                }
            }

            var currentRow = rows - 1;
            var currentCol = cols - 1;
            path.Add(matrix[currentRow, currentCol]);

            while (currentRow > 0 &&
                    currentCol > 0)
            {
                if (helperMatrix[currentRow - 1, currentCol] >=
                    helperMatrix[currentRow, currentCol - 1])
                {
                    currentRow--;
                }
                else
                {
                    currentCol--;
                }

                path.Add(matrix[currentRow, currentCol]);
            }

            if (currentRow == 0)
            {
                for (int col = currentCol - 1; col >= 0; col--)
                {
                    path.Add(matrix[currentRow, col]);
                }
            }
            else
            {
                for (int row = currentRow - 1; row >= 0; row--)
                {
                    path.Add(matrix[row, currentCol]);
                }
            }

            ulong sum = 0;

            foreach (var element in path)
            {
                sum += element;
            }
            Console.WriteLine(sum);
            Console.WriteLine(string.Join(" ", path));
        }
    }
}
