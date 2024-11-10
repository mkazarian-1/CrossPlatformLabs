using McMaster.Extensions.CommandLineUtils;
using System;
using Lab1.Labs;
using Lab2.Lab;
using Lab3.Lab;

namespace Lab4;

[Command(Name = "Lab4", Description = "A tool for running labs.")]
[Subcommand(typeof(VersionCommand), typeof(RunCommand), typeof(SetPathCommand))]
class Program
{
    static int Main(string[] args)
    {
        var app = new CommandLineApplication<Program>();
        app.Conventions.UseDefaultConventions();
        app.OnExecute(() =>
        {
            app.ShowHelp();
            return 1;
        });
        app.UnrecognizedArgumentHandling = UnrecognizedArgumentHandling.StopParsingAndCollect;

        return app.Execute(args);
    }
}

[Command(Name = "version", Description = "Displays the program version and author.")]
class VersionCommand
{
    private int OnExecute()
    {
        Console.WriteLine("Author: Mykhailo Kazarian");
        Console.WriteLine("Version: 1.0.0");
        return 0;
    }
}

[Command(Name = "run", Description = "Runs the specified lab.")]
[Subcommand(typeof(Lab1Command), typeof(Lab2Command), typeof(Lab3Command))]
class RunCommand
{
    private int OnExecute(CommandLineApplication app)
    {
        Console.WriteLine("Please specify a lab to run (lab1, lab2, lab3).");
        app.ShowHelp();
        return 1;
    }
}

[Command(Name = "set-path", Description = "Sets the path for input and output files.")]
class SetPathCommand
{
    [Option("-p|--path <PATH>", Description = "Path to the folder with input and output files.")]
    public string? Path { get; set; }

    private int OnExecute()
    {
        if (string.IsNullOrEmpty(Path))
        {
            Console.WriteLine("Error: Path is required. Use -p or --path to specify the folder.");
            return 1;
        }

        Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
        Console.WriteLine($"LAB_PATH has been set to: {Path}");
        return 0;
    }
}


abstract class LabCommandBase
{
    [Option("-I|--input <INPUT_FILE>", Description = "Input file path.")]
    public string? InputFile { get; set; }

    [Option("-o|--output <OUTPUT_FILE>", Description = "Output file path.")]
    public string? OutputFile { get; set; }

    protected int ExecuteLab(Action<string, string> runLabMethod)
    {
        string inputPath = ResolveFilePath(InputFile, "input.txt");
        string outputPath = ResolveFilePath(OutputFile, "output.txt");

        // Validate input file path
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Error: Input file '{inputPath}' does not exist.");
            return 1;
        }

        // Ensure output directory exists or create it if necessary
        string? outputDirectory = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        Console.WriteLine("Running Lab\n");
        runLabMethod(inputPath, outputPath);

        return 0;
    }

    // Method to resolve the file path with fallback options
    private string ResolveFilePath(string? userProvidedPath, string defaultFileName)
    {
        // Use the provided path if available
        if (!string.IsNullOrEmpty(userProvidedPath))
        {
            return userProvidedPath;
        }

        // Check for environment variable LAB_PATH as a base directory
        string? labPath = Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User);

        if (!string.IsNullOrEmpty(labPath) && Directory.Exists(labPath))
        {
            string labPathFile = Path.Combine(labPath, defaultFileName);
            
            if (File.Exists(labPathFile)) return labPathFile;
        }

        // Fallback to user's profile directory and check if the file exists
        string userProfileFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), defaultFileName);
        if (File.Exists(userProfileFile)) return userProfileFile;

        // If file is not found in any location, return path to user profile as a last resort
        return userProfileFile;
    }
}

[Command(Name = "lab1", Description = "Run Lab 1")]
class Lab1Command : LabCommandBase
{
    private int OnExecute()
    {
        return ExecuteLab((inputPath, outputPath) =>
        {
            FirstLab firstLab = new FirstLab();
            firstLab.RunLab(inputPath, outputPath);
        });
    }
}

[Command(Name = "lab2", Description = "Run Lab 2")]
class Lab2Command : LabCommandBase
{
    private int OnExecute()
    {
        return ExecuteLab((inputPath, outputPath) =>
        {
            SecondLab secondLab = new SecondLab();
            secondLab.RunLab(inputPath, outputPath);
        });
    }
}

[Command(Name = "lab3", Description = "Run Lab 3")]
class Lab3Command : LabCommandBase
{
    private int OnExecute()
    {
        return ExecuteLab((inputPath, outputPath) =>
        {
            ThirdLab thirdLab = new ThirdLab();
            thirdLab.RunLab(inputPath, outputPath);
        });
    }
}

