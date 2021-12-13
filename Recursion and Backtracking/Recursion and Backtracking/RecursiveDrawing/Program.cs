using System;

namespace RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            Draw(inputNumber);
        }

        private static void Draw(int number)
        {
            if (number < 1)
                return;

            for (int i = 0; i < number; i++)
            {
                Console.Write('*');
            }

            Console.WriteLine();

            Draw(number - 1);

            for (int i = 0; i < number; i++)
            {
                Console.Write('#');
            }

            Console.WriteLine();
        }
    }
}
