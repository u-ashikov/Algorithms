namespace ReverseArray
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Reverse(arr, 0);

            Console.WriteLine(string.Join(" ",arr));
        }

        private static void Reverse(int[] arr, int index)
        {
            if (index >= arr.Length / 2)
            {
                return;
            }

            Swap(arr, index);

            Reverse(arr, index + 1);
        }

        private static void Swap(int[] arr, int index)
        {
            int temp = arr[index];

            arr[index] = arr[arr.Length - 1 - index];
            arr[arr.Length - 1 - index] = temp;
        }
    }
}
