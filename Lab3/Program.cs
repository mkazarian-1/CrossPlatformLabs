using Lab1.Service;
using Lab3.Lab;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ThirdLab thirdLab = new ThirdLab();
            FileReader fileReader = new FileReader();
            FileWriter fileWriter = new FileWriter();

            string readPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Read.txt"));
            string writePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\Write.txt"));


            string[] input = fileReader.ReadFile(readPath);

            Console.WriteLine($"Input: {readPath}");
            Console.WriteLine(string.Join(Environment.NewLine, input));
            Console.WriteLine();

            if (!thirdLab.ValidateInput(input)) return;

            int n;
            char[,] board;
            (int, int) start, end;
            (n, board, start, end) = thirdLab.ParseInput(input);

            char[,] newBoard = thirdLab.BFS(board, start, end, n);

            if (newBoard == null)
            {
                Console.WriteLine($"Write: {writePath}");
                Console.WriteLine("Impossible");
                Console.WriteLine();
                fileWriter.WriteResult(writePath, "Impossible");
            }
            else
            {
                Console.WriteLine($"Write: {writePath}");

                string res = thirdLab.FormatBoardToString(n, newBoard);

                Console.WriteLine(res);
                Console.WriteLine();
                fileWriter.WriteResult(writePath, res);
            }
            Console.WriteLine();
        }
    }
}
