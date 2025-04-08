// See https://aka.ms/new-console-template for more information
using System;

namespace LoopsAndFunctionsDemo
{
    class LoopAndFunctionHandler
    {
        // For loop to print numbers from 1 to 10
        public void PrintNumbers()
        {
            Console.WriteLine("Numbers from 1 to 10:");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        // Function to calculate factorial of a number
        public long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // While loop to keep asking for input until "exit" is typed
        public void InputLoop()
        {
            string? input;
            while (true)
            {
                Console.Write("\nEnter a number to calculate its factorial (or type 'exit' to quit): ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input was empty or null. Try again.");
                    continue;
                }
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }

                if (int.TryParse(input, out int number) && number >= 0)
                {
                    Console.WriteLine($"Factorial of {number} is: {Factorial(number)}");
                }
                else
                {
                    Console.WriteLine("Please enter a valid non-negative integer.");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            LoopAndFunctionHandler handler = new LoopAndFunctionHandler();

            handler.PrintNumbers();    // For loop demo
            handler.InputLoop();       // While loop and factorial function
        }
    }
}
