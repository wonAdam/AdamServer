@echo off

echo [database drop]
dotnet ef database drop --project ServerLib -f 

echo [migrations remove]
dotnet ef migrations remove --project ServerLib -f

echo [migrations add]
dotnet ef migrations add SDDBMigration --project ServerLib 

echo [database update]
dotnet ef database update SDDBMigration --project ServerLib 

CALL rake
pause
