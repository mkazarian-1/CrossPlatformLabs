using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Labs
{
    public class FirstLab
    {
        public int CalculateRookPlacements(int N, int K)
        {
            if (!Validate(N, K)) return 0;

            int factorialN = Factorial(N);
            int factorialK = Factorial(K);
            int factorialNK = Factorial(N - K);

            int accommodationNK = factorialN / factorialNK;

            return (accommodationNK * accommodationNK) / factorialK;
        }

        public (int N, int K) ParseNKValues(string[] lines)
        {
            string[] parts = lines[0].Split(' ');
            return (int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public bool ValidateInputForRooks(string[] input)
        {
            if (input.Length == 0)
            {
                Console.WriteLine("Input file is empty.");
                return false;
            }

            string[] parts = input[0].Split(' ');

            if (parts.Length != 2)
            {
                Console.WriteLine("Input file must contain exactly two space-separated values for N and K.");
                return false;
            }

            if (!int.TryParse(parts[0], out int N) || !int.TryParse(parts[1], out int K))
            {
                Console.WriteLine("The input contains invalid integer values for N or K.");
                return false;
            }
            return true;
        }


            private bool Validate(int N, int K)
        {
            if (N <= 0 || N > 8 || K <= 0 || K > 8)
            {
                Console.WriteLine("Invalid input. N and K must be natural numbers less than or equal to 8.");
                return false;
            }
            if (K > N)
            {
                Console.WriteLine("Invalid input. K cannot be greater than N.");
                return false;
            }
            return true;
        }

        private static int Factorial(int num)
        {
            int result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }



    }
}
