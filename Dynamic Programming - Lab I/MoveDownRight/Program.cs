namespace MoveDownRight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new long[rows][];
            var result = new List<string>();
            InitMatrix(matrix,rows,cols);

            var dpMatrix = new long[rows][];
            BuildDPMatrix(matrix, dpMatrix);

            FindPath(dpMatrix, result);
            result.Reverse();
            Console.WriteLine(string.Join(" ",result));
        }

        private static void BuildDPMatrix(long[][] matrix, long[][] dpMatrix)
        {
            FillFirstRow(matrix, dpMatrix);
            FillFirstCol(matrix, dpMatrix);

            for (int r = 1; r < matrix.Length; r++)
            {
                for (int c = 1; c < matrix[0].Length; c++)
                {
                    dpMatrix[r][c] = matrix[r][c] + Math.Max(dpMatrix[r - 1][c], dpMatrix[r][c - 1]);
                }
            }
        }

        private static void FillFirstCol(long[][] matrix, long[][] dpMatrix)
        {
            for (int r = 1; r < matrix.Length; r++)
            {
                dpMatrix[r] = new long[matrix[0].Length];
                dpMatrix[r][0] = dpMatrix[r - 1][0] + matrix[r][0];
            }
        }

        private static void FillFirstRow(long[][] matrix, long[][] dpMatrix)
        {
            dpMatrix[0] = new long[matrix[0].Length];
            dpMatrix[0][0] = matrix[0][0];

            for (int c = 1; c < matrix[0].Length; c++)
            {
                dpMatrix[0][c] = dpMatrix[0][c - 1] + matrix[0][c];
            }
        }

        private static void FindPath(long[][] matrix, List<string> result)
        {
            var row = matrix.Length-1;
            var col = matrix[0].Length-1;

            result.Add($"[{row}, {col}]");

            while (row != 0 || col != 0)
            {
                long up = CalculateUp(matrix,row-1,col);
                long left = CalculateLeft(matrix,row,col-1);

                if (up > left)
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }

                result.Add($"[{row}, {col}]");
            }
        }

        private static long CalculateLeft(long[][] matrix, int row, int col)
        {
            if (col < 0)
            {
                return long.MinValue;
            }

            return matrix[row][col];
        }

        private static long CalculateUp(long[][] matrix, int row, int col)
        {
            if (row < 0)
            {
                return long.MinValue;
            }

            return matrix[row][col];
        }

        private static void InitMatrix(long[][] matrix, int rows, int cols)
        {
            for (int r = 0; r < rows; r++)
            {
                matrix[r] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }
        }
    }
}