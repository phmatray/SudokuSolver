using SudokuSolver.Domain;
using SudokuSolver.Ports;

namespace SudokuSolver.Application;

public class SudokuGameService
{
    private readonly ISudokuSolver _solver;
    private readonly ISudokuPuzzleProvider _puzzleProvider;
    private readonly ISudokuSolutionHandler _solutionHandler;

    public SudokuGameService(
        ISudokuSolver solver,
        ISudokuPuzzleProvider puzzleProvider,
        ISudokuSolutionHandler solutionHandler)
    {
        _solver = solver;
        _puzzleProvider = puzzleProvider;
        _solutionHandler = solutionHandler;
    }

    public void RunGame()
    {
        try
        {
            var puzzle = _puzzleProvider.GetPuzzle();
            var solution = _solver.Solve(puzzle);
            _solutionHandler.HandleSolution(solution);
        }
        catch (NoSolutionException)
        {
            Console.WriteLine("No solution found.");
        }
    }
}