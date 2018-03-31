namespace ShellSorting
{
    using System;
    using System.Linq;

    public class Program
    {
        public class ShellSort<T> where T : IComparable
        {
            public static void Sort(T[] elements, int n)
            {
                for (int gap = n/2; gap > 0; gap /= 2)
                {
                    for (int i = gap; i < n; i++)
                    {
                        var temp = elements[i];
                        int j;

                        for (j = i; j >= gap && elements[j - gap].CompareTo(temp) > 0; j -= gap)
                        {
                            elements[j] = elements[j - gap];
                            elements[j] = temp;
                        }
                    }
                }
            }
        }

        public static void Main()
        {
            var elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ShellSort<int>.Sort(elements, elements.Length);
            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
