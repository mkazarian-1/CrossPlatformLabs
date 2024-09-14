using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformLabs.Labs
{
    public class FirstLab
    {
        public long CalculateRookPlacements(int N, int K)
        {
            if (!Validate(N, K)) return 0;

            long factorialN = Factorial(N);
            long factorialK = Factorial(K);
            long factorialNK = Factorial(N - K);

            long accommodationNK = factorialN / factorialNK;

            return (accommodationNK * accommodationNK) / factorialK;
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

        private static long Factorial(int num)
        {
            long result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
