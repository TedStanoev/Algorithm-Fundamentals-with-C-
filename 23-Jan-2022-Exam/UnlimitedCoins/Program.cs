using System;
using System.Collections.Generic;
using System.Linq;

namespace UnlimitedCoins
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var coins = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine());

            var countOfCombinations = GetSumOfCoins(target, coins);

            Console.WriteLine(countOfCombinations);
        }

        private static int GetSumOfCoins(int target, int[] coins)
        {
            var sums = new int[target + 1];
            sums[0] = 1;

            foreach (var coin in coins)
            {
                for (int sum = coin; sum <= target; sum++)
                {
                    sums[sum] += sums[sum - coin];
                }
            }

            return sums[target];
        }
    }
}
