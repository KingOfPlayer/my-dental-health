# My Dental Health
 Track your dental health

# Getting Started
 1. Configure The Project
	1. Init User secrets 
		>Execute in MyDentalHealth folder<br>
		>dotnet user-secrets init<br>
	1. Set your SQL Connection for SQL Database<br>
		>Execute in MyDentalHealth folder<br>
		>dotnet user-secrets set "ConnectionStrings:mssqlconnection" "Server=localhost;Database=mdhapp;User Id=-----;Password=-----;Trusted_Connection=False; Encrypt=True; TrustServerCertificate=True;;"<br>
	2. Set your SMTP mail information for Mail Service<br>
		>Execute in MyDentalHealth folder<br>
		>dotnet user-secrets set "EmailSettings:Username" "------@-----"<br>
		>dotnet user-secrets set "EmailSettings:Password" "-------"<br>
		>dotnet user-secrets set "EmailSettings:FromEmail" "------@-----"<br>
 2. Run `MyDentalHealth/RefleshDatabase.bat` file for migrations and database update<br>
	1. Script will checking missing tool and NuGet packets. it will restore tool and packets
 3. Ready to build/start<br>

 Default database values directory: `Repository/ContextConfig/`<br>

> Default User:<br>
> Email: admin@admin.com<br>
> Password: Admin1234

