using CrossPlatformLabs.Labs;

namespace CrossPlatformLabs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstLab lab1 = new FirstLab();

            Console.WriteLine(lab1.CalculateRookPlacements(8, 7));
        }
    }
}
