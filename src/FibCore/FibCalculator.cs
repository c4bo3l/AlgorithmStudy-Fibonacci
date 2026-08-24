using System.Numerics;

/// <summary>
/// Provides utility methods for calculating Fibonacci numbers using various algorithms.
/// </summary>
public static class FibonacciCalculator
{
    /// <summary>
    /// Represents a 2x2 matrix used for the matrix exponentiation algorithm to calculate Fibonacci numbers.
    /// </summary>
    private readonly record struct Matrix2x2(BigInteger M00, BigInteger M01, BigInteger M10, BigInteger M11);

    /// <summary>
    /// Calculates the nth Fibonacci number using an iterative approach with O(n) time complexity.
    /// </summary>
    /// <param name="n">The index of the Fibonacci number to calculate.</param>
    /// <returns>The nth Fibonacci number as a BigInteger.</returns>
    /// <exception cref="ArgumentException">Thrown when n is negative.</exception>
    public static BigInteger FibonacciIterative(int n)
    {
        if (n < 0) throw new ArgumentException("Invalid input: cannot be negative");
        if (n == 0) return 0;
        if (n == 1) return 1;

        BigInteger previous = 0, current = 1;
        for (int i = 2; i <= n; i++)
        {
            BigInteger next = previous + current;
            previous = current;
            current = next;
        }
        return current;
    }

    /// <summary>
    /// Calculates the nth Fibonacci number using a recursive approach. 
    /// Note: This method has exponential time complexity O(2^n).
    /// </summary>
    /// <param name="n">The index of the Fibonacci number to calculate.</param>
    /// <returns>The nth Fibonacci number as a BigInteger.</returns>
    /// <exception cref="ArgumentException">Thrown when n is negative.</exception>
    public static BigInteger FibonacciRecursive(int n)
    {
        if (n < 0) throw new ArgumentException("Invalid input: cannot be negative");
        if (n == 0) return 0;
        if (n == 1) return 1;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    /// <summary>
    /// Calculates the nth Fibonacci number using matrix exponentiation with O(log n) time complexity.
    /// </summary>
    /// <param name="n">The index of the Fibonacci number to calculate.</param>
    /// <returns>The nth Fibonacci number as a BigInteger.</returns>
    /// <exception cref="ArgumentException">Thrown when n is negative.</exception>
    public static BigInteger FibonacciMatrix(int n)
    {
        if (n < 0) throw new ArgumentException("Invalid input: cannot be negative");
        if (n == 0) return 0;
        if (n == 1) return 1;

        var T = new Matrix2x2(1, 1, 1, 0);
        var result = Power(T, n - 1);

        return result.M00;
    }

    public static BigInteger FibonacciFastDoubling(int n)
    {
        if (n < 0) throw new ArgumentException("Invalid input: cannot be negative");
        if (n == 0) return 0;
        if (n == 1) return 1;

        return FastDoublingRecursive(n).Fk;
    }

    /// <summary>
    /// Helper method for the Fast Doubling algorithm.
    /// Returns a tuple containing (F_k, F_{k+1}).
    /// </summary>
    private static (BigInteger Fk, BigInteger Fkp1) FastDoublingRecursive(int n)
    {
        if (n == 0) return (0, 1);

        var (a, b) = FastDoublingRecursive(n / 2);

        // c = F_{2k} = F_k * (2*F_{k+1} - F_k)
        BigInteger c = a * (2 * b - a);
        // d = F_{2k+1} = F_{k+1}^2 + F_k^2
        BigInteger d = b * b + a * a;

        if (n % 2 == 0)
            return (c, d);
        else
            return (d, c + d);
    }

    /// <summary>
    /// Performs modular exponentiation on a 2x2 matrix to achieve O(log p) complexity.
    /// </summary>
    /// <param name="matrix">The base matrix.</param>
    /// <param name="p">The power to raise the matrix to.</param>
    /// <returns>The resulting matrix after exponentiation.</returns>
    private static Matrix2x2 Power(Matrix2x2 matrix, int p)
    {
        var res = new Matrix2x2(1, 0, 0, 1);
        while (p > 0)
        {
            if (p % 2 == 1) res = Multiply(res, matrix);
            matrix = Multiply(matrix, matrix);
            p /= 2;
        }
        return res;
    }

    /// <summary>
    /// Multiplies two 2x2 matrices.
    /// </summary>
    /// <param name="A">The first matrix.</param>
    /// <param name="B">The second matrix.</param>
    /// <returns>The product of the two matrices.</returns>
    private static Matrix2x2 Multiply(Matrix2x2 A, Matrix2x2 B)
    {
        return new Matrix2x2(
            A.M00 * B.M00 + A.M01 * B.M10,
            A.M00 * B.M01 + A.M01 * B.M11,
            A.M10 * B.M00 + A.M11 * B.M10,
            A.M10 * B.M01 + A.M11 * B.M11
        );
    }

    /// <summary>
    /// Generates a full sequence of Fibonacci numbers up to the specified index.
    /// </summary>
    /// <param name="n">The maximum index in the sequence.</param>
    /// <returns>An array containing the Fibonacci sequence from 0 to n.</returns>
    /// <exception cref="ArgumentException">Thrown when n is negative.</exception>
    public static BigInteger[] GetFullSequence(int n)
    {
        if (n < 0) throw new ArgumentException("Invalid input: cannot be negative");
        if (n > 1000000) Console.WriteLine("Warning: Generating a large sequence may consume significant memory.");
        var fib = new BigInteger[n + 1];
        fib[0] = 0;
        if (n >= 1) fib[1] = 1;

        for (int i = 2; i <= n; i++)
            fib[i] = fib[i - 1] + fib[i - 2];

        return fib;
    }

    /// <summary>
    /// Calculates the nth Fibonacci number by generating the full sequence up to that point (Legacy - for benchmarking).
    /// </summary>
    /// <param name="n">The index of the Fibonacci number to calculate.</param>
    /// <returns>The nth Fibonacci number as a BigInteger.</returns>
    /// <exception cref="ArgumentException">Thrown when n is negative.</exception>
    public static BigInteger FibonacciWithArray(int n)
    {
        if (n < 0) throw new ArgumentException("Invalid input: cannot be negative");
        return GetFullSequence(n)[n];
    }
}
