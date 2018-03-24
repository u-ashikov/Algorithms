namespace PermutationsWithRepetitions
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Permute(0, elements);
        }

        private static void Permute(int index, string[] elements)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ",elements));
            }
            else
            {
                HashSet<string> swapped = new HashSet<string>();

                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i, elements);
                        Permute(index + 1, elements);
                        Swap(index, i, elements);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        private static void Swap(int index, int i, string[] elements)
        {
            var temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }
    }
}
