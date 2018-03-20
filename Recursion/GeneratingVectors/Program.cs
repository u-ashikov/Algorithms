namespace GeneratingVectors
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var vectorSize = int.Parse(Console.ReadLine());
            var vector = new int[vectorSize];

            GenerateVector(vector, 0);
        }

        private static void GenerateVector(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("",vector));
            }
            else
            {
                for (int p = 0; p < 2; p++)
                {
                    vector[index] = p;
                    GenerateVector(vector, index + 1);
                }
            }
        }
    }
}
