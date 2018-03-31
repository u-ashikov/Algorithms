namespace QuickSortImplementation
{
    using System;
    using System.Linq;

    public class Program
    {
        public class QuickSort<T> where T : IComparable
        {
            public static void Sort(T[] elements, int start, int end)
            {
                if (start >= end)
                {
                    return;
                }

                int pivotIndex = Partition(elements, start, end);

                Sort(elements, start, pivotIndex-1);
                Sort(elements, pivotIndex + 1, end);
            }

            private static int Partition(T[] elements, int start, int end)
            {
                if (start >= end)
                {
                    return start;
                }

                int i = start;
                int j = end + 1;

                while (true)
                {
                    while (IsLess(elements[++i], elements[start]))
                    {
                        if (i == end)
                        {
                            break;
                        }
                    }

                    while (IsLess(elements[start], elements[--j]))
                    {
                        if (j == start)
                        {
                            break;
                        }
                    }

                    if (i >= j)
                    {
                        break;
                    }

                    Swap(elements, i, j);
                }

                Swap(elements, start, j);
                return j;
            }

            private static void Swap(T[] elements, int i, int j)
            {
                var temp = elements[i];
                elements[i] = elements[j];
                elements[j] = temp;
            }

            private static bool IsLess(T next, T current) => next.CompareTo(current) < 0;
        }

        public static void Main()
        {
            var elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            QuickSort<int>.Sort(elements,0,elements.Length-1);
            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
