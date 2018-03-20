namespace AllPathsInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var labyrinth = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                labyrinth[i] = Console.ReadLine().ToCharArray();
            }

            var path = new List<char>();

            FindPaths(0, 0, labyrinth, path,' ');
        }

        private static void FindPaths(int row, int col, char[][] labyrinth, List<char> path, char direction)
        {
            if (!IsInDimensions(row,col,labyrinth))
            {
                return;
            }

            path.Add(direction);

            if (IsPath(row,col,labyrinth))
            {
                Print(path);
            }
            else if (!IsVisited(row,col,labyrinth) && IsFree(row,col,labyrinth))
            {
                Mark(row, col, labyrinth);
                FindPaths(row, col+1, labyrinth, path, 'R');
                FindPaths(row +1, col, labyrinth, path, 'D');
                FindPaths(row, col-1, labyrinth, path, 'L');
                FindPaths(row-1, col, labyrinth, path, 'U');
                Unmark(row, col, labyrinth);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void Print(List<char> path)
        {
            Console.WriteLine(string.Join("",path).Trim());
        }

        private static void Unmark(int row, int col, char[][] labyrinth)
        {
            labyrinth[row][col] = '-';
        }

        private static void Mark(int row, int col, char[][] labyrinth)
        {
            labyrinth[row][col] = 'x';
        }

        private static bool IsFree(int row, int col, char[][] labyrinth) => labyrinth[row][col] == '-';

        private static bool IsVisited(int row, int col, char[][] labyrinth) => labyrinth[row][col] == 'x';

        private static bool IsInDimensions(int row, int col, char[][] labyrinth)
        {
            if (row >= labyrinth.Length || col >= labyrinth[0].Length || row < 0 || col < 0)
            {
                return false;
            }

            return true;
        }

        private static bool IsPath(int row, int col, char[][] labyrinth) => labyrinth[row][col] == 'e';
    }
}
