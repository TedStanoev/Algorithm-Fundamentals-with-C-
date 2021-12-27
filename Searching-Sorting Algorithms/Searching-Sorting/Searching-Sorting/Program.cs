using System;
using System.Linq;

namespace Searching_Sorting
{
    public class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(array, number));
        }

        private static int BinarySearch(int[] array, int number)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (array[mid] == number)
                {
                    return mid;
                }

                if (array[mid] > number)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }
    }
}
