# TODO

- [x] add doc comments
- [x] add exception handling in NameSortingService
- [x] add unit tests
- [x] dockerize project
- [ ] add ci/cd things

---
# Name Sorter

### Prerequisites
- .NET 9.0 SDK
- Visual Studio or Rider for IDE support

### Nuget Dependencies
- Microsoft.Extensions.DependencyInjection
- xUnit
- Moq

# Running App

### Running Via IDE
If you've got an IDE installed you can simply open the project and run the 
`NameSorter.App` project.

### Running Via .NET Commands
To run using .NET commands, you can do the following from the root
directory of the project:
```bash
dotnet run --project ./NameSorter.App/NameSorter.App.csproj ./NameSorter.App/unsorted-names-list.txt
```

### Docker Commands

Build the image:
```bash
docker build -t namesorter-app .
```

Run the container:
```bash
docker run --rm -it namersorter-app unsorted-names-list.txt
```

---

**After running the app you will find the sorted list of names in the
`sort-names-list.txt` file located in:**
```text
NameSorter.App/bin/Debug/net9.0/sorted-names-list.txt
```

When using the `dotnet run` the file will appear under the root directory.

# Running Tests
Tests reside in the `NameSorter.Tests` project and can be run 
on the IDE.

On the terminal you can run the tests from the root directory with the 
command:
```bash
dotnet test NameSorter.Tests/NameSorter.Tests.csproj
```