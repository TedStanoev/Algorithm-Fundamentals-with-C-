using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoMinutes
{
    public class Program
    {
        private static long[][] binoms;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            binoms = new long[n + 1][];

            for (int i = 1; i <= binoms.Length; i++)
            {
                binoms[i - 1] = new long[i];
            }

            Console.WriteLine(GetBinom(n, k));
        }

        private static long GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            if (binoms[row][col] == 0)
            {
                var binom1 = GetBinom(row - 1, col);
                var binom2 = GetBinom(row - 1, col - 1);

                binoms[row][col] = binom1 + binom2;
            }

            return binoms[row][col];
        }
    }
}
