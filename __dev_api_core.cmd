:: inicia dotnet
::dotnet --version

:: accede al directorio
::Pushd "%~dp0\src\Mpm.bFast.Services.Core\bin\Debug"
:: muestra el directorio
::Pushd "%CD%"
::echo %CD%\src\Mpm.bFast.Services.Jwt\bin\Debug\netcoreapp3.1\Mpm.bFast.Services.Jwt.dll
::echo %CD%\src\Mpm.bFast.Services.Jwt\
@ECHO OFF
Title ------- [ Proyecto API CORE  ] -------
::ECHO -- Iniciando
::ECHO -- Construyendo el ensamblado para el API
::dotnet build %CD%\src\Mpm.bFast.Services.Jwt\Mpm.bFast.Services.Jwt.csproj
  
ECHO -- Ejecutando el proyecto API CORE
dotnet run --project %CD%\src\Mpm.Services.Core\Mpm.Services.Core.csproj