using System;

namespace RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            var result = CalculateFactorial(inputNumber);

            Console.WriteLine(result);
        }

        private static int CalculateFactorial(int n)
        {
            if (n == 1)
                return 1;

            return n * CalculateFactorial(n - 1);
        }
    }
}
