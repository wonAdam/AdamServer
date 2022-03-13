@echo off

echo [database drop]
dotnet ef database drop --project GameServer -f 

echo [migrations remove]
dotnet ef migrations remove --project GameServer -f

echo [migrations add]
dotnet ef migrations add SDDBMigration --project GameServer 

echo [database update]
dotnet ef database update SDDBMigration --project GameServer 

pause
