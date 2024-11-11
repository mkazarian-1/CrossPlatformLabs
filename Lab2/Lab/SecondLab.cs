using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Service;

namespace Lab2.Lab
{
    public class SecondLab
    {
        private readonly FileReader _fileReader = new();
        private readonly FileWriter _fileWriter = new();
        
        public void RunLab(string inputPath, string outputPath)
        {
            int N;
            int[,] grid;
            char[,] result;

            string[] input = _fileReader.ReadFile(inputPath);

            Console.WriteLine($"Input: {inputPath}");
            Console.WriteLine(string.Join(Environment.NewLine, input));
            Console.WriteLine();

            if (!ValidateInputForMinPath(input)) return;

            (N, grid) = Parser(input);

            result = Solve(N,grid);
            string res = ResultFormation(result);

            Console.WriteLine($"Write: {outputPath}");
            Console.WriteLine(res);
            Console.WriteLine($"\n");

            _fileWriter.WriteResult(outputPath, res.ToString());
        }
        
        public bool ValidateInputForMinPath(string[] input)
        {
            if (!int.TryParse(input[0], out int n) || n < 2 || n > 250)
            {
                Console.WriteLine("N must be an integer between 2 and 250.");
                return false;
            }

            if (input.Length != n + 1)
            {
                Console.WriteLine("Input does not contain the correct number of rows.");
                return false;
            }

            for (int i = 1; i <= n; i++)
            {
                if (input[i].Length != n)
                {
                    Console.WriteLine($"Row {i} does not have the correct number of characters (expected {n}).");
                    return false;
                }

                foreach (char cell in input[i])
                {
                    if (!char.IsDigit(cell))
                    {
                        Console.WriteLine($"Invalid character '{cell}' in row {i}. Allowed characters are digits from 0 to 9.");
                        return false;
                    }
                }
            }

            return true;
        }


        public char[,] Solve(int N, int[,] grid)
        {
            int[,] dp = new int[N, N];
            dp[0, 0] = grid[0, 0];

            for (int i = 1; i < N; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + grid[i, 0];
                dp[0, i] = dp[0, i - 1] + grid[0, i];
            }

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i, j];
                }
            }

            char[,] result = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    result[i, j] = '.';
                }
            }

            int x = N - 1;
            int y = N - 1;
            result[x, y] = '#';

            while (x > 0 || y > 0)
            {
                if (x == 0)
                {
                    y--;
                }
                else if (y == 0)
                {
                    x--;
                }
                else if (dp[x - 1, y] < dp[x, y - 1])
                {
                    x--;
                }
                else
                {
                    y--;
                }
                result[x, y] = '#';
            }

            return result;
        }

        public (int N, int[,] grid) Parser(string[] input)
        {
            int N = int.Parse(input[0]);
            int[,] grid = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    grid[i, j] = input[i + 1][j] - '0';
                }
            }

            return (N, grid);
        }

        public string ResultFormation(char[,] chars)
        {
            int N = chars.GetLength(0);
            var output = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    output.Append(chars[i, j]);
                }
                output.AppendLine();
            }

            return output.ToString();
        }
    }
}
