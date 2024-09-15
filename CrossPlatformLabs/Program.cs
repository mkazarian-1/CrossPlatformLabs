using CrossPlatformLabs.Labs;
using CrossPlatformLabs.Service;

namespace CrossPlatformLabs
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
                
            (N,K)= firstLab.ParseNKValues(fileReader.ReadFile(readPath));

            int res = firstLab.CalculateRookPlacements(N, K);

            Console.WriteLine($"N={N},K={K}, res = {res}");

            fileWriter.WriteResult(writePath, res.ToString());
        }
    }
}
