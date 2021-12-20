using System;

namespace _2.NestedLoops
{
    public class Program
    {
        static int elementsCount;
        static int[] elements;
        static void Main(string[] args)
        {
            elementsCount = int.Parse(Console.ReadLine());
            elements = new int[elementsCount];

            Loop(0);
        }

        private static void Loop(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }
            
            for (int i = 1; i < elements.Length + 1; i++)
            {
                elements[index] = i;
                Loop(index + 1);
            }
        }
    }
}
