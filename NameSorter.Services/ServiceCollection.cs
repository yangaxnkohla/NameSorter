using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NameSorter.Services.Interfaces;
using NameSorter.Services.Services;

namespace NameSorter.Services;

/// <summary>
/// Configures services for dependency injection.
/// </summary>
public abstract class ServiceCollection
{
    /// <summary>
    /// Adds services to be used for dependency injection.
    /// </summary>
    /// <param name="args">Array of string arguments.</param>
    /// <returns>An instance of <see cref="IHostBuilder"/>.</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddTransient<IFileService, FileService>();
                services.AddTransient<INameSortingService, NameSortingService>();
            });
}