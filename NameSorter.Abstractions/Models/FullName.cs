namespace NameSorter.Abstractions.Models;

/// <summary>
/// Model to represent a person's full name.
/// </summary>
/// <param name="givenName">The given names <see cref="GivenName"/>.</param>
/// <param name="lastName">The last name.</param>
public class FullName(GivenName givenName, string lastName)
{
    /// <summary>
    /// Given names of a person <see cref="GivenName"/>.
    /// </summary>
    public GivenName GivenName { get; } = givenName;
    
    /// <summary>
    /// The last name of a person.
    /// </summary>
    public string LastName { get; } = lastName;

    /// <summary>
    /// Displays the full name of a person.
    /// </summary>
    public string DisplayFullName => $"{GivenName.DisplayGivenName} {LastName}";
}