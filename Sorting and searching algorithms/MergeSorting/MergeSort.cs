namespace MergeSorting
{
    using System;

    public class MergeSort<T> where T : IComparable
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Merge(T[] arr, int start, int mid, int end)
        {
            if (IsLess(arr[mid],arr[mid+1]))
            {
                return;
            }

            for (int index = start; index < end + 1; index++)
            {
                aux[index] = arr[index];
            }

            int i = start;
            int j = mid + 1;

            for (int k = start; k <= end; k++)
            {
                if (i > mid)
                {
                    arr[k] = aux[j++];
                }
                else if (j > end)
                {
                    arr[k] = aux[i++];
                }
                else if (IsLess(aux[i],aux[j]))
                {
                    arr[k] = aux[i++];
                }
                else
                {
                    arr[k] = aux[j++];
                }
            }
        }

        private static bool IsLess(T maxLeftArrElement, T minRightArrElement)
        {
            return maxLeftArrElement.CompareTo(minRightArrElement) < 0;
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            var mid = lo + (hi-lo) / 2;

            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            Merge(arr, lo, mid, hi);
        }
    }
}
