namespace GeneratingCombinations
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var combinations = int.Parse(Console.ReadLine());
            var result = new int[combinations];

            Combine(arr, result, 0, 0);
        }

        private static void Combine(int[] arr, int[] result, int index, int border)
        {
            if (index == result.Length)
            {
                Console.WriteLine(string.Join(" ",result));
            }
            else
            {
                for (int i = border; i < arr.Length; i++)
                {
                    result[index] = arr[i];
                    Combine(arr, result, index + 1, i + 1);
                }
            }
        }
    }
}
