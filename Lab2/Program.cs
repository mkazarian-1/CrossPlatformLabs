using Lab1.Service;
using Lab2.Lab;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SecondLab secondLab = new SecondLab();
            FileReader fileReader = new FileReader();
            FileWriter fileWriter = new FileWriter();

            string readPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Read.txt"));
            string writePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Write.txt"));

            int N;
            int[,] grid;
            char[,] result;

            string[] input = fileReader.ReadFile(readPath);
            (N, grid) = secondLab.Parser(fileReader.ReadFile(readPath));

            Console.WriteLine($"Input: {readPath}");
            Console.WriteLine(string.Join(Environment.NewLine, input));
            Console.WriteLine();

            result = secondLab.Solve(N,grid);
            string res = secondLab.ResultFormation(result);

            Console.WriteLine($"Write: {writePath}");
            Console.WriteLine(res);
            Console.WriteLine($"\n");

            fileWriter.WriteResult(writePath, res.ToString());
        }
    }
}
