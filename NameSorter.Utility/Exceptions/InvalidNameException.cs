namespace NameSorter.Utility.Exceptions;

/// <summary>
/// Custom class for <see cref="NameExtractor"/> exceptions.
/// </summary>
/// <param name="message">The exception message.</param>
public class InvalidNameException(string message) : Exception(message);