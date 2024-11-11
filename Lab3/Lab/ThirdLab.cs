using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Service;

namespace Lab3.Lab
{
    public class ThirdLab
    {
        static readonly int[] dx = { 2, 2, 1, 1, -1, -1, -2, -2 };
        static readonly int[] dy = { 1, -1, 2, -2, 2, -2, 1, -1 };

        private readonly FileReader _fileReader = new();
        private readonly FileWriter _fileWriter = new();

        public void RunLab(string inputPath, string outputPath)
        {
            string[] input = _fileReader.ReadFile(inputPath);

            Console.WriteLine($"Input: {inputPath}");
            Console.WriteLine(string.Join(Environment.NewLine, input));
            Console.WriteLine();

            if (!ValidateInput(input)) return;

            int n;
            char[,] board;
            (int, int) start, end;
            (n, board, start, end) = ParseInput(input);

            char[,]? newBoard = BFS(board, start, end, n);

            if (newBoard == null)
            {
                Console.WriteLine($"Write: {outputPath}");
                Console.WriteLine("Impossible");
                Console.WriteLine();
                _fileWriter.WriteResult(outputPath, "Impossible");
            }
            else
            {
                Console.WriteLine($"Write: {outputPath}");

                string res = FormatBoardToString(n, newBoard);

                Console.WriteLine(res);
                Console.WriteLine();
                _fileWriter.WriteResult(outputPath, res);
            }
            Console.WriteLine();
        }

        public bool ValidateInput(string[] input)
        {
            if (!int.TryParse(input[0], out int n) || n < 2 || n > 50)
            {
                Console.WriteLine("N must be an integer between 2 and 50.");
                return false;
            }

            if (input.Length != n + 1)
            {
                Console.WriteLine("Input does not contain the correct number of rows.");
                return false;
            }

            int atCount = 0;
            for (int i = 1; i <= n; i++)
            {
                if (input[i].Length != n)
                {
                    Console.WriteLine($"Row {i} does not have the correct number of characters (expected {n}).");
                    return false;
                }

                foreach (char cell in input[i])
                {
                    if (cell != '.' && cell != '#' && cell != '@')
                    {
                        Console.WriteLine($"Invalid character '{cell}' in row {i}. Allowed characters are '.', '#', and '@'.");
                        return false;
                    }

                    if (cell == '@')
                    {
                        atCount++;
                    }
                }
            }
            if (atCount != 2)
            {
                Console.WriteLine($"There must be exactly two '@' symbols on the board. Found {atCount}.");
                return false;
            }
            return true;
        }


        public char[,]? BFS(char[,] board, (int, int) start, (int, int) end, int n)
        {
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int[,] dist = new int[n, n];
            (int, int)[,] prev = new (int, int)[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dist[i, j] = -1;

            queue.Enqueue(start);
            dist[start.Item1, start.Item2] = 0;

            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();

                if ((x, y) == end)
                {
                    // Відновлення шляху
                    return MarkPath(board, prev, start, end);
                }

                for (int i = 0; i < 8; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (nx >= 0 && ny >= 0 && nx < n && ny < n && board[nx, ny] != '#' && dist[nx, ny] == -1)
                    {
                        dist[nx, ny] = dist[x, y] + 1;
                        prev[nx, ny] = (x, y);
                        queue.Enqueue((nx, ny));

                        board[nx, ny] = '@';
                        PrintBoard(board, n);
                        board[nx, ny] = '.';
                    }
                }
            }

            return null;
        }

        public (int n, char[,] board, (int, int) start, (int, int) end) ParseInput(string[] input)
        {
            int n = int.Parse(input[0]);
            char[,] board = new char[n, n];
            (int, int) start = (-1, -1), end = (-1, -1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = input[i + 1][j];
                    if (board[i, j] == '@')
                    {
                        if (start == (-1, -1))
                            start = (i, j);
                        else
                            end = (i, j);
                    }
                }
            }

            return (n, board, start, end);
        }
        public string FormatBoardToString(int n, char[,] board)
        {
            string[] output = new string[n];

            for (int i = 0; i < n; i++)
            {
                char[] row = new char[n];
                for (int j = 0; j < n; j++)
                {
                    row[j] = board[i, j];
                }
                output[i] = new string(row);
            }

            return string.Join(Environment.NewLine, output);
        }

        private char[,] MarkPath(char[,] board, (int, int)[,] prev, (int, int) start, (int, int) end)
        {
            int n = board.GetLength(0);
            char[,] newBoard = new char[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    newBoard[i, j] = board[i, j];

            (int x, int y) = end;
            while ((x, y) != start)
            {
                newBoard[x, y] = '@';
                (x, y) = prev[x, y];
            }
            newBoard[start.Item1, start.Item2] = '@';


            return newBoard;
        }

        private void PrintBoard(char[,] board, int n)
        {
            Console.WriteLine("Current board state:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
