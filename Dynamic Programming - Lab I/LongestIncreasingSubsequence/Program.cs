namespace LongestIncreasingSubsequence
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var bestSolutions = new int[numbers.Length];
            bestSolutions[numbers.Length - 1] = 1;
            int bestStart = 0;
            int maxSolution = int.MinValue;

            for (int i = numbers.Length-2; i >= 0; i--)
            {
                var currentNum = numbers[i];
                var bestSolution = bestSolutions[i];

                for (int p = i+1; p < numbers.Length; p++)
                {
                    var nextNum = numbers[p];

                    if (currentNum < nextNum)
                    {
                        var currentBest = bestSolutions[p];

                        if (currentBest > bestSolution)
                        {
                            bestSolution = currentBest;
                        }
                    }
                }

                if (bestSolution + 1 >= maxSolution)
                {
                    maxSolution = bestSolution + 1;
                    bestStart = i;
                }

                bestSolutions[i] = bestSolution+1;
            }

            for (int i = bestStart; i < bestSolutions.Length; i++)
            {
                if (bestSolutions[i] == maxSolution)
                {
                    Console.Write(numbers[i] + " ");
                    maxSolution--;
                }
            }
            Console.WriteLine();
        }
    }
}
