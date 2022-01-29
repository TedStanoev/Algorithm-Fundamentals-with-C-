using System;
using System.Collections.Generic;
using System.Linq;

namespace Time
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sequence1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var sequence2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var lcs = new int[sequence1.Length + 1, sequence2.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (sequence1[r - 1] == sequence2[c - 1])
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    else
                        lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
                }
            }


            var timeLine = new Stack<int>();

            var row = lcs.GetLength(0) - 1;
            var col = lcs.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                if (sequence1[row - 1] == sequence2[col - 1]
                    && lcs[row, col] == lcs[row - 1, col - 1] + 1)
                {
                    timeLine.Push(sequence1[row - 1]);

                    row--;
                    col--;
                }
                else if (lcs[row - 1, col] > lcs[row, col - 1])
                    row--;
                else
                    col--;
            }

            Console.WriteLine(string.Join(" ", timeLine));
            Console.WriteLine(lcs[sequence1.Length, sequence2.Length]);
        }
    }
}
