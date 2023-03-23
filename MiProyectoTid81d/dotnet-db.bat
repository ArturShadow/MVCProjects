set /p server="Server: "
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0-preview.2.23128.3
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0-preview.2.23128.3

echo off
set /p db="Database: "
dotnet-ef dbcontext scaffold "Server=%server%; Database=%db%; TrustServerCertificate=True; Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models/DB --force
