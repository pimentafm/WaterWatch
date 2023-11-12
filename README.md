
## Database

docker run --name gis -e POSTGRES_PASSWORD=gis -e POSTGRES_DB=gis -e POSTGRES_USER=gis -p 5432:5432 -d postgis/postgis

## Packages and tools

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Newtonsoft.Json
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef

## Run migrations
dotnet ef migrations add InitialMigration
dotnet ef database update