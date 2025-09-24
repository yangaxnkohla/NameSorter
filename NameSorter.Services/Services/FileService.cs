using NameSorter.Services.Exceptions;
using NameSorter.Services.Interfaces;

namespace NameSorter.Services.Services;

/// <inheritdoc cref="IFileService"/>
public class FileService : IFileService
{
    /// <inheritdoc cref="IFileService.ReadLinesFromFileAsync"/>
    public async Task<List<string>> ReadLinesFromFileAsync(string filePath)
    {
        try
        {
            var lines = await File.ReadAllLinesAsync(filePath);
            
            if (lines.Length == 0)
            {
                throw new FileException($"Could not read lines from file path '{filePath}'");
            }
            
            return lines.ToList();
        }
        catch (FileNotFoundException ex)
        {
            throw new FileNotFoundException($"Could not find the file: {ex.Message}", filePath);
        }
        catch (Exception ex)
        {
            throw new Exception($"File {filePath} could not be read", ex);
        }
    }

    /// <inheritdoc cref="IFileService.WriteLinesToFileAsync"/>
    public Task WriteLinesToFileAsync(string filePath, List<string> lines, bool append)
    {
        try
        {
            return append ? 
                File.AppendAllLinesAsync(filePath, lines) : 
                File.WriteAllLinesAsync(filePath, lines);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occured while writing to file: {ex.Message}", ex);
        }
    }
}