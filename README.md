# My Dental Health
 Track your dental health

# Getting Started
 1. Configure The Project
	1. Set your SQL Connection for SQL database from 'MyDentalHealth/appsettings'<br>
	2. Set your mail information for mail service<br>
		>### Execute in MyDentalHealth folder<br> 
		>dotnet user-secrets init<br>
		>dotnet user-secrets set "EmailSettings:Username" "*******@*******.com"<br>
		>dotnet user-secrets set "EmailSettings:Password" "***********"<br>
		>dotnet user-secrets set "EmailSettings:FromEmail" "*******@*******.com"<br>
	1. Set your SQL Connection for Sesssion storage from `MyDentalHealth/RefleshDatabase.bat`
 2. Run `MyDentalHealth/RefleshDatabase.bat` file for migrations and database update<br>
 3. Ready to build/start<br>

 Default database values directory: `Repository/ContextConfig/`<br>

> Default User:<br>
> Email: admin@admin.com<br>
> Password: Admin1234

