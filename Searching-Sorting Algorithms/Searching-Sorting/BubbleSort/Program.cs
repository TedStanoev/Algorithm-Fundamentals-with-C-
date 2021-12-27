using System;
using System.Linq;

namespace BubbleSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            BubbleSort(array);
            Console.WriteLine(string.Join(" ", array));
        }

        private static void BubbleSort(int[] array)
        {
            var isSorted = false;
            int sortedCount = 0;

            while (isSorted == false)
            {
                for (int i = 0; i < array.Length - 1 - sortedCount; i++)
                {
                    if (array[i] > array[i + 1])
                        Swap(array, i, i + 1);
                }

                sortedCount++;

                isSorted = sortedCount == array.Length;
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
