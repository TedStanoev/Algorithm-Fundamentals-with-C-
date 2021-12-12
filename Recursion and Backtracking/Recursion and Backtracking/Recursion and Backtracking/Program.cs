using System;

namespace RecursiveFibonacci
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fibonacciNum = GetFibonacci(21);
            Console.WriteLine(fibonacciNum);
        }

        public static int GetFibonacci(int n)
        {
            Console.WriteLine(n);

            if (n == 0 || n == 1)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
