using SudokuSolver.Ports;
using static SudokuSolver.Domain.Constants;

namespace SudokuSolver.Infrastructure;

public class ConsoleSudokuSolutionHandler : ISudokuSolutionHandler
{
    public void HandleSolution(int[,] solution)
    {
        for (var i = 0; i < Dimension; ++i)
        {
            // Print horizontal line after each 3 rows
            if (i != 0 && i % SubGridSize == 0)
            {
                Console.WriteLine(new string('-', Dimension * 2 + SubGridSize));
            }

            for (var j = 0; j < Dimension; ++j)
            {
                // Print vertical line after each 3 columns
                if (j != 0 && j % SubGridSize == 0)
                {
                    Console.Write("| ");
                }

                Console.Write($"{solution[i, j]} ");
            }

            Console.WriteLine();
        }
    }
}