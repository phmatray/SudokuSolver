using Google.OrTools.Sat;
using SudokuSolver.Domain;
using static SudokuSolver.Domain.Constants;

namespace SudokuSolver.Infrastructure;

public class OrToolsSudokuSolver : ISudokuSolver
{
    private readonly CpSolver _solver = new();

    public int[,] Solve(int[,] puzzle)
    {
        (CpModel model, IntVar[,]? grid) = CreateModel(puzzle);
        CpSolverStatus status = _solver.Solve(model);

        return status is CpSolverStatus.Feasible or CpSolverStatus.Optimal
            ? ExtractSolution(_solver, grid)
            : throw new NoSolutionException();
    }

    private static (CpModel, IntVar[,]) CreateModel(int[,] puzzle)
    {
        CpModel model = new();
        IntVar[,] grid = new IntVar[Dimension, Dimension];

        CreateVariables(model, grid, puzzle);
        AddConstraints(model, grid);

        return (model, grid);
    }

    private static void CreateVariables(CpModel model, IntVar[,] grid, int[,] puzzle)
    {
        for (int i = 0; i < Dimension; ++i)
        {
            for (int j = 0; j < Dimension; ++j)
            {
                grid[i, j] = model.NewIntVar(1, Dimension, $"grid[{i},{j}]");
                if (puzzle[i, j] != 0)
                {
                    model.Add(grid[i, j] == puzzle[i, j]);
                }
            }
        }
    }

    private static void AddConstraints(CpModel model, IntVar[,] grid)
    {
        for (int i = 0; i < Dimension; ++i)
        {
            AddRowConstraint(model, grid, i);
            AddColumnConstraint(model, grid, i);
        }

        for (int i = 0; i < Dimension; i += SubGridSize)
        {
            for (int j = 0; j < Dimension; j += SubGridSize)
            {
                AddCellConstraint(model, grid, i, j);
            }
        }
    }

    private static void AddRowConstraint(CpModel model, IntVar[,] grid, int row)
    {
        IntVar[] intVars = Enumerable
            .Range(0, Dimension)
            .Select(col => grid[row, col])
            .ToArray();

        model.AddAllDifferent(intVars);
    }

    private static void AddColumnConstraint(CpModel model, IntVar[,] grid, int col)
    {
        IntVar[] intVars = Enumerable
            .Range(0, Dimension)
            .Select(row => grid[row, col])
            .ToArray();

        model.AddAllDifferent(intVars);
    }

    private static void AddCellConstraint(CpModel model, IntVar[,] grid, int startRow, int startCol)
    {
        IntVar[] cellVariables = Enumerable
            .Range(0, SubGridSize)
            .SelectMany(i => Enumerable.Range(0, SubGridSize).Select(j => grid[startRow + i, startCol + j]))
            .ToArray();

        model.AddAllDifferent(cellVariables);
    }

    private static int[,] ExtractSolution(CpSolver solver, IntVar[,] grid)
    {
        int[,] solution = new int[Dimension, Dimension];

        for (int i = 0; i < Dimension; ++i)
        {
            for (int j = 0; j < Dimension; ++j)
            {
                solution[i, j] = (int)solver.Value(grid[i, j]);
            }
        }

        return solution;
    }
}