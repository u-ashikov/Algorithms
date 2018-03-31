namespace FibonacciSearching
{
    using System;
    using System.Linq;

    public class Program
    {
        public class FibonacciSearch<T> where T:IComparable
        {
            public static int Search(T[] elements, T targetElement, int arrayLength)
            {
                /* Initialize fibonacci numbers */
                int fibMMm2 = 0;   // (m-2)'th Fibonacci No.
                int fibMMm1 = 1;   // (m-1)'th Fibonacci No.
                int fibM = fibMMm2 + fibMMm1;  // m'th Fibonacci

                /* fibM is going to store the smallest Fibonacci
                   Number greater than or equal to array length */
                while (fibM < arrayLength)
                {
                    fibMMm2 = fibMMm1;
                    fibMMm1 = fibM;
                    fibM = fibMMm2 + fibMMm1;
                }

                // Marks the eliminated range from front
                int offset = -1;

                /* while there are elements to be inspected. Note that
                   we compare arr[fibMm2] with x. When fibM becomes 1,
                   fibMm2 becomes 0 */
                while (fibM > 1)
                {
                    // Check if fibMm2 is a valid location
                    int i = Min(offset + fibMMm2, arrayLength - 1);

                    /* If x is greater than the value at index fibMm2,
                       cut the subarray array from offset to i */
                    if (elements[i].CompareTo(targetElement) < 0)
                    {
                        fibM = fibMMm1;
                        fibMMm1 = fibMMm2;
                        fibMMm2 = fibM - fibMMm1;
                        offset = i;
                    }

                    /* If x is greater than the value at index fibMm2,
                       cut the subarray after i+1  */
                    else if (elements[i].CompareTo(targetElement) > 0)
                    {
                        fibM = fibMMm2;
                        fibMMm1 = fibMMm1 - fibMMm2;
                        fibMMm2 = fibM - fibMMm1;
                    }

                    /* element found. return index */
                    else return i;
                }

                /* comparing the last element with x */
                if (elements[offset + 1].CompareTo(targetElement) == 0) return offset + 1;

                /*element not found. return -1 */
                return -1;
            }

            private static int Min(int x, int y) => x <= y ? x : y;
        }

        public static void Main(string[] args)
        {
            var elements = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var targetElement = int.Parse(Console.ReadLine());
            Console.WriteLine(FibonacciSearch<int>.Search(elements,targetElement,elements.Length));
        }
    }
}
