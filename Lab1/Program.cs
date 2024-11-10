using Lab1.Labs;
using Lab1.Service;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstLab firstLab = new FirstLab();

            string inputPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Read.txt"));
            string outputPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Write.txt"));
            
            firstLab.RunLab(inputPath, outputPath);
        }
    }
}
