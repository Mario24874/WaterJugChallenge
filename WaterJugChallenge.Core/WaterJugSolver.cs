using System;
using System.Collections.Generic;

namespace WaterJugChallenge.Core
{
    public class WaterJugSolver
    {
        // Class representing the current state of the jugs and the steps taken
        public class State
        {
            public int X { get; set; } // Amount of water in jug X (in gallons)
            public int Y { get; set; } // Amount of water in jug Y (in gallons)
            public List<string> Steps { get; set; } // List of steps taken

            // Constructor to initialize the state with water amounts in the jugs
            public State(int x, int y)
            {
                X = x;
                Y = y;
                Steps = new List<string>();
            }

            // Method to clone the current state
            public State Clone()
            {
                return new State(X, Y) { Steps = new List<string>(Steps) };
            }
        }

        // Main method to solve the water jug problem
        public static List<string> Solve(int X, int Y, int Z)
        {
            // Check if the target amount Z is greater than the jugs X or Y
            if (Z > Math.Max(X, Y))
            {
                return new List<string> { "No solution" };
            }

            // Check if Z is a multiple of the GCD of X and Y
            if (Z % GCD(X, Y) != 0)
            {
                return new List<string> { "No solution" };
            }

            // Queue for breadth-first search
            Queue<State> queue = new Queue<State>();
            // Set to track visited states
            HashSet<string> visited = new HashSet<string>();
            // Initial state with both jugs empty
            State initialState = new State(0, 0);
            queue.Enqueue(initialState);

            // Main loop for breadth-first search
            while (queue.Count > 0)
            {
                State current = queue.Dequeue();
                // Check if the target amount Z is reached
                if (current.X == Z || current.Y == Z)
                {
                    return current.Steps;
                }

                // Mark the current state as visited
                visited.Add($"{current.X},{current.Y}");

                // Possible operations
                PerformOperation(queue, visited, current, X, Y, "Fill jug X", (state, max) => state.X = max);
                PerformOperation(queue, visited, current, X, Y, "Fill jug Y", (state, max) => state.Y = max);
                PerformOperation(queue, visited, current, X, Y, "Empty jug X", (state, max) => state.X = 0);
                PerformOperation(queue, visited, current, X, Y, "Empty jug Y", (state, max) => state.Y = 0);
                PerformTransfer(queue, visited, current, X, Y, "Transfer from jug X to jug Y", (state, amount) => { state.X -= amount; state.Y += amount; });
                PerformTransfer(queue, visited, current, X, Y, "Transfer from jug Y to jug X", (state, amount) => { state.X += amount; state.Y -= amount; });
            }

            // If no solution is found, return an error message
            return new List<string> { "No solution" };
        }

        // Method to perform an operation on a jug
        private static void PerformOperation(Queue<State> queue, HashSet<string> visited, State current, int maxX, int maxY, string description, Action<State, int> operation)
        {
            // Clone the current state
            State next = current.Clone();
            // Perform the operation on the cloned state
            operation(next, maxX);
            // Check if the resulting state has already been visited
            if (!visited.Contains($"{next.X},{next.Y}"))
            {
                // Add the step taken to the list of steps
                next.Steps.Add($"{description}: {next.X} gallons, {next.Y} gallons");
                // Enqueue the new state
                queue.Enqueue(next);
            }
        }

        // Method to perform a transfer of water between jugs
        private static void PerformTransfer(Queue<State> queue, HashSet<string> visited, State current, int maxX, int maxY, string description, Action<State, int> transfer)
        {
            // Calculate the amount of water to transfer
            int transferAmount = Math.Min(current.X, maxY - current.Y);
            // Check if the transfer amount is greater than 0
            if (transferAmount > 0)
            {
                // Clone the current state
                State next = current.Clone();
                // Perform the transfer on the cloned state
                transfer(next, transferAmount);
                // Check if the resulting state has already been visited
                if (!visited.Contains($"{next.X},{next.Y}"))
                {
                    // Add the step taken to the list of steps
                    next.Steps.Add($"{description}: {next.X} gallons, {next.Y} gallons");
                    // Enqueue the new state
                    queue.Enqueue(next);
                }
            }
        }

        // Method to calculate the Greatest Common Divisor (GCD)
        private static int GCD(int a, int b)
        {
            // Euclidean algorithm to calculate the GCD
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}