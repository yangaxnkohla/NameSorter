using Moq;
using NameSorter.Services.Interfaces;
using NameSorter.Utility;
using NameSorter.Utility.Exceptions;

namespace NameSorter.Tests.UtilityTests;

public class NameExtractorTests
{
    private readonly Mock<IFileService> _mockFileService = new();

    [Fact]
    public void GetValidFullNames_ShouldReturnsListOfFullNames()
    {
        // Arrange
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
        var result = NameExtractor.GetValidFullNames(fileLines);

        // Assert
        Assert.Equal(fileLines.Count, result.Count);

        for (var i = 0; i < result.Count; i++)
        {
            var actualFullName = result[i].DisplayFullName;
            var expectedFullName = fileLines[i];
            Assert.Equal(expectedFullName, actualFullName);
        }
    }
    
    [Fact]
    public void GetValidFullNames_NullList_ShouldThrowArgumentNullException()
    {
        // Act & Assert
        var result = Assert.Throws<ArgumentNullException>(() => NameExtractor.GetValidFullNames(null!));
        
        Assert.Equal("fileLines", result.ParamName);
        Assert.Contains("Value cannot be null", result.Message);
    }
    
    [Fact]
    public void GetValidFullNames_InvalidNames_ShouldThrowInvalidNameException()
    {
        // Arrange
        var fileLines = new List<string>
        {
            "Janet Parsons",
            "Vaughn Lewis",
            "Adonis Julius Archer Lorem Ipsum", // invalid
            "Shelby Nathan Yoder",
            "Lorem", // invalid
            "Marin Alvarez",
            "London Lindsey",
            "Beau Tristan Bentley",
            "Leo Gardner",
            "Hunter Uriah Mathew Clarke",
            "Mikayla Lopez",
            "Frankie Conner Ritter"
        };
        
        // Act & Assert
        var result = Assert.Throws<InvalidNameException>(() => NameExtractor.GetValidFullNames(fileLines));
        
        // Assert
        Assert.Contains($"either too long or too short", result.Message);
    }
}