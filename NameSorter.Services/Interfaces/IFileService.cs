namespace NameSorter.Services.Interfaces;

/// <summary>
/// Responsible for handling IO operations of files.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Read lines from a file.
    /// </summary>
    /// <param name="filePath">The input file path.</param>
    /// <returns>Task result containing a list of lines from the file.</returns>
    Task<List<string>> ReadLinesFromFileAsync(string filePath);
    
    /// <summary>
    /// Writes lines to a file.
    /// </summary>
    /// <param name="filePath">The output file path.</param>
    /// <param name="lines">Lines to write to a file.</param>
    /// <param name="append">Flag to indicate whether to append or replace contents of a file.</param>
    /// <returns>Void task result indicating completion of operation.</returns>
    Task WriteLinesToFileAsync(string filePath, List<string> lines, bool append);
}