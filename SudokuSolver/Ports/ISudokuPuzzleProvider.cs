namespace SudokuSolver.Ports;

public interface ISudokuPuzzleProvider
{
    int[,] GetPuzzle();
}