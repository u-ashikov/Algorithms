namespace Fibonacci
{
    using System;

    public class Program
    {
        private static long[] fibonacciNums;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            fibonacciNums = new long[n + 1];
            Console.WriteLine(CalculateFibonacci(n));
        }

        private static long CalculateFibonacci(long n)
        {
            if (fibonacciNums[n] != 0)
            {
                return fibonacciNums[n];
            }

            if (n <= 2)
            {
                return 1;
            }

            var fib = CalculateFibonacci(n-1) + CalculateFibonacci(n-2);
            fibonacciNums[n] = fib;

            return fib;
        }
    }
}
