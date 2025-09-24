using NameSorter.Services.Services;

namespace NameSorter.Services.Exceptions;

/// <summary>
/// Custom class for <see cref="FileService"/> exceptions.
/// </summary>
/// <param name="message">The exception message.</param>
public class FileException(string message) : Exception(message);