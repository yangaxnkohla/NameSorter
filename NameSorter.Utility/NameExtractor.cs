using System.Text.RegularExpressions;
using NameSorter.Abstractions.Models;
using NameSorter.Utility.Exceptions;

namespace NameSorter.Utility;

public static class NameExtractor
{
    /// <summary>
    /// Helper method to extract full names from a given list of strings.
    /// </summary>
    /// <param name="fileLines">List of strings read from a file.</param>
    /// <returns>List of <see cref="FullName"/>.</returns>
    /// <exception cref="InvalidNameException">Invalid name exception.</exception>
    public static List<FullName> GetFullNames(List<string> fileLines)
    {
        var fullNames = new List<FullName>();

        foreach (var line in fileLines)
        {
            if (GetNames(line).Length < 2 || GetNames(line).Length > 4)
            {
                throw new InvalidNameException($"Error: the name '{line}' is either too long or too short");
            }
            
            var firstName = GetNames(line).First();
            var lastName = GetNames(line).Last();

            var givenName = new GivenName(firstName);

            if (GetNames(line).Length > 3)
            {
                givenName.SecondName = GetNames(line)[1];
                givenName.ThirdName = GetNames(line)[2];
            }
            else if (GetNames(line).Length > 2)
            {
                givenName.SecondName = GetNames(line)[1];
            }
            
            var fullName = new FullName(givenName, lastName);
            
            fullNames.Add(fullName);
        }
        
        return fullNames;
    }

    /// <summary>
    /// Helper method for splitting lines into arrays.
    /// </summary>
    /// <param name="lineFromFile">Line from a file.</param>
    /// <returns></returns>
    private static string[] GetNames(string lineFromFile)
    {
        var regex = new Regex(@"\s", RegexOptions.Compiled);
        return regex.Split(lineFromFile);
    }
}