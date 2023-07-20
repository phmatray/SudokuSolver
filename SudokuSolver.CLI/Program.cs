using SudokuSolver.CLI;

Console.WriteLine("Sudoku Solver");
Console.WriteLine("=============");

DependencyInjections
    .ConfigureAndBuildServices()
    .RetrieveGameService()
    .RunGame();

Console.ReadLine();
