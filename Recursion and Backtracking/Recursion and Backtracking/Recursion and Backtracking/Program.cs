using System;

namespace RecursiveFibonacci
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            var fibonacciNum = GetFibonacci(inputNumber);
            Console.WriteLine(fibonacciNum);
        }

        public static int GetFibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
