## Water Jug Challenge

## Summary
This project solves the classic Water Jug Puzzle using two jugs with different capacities (X gallons and Y gallons) to measure exactly Z gallons of water. The application shows the state changes of each jug as it progresses toward the solution.

## Objectives
1. Solve the problem of measuring Z gallons of water using the two jugs as efficiently as possible.
2. Create a user interface where users can enter any value for X, Y, and Z and see the solution step by step. If this is not possible, the interface should show “No solution”.

## Limitations
- Actions allowed: Fill, Empty, Transfer (only between the two jars).
- X, Y and Z are greater than 0.
- X, Y and Z are integers (no decimals, fractions).

## Deliverables
- The source code of the application is in a public GitHub repository.
- Algorithmic approach: breadth-first search (BFS) algorithm and Euclid's algorithm are used to find the greatest common divisor (GCM).
- Test cases for validation.
- Instructions to run the program.

## Program Execution

### Prerequisites
1. **Install .NET SDK**:
   - Download and install the [.NET SDK](https://dotnet.microsoft.com/download) from the official Microsoft site.

2. **Install Visual Studio Code**:
   - Download and install [Visual Studio Code](https://code.visualstudio.com/) from its official site.

3. **Install VSC Extensions**:
   - Open Visual Studio Code and go to the extensions section (`Ctrl+Shift+X`).
   - Install the following extensions:
     - **C# (Microsoft)**: For C# support.
     - **C# Dev Kit (Microsoft)**: For debugging and testing. (Optional)
     - **IntelliCode for C# Dev Kit (Microsoft)**: AI-assisted development for C# Dev Kit. (Optional)
     - .NET Install Tool (Microsoft)**: For installation of local versions of the .NET Runtime and machine-wide versions of the .NET SDK.
     - .NET Core Test Explorer (Jun Han)**: For running and debugging unit tests.

### Steps to Run the Application

1. **Clone the Repository** (if you are using a repository):
   ````bash
   git clone https://github.com/Mario24874/WaterJugChallenge.git

2. **Navigate to UI Project Folder**:
   ````bash
   cd WaterJugChallenge

3. **Run the Application**:
   ````bash
   dotnet run
