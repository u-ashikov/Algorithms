namespace CombinationsWithoutRepetitions
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var combinations = int.Parse(Console.ReadLine());
            var result = new string[combinations];

            Combine(elements, result, 0, 0);
        }

        private static void Combine(string[] elements, string[] result, int index, int start)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    result[index] = elements[i];
                    Combine(elements, result, index + 1, i+1);
                }
            }
        }
    }
}
