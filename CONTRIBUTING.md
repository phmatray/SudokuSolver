# Contributing to SudokuSolver

Contributions are welcome! Whether it's a bug fix, new feature, or documentation improvement, here's how to get started.

## Prerequisites

- [.NET SDK 10.0+](https://dotnet.microsoft.com/download)
- Git

## Getting Started

1. Fork the repository
2. Clone your fork:
   ```bash
   git clone https://github.com/<your-username>/SudokuSolver.git
   cd SudokuSolver
   ```
3. Verify the build:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run --project SudokuSolver.CLI
   ```

## Making Changes

1. Create a branch from `main`:
   ```bash
   git checkout -b feature/your-change
   ```
2. Make your changes
3. Verify the build succeeds:
   ```bash
   dotnet build
   ```
4. Commit with a descriptive message
5. Push and open a pull request against `main`

## Code Style

- Follow standard C# conventions and naming guidelines
- The project uses .NET analyzers with strict settings — ensure no new warnings are introduced
- Keep the hexagonal architecture boundaries: domain logic stays in `SudokuSolver`, CLI concerns stay in `SudokuSolver.CLI`

## Pull Requests

- Fill out the PR template completely
- Keep PRs focused on a single change
- Link related issues using "Closes #N"

## Reporting Issues

Use the [issue templates](https://github.com/phmatray/SudokuSolver/issues/new/choose) to report bugs or request features.
