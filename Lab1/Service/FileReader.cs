using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Service
{
    public class FileReader
    {
        public string[] ReadFile(string inputFilePath)
        {
            try
            {
                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException("The input file does not exist.");
                }

                return File.ReadAllLines(inputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                throw;
            }
        }
    }
}
