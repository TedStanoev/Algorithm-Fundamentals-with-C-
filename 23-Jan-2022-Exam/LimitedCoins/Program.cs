using System;
using System.Collections.Generic;
using System.Linq;

namespace LimitedCoins
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
            var counter = 0;
            var sums = new HashSet<int> { 0 };

            foreach (var coin in coins)
            {
                var currentSums = new HashSet<int>();
                foreach (var sum in sums)
                {
                    var newSum = sum + coin;

                    if (newSum == target)
                        counter++;

                    currentSums.Add(newSum);
                }

                sums.UnionWith(currentSums);
            }

            return counter;
        }
    }
}
