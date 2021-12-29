using System;
using System.Linq;
using System.Text;

namespace CoinSum
{
    public class Program
    {
        static void Main(string[] args)
        {
            var coins = Console.ReadLine()
                .Split(", ", StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine());

            FindSum(coins, target);
        }

        private static void FindSum(int[] coins, int target)
        {
            var sortedCoins = coins
                .OrderByDescending(c => c)
                .ToList();

            StringBuilder sb = new StringBuilder();

            var coinsCount = 0;
            var coinIndex = 0;

            while (target > 0 && coinIndex < sortedCoins.Count)
            {
                var currentCoin = sortedCoins[coinIndex++];

                var count = target / currentCoin;

                if (count > 0)
                {
                    coinsCount += count;
                    target -= count * currentCoin;
                    sb.AppendLine($"{count} coin(s) with value {currentCoin}");
                }
            }

            if (target == 0)
            {
                Console.WriteLine($"Number of coins to take: {coinsCount}");
                Console.WriteLine(sb.ToString().Trim());
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
