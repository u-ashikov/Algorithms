namespace BinarySearching
{
    using System;
    using System.Linq;

    public class Program
    {
        public class BinarySearch<T> where T:IComparable
        {
            public static int Search(T[] elements, T targetElement)
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
            var elements = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var targetElement = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch<int>.Search(elements, targetElement));
        }
    }
}
