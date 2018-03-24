namespace PermutationsWithoutRepetitions
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Permute(0,elements);
        }

        private static void Permute(int index, string[] elements)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ",elements));
            }
            else
            {
                Permute(index + 1, elements);

                for (int i = index; i < elements.Length; i++)
                {
                    Swap(index, i, elements);
                    Permute(index + 1, elements);
                    Swap(index, i, elements);
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
