using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SudokuSolver.Application;
using SudokuSolver.Domain;
using SudokuSolver.Infrastructure;
using SudokuSolver.Ports;

namespace SudokuSolver.CLI;

public static class DependencyInjections
{
    public static ServiceProvider ConfigureAndBuildServices(ILogger logger)
    {
        logger.LogInformation("Configuring and building services...");
        var serviceProvider = new ServiceCollection()
            .AddRequiredServices()
            .BuildServiceProvider();
        logger.LogInformation("Services have been configured and built.");
        return serviceProvider;
    }

    public static SudokuGameService RetrieveGameService(this ServiceProvider serviceProvider, ILogger logger)
    {
        logger.LogInformation("Retrieving game service...");
        var gameService = serviceProvider
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<SudokuGameService>();
        logger.LogInformation("Game service has been retrieved.");
        return gameService;
    }

    private static IServiceCollection AddRequiredServices(this IServiceCollection services)
    {
        services.AddSingleton<ISudokuSolver, OrToolsSudokuSolver>();
        services.AddSingleton<ISudokuPuzzleProvider, ConsoleSudokuPuzzleProvider>();
        services.AddSingleton<ISudokuSolutionHandler, ConsoleSudokuSolutionHandler>();
        services.AddTransient<SudokuGameService>();
        services.AddLogging(config => config.AddConsole()); // Add logging services

        return services;
    }
}