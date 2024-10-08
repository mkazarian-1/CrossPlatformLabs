using Lab1.Labs;
using Lab1.Service;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstLab firstLab = new FirstLab();
            FileReader fileReader = new FileReader();
            FileWriter fileWriter = new FileWriter();

            string readPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Read.txt"));
            string writePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Write.txt"));

            int N, K;
            string[] input = fileReader.ReadFile(readPath);

            Console.WriteLine($"Input: {readPath}");
            Console.WriteLine(string.Join(Environment.NewLine, input));
            Console.WriteLine();

            if (!firstLab.ValidateInputForRooks(input)) return;

            (N, K) = firstLab.ParseNKValues(fileReader.ReadFile(readPath));

            int res = firstLab.CalculateRookPlacements(N, K);

            Console.WriteLine($"N={N},K={K}, res = {res}\n");

            Console.WriteLine($"Write: {writePath}");
            Console.WriteLine(res);
            Console.WriteLine($"\n");

            fileWriter.WriteResult(writePath, res.ToString());
        }
    }
}
