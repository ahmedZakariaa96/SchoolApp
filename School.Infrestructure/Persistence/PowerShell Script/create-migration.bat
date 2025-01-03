@echo off
set migrationName=%1
if "%migrationName%"=="" (
    echo Please provide a migration name.
    exit /b 1
)
dotnet ef migrations add %migrationName% -OutputDir Persistence/Migrations -Context ApplicationDbContext
