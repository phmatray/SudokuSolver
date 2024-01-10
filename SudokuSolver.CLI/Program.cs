using Microsoft.Extensions.Logging;
using SudokuSolver.CLI;

Console.WriteLine("Sudoku Solver");
Console.WriteLine("=============");

ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

DependencyInjections
    .ConfigureAndBuildServices(logger)
    .RetrieveGameService(logger)
    .RunGame();

Console.ReadLine();
