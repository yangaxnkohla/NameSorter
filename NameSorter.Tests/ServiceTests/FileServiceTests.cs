using NameSorter.Services.Exceptions;
using NameSorter.Services.Services;

namespace NameSorter.Tests.ServiceTests;

public class FileServiceTests
{
    private readonly FileService _fileService = new();

    [Fact]
    public async Task ReadLinesFromFileAsync_ShouldReturnLinesFromFile()
    {
        // Arrange
        var expectedLines = (await File.ReadAllLinesAsync("./TestData/unsorted-names-list.txt")).ToList();
        
        // Act
        var result = await _fileService.ReadLinesFromFileAsync("./TestData/unsorted-names-list.txt");
        
        // Assert
        Assert.Equal(expectedLines, result);
    }

    [Fact]
    public async Task ReadLinesFromFileAsync_EmptyFile_ShouldThrowFileException()
    {
        // Act & Assert
        var result = await Assert.ThrowsAsync<FileException>(async () => await _fileService.ReadLinesFromFileAsync("./TestData/no-names-list.txt"));
        
        Assert.Equal("Could not read lines from file path './TestData/no-names-list.txt'", result.Message);
    }
    
    [Fact]
    public async Task ReadLinesFromFileAsync_WrongPath_ShouldThrowFileNotFoundException()
    {
        // Act & Assert
        var result = await Assert.ThrowsAsync<FileNotFoundException>(async () => await _fileService.ReadLinesFromFileAsync("./TestData/wrong-names-list.txt"));
        
        Assert.Contains("Could not find the file", result.Message);
    }
    
    [Fact]
    public async Task WriteLinesToFileAsync_AppendFalse_ShouldWriteLinesToFile()
    {
        // Arrange
        var lines = (await File.ReadAllLinesAsync("./TestData/unsorted-names-list.txt")).ToList();
        
        // Act
        await _fileService.WriteLinesToFileAsync("./TestData/write-names-list.txt", lines, false);
        var result = await _fileService.ReadLinesFromFileAsync("./TestData/write-names-list.txt");
        
        // Assert
        Assert.Equal(lines, result);
    }
    
    [Fact]
    public async Task WriteLinesToFileAsync_AppendTrue_ShouldWriteLinesToFile()
    {
        // Arrange
        var lines = (await File.ReadAllLinesAsync("./TestData/unsorted-names-list.txt")).ToList();
        
        // Act
        await _fileService.WriteLinesToFileAsync("./TestData/write-names-list.txt", lines, true);
        var result = await _fileService.ReadLinesFromFileAsync("./TestData/write-names-list.txt");
        
        // Assert
        Assert.NotEmpty(result);
    }
    
    [Fact]
    public async Task WriteLinesToFileAsync_EmptyLines_ShouldThrowFileException()
    {
        // Arrange
        var lines = new List<string>();
        
        // Act
        var result = await Assert.ThrowsAsync<FileException>(async () => await _fileService.WriteLinesToFileAsync("./TestData/wrong-names-list.txt", lines, false));
        
        // Assert
        Assert.Equal($"Cannot empty lines to file path './TestData/wrong-names-list.txt'", result.Message);
    }
}