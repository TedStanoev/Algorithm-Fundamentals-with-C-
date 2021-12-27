using System;
using System.Linq;

namespace SelectionSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SelectionSort(array);

            Console.WriteLine(string.Join(" ", array));
        }

        private static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                Swap(array, i, min);
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
