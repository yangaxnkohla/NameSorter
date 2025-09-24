namespace NameSorter.Services.Interfaces;

/// <summary>
/// Responsible for sorting names that are read from a file.
/// </summary>
public interface INameSortingService
{
    /// <summary>
    /// Sorts a list of names from a file.
    /// First sorts by the last name, then by the given names of a person.
    /// </summary>
    /// <param name="inputPath">The file input path.</param>
    /// <returns>Task result containing a list of sorted names.</returns>
    Task<List<string>> SortNamesFromFileAsync(string inputPath);
}