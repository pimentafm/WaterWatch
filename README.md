
<div align="center">
<h1>WaterWatch - Water Resource Dashboard</h1>
<br>
<img width="600" src="Assets/image.png" alt="OBahia - Análise de séries temporais">
<br>
<br>
</div>

<div align="center">
  <img alt="GitHub language count" src="https://img.shields.io/github/languages/count/pimentafm/WaterWatch?color=blue&style=for-the-badge">

</div>

<div align="center">

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
[![made-with-PostGIS](https://img.shields.io/badge/PostGIS-5a7a9f?style=for-the-badge)](https://postgis.net/)

</div>

## Database

Create the database using docker

```Shell
docker run --name gis -e POSTGRES_PASSWORD=gis -e POSTGRES_DB=gis -e POSTGRES_USER=gis -p 5432:5432 -d postgis/postgis
```

Connect to database adding the `DefaultConnection` parameters
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=cptwater;Username=gis;Password=gis"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
## Packages and tools
```Shell
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Newtonsoft.Json
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef
```
## Run migrations
```Shell
dotnet ef migrations add InitialMigration
dotnet ef database update
```

Developed by Fernando Pimenta [My Github!](https://github.com/pimentafm) :bird: :sunglasses: