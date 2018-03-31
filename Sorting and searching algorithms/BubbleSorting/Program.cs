namespace BubbleSorting
{
    using System;
    using System.Linq;

    public class Program
    {
        public class BubbleSort<T> where T : IComparable
        {
            public static void Sort(T[] elements, int n)
            {
                if (n == 1)
                {
                    return;
                }

                for (int i = 0; i < n-1; i++)
                {
                    if (elements[i].CompareTo(elements[i+1]) > 0)
                    {
                        Swap(elements, i, i + 1);
                    }
                }

                Sort(elements, n - 1);
            }

            private static void Swap(T[] elements, int i, int p)
            {
                var temp = elements[i];
                elements[i] = elements[p];
                elements[p] = temp;
            }
        }

        public static void Main()
        {
            var elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            BubbleSort<int>.Sort(elements,elements.Length);
            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
