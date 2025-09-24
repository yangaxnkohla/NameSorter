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

### Running Via Github Actions

For CI pipeline I chose to go with Github Actions as it is already part 
of my project repository and I just had to add a `.github/workflows/main.yml` 
 to the project to make it work.

Step to run:
- Click the `Actions` tab on the repository
- Click `All workflows` then select the `.NET CI` workflow on 
the left hand side panel
- Click the `Run workflow` dropdown, then click the `Run workflow` button

You can select the run from the table to see progress.

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