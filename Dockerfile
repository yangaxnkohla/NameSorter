FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY NameSorter.sln ./
COPY NameSorter.App/NameSorter.App.csproj NameSorter.App/
COPY NameSorter.Abstractions/NameSorter.Abstractions.csproj NameSorter.Abstractions/
COPY NameSorter.Services/NameSorter.Services.csproj NameSorter.Services/
COPY NameSorter.Utility/NameSorter.Utility.csproj NameSorter.Utility/
COPY NameSorter.Tests/NameSorter.Tests.csproj NameSorter.Tests/

RUN dotnet restore

COPY . .
WORKDIR /src/NameSorter.App
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "NameSorter.App.dll"]