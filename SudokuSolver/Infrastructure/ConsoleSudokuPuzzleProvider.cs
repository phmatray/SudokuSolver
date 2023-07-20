using SudokuSolver.Ports;

namespace SudokuSolver.Infrastructure;

public class ConsoleSudokuPuzzleProvider : ISudokuPuzzleProvider
{
    public int[,] GetPuzzle()
    {
        // We will hardcode a 9x9 Sudoku for simplicity.
        var puzzle = new[,]
        {
            { 0, 0, 6, 5, 1, 0, 0, 0, 8 },
            { 7, 0, 3, 8, 0, 0, 6, 9, 1 },
            { 2, 0, 0, 0, 3, 0, 5, 4, 7 },
            { 0, 0, 1, 7, 0, 0, 0, 8, 0 },
            { 6, 0, 0, 3, 0, 1, 7, 5, 0 },
            { 8, 0, 7, 4, 5, 0, 3, 1, 0 },
            { 0, 8, 5, 6, 0, 0, 9, 0, 0 },
            { 9, 0, 0, 0, 0, 5, 0, 7, 0 },
            { 0, 7, 4, 0, 0, 0, 0, 0, 0 }
        };

        return puzzle;
    }
}