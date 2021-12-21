using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SchoolTeams
{
    public class Program
    {
        static int girlsCount = 3;
        static int boysCount = 2;

        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ").ToArray();
            var girlsCombination = new string[girlsCount];
            var girlsCombinationList = new List<string[]>();

            GenerateCombinations(0, 0, girls, girlsCombination, girlsCombinationList);

            var boys = Console.ReadLine().Split(", ").ToArray();
            var boysCombination = new string[boysCount];
            var boysCombinationList = new List<string[]>();

            GenerateCombinations(0, 0, boys, boysCombination, boysCombinationList);

            PrintCombinations(girlsCombinationList, boysCombinationList);
        }

        private static void GenerateCombinations(int index, int start, string[] elements, string[] combs, List<string[]> combsList)
        {
            if (index >= combs.Length)
            {
                combsList.Add(combs.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combs[index] = elements[i];
                GenerateCombinations(index + 1, i + 1, elements, combs, combsList);
            }
        }

        private static void PrintCombinations(List<string[]> girlsCombs, List<string[]> boysCombs)
        {
            foreach (var girlsCombo in girlsCombs)
            {
                var girlsOutput = string.Join(", ", girlsCombo);

                foreach (var boysCombo in boysCombs)
                {
                    var boysOutput = string.Join(", ", boysCombo);

                    Console.WriteLine($"{girlsOutput}, {boysOutput}");
                }
            }
        }
    }
}
