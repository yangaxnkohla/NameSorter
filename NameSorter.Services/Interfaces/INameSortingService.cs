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
    
    /// <summary>
    /// Writes a list of names to a file.
    /// </summary>
    /// <param name="outputPath">The file output path.</param>
    /// <param name="nameList">The list of names to write to file.</param>
    /// <returns>Void task result indicating the completion of operation.</returns>
    Task WriteNamesToFileAsync(string outputPath, List<string> nameList);
}