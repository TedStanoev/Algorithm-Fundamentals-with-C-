using System;
using System.Linq;

namespace ExamPreparation
{
    public class Program
    {
        private static int[] array;
        public static void Main(string[] args)
        {
            array = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 1; i <= array.Length; i++)
            {
                var slots = new int[i];
                FindCombinations(0, 0, slots);
            }
        }

        private static void FindCombinations(int index, int start, int[] slots)
        {
            if (index >= slots.Length)
            {
                Console.WriteLine(string.Join(" ", slots));
            }
            else
            {
                for (int i = start; i < array.Length; i++)
                {
                    slots[index] = array[i];
                    FindCombinations(index + 1, i + 1, slots);
                }
            }
        }
    }
}
