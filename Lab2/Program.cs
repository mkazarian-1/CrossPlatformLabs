using Lab1.Service;
using Lab2.Lab;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SecondLab secondLab = new SecondLab();

            string inputPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Read.txt"));
            string outputPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Write.txt"));

            secondLab.RunLab(inputPath, outputPath);
        }
    }
}
