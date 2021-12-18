using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.VariationsWithoutRepetition
{
    public class Program
    {
        static string[] elements;
        static string[] variations;
        static bool[] used;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();

            var variantsCount = int.Parse(Console.ReadLine());

            variations = new string[variantsCount];
            used = new bool[elements.Length];

            FindVariation(0);
        }

        private static void FindVariation(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    FindVariation(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
