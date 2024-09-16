dotnet tool install --global dotnet-ef
del .\Migrations\
dotnet ef migrations add Init
dotnet ef database drop
dotnet ef database update
dotnet tool install --global dotnet-sql-cache
dotnet sql-cache create "Server=localhost;Database=mdhapp;User Id=SA;Password=1234;Trusted_Connection=False; Encrypt=True; TrustServerCertificate=True;" dbo UserSessions