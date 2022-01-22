using System;
using System.Linq;

namespace Socks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var left = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var right = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var dp = new int[left.Length + 1, right.Length + 1];

            for (int r = 1; r < dp.GetLength(0); r++)
            {
                for (int c = 1; c < dp.GetLength(1); c++)
                {
                    if (left[r - 1] == right[c - 1])
                    {
                        dp[r, c] = ++dp[r - 1, c - 1];
                    }
                    else
                    {
                        dp[r, c] = Math.Max(dp[r - 1, c], dp[r, c - 1]);
                    }
                }
            }

            Console.WriteLine(dp[left.Length, right.Length]);
        }
    }
}
