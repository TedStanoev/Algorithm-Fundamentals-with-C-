using System;
using System.Linq;

namespace RecursiveSumArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = GetResult(0, inputArray);

            Console.WriteLine(result);
        }

        private static int GetResult(int index, int[] array)
        {
            if (index == array.Length - 1)
                return array[index];

            return array[index] + GetResult(index + 1, array);
        }
    }
}
