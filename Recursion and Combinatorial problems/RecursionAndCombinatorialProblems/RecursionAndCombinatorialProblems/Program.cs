using System;
using System.Linq;

namespace _1.ReverseArray
{
    public class Program
    {
        static string[] reversedElements;

        static void Main(string[] args)
        {
            var inputArr = Console.ReadLine()
                .Split()
                .ToArray();

            reversedElements = new string[inputArr.Length];

            Reverse(0, inputArr.Length - 1, inputArr);
            Console.WriteLine(string.Join(" ", reversedElements));
        }

        private static void Reverse(int index, int reversedIndex, string[] elements)
        {
            if (index == elements.Length - 1 || reversedIndex == 0)
            {
                reversedElements[reversedIndex] = elements[index];
                return;
            }

            Reverse(index + 1, reversedIndex - 1, elements);

            reversedElements[reversedIndex] = elements[index];
        }
    }
}
