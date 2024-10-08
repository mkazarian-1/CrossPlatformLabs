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
        /*private SecondLab secondLab*/
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
        public void Solve_ShouldReturnEmptyGrid_ForInvalidInput()
        {           
            int N = 0;
            int[,] grid = new int[0, 0];

            char[,] result = secondLab.Solve(N, grid);

            Assert.Empty(result);
        }

        [Fact]
        public void Solve_ShouldReturnEmptyGrid_ForNegativeN()
        {
            int N = -1;
            int[,] grid = new int[0, 0];

            char[,] result = secondLab.Solve(N, grid);

            Assert.Empty(result); 
        }
    }
}
