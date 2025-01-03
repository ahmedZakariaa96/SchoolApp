param(
    [string]$MigrationName
)

if (-not $MigrationName) {
    Write-Host "Please provide a migration name."
    exit 1
}

dotnet ef migrations add $MigrationName -OutputDir Persistence/Migrations -Context ApplicationDbContext
