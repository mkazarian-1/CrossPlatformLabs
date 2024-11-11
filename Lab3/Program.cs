using Lab1.Service;
using Lab3.Lab;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThirdLab thirdLab = new ThirdLab();

            string inputPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Read.txt"));
            string outputPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Write.txt"));

            thirdLab.RunLab(inputPath, outputPath);
        }
    }
}
