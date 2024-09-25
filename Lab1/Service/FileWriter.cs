using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Service
{
    public class FileWriter
    {
        public void WriteResult(string outputFilePath, string output)
        {
            try
            {
                File.WriteAllText(outputFilePath, output);
                Console.WriteLine($"Result successfully written to {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing the file: {ex.Message}");
                throw;
            }
        }
    }
}
