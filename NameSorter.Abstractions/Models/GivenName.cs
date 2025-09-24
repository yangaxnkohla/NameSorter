namespace NameSorter.Abstractions.Models;

/// <summary>
/// Model to represent the given names of a person.
/// </summary>
/// <param name="firstName">The first given name.</param>
/// <param name="secondName">The second given name if they have one.</param>
/// <param name="thirdName">The third given name if they have one.</param>
public class GivenName(
    string firstName,
    string? secondName = null,
    string? thirdName = null
)
{
    /// <summary>
    /// The first given name.
    /// </summary>
    public string FirstName { get; } = firstName;
    
    /// <summary>
    /// The second given name if they have one.
    /// </summary>
    public string SecondName { get; set; } = secondName ?? string.Empty;
    
    /// <summary>
    /// The third given name if they have one.
    /// </summary>
    public string ThirdName { get; set; } = thirdName ?? string.Empty;
    
    /// <summary>
    /// Displays the given names of a person.
    /// </summary>
    public string DisplayGivenName => $"{FirstName} {(SecondName)} {(ThirdName)}".Trim();
}