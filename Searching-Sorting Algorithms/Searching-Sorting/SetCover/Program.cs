using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    public class Program
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var numberOfSets = int.Parse(Console.ReadLine());
            var sets = new List<int[]>();

            for (int i = 0; i < numberOfSets; i++)
            {
                var set = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(set);
            }

            var result = TakeSets(universe, sets);

            Console.WriteLine($"Sets to take ({result.Count}):");

            foreach (var set in result)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }

        private static List<int[]> TakeSets(int[] universe, List<int[]> sets)
        {
            var selectedSets = new List<int[]>();

            while (universe.Length > 0)
            {
                var currentSet = sets
                    .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(currentSet);
                sets.Remove(currentSet);

                universe = universe
                    .Where(e => !currentSet.Contains(e))
                    .ToArray();
            }

            return selectedSets;
        }
    }
}
