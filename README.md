# My Dental Health
 Track your dental health

# Getting Started
 1. Configure The Project
	1. Init User secrets 
		>Execute in MyDentalHealth folder<br>
		>dotnet user-secrets init<br>
	1. Set your SQL Connection for SQL database<br>
		>Execute in MyDentalHealth folder<br>
		>dotnet user-secrets set "ConnectionStrings:mssqlconnection" "SqlconnectionString;"<br>
	2. Set your SMTP mail information for mail service<br>
		>Execute in MyDentalHealth folder<br>
		>dotnet user-secrets set "EmailSettings:Username" "------@-----"<br>
		>dotnet user-secrets set "EmailSettings:Password" "-------"<br>
		>dotnet user-secrets set "EmailSettings:FromEmail" "------@-----"<br>
 2. Run `MyDentalHealth/RefleshDatabase.bat` file for migrations and database update<br>
	1. Script will Check dotnet-ef tool if is not installed dotnet-ef, it will install
 3. Ready to build/start<br>

 Default database values directory: `Repository/ContextConfig/`<br>

> Default User:<br>
> Email: admin@admin.com<br>
> Password: Admin1234

