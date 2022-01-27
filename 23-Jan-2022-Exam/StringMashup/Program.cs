using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.StringsMashup
{
    internal class Program
    {
        static void Main()
        {
            var str1 = Console.ReadLine();
            List<char> vectors = new List<char>(str1);

            Permutations(vectors, 0);
        }

        private static void Permutations(List<char> vectors, int index)
        {
            if (index == vectors.Count)
            {
                Console.WriteLine(String.Join("", vectors));
                return;
            }

            Permutations(vectors, index + 1);

            if (char.IsLetter(vectors[index]))
            {
                for (int i = 0; i < 1; i++)
                {
                    vectors[index] = Swap(vectors, index);
                    Permutations(vectors, index + 1);
                    vectors[index] = Swap(vectors, index);
                }
            }
        }

        private static char Swap(List<char> elements, int index)
        {
            return char.IsLower(elements[index])
                        ? char.ToUpper(elements[index])
                        : char.ToLower(elements[index]);
        }
    }
}