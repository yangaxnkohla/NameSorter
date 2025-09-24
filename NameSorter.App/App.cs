using NameSorter.Abstractions.Constants;
using NameSorter.Services.Interfaces;

namespace NameSorter;

/// <summary>
/// Driver application for sorting names from a file and writing the sorted names to another file.
/// </summary>
/// <param name="nameSortingService">An instance of <see cref="INameSortingService"/>.</param>
public class App(INameSortingService nameSortingService, IFileService fileService)
{
    /// <summary>
    /// Starts up the application to sort names from file and write them to another file.
    /// </summary>
    public async Task RunAsync(string? filePath)
    {
        var baseDirectory = Environment.CurrentDirectory;
        var inputPath = !string.IsNullOrEmpty(filePath) ? filePath : Path.Combine(baseDirectory, FilePathConstants.UnSortedNameFile);
        var outputPath = Path.Combine(baseDirectory, FilePathConstants.SortedNameFile);
        
        var nameList = await nameSortingService.SortNamesFromFileAsync(inputPath);
        
        await fileService.WriteLinesToFileAsync(outputPath, nameList, false);
        
        nameList.ForEach(Console.WriteLine);
    }
}