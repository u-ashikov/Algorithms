namespace QuickSorting
{
    using System;

    public class Program
    {
        public class QuickSort<T> where T:IComparable
        {
            public static void Sort(T[] elements, int start, int end)
            {
                if (start >= end)
                {
                    return;
                }

                int pivotIndex = Partition(elements, start, end);

                Sort(elements,start,pivotIndex-1);
                Sort(elements,pivotIndex+1,end);
            }

            private static int Partition(T[] elements, int start, int end)
            {
                if (start >= end)
                {
                    return start;
                }

                int i = start;
                int j = end+1;

                while (true)
                {
                    // next element < start element
                    while (IsLess(elements[++i],elements[start]))
                    {
                        if (i == end)
                        {
                            break;
                        }
                    }

                    // start element < last element --
                    while (IsLess(elements[start],elements[--j]))
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

            private static bool IsLess(T next, T current)
            {
                return next.CompareTo(current) < 0;
            }

            private static void Swap(T[] elements, int nextIndex, int pivotIndex)
            {
                var temp = elements[pivotIndex];
                elements[pivotIndex] = elements[nextIndex];
                elements[nextIndex] = temp;
            }
        }

        public static void Main()
        {
            var elements = new int[] { 5, 4, 3, 2, 1 };
            QuickSort<int>.Sort(elements,0,elements.Length-1);
        }
    }
}
