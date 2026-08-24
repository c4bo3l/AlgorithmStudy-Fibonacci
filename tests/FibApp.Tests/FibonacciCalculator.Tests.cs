using Xunit;
using System.Numerics;

namespace FibApp.Tests
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(10, 55)]
        [InlineData(20, 6765)]
        public void FibonacciIterative_ReturnsExpectedValue(int n, BigInteger expected)
        {
            BigInteger result = FibonacciCalculator.FibonacciIterative(n);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(10, 55)]
        [InlineData(20, 6765)]
        public void FibonacciMatrix_ReturnsExpectedValue(int n, BigInteger expected)
        {
            BigInteger result = FibonacciCalculator.FibonacciMatrix(n);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(10, 55)]
        [InlineData(20, 6765)]
        public void FibonacciWithArray_ReturnsExpectedValue(int n, BigInteger expected)
        {
            BigInteger result = FibonacciCalculator.FibonacciWithArray(n);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(10, 55)]
        [InlineData(20, 6765)]
        public void FibonacciFastDoubling_ReturnsExpectedValue(int n, BigInteger expected)
        {
            BigInteger result = FibonacciCalculator.FibonacciFastDoubling(n);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FibonacciMethods_ThrowExceptionOnNegativeInput()
        {
            Assert.Throws<ArgumentException>(() => FibonacciCalculator.FibonacciIterative(-1));
            Assert.Throws<ArgumentException>(() => FibonacciCalculator.FibonacciMatrix(-1));
            Assert.Throws<ArgumentException>(() => FibonacciCalculator.FibonacciWithArray(-1));
            Assert.Throws<ArgumentException>(() => FibonacciCalculator.FibonacciRecursive(-1));
            Assert.Throws<ArgumentException>(() => FibonacciCalculator.FibonacciFastDoubling(-1));
        }

        [Fact]
        public void FibonacciIterative_ReturnsCorrectLargeValue()
        {
            // Test for a large value that was requested in the review
            int n = 100;
            BigInteger expected = BigInteger.Parse("354224848179261915075");
            BigInteger result = FibonacciCalculator.FibonacciIterative(n);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FibonacciRecursive_Note()
        {
            // Note: Recursive approach is only suitable for small values of n due to exponential complexity and stack limits.
            int n = 10;
            BigInteger expected = BigInteger.Parse("55");
            BigInteger result = FibonacciCalculator.FibonacciRecursive(n);
            Assert.Equal(expected, result);
        }
    }
}