using CrossPlatformLabs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformLabs.Tests.Service
{

    public class FileReaderTests
    {
        [Fact]
        public void ReadFile_FileExists_ReturnsFileContent()
        {
            var fileReader = new FileReader();
            var inputFilePath = "testFile.txt";
            var expectedContent = new string[] { "Line1", "Line2", "Line3" };

            File.WriteAllLines(inputFilePath, expectedContent);

            var result = fileReader.ReadFile(inputFilePath);

            Assert.Equal(expectedContent, result);

            File.Delete(inputFilePath);
        }

        [Fact]
        public void ReadFile_FileDoesNotExist_ThrowsFileNotFoundException()
        {
            var fileReader = new FileReader();
            var inputFilePath = "nonExistentFile.txt";

            var exception = Assert.Throws<FileNotFoundException>(() => fileReader.ReadFile(inputFilePath));
            Assert.Equal("The input file does not exist.", exception.Message);
        }
    }

}
