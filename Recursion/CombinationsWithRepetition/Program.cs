namespace CombinationsWithRepetition
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var elementsCount = int.Parse(Console.ReadLine());
            var combinationsCount = int.Parse(Console.ReadLine());
            var result = new int[combinationsCount];

            Combine(elementsCount, 1, result, 0);
        }

        private static void Combine(int elementsCount, int element, int[] result, int index)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(" ",result));
            }
            else
            {
                for (int i = element; i <= elementsCount; i++)
                {
                    result[index] = i;
                    Combine(elementsCount,i, result, index+1);
                }
            }
        }
    }
}
