namespace VariationsWithRepetitions
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var variations = int.Parse(Console.ReadLine());
            var result = new string[variations];

            Variate(elements, result, variations, 0);
        }

        private static void Variate(string[] elements, string[] result, int variations, int index)
        {
            if (index >= variations)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    result[index] = elements[i];
                    Variate(elements, result, variations, index + 1);
                }
            }
        }
    }
}
