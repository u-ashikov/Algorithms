namespace MergeSorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var arr = new int[] { 5, 4, 3, 2, 1 };
            MergeSort<int>.Sort(arr);
        }
    }
}
