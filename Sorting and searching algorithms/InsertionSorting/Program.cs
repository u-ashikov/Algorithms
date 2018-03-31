namespace InsertionSorting
{
    using System;
    using System.Linq;

    public class Program
    {
        public class InsertionSort<T> where T:IComparable
        {
            public static void Sort(T[] elements)
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    for (int p = i+1; p < elements.Length; p++)
                    {
                        if (elements[i].CompareTo(elements[p]) > 0)
                        {
                            Swap(elements, i, p);
                        }
                    }
                }
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

            InsertionSort<int>.Sort(elements);

            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
