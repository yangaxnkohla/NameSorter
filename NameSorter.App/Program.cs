using Microsoft.Extensions.DependencyInjection;
using NameSorter;
using ServiceCollection = NameSorter.Services.ServiceCollection;

/*
 * This is the entry point of our application.
 * It is responsible for adding all the required services and running the application.
 * Once done it gracefully stops the application and the results will be seen on the console. 
 */

var host = ServiceCollection.CreateHostBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddScoped<App>();
    }).Build();

using (var scope = host.Services.CreateScope())
{
    var app = scope.ServiceProvider.GetRequiredService<App>();
    await app.RunAsync(args.Length > 0 ? args[0] : null); 
}

await host.StopAsync();