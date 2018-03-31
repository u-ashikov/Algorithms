namespace LinearSearching
{
    using System;
    using System.Linq;

    public class Program
    {
        public class LinearSearch<T> where T:IComparable
        {
            public static int Search(T[] elements, T targetElement, int index)
            {
                if (index >= elements.Length)
                {
                    return -1;
                }

                if (elements[index].CompareTo(targetElement) == 0)
                {
                    return index;
                }

                return Search(elements, targetElement, index + 1);
            }
        }

        public static void Main()
        {
            var elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var targetElement = int.Parse(Console.ReadLine());
            Console.WriteLine(LinearSearch<int>.Search(elements, targetElement, 0));
        }
    }
}
