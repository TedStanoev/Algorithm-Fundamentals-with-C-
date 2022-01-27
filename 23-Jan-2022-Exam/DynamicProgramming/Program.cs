using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class Program
    {
        private static long[,] dp;
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            dp = new long[n + 1, k + 1];

            Console.WriteLine(GetBinom(n, k));
        }

        private static long GetBinom(int row, int col)
        {
            if (dp[row, col] != 0)
            {
                return dp[row, col];
            }

            if (row <= 1 || col == 0 || col == row)
            {
                dp[row, col] = 1;
            }
            else
            {
                dp[row, col] = GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
            }

            return dp[row, col];
        }
    }
}
