using System;
using WaterJugChallenge.Core;

namespace WaterJugChallenge.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Water Jug Challenge!");
            Console.Write("Enter the capacity of the X pitcher: ");
            int X = int.Parse(Console.ReadLine());
            Console.Write("Enter the capacity of pitcher Y: ");
            int Y = int.Parse(Console.ReadLine());
            Console.Write("Enter the desired amount Z: ");
            int Z = int.Parse(Console.ReadLine());

            var steps = WaterJugSolver.Solve(X, Y, Z);

            foreach (var step in steps)
            {
                Console.WriteLine(step);
            }
        }
    }
}