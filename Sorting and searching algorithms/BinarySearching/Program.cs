namespace BinarySearching
{
    using System;

    public class Program
    {
        public class BinarySearch<T> where T:IComparable
        {
            public static int IndexOf(T[] elements, T targetElement)
            {
                int start = 0;
                int end = elements.Length - 1;

                while (start <= end)
                {
                    int index = start + (end-start) / 2;

                    var current = elements[index];

                    if (current.CompareTo(targetElement) < 0)
                    {
                        start = index + 1;
                    }
                    else if (current.CompareTo(targetElement) > 0)
                    {
                        end = index - 1;
                    }
                    else
                    {
                        return index;
                    }
                }

                return -1;
            }
        }

        public static void Main()
        {
            var elements = new int[] { 1, 2, 3, 4, 5 };
            var targetElement = 5;
            var indexOf = BinarySearch<int>.IndexOf(elements, targetElement);

            Console.WriteLine($"Index of {targetElement} is {indexOf}");
        }
    }
}
