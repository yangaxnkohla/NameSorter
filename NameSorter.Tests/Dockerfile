FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NameSorter.Tests/NameSorter.Tests.csproj", "NameSorter.Tests/"]
RUN dotnet restore "NameSorter.Tests/NameSorter.Tests.csproj"
COPY . .
WORKDIR "/src/NameSorter.Tests"
RUN dotnet build "NameSorter.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NameSorter.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NameSorter.Tests.dll"]
