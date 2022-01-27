using System;
using System.Collections.Generic;
using System.Linq;

namespace DividingPresents
{
    public class Program
    {
        private static Dictionary<int, int> allSums;
        public static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var totalSum = presents.Sum();
            allSums = GetSums(presents);
            var half = totalSum / 2;
            var alanSum = half;

            while (alanSum > 0)
            {
                if (allSums.ContainsKey(alanSum))
                {
                    var bobSum = totalSum - alanSum;
                    var alanPresents = string.Join(" ", GetPresents(alanSum));

                    Console.WriteLine($"Difference: {bobSum - alanSum}");
                    Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {alanPresents}");
                    Console.WriteLine("Bob takes the rest.");

                    break;
                }

                alanSum--;
            }
        }

        private static List<int> GetPresents(int key)
        {
            var presents = new List<int>();

            while (key != 0)
            {
                var number = allSums[key];
                presents.Add(number);
                key -= number;
            }

            return presents;
        }

        private static Dictionary<int, int> GetSums(int[] numbers)
        {
            var sums = new Dictionary<int, int>() { { 0, 0 } };

            foreach (var num in numbers)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;

                    if (sums.ContainsKey(newSum))
                        continue;

                    sums.Add(sum + num, num);
                }
            }

            return sums;
        }
    }
}
