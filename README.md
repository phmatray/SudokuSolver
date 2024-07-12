# 🧩 Sudoku Solver
A Sudoku puzzle solver based on Hexagonal Architecture and written in C#. The application uses Google's OR-Tools for the solution process.

## 🚀 Getting Started
### Prerequisites
The project is built in C#, so you need:

* .NET 8+ SDK
The project uses Google OR-Tools library for solving Sudoku puzzles. To install it, run:

```csharp
dotnet add package Google.OrTools
```

### Running the Project
Clone the repository and navigate to the directory of the solution file (.sln). Run the project using:
You will see the solution printed to the console.

```shell
dotnet run
```

## 🧠 How It Works
The project uses the Constraint Programming (CP) model, which is a powerful tool to solve combinatorial problems - in this case, Sudoku.

We represent the Sudoku board as a 2D array of integer variables. Each of these variables can hold an integer between 1 and 9.

We then add constraints:

* All numbers in a row must be different
* All numbers in a column must be different
* All numbers in a 3x3 grid must be different
* The values already filled in the Sudoku puzzle

The Google OR-Tools CP solver will try to find a solution that satisfies all these constraints.

If a solution is found, it is printed to the console. If no solution is found, the program prints a message stating that no solution was found.

## 🌟 Features
* Ability to solve any standard 9x9 Sudoku puzzle.
* Uses Google OR-Tools for solving the puzzles, ensuring an efficient solution.
* Clean and maintainable codebase following Hexagonal Architecture.

## 📈 Future Improvements
* Adding more interfaces to interact with the application (like a GUI, Web API, etc.)
* Extending the application to support different sizes of Sudoku puzzles.

## 🤝 Contributing
Contributions are always welcome. Please feel free to open an issue or submit a pull request with your changes or improvements.

## 📜 License
This project is open-source and available under the MIT License.
