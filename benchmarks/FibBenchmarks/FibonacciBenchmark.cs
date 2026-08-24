using BenchmarkDotNet.Attributes;
using System.Numerics;

namespace FibApp.Benchmarks
{
    [MemoryDiagnoser]
    public class FibonacciBenchmark
    {
        private const int N = 1500;

        [Benchmark(Baseline = true)]
        public BigInteger Iterative()
        {
            return FibonacciCalculator.FibonacciIterative(N);
        }

        [Benchmark]
        public BigInteger Matrix()
        {
            return FibonacciCalculator.FibonacciMatrix(N);
        }

        [Benchmark]
        public BigInteger ArrayBased()
        {
            return FibonacciCalculator.FibonacciWithArray(N);
        }

        [Benchmark]
        public BigInteger FastDoubling()
        {
            return FibonacciCalculator.FibonacciFastDoubling(N);
        }

        /*
        [Benchmark]
        public BigInteger Recursive()
        {
            // Warning: This will be very slow for N=1500 and might cause a StackOverflowException.
            // Only run with small values of N if testing this specific method in benchmarks.
            return FibonacciCalculator.FibonacciRecursive(N);
        }
        */
    }
}