namespace BucketSorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class BucketSort
        {
            public static void Sort(int[] elements,int n)
            {
                var buckets = new List<int>[n];
                InitBuckets(buckets, n);

                for (int i = 0; i < n; i++)
                {
                    var bucketIndex = elements[i] / n;
                    buckets[bucketIndex].Add(elements[i]);
                }

                SortBuckets(buckets);
                ConcatBuckets(buckets, elements);
            }

            private static void ConcatBuckets(List<int>[] buckets, int[] elements)
            {
                int index = 0;
                for (int i = 0; i < buckets.Length; i++)
                {
                    if (index >= elements.Length)
                    {
                        break;
                    }

                    for (int p = 0; p < buckets[i].Count; p++)
                    {
                        elements[index++] = buckets[i][p];
                    }
                }
            }

            private static void SortBuckets(List<int>[] buckets)
            {
                for (int i = 0; i < buckets.Length; i++)
                {
                    var bucket = buckets[i];

                    for (int p = 0; p < bucket.Count; p++)
                    {
                        for (int j = p+1; j < bucket.Count; j++)
                        {
                            if (bucket[p].CompareTo(bucket[j]) > 0)
                            {
                                var temp = bucket[p];
                                bucket[p] = bucket[j];
                                bucket[j] = temp;
                            }
                        }
                    }
                }
            }

            private static void InitBuckets(List<int>[] buckets, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    buckets[i] = new List<int>();
                }
            }
        }

        public static void Main()
        {
            var elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            BucketSort.Sort(elements, elements.Length);
            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
