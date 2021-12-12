using System;
using System.Collections.Generic;

namespace _8Queens
{
    public class Program
    {
        private static readonly int chessBoardSize = 8;
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedColumns = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();
        public static void Main(string[] args)
        {
            bool[,] board = new bool[chessBoardSize, chessBoardSize];
            PlaceQueens(board, 0);
        }

        public static void PlaceQueens(bool[,] board, int row)
        {
            if (row == chessBoardSize)
            {
                for (int i = 0; i < chessBoardSize; i++)
                {
                    for (int j = 0; j < chessBoardSize; j++)
                    {
                        if (board[i, j])
                            Console.Write("* ");
                        else
                            Console.Write("- ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                return;
            }

            for (int col = 0; col < chessBoardSize; col++)
            {
                if (CanPlace(row, col))
                {
                    attackedRows.Add(row);
                    attackedColumns.Add(col);
                    attackedLeftDiagonals.Add(col - row);
                    attackedRightDiagonals.Add(row + col);
                    board[row, col] = true;

                    PlaceQueens(board, row + 1);

                    attackedRows.Remove(row);
                    attackedColumns.Remove(col);
                    attackedLeftDiagonals.Remove(col - row);
                    attackedRightDiagonals.Remove(row + col);
                    board[row, col] = false;
                }
            }
        }

        public static bool CanPlace(int row, int col)
            => !attackedRows.Contains(row) &&
                !attackedColumns.Contains(col) &&
                !attackedLeftDiagonals.Contains(col - row) &&
                !attackedRightDiagonals.Contains(row + col);
    }
}
