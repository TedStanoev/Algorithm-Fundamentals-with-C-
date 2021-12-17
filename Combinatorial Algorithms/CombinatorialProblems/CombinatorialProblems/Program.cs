using System;
using System.Collections.Generic;
using System.Linq;

namespace CombinatorialProblems
{
    public class Program
    {
        static string[] elements;
        static string[] permutations;
        static bool[] used;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();
            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < permutations.Length; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    permutations[index] = elements[i];
                    Permute(index + 1);
                    used[i] = false;
                }
            }           
        }
    }
}
