namespace NestedLoops
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Nest(n, new int[n], 0);
        }

        private static void Nest(int n, int[] result, int index)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(" ",result));
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    result[index] = i;
                    Nest(n, result, index+1);
                }
            }
        }
    }
}
