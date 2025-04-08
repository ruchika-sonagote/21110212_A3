// See https://aka.ms/new-console-template for more information
using System;

namespace BasicSyntaxDemo
{
    // A simple Calculator class
    class Calculator
    {
        private int num1;
        private int num2;

        // Constructor
        public Calculator(int n1, int n2)
        {
            num1 = n1;
            num2 = n2;
        }

        // Methods to perform operations
        public int Add() => num1 + num2;
        public int Subtract() => num1 - num2;
        public int Multiply() => num1 * num2;

        public double Divide()
        {
            if (num2 == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return (double)num1 / num2;
        }

        // Check if a number is even or odd
        public void CheckEvenOdd(int number)
        {
            if (number % 2 == 0)
                Console.WriteLine("The sum is even.");
            else
                Console.WriteLine("The sum is odd.");
        }

        // Display all results
        public void DisplayResults()
        {
            int sum = Add();
            Console.WriteLine("Addition: " + sum);
            CheckEvenOdd(sum);
            Console.WriteLine("Subtraction: " + Subtract());
            Console.WriteLine("Multiplication: " + Multiply());

            try
            {
                Console.WriteLine("Division: " + Divide());
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Accept user input
                Console.Write("Enter the first number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the second number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                // Create Calculator object and perform operations
                Calculator calc = new Calculator(num1, num2);
                calc.DisplayResults();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numeric values only.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}
