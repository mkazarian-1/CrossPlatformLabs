using Lab1.Labs;
using Lab2.Lab;
using Lab3.Lab;

namespace LabLibrary;

public static class Lab1Lab
{
    private static FirstLab _firstLab = new FirstLab();
    
    public static string Run(string[] input)
    {
        if (!_firstLab.ValidateInputForRooks(input)) return "The data entered is incorrect. Try again!";

        int N, K;
        (N, K) = _firstLab.ParseNKValues(input);

        int res = _firstLab.CalculateRookPlacements(N, K);

        return res.ToString();
    }
}

public static class Lab2Lab
{
    private static SecondLab _secondLab = new SecondLab();
    
    public static string Run(string[] input)
    {
        int N;
        int[,] grid;
        char[,] result;

        if (!_secondLab.ValidateInputForMinPath(input)) return "The data entered is incorrect. Try again!";

        (N, grid) = _secondLab.Parser(input);

        result = _secondLab.Solve(N,grid);
        
        return _secondLab.ResultFormation(result);
    }
}

public static class Lab3Lab
{
    private static ThirdLab _thirdLab = new ThirdLab();
    
    public static string Run(string[] input)
    {
        if (!_thirdLab.ValidateInput(input)) return "The data entered is incorrect. Try again!";

        int n;
        char[,] board;
        (int, int) start, end;
        (n, board, start, end) = _thirdLab.ParseInput(input);

        char[,]? newBoard = _thirdLab.BFS(board, start, end, n);

        if (newBoard == null)
        {
            return "Impossible";
        }

        return _thirdLab.FormatBoardToString(n, newBoard);
    }
}