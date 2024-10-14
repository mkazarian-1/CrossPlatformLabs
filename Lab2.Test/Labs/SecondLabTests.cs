using Lab2.Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lab1.Test.Labs
{
    public class SecondLabTests
    {
        private readonly SecondLab secondLab = new SecondLab();

        [Fact]
        public void Solve_ShouldReturnCorrectPath_ForValid3x3Grid()
        {
            int N = 3;
            int[,] grid = {
            { 9, 4, 3 },
            { 2, 1, 6 },
            { 0, 9, 1 }
        };

            char[,] result = secondLab.Solve(N, grid);

            char[,] expected = {
            { '#', '.', '.' },
            { '#', '#', '#' },
            { '.', '.', '#' }
        };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Solve_ShouldReturnCorrectPath_ForLargerGrid()
        {
            // Arrange
            int N = 4;
            int[,] grid = {
                { 1, 1, 1, 1 },
                { 1, 9, 9, 9 },
                { 1, 9, 1, 1 },
                { 1, 1, 1, 1 }
            };

            char[,] result = secondLab.Solve(N, grid);

            char[,] expected = {
                { '#', '.', '.', '.' },
                { '#', '.', '.', '.' },
                { '#', '.', '.', '.' },
                { '#', '#', '#', '#' }
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ValidateInputForMinPath_ShouldReturnTrueForValidInput()
        {
            // Arrange
            string[] validInput = {
            "3",
            "123",
            "456",
            "789"
        };

            // Act
            bool result = secondLab.ValidateInputForMinPath(validInput);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateInputForMinPath_ShouldReturnFalseForInvalidN()
        {
            // Arrange
            string[] invalidInput = {
            "300", // N is greater than the allowed limit (N > 250)
            "123",
            "456",
            "789"
        };

            // Act
            bool result = secondLab.ValidateInputForMinPath(invalidInput);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInputForMinPath_ShouldReturnFalseWhenRowCountIsIncorrect()
        {
            // Arrange
            string[] inputWithMissingRow = {
            "3",
            "123",
            "456" // Missing the third row
        };

            // Act
            bool result = secondLab.ValidateInputForMinPath(inputWithMissingRow);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInputForMinPath_ShouldReturnFalseWhenRowLengthIsIncorrect()
        {
            // Arrange
            string[] inputWithIncorrectRowLength = {
            "3",
            "1234", // Row length is greater than N
            "456",
            "789"
        };

            // Act
            bool result = secondLab.ValidateInputForMinPath(inputWithIncorrectRowLength);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInputForMinPath_ShouldReturnFalseForInvalidCharacter()
        {
            // Arrange
            string[] inputWithInvalidCharacter = {
            "3",
            "12a", // Invalid character 'a'
            "456",
            "789"
        };

            // Act
            bool result = secondLab.ValidateInputForMinPath(inputWithInvalidCharacter);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInputForMinPath_ShouldReturnFalseForTooFewRows()
        {
            // Arrange
            string[] inputWithTooFewRows = {
            "4",
            "1234",
            "5678",
            "9101" // Missing the fourth row
        };

            // Act
            bool result = secondLab.ValidateInputForMinPath(inputWithTooFewRows);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateInputForMinPath_ShouldReturnFalseForTooManyRows()
        {
            // Arrange
            string[] inputWithTooManyRows = {
            "3",
            "123",
            "456",
            "789",
            "012" // Extra row
        };

            // Act
            bool result = secondLab.ValidateInputForMinPath(inputWithTooManyRows);

            // Assert
            Assert.False(result);
        }
    }
}
