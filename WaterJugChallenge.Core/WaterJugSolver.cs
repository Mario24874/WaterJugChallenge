using System;
using System.Collections.Generic;

namespace WaterJugChallenge.Core
{
    public class WaterJugSolver
    {
        public class State
        {
            public int X { get; set; }
            public int Y { get; set; }
            public List<string> Steps { get; set; }

            public State(int x, int y)
            {
                X = x;
                Y = y;
                Steps = new List<string>();
            }

            public State Clone()
            {
                return new State(X, Y) { Steps = new List<string>(Steps) };
            }
        }

        public static List<string> Solve(int X, int Y, int Z)
        {
            if (Z > Math.Max(X, Y))
            {
                return new List<string> { "Sin solución" };
            }

            if (Z % GCD(X, Y) != 0)
            {
                return new List<string> { "Sin solución" };
            }

            Queue<State> queue = new Queue<State>();
            HashSet<string> visited = new HashSet<string>();
            State initialState = new State(0, 0);
            queue.Enqueue(initialState);

            while (queue.Count > 0)
            {
                State current = queue.Dequeue();
                if (current.X == Z || current.Y == Z)
                {
                    return current.Steps;
                }

                visited.Add($"{current.X},{current.Y}");

                // Fill X
                if (!visited.Contains($"{X},{current.Y}"))
                {
                    State next = current.Clone();
                    next.X = X;
                    next.Steps.Add($"Llenar el cubo X: {next.X}, {next.Y}");
                    queue.Enqueue(next);
                }

                // Fill Y
                if (!visited.Contains($"{current.X},{Y}"))
                {
                    State next = current.Clone();
                    next.Y = Y;
                    next.Steps.Add($"Llenar el cubo Y: {next.X}, {next.Y}");
                    queue.Enqueue(next);
                }

                // Empty X
                if (!visited.Contains($"0,{current.Y}"))
                {
                    State next = current.Clone();
                    next.X = 0;
                    next.Steps.Add($"Vaciar el cubo X: {next.X}, {next.Y}");
                    queue.Enqueue(next);
                }

                // Empty Y
                if (!visited.Contains($"{current.X},0"))
                {
                    State next = current.Clone();
                    next.Y = 0;
                    next.Steps.Add($"Vaciar el cubo Y: {next.X}, {next.Y}");
                    queue.Enqueue(next);
                }

                // Transfer X to Y
                int transferAmount = Math.Min(current.X, Y - current.Y);
                if (transferAmount > 0 && !visited.Contains($"{current.X - transferAmount},{current.Y + transferAmount}"))
                {
                    State next = current.Clone();
                    next.X -= transferAmount;
                    next.Y += transferAmount;
                    next.Steps.Add($"Transferir del cubo X al cubo Y: {next.X}, {next.Y}");
                    queue.Enqueue(next);
                }

                // Transfer Y to X
                transferAmount = Math.Min(current.Y, X - current.X);
                if (transferAmount > 0 && !visited.Contains($"{current.X + transferAmount},{current.Y - transferAmount}"))
                {
                    State next = current.Clone();
                    next.X += transferAmount;
                    next.Y -= transferAmount;
                    next.Steps.Add($"Transferir del cubo Y al cubo X: {next.X}, {next.Y}");
                    queue.Enqueue(next);
                }
            }

            return new List<string> { "Sin solución" };
        }

        private static int GCD(int a, int b)
        {
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