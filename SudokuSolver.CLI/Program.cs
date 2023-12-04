using Microsoft.Extensions.Logging;
using SudokuSolver.CLI;

Console.WriteLine("Sudoku Solver");
Console.WriteLine("=============");

var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = loggerFactory.CreateLogger<Program>();

DependencyInjections
    .ConfigureAndBuildServices(logger)
    .RetrieveGameService(logger)
    .RunGame();

Console.ReadLine();
