using Microsoft.Extensions.DependencyInjection;
using SudokuSolver.Application;
using SudokuSolver.Domain;
using SudokuSolver.Infrastructure;
using SudokuSolver.Ports;

namespace SudokuSolver.CLI;

public static class DependencyInjections
{
    public static ServiceProvider ConfigureAndBuildServices()
    {
        return new ServiceCollection()
            .AddRequiredServices()
            .BuildServiceProvider();
    }

    public static SudokuGameService RetrieveGameService(this ServiceProvider serviceProvider)
    {
        return serviceProvider
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<SudokuGameService>();
    }
    
    private static IServiceCollection AddRequiredServices(this IServiceCollection services)
    {
        services.AddSingleton<ISudokuSolver, OrToolsSudokuSolver>();
        services.AddSingleton<ISudokuPuzzleProvider, ConsoleSudokuPuzzleProvider>();
        services.AddSingleton<ISudokuSolutionHandler, ConsoleSudokuSolutionHandler>();
        services.AddTransient<SudokuGameService>();

        return services;
    }
}