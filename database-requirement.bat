@echo off

dotnet tool install --global dotnet-ef

dotnet add GameServer package Google.Protobuf --version 3.19.4

dotnet add ServerLib package Google.Protobuf --version 3.19.4

dotnet add ClientBot package Google.Protobuf --version 3.19.4

dotnet add GameServer package Pomelo.EntityFrameworkCore.MySql --version 6.0.1

dotnet add GameServer package Microsoft.EntityFrameworkCore --version 6.0.3

dotnet add GameServer package Microsoft.EntityFrameworkCore.Design --version 6.0.3

dotnet add GameServer package Microsoft.EntityFrameworkCore.Tools --version 6.0.3

dotnet add GameServer package Microsoft.AspNetCore.Cryptography.KeyDerivation --version 6.0.3

pause
