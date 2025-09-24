using Moq;
using NameSorter.Services.Exceptions;
using NameSorter.Services.Interfaces;
using NameSorter.Services.Services;

namespace NameSorter.Tests.ServiceTests;

public class NameSortingServiceTests
{
    private readonly Mock<IFileService> _mockFileService;
    private readonly NameSortingService _nameSortingService;

    public NameSortingServiceTests()
    {
        _mockFileService = new Mock<IFileService>();
        _nameSortingService = new NameSortingService(_mockFileService.Object);
    }
    
    [Fact]
    public async Task SortNamesFromFileAsync_ShouldReturnListOfNames()
    {
        // Arrange
        var expectedLines = new List<string>{
            "Marin Alvarez",
            "Adonis Julius Archer",
            "Beau Tristan Bentley",
            "Hunter Uriah Mathew Clarke",
            "Leo Gardner",
            "Vaughn Lewis",
            "London Lindsey",
            "Mikayla Lopez",
            "Janet Parsons",
            "Frankie Conner Ritter",
            "Shelby Nathan Yoder"
        };

        var fileLines = new List<string>
        {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer",
            "Shelby Nathan Yoder",
            "Marin Alvarez",
            "London Lindsey",
            "Beau Tristan Bentley",
            "Leo Gardner",
            "Hunter Uriah Mathew Clarke",
            "Mikayla Lopez",
            "Frankie Conner Ritter"
        };
        
        _mockFileService.Setup(service => service.ReadLinesFromFileAsync(It.IsAny<string>())).ReturnsAsync(fileLines);
        
        // Act
        var result = await _nameSortingService.SortNamesFromFileAsync("./TestData/unsorted-names-list.txt");
        
         // Assert
         Assert.Equal(expectedLines, result);
    }
    
    [Fact]
    public async Task SortNamesFromFileAsync_EmptyPath_ShouldThrowArgumentNullException()
    {
        // Arrange
        _mockFileService.Setup(service => service.ReadLinesFromFileAsync(string.Empty)).ThrowsAsync(It.IsAny<FileException>());
        
        // Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await _nameSortingService.SortNamesFromFileAsync("./TestData/unsorted-names-list.txt"));
        
        // Assert
        Assert.Contains("Value cannot be null", result.Message);
    }
    
    [Fact]
    public async Task SortNamesFromFileAsync_WrongPath_ShouldThrowArgumentNullException()
    {
        // Arrange
        _mockFileService.Setup(service => service.ReadLinesFromFileAsync("testing")).ThrowsAsync(It.IsAny<FileNotFoundException>());
        
        // Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await _nameSortingService.SortNamesFromFileAsync("./TestData/unsorted-names-list.txt"));
        
        // Assert
        Assert.Contains("Value cannot be null", result.Message);
    }
}