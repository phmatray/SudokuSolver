namespace SudokuSolver.Ports;

public interface ISudokuSolutionHandler
{
    void HandleSolution(int[,] solution);
}