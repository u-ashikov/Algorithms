namespace VariationsWithoutRepetition
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var variations = int.Parse(Console.ReadLine());
            var result = new string[variations];
            var used = new bool[elements.Length];

            Variate(elements, result, variations, used, 0);
        }

        private static void Variate(string[] elements, string[] result, int variations, bool[] used, int index)
        {
            if (index >= variations)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        result[index] = elements[i];
                        Variate(elements, result, variations, used, index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
