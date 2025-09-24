using NameSorter.Services.Interfaces;
using NameSorter.Utility;

namespace NameSorter.Services.Services;

/// <inheritdoc cref="INameSortingService"/>
public class NameSortingService(IFileService fileService) : INameSortingService
{
    /// <inheritdoc cref="INameSortingService.SortNamesFromFileAsync"/>
    public async Task<List<string>> SortNamesFromFileAsync(string inputPath)
    {
        var fileLines = await fileService.ReadLinesFromFileAsync(inputPath);

        var fullNames = NameExtractor.GetValidFullNames(fileLines);
        
        var sortedNames = fullNames.OrderBy(x => x.LastName)
            .ThenBy(x => x.GivenName.FirstName)
            .ThenBy(x => x.GivenName.SecondName)
            .ThenBy(x => x.GivenName.ThirdName)
            .ToList();
        
        var sortedNameList = sortedNames.Select(x => x.DisplayFullName).ToList();
        
        return await Task.FromResult(sortedNameList);
    }
}