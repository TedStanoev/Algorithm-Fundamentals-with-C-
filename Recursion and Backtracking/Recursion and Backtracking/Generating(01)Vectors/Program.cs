using System;

namespace Generating_01_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumberOfVectors = int.Parse(Console.ReadLine());
            var vector = new int[inputNumberOfVectors];

            GenerateVectors(vector, 0);
        }

        private static void GenerateVectors(int[] vector, int index)
        {
            if (index > vector.Length - 1)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int j = 0; j < 2; j++)
            {
                vector[index] = j;
                GenerateVectors(vector, index + 1);
            }
        }
    }
}
