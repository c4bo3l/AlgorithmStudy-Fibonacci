public static class FibonacciCalculatorApp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Fibonacci Calculator");
        Console.Write("Enter a number: ");
        
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            try
            {
                if (n > 100000)
                {
                    Console.WriteLine("Warning: Printing the full sequence for such a large number may be very slow and use significant memory.");
                }

                var arr = FibonacciCalculator.GetFullSequence(n);
                for (int i = 0; i <= n; i++)
                    Console.Write(arr[i] + " ");
                
                Console.WriteLine($"\nThe {n}th Fibonacci number: {FibonacciCalculator.FibonacciWithArray(n)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid integer.");
        }
    }
}
