using CrossPlatformLabs.Labs;

namespace CrossPlatformLabs.Tests.Labs
{
    public class FirstLabTests
    {
        private readonly FirstLab _firstLab;

        public FirstLabTests()
        {
            _firstLab = new FirstLab();
        }

        [Theory]
        [InlineData(8, 8, 40320)]
        [InlineData(8, 1, 64)]
        [InlineData(8, 7, 322560)]
        [InlineData(5, 4, 600)]
        [InlineData(5, 10, 0)]
        [InlineData(-10, -3, 0)]
        [InlineData(-1, -3, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(9, 8, 0)]
        public void CalculateRookPlacements_ValidInput(int N, int K, long expected)
        {
            // Act
            long result = _firstLab.CalculateRookPlacements(N, K);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}