# Algorithm Study - Fibonacci

This project explores different algorithmic approaches to calculate numbers in the Fibonacci sequence, comparing their time and space complexities.

## Algorithms Explored

- **Iterative**: A simple bottom-up approach using a loop.
- **Matrix Exponentiation**: Uses matrix multiplication to achieve logarithmic time complexity.
- **Array-Based (Memoization)**: Stores previously calculated values in an array to avoid redundant computations.
- **Fast Doubling**: An optimized version of the matrix exponentiation method.
- **Recursive**: The standard naive recursive approach, demonstrating exponential time complexity.

## Conclusion

The benchmarks highlight the significant performance differences between various Fibonacci implementations:
- **Iterative** is the fastest for small to medium inputs due to its low overhead and $O(n)$ time complexity.
- **Recursive** should be avoided for larger values as it suffers from exponential time complexity ($O(2^n)$).
- **Matrix Exponentiation** and **Fast Doubling** provide superior performance for very large numbers, offering logarithmic time complexity ($O(\log n)$), making them the preferred choice for high-scale computations.
- **Array-Based (Memoization)** offers a good balance of speed and simplicity but requires $O(n)$ space.
