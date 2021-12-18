using System;
using System.Linq;

namespace _4.VariationsWithRepetition
{
    public class Program
    {
        static string[] elements;
        static string[] variations;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();

            var variantsCount = int.Parse(Console.ReadLine());

            variations = new string[variantsCount];

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
                variations[index] = elements[i];
                FindVariation(index + 1);
            }
        }
    }
}
