namespace RecursiveFactorial
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var factorial = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFactorial(factorial));
        }

        private static int CalculateFactorial(int factorial)
        {
            if (factorial <= 1)
            {
                return 1;
            }

            return factorial * CalculateFactorial(factorial - 1);
        }
    }
}
