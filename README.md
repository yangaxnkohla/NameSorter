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
<img width="1076" height="55" alt="image" src="https://github.com/user-attachments/assets/20ea1483-a3fe-44d4-b16a-3d7762278c38" />

- Click `All workflows` then select the `.NET CI` workflow on 
the left hand side panel
<img width="413" height="186" alt="image" src="https://github.com/user-attachments/assets/b91d1556-29cc-4322-913a-90a07cf0346b" />


- Click the `Run workflow` dropdown, then click the `Run workflow` button
<img width="1177" height="173" alt="image" src="https://github.com/user-attachments/assets/d080410e-d253-4836-8cdd-cfe7b6f7ca15" />


You can select the run from the table to see progress.
<img width="1637" height="564" alt="image" src="https://github.com/user-attachments/assets/97bc7e39-3782-4f14-895a-6615cf470fd1" />

<img width="1637" height="1087" alt="image" src="https://github.com/user-attachments/assets/c8a22366-d992-4ee3-9a67-22cdafd608c2" />

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
