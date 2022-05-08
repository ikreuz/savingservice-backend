
@ECHO OFF

Title Launcher

ECHO -- Build
dotnet build %CD%\src\SavingService.Services.WebApi\SavingService.Services.WebApi.csproj

ECHO -- Run 
dotnet run --project %CD%\src\SavingService.Services.WebApi\SavingService.Services.WebApi.csproj