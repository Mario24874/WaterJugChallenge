using System;
using WaterJugChallenge.Core;

namespace WaterJugChallenge.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message and instructions
            Console.WriteLine("Welcome to the Water Jug Challenge!");
            Console.Write("Enter the capacity of the jug X (Gallons): ");
            int X = ReadIntFromConsole();
            Console.Write("Enter the capacity of the jug Y (Gallons): ");
            int Y = ReadIntFromConsole();
            Console.Write("Enter the desired amount Z (Gallons): ");
            int Z = ReadIntFromConsole();

            // Solve the water jug problem using the WaterJugSolver class
            var steps = WaterJugSolver.Solve(X, Y, Z);

            // Display each step in the solution
            foreach (var step in steps)
            {
                Console.WriteLine(step);
            }
        }

        // Method to read an integer from the console with validation
        static int ReadIntFromConsole()
        {
            string input = Console.ReadLine() ?? "";
    
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Invalid input. Please enter a valid integer: ");
                input = Console.ReadLine() ?? "";
            }

            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.Write("Invalid input. Please enter a valid integer: ");
                return ReadIntFromConsole();
            }
        }
    }
}