using System;
using System.Linq;

namespace InsertionSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            InsertionSort(array);
            Console.WriteLine(string.Join(" ", array));
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;

                while (j > 0 && array[j - 1] > array[j])
                {
                    Swap(array, j, j - 1);
                    j--;
                }
            }
        }

        private static void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
