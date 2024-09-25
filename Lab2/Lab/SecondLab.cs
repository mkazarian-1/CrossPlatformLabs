using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Lab
{
    public class SecondLab
    {
        public char[,] Solve(int N, int[,] grid)
        {
            if (!this.ValidateInput(N,grid))
            {
                Console.WriteLine("Error: Invalid input data.");
                return new char[0,0];
            }

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
        private bool ValidateInput(int N, int[,] grid)
        {

            if (N < 2 || N > 250)
            {
                return false;
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (grid[i, j] < -1 || grid[i, j] > 10)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
    

}
