using Lab3.Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Test.Lab
{
    public class ThirdLabTest
    {
        [Fact]
        public void ParseInput_ShouldParseCorrectly()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            string[] input = {
            "5",
            ".....",
            ".@@..",
            ".....",
            ".....",
            "....."
        };

            // Act
            var result = lab.ParseInput(input);

            // Assert
            char[,] board = {
            { '.', '.', '.', '.', '.' },
            { '.', '@', '@', '.', '.' },
            { '.', '.', '.', '.', '.' },
            { '.', '.', '.', '.', '.' },
            { '.', '.', '.', '.', '.' }
            };

            Assert.Equal(5, result.n);
            Assert.Equal(board, result.board);
            Assert.Equal(('@', 1, 1), (result.board[1, 1], result.start.Item1, result.start.Item2));
            Assert.Equal(('@', 1, 2), (result.board[1, 2], result.end.Item1, result.end.Item2));
        }

        [Fact]
        public void BFS_ShouldReturnCorrectPath()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            char[,] board = {
            { '.', '.', '.', '.', '.' },
            { '.', '@', '@', '.', '.' },
            { '.', '.', '.', '.', '.' },
            { '.', '.', '.', '.', '.' },
            { '.', '.', '.', '.', '.' }
        };
            var start = (1, 1);
            var end = (1, 2);

            // Act
            var result = lab.BFS(board, start, end, 5);

            // Assert
            char[,] expectedBoard = {
            { '.', '.', '.', '.', '.' },
            { '.', '@', '@', '.', '.' },
            { '.', '.', '.', '.', '@' },
            { '.', '.', '@', '.', '.' },
            { '.', '.', '.', '.', '.' }
        };

            Assert.Equal(expectedBoard, result);
        }

        [Fact]
        public void BFS_ShouldReturnNullWhenNoPathExists()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            char[,] board = {
            { '@', '.', '.', '.', '.' },
            { '.', '.', '#', '.', '.' },
            { '.', '#', '.', '.', '.' },
            { '.', '.', '.', '.', '.' },
            { '.', '.', '.', '.', '@' }
        };
            var start = (0, 0);
            var end = (4, 4);

            // Act
            var result = lab.BFS(board, start, end, 5);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void BFSWithDeeps_ShouldReturnCorrectPath()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            char[,] board = {
            { '@', '.', '.', '@', '.' },
            { '.', '.', '#', '#', '.' },
            { '.', '.', '.', '.', '.' },
            { '.', '.', '.', '.', '.' },
            { '.', '.', '.', '.', '.' }
        };
            var start = (0, 0);
            var end = (0, 3);

            // Act
            var result = lab.BFS(board, start, end, 5);

            // Assert
            char[,] expectedBoard = {
            { '@', '.', '.', '@', '.' },
            { '.', '.', '#', '#', '.' },
            { '.', '@', '@', '.', '.' },
            { '.', '.', '.', '.', '@' },
            { '.', '.', '@', '.', '.' }
        };

            Assert.Equal(expectedBoard, result);
        }

        [Fact]
        public void ValidateInput_ShouldReturnTrueForValidInput()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            string[] validInput = {
            "5",
            ".....",
            ".@@..",
            ".....",
            ".....",
            "....."
        };

            // Act
            bool result = lab.ValidateInput(validInput);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateInput_ShouldReturnFalseWhenNIsOutOfRange()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            string[] inputWithInvalidN = {
            "60",  // N > 50
            ".....",
            ".....",
            ".....",
            ".....",
            "....."
        };

            // Act
            bool result = lab.ValidateInput(inputWithInvalidN);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_ShouldReturnFalseWhenRowCountIsIncorrect()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            string[] inputWithIncorrectRowCount = {
            "5",
            ".....",
            ".@@..",
            ".....",
            "....."  // Один рядок відсутній
        };

            // Act
            bool result = lab.ValidateInput(inputWithIncorrectRowCount);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_ShouldReturnFalseWhenRowLengthIsIncorrect()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            string[] inputWithIncorrectRowLength = {
            "5",
            "......",  // Рядок занадто довгий
            ".@@..",
            ".....",
            ".....",
            "....."
        };

            // Act
            bool result = lab.ValidateInput(inputWithIncorrectRowLength);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_ShouldReturnFalseWhenThereAreNotExactlyTwoAtSymbols()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            string[] inputWithTooManyAtSymbols = {
            "5",
            ".....",
            ".@@@.",  // Занадто багато @
            ".....",
            ".....",
            "....."
        };

            // Act
            bool result = lab.ValidateInput(inputWithTooManyAtSymbols);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_ShouldReturnFalseWhenThereIsInvalidCharacter()
        {
            // Arrange
            ThirdLab lab = new ThirdLab();
            string[] inputWithInvalidCharacter = {
            "5",
            ".....",
            ".@@..",
            ".....",
            ".....",
            ".....X"  // Неправильний символ 'X'
        };

            // Act
            bool result = lab.ValidateInput(inputWithInvalidCharacter);

            // Assert
            Assert.False(result);
        }
    }
}
