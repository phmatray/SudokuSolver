using SudokuSolver.Domain;
using SudokuSolver.Ports;

namespace SudokuSolver.Application;

public class SudokuGameService(
    ISudokuSolver solver,
    ISudokuPuzzleProvider puzzleProvider,
    ISudokuSolutionHandler solutionHandler)
{
    public void RunGame()
    {
        try
        {
            int[,] puzzle = puzzleProvider.GetPuzzle();
            int[,] solution = solver.Solve(puzzle);
            solutionHandler.HandleSolution(solution);
        }
        catch (NoSolutionException)
        {
            Console.WriteLine("No solution found.");
        }
    }
}