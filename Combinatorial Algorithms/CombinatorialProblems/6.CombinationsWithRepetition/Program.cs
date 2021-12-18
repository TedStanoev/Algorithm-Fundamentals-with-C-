using System;
using System.Linq;

namespace _6.CombinationsWithRepetition
{
    public class Program
    {
        static string[] elements;
        static string[] combinationSet;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();

            var cellsCount = int.Parse(Console.ReadLine());

            combinationSet = new string[cellsCount];

            GetCombination(0, 0);
        }

        private static void GetCombination(int index, int elementStartIndex)
        {
            if (index >= combinationSet.Length)
            {
                var set = string.Join(" ", combinationSet);

                Console.WriteLine(set);
                return;
            }

            for (int i = elementStartIndex; i < elements.Length; i++)
            {
                combinationSet[index] = elements[i];
                GetCombination(index + 1, i);
            }
        }
    }
}
