namespace KnightsTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Cell
        {
            public Cell(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; set; }

            public int Col { get; set; }

            public bool IsVisited { get; set; }

            public int Value { get; set; }
        }

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var board = new List<Cell>();
            var value = 1;

            InitBoard(n,board);
            board[0].Value = value;
            board[0].IsVisited = true;
            Cell lastVisitedCell = board[0];
            value++;

            while (value < n * n)
            {
                lastVisitedCell = VisitCell(board, lastVisitedCell, value++);

                lastVisitedCell.IsVisited = true;
                lastVisitedCell.Value = value;
            }

            Print(board,n);
        }

        private static void Print(List<Cell> board, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(board[i * n + j].Value.ToString().PadLeft(3) + " ");
                }
            }
        }

        private static Cell VisitCell(List<Cell> board, Cell lastVisitedCell, int value)
        {
            return GetAvailableMoves(board, lastVisitedCell)
                .Where(c => c != null && !c.IsVisited)
                .OrderBy(c => MovesCount(c, board))
                .FirstOrDefault();
        }

        private static List<Cell> GetAvailableMoves(List<Cell> board, Cell cell)
        {
            var row = cell.Row;
            var col = cell.Col;

            var topRight = board.FirstOrDefault(c => c.Row == row - 2 && c.Col == col + 1);
            var topLeft = board.FirstOrDefault(c => c.Row == row - 2 && c.Col == col - 1);
            var topMiddleLeft = board.FirstOrDefault(c => c.Row == row - 1 && c.Col == col - 2);
            var topMiddleRight = board.FirstOrDefault(c => c.Row == row - 1 && c.Col == col + 2);

            var bottomLeft = board.FirstOrDefault(c => c.Row == row + 2 && c.Col == col - 1);
            var bottomRight = board.FirstOrDefault(c => c.Row == row + 2 && c.Col == col + 1);
            var bottomMiddleRight = board.FirstOrDefault(c => c.Row == row + 1 && c.Col == col + 2);
            var bottomMiddleLeft = board.FirstOrDefault(c => c.Row == row + 1 && c.Col == col - 2);

            var result = new List<Cell>()
            {
                topLeft,
                topRight,
                topMiddleLeft,
                topMiddleRight,
                bottomMiddleRight,
                bottomMiddleLeft,
                bottomLeft,
                bottomRight
            };

            return result;
        }

        private static int MovesCount(Cell cell, List<Cell> board) => GetAvailableMoves(board, cell).Count(c => c != null && !c.IsVisited);

        private static void InitBoard(int n, List<Cell> board)
        {
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    board.Add(new Cell(r,c));
                }
            }
        }
    }
}
