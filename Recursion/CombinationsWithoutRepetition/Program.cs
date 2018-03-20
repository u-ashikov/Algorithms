namespace CombinationsWithoutRepetition
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numbersCount = int.Parse(Console.ReadLine());
            var combinations = int.Parse(Console.ReadLine());
            var result = new int[combinations];

            Combine(numbersCount, 0,result,1);
        }

        private static void Combine(int numbersCount, int index, int[] result, int element)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(" ",result));
            }
            else
            {
                for (int i = element; i <= numbersCount; i++)
                {
                    result[index] = i;
                    Combine(numbersCount, index+1, result, i+1);
                }
            }
        }
    }
}
