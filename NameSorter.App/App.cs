using NameSorter.Abstractions.Constants;
using NameSorter.Services.Interfaces;

namespace NameSorter;

/// <summary>
/// Driver application for sorting names from a file and writing the sorted names to another file.
/// </summary>
/// <param name="nameSortingService">An instance of <see cref="INameSortingService"/>.</param>
public class App(INameSortingService nameSortingService)
{
    /// <summary>
    /// Starts up the application to sort names from file and write them to another file.
    /// </summary>
    public async Task RunAsync()
    {
        var baseDirectory = Environment.CurrentDirectory;
        var inputPath = Path.Combine(baseDirectory, FilePathConstants.UnSortedNameFile);
        var outputPath = Path.Combine(baseDirectory, FilePathConstants.SortedNameFile);
        
        var nameList = await nameSortingService.SortNamesFromFileAsync(inputPath);
        
        await nameSortingService.WriteNamesToFileAsync(outputPath, nameList);
        
        nameList.ForEach(Console.WriteLine);
    }
}