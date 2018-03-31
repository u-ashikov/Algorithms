namespace EgyptianFractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            var targetSum = input[0];
            var target = input[0];
            var fraction = input[1];
            var result = new List<string>();

            if (target > fraction)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
            }
            else
            {
                while (target > 0)
                {
                    var remainder = Math.Round(fraction / target, 2);

                    result.Add($"1/{Math.Ceiling(remainder)}");
                    target -= (fraction / Math.Ceiling(remainder));
                }
                Console.WriteLine($"{targetSum}/{fraction} = {string.Join(" + ", result)}");
            }
        }
    }
}
