namespace SudokuSolver.Domain;

public interface ISudokuSolver
{
    int[,] Solve(int[,] puzzle);
}