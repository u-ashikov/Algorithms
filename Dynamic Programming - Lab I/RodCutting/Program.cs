namespace RodCutting
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var prices = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var desiredLength = int.Parse(Console.ReadLine());
            var bestSolutions = new int[prices.Length];
            var bestCombo = new int[prices.Length];

            bestSolutions[0] = 0;
            bestSolutions[1] = 1;

            for (int current = 2; current <= desiredLength; current++)
            {
                var bestSolution = bestSolutions[current];

                for (int prev = 1; prev <= current; prev++)
                {
                    bestSolution = Math.Max(bestSolutions[current], prices[prev] + bestSolutions[current - prev]);

                    if (bestSolution > bestSolutions[current])
                    {
                        bestSolutions[current] = bestSolution;
                        bestCombo[current] = prev;
                    }
                }
            }

            ReconstructSolution(desiredLength,bestCombo, bestSolutions);
        }

        private static void ReconstructSolution(int desiredLength, int[] bestCombo, int[] bestSolutions)
        {
            Console.WriteLine(bestSolutions[desiredLength]);

            while (desiredLength - bestCombo[desiredLength] != 0)
            {
                Console.Write(bestCombo[desiredLength] + " ");
                desiredLength = desiredLength - bestCombo[desiredLength];
            }

            Console.WriteLine(bestCombo[desiredLength]);
        }
    }
}