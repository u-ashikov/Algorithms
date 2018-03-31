namespace Needles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] info = ParseNums();

            var numsCount = info[0];
            var needlesCount = info[1];

            var nums = ParseNums();
            var needles = ParseNums();

            var result = new List<int>();

            foreach (var needle in needles)
            {
                FindPlace(nums, needle, result);
            }
        }

        private static void FindPlace(int[] nums, int needle, List<int> result)
        {
            int start = 0;
            int end = nums.Length - 1;
            int index = 0;

            while (start <= end)
            {
                index = start + (end - start) / 2;

                var current = nums[index];

                if (current > needle)
                {
                    end = index - 1;
                }
                else if (current < needle)
                {
                    start = index + 1;
                }
            }

            Console.WriteLine();
        }

        private static int[] ParseNums()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
